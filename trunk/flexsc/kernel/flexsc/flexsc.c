#include <linux/linkage.h>
#include <linux/kernel.h>
#include <linux/ioport.h>
#include <linux/workqueue.h>
#include <linux/wait.h>
#include <linux/kthread.h>
#include <linux/slab.h>
#include <linux/version.h>
#include <linux/init.h>
#include <linux/module.h>
#include <linux/fs.h>
#include <linux/cdev.h>
#include <linux/mm.h>
#include <linux/kthread.h>
#ifdef MODVERSIONS
#  include <linux/modversions.h>
#endif
#include <asm/io.h>
#include <linux/fs.h>      // Needed by filp
#include <asm/uaccess.h>   // Needed by segment descriptors
#include <flexsc/flexsc.h>
#include <flexsc/flexsc_syscalls.h>

#define MAX_SYSCALL_THREAD 128
#define FLEX_DEV_MAJOR_NO	240
typedef struct
{
	struct work_struct my_work;
	int index;
	int status;
} my_work_t;

static int ACTIVE_THREADS = 0;

/*
 * Workqueue structures.
 * */
static int valid_wq = 0;
static struct workqueue_struct *my_wq = NULL;
static my_work_t flex_work_data[MAX_SYSCALL_THREAD];

/*
 * kthread structures.
 * */
static struct task_struct* syscall_threads[MAX_SYSCALL_THREAD] =
{ 0 };


static struct syscall_page* shared_syscall_page = NULL;
static struct task_struct* registered_process = NULL;

static int flexsc_device_created = 0;

void print_entry(int i)
{
	int j = i / 64;
	int index = i % 64;
	printk("%d %d %d %ld %ld %ld %ld %ld %ld %ld\n", i, //
			shared_syscall_page[j].entries[index].status, //
			shared_syscall_page[j].entries[index].return_code, //
			shared_syscall_page[j].entries[index].args[0], //
			shared_syscall_page[j].entries[index].args[1], //
			shared_syscall_page[j].entries[index].args[2], //
			shared_syscall_page[j].entries[index].args[3], //
			shared_syscall_page[j].entries[index].args[4], //
			shared_syscall_page[j].entries[index].args[5]);
}

int perform_flex_system_call(struct syscall_entry* entry)
{
	if (entry->status == SUBMITTED)
	{
		//		kprint_true ? printk("~~~~~~~~~~~~~FOUND~~~~~~~~~~~~~~~~\n") : 1;
		//		kprint_true ? printk("##ENTRY From Worker Thread. [%d] = %d, [0]=%ld, [1]=%ld, [2]=%ld\n", entry->index, entry->syscall, entry->args[0], entry->args[1], entry->args[2]) : 1;
		if (entry->syscall == 2)
		{ // open
			//			kprint_true ? printk("Filename: %d\n", entry->args[0]) : 1;
			char filename[256] =
			{ 0 };
			sprintf(filename, "/home/maksud/file%ld.txt", entry->args[0]);

			if (entry->args[5])
			{
				//				if (entry->args[0])
				entry->return_code = (long long) file_open(filename, entry->args[1], entry->args[2]);
				//				else
				//					entry->return_code = file_open(file2, entry->args[1], entry->args[2]);
			}
			//kprint_true ? printk("file_open returned= %d\n") : 1;
		}
		else if (entry->syscall == 1)
		{
			char fw_buff[4];
			// write
			fw_buff[0] = (entry->args[2]) & 0xFF;
			fw_buff[1] = (entry->args[2] >> 8) & 0xFF;
			fw_buff[2] = (entry->args[2] >> 16) & 0xFF;
			fw_buff[3] = (entry->args[2] >> 24) & 0xFF;

			if (entry->args[5])
			{
				//kprint_true ? printk("Buffer", entry->args[0]) : 1;
				entry->return_code = (long long) file_write((struct file*) entry->args[0], entry->args[1], fw_buff, 4);
				//kprint_true ? printk("file_open returned= %d\n") : 1;
			}
		}
		else if (entry->syscall == 3)
		{ // close
			if (entry->args[5])
			{
				entry->return_code = 0;
				file_close((struct file*) entry->args[0]);
				//				kprint_true ? printk("file_open returned= %d\n") : 1;
			}
		}
		entry->status = DONE;
		//		kprint_true ? printk("ENTRY %d:%d\n", entry->status, entry->return_code) : 1;
	}
	return 0;
}

static void my_wq_function(struct work_struct *work)
{
	my_work_t *my_work = (my_work_t *) work;
	int index = my_work->index;
	int status = my_work->status;
	int j = index / 64;
	int i = index % 64;

	struct syscall_entry* entry = &shared_syscall_page[j].entries[i]; //User


	if (entry->status == SUBMITTED)
	{
		//		print_entry(j);
		perform_flex_system_call(entry);
	}
	//if (sleep_count > 0)
	//	msleep(sleep_count);

	if (valid_wq && status == 1)
		queue_work(my_wq, (struct work_struct *) work);

	return;
}

int syscall_thread_run(void *work)
{
	my_work_t* my_work = (my_work_t *) work;
	int index = my_work->index;
	int j = index / 64;
	int i = index % 64;

	struct syscall_entry* entry = &shared_syscall_page[j].entries[i]; //User


	while (1)
	{
		//
		if (entry->status == SUBMITTED)
		{
			//			print_entry(j);
			perform_flex_system_call(entry);
		}

		msleep(1);

		if (kthread_should_stop())
			break;
	}
	return 0;
}

//mmap portion//////////////
/* character device structures */
static dev_t mmap_dev;
static struct cdev mmap_cdev;

/* methods of the character device */
static int mmap_open(struct inode *inode, struct file *filp);
static int mmap_release(struct inode *inode, struct file *filp);
static int mmap_mmap(struct file *filp, struct vm_area_struct *vma);

/* the file operations, i.e. all character device methods */
static struct file_operations mmap_fops =
{ .open = mmap_open, .release = mmap_release, .mmap = mmap_mmap,
//		, .owner = THIS_MODULE,
		};

//
// internal data
// length of the two memory areas
#define NPAGES 16
// pointer to the kmalloc'd area, rounded up to a page boundary
static struct syscall_page *kmalloc_area = NULL;
// original pointer for kmalloc'd area as returned by kmalloc
static void *kmalloc_ptr = NULL;

/* character device open method */
static int mmap_open(struct inode *inode, struct file *filp)
{
	return 0;
}
/* character device last close method */
static int mmap_release(struct inode *inode, struct file *filp)
{
	return 0;
}

/* character device mmap method */
static int mmap_mmap(struct file *filp, struct vm_area_struct *vma)
{
	/* at offset NPAGES we map the kmalloc'd area */
	if (vma->vm_pgoff == NPAGES)
	{
		int ret;
		long length = vma->vm_end - vma->vm_start;

		/* check length - do not allow larger mappings than the number of pages allocated */
		if (length > NPAGES * PAGE_SIZE)
			return -EIO;

		/* map the whole physically contiguous area in one piece */
		if ((ret = remap_pfn_range(vma, vma->vm_start, virt_to_phys((void *) kmalloc_area) >> PAGE_SHIFT, length, vma->vm_page_prot)) < 0)
		{
			return ret;
		}

		return 0;
	}
	/* at any other offset we return an error */
	return -EIO;
}

void stop_syscall_threads(void)
{
	int i;
	for (i = 0; i < MAX_SYSCALL_THREAD; i++)
	{
		if (syscall_threads[i] != NULL)
		{
			kthread_stop(syscall_threads[i]);
			syscall_threads[i] = NULL;
		}
	}
}

void register_kthread_version(void)
{
	int i;

	stop_syscall_threads();

	for (i = 0; i < ACTIVE_THREADS; i++)
	{
		flex_work_data[i].index = i;
		syscall_threads[i] = kthread_run(syscall_thread_run, (void *) &flex_work_data[i], "syscall_thread");
	}
}

/*
 * Work Queue Implementation of syscall thread.
 *
 * */

void register_workqueue_version(void)
{
	int i, j, index, ret;

	if (my_wq != NULL)
	{
		//		valid_wq = 0;
		printk("Previous Work Queue Found!\n");
		//		destroy_workqueue(my_wq);
		//Initialize All the Works
		for (i = 0; i < MAX_SYSCALL_THREAD; i++)
		{
			// Activate deactivated threads.
			if (i < ACTIVE_THREADS && flex_work_data[i].status == 0)
			{
				printk("Activate a deactivated thread: %d!\n", i);
				flex_work_data[i].status = 1;
				ret = queue_work(my_wq, (struct work_struct *) &flex_work_data[i]);
			}

			//Stop the rest threads
			if (i >= ACTIVE_THREADS)
			{
				flex_work_data[i].status = 0;
			}
		}
	}
	else
	{
		printk("Creating Work Queue\n");
		my_wq = create_workqueue("flexsc_queue");
		valid_wq = 1;

		if (my_wq == NULL)
		{
			printk("Problem Creating Work Queue\n");
			return;
		}

		//Initialize All the Works
		for (index = 0; index < MAX_SYSCALL_THREAD; index++)
		{
			j = index / 64;
			i = index % 64;
			//printk("Allocating necessary memories: %d\n", i);
			printk("+++++++++++++++++[%d] = S: %d, #: %d, St: %d, Args[5]=%ld\n", index, //
					shared_syscall_page[j].entries[i].syscall, //
					shared_syscall_page[j].entries[i].num_args, //
					shared_syscall_page[j].entries[i].status, //
					shared_syscall_page[j].entries[i].args[5]);
			//
			printk("*****************Creating Works:%d\n", index);
			INIT_WORK((struct work_struct *) &flex_work_data[index], my_wq_function);
			flex_work_data[index].index = index;
			flex_work_data[index].status = 0;
		}

		//Queue only active threads
		for (i = 0; i < ACTIVE_THREADS; i++)
		{
			flex_work_data[i].status = 1;
			ret = queue_work(my_wq, (struct work_struct *) &flex_work_data[i]);
		}

	}
}

asmlinkage void* sys_flexsc_register2(void* user_pages)
{
	int i, j, index, ret;
	long params = (long) user_pages;
	//
	ACTIVE_THREADS = params / 128;
	int thread_type = params % 128;

	//	struct syscall_page* pp;
	printk("Registering Process: PID = %d\n", current->pid);
	registered_process = current;

	printk("Number of Threads=%d\n", ACTIVE_THREADS);
	printk("Register: %p\n", kmalloc_ptr);

	/**
	 * If already allocated, not allocate again. Use previous memory.
	 */
	if (kmalloc_ptr == NULL)
	{
		/* allocate a memory area with kmalloc. Will be rounded up to a page boundary */
		if ((kmalloc_ptr = kmalloc((NPAGES + 2) * PAGE_SIZE, GFP_KERNEL)) == NULL)
		{
			ret = -ENOMEM;
			goto out;
		}

		/* round it up to the page bondary */
		kmalloc_area = (struct syscall_page *) ((((unsigned long) kmalloc_ptr) + PAGE_SIZE - 1) & PAGE_MASK);

		/* mark the pages reserved */
		for (i = 0; i < NPAGES * PAGE_SIZE; i += PAGE_SIZE)
		{
			SetPageReserved(virt_to_page(((unsigned long) kmalloc_area) + i));
		}

		for (index = 0; index < MAX_SYSCALL_THREAD; index++)
		{
			j = index / 64;
			i = index % 64;
			//
			kmalloc_area[j].entries[i].status = FREE;
			kmalloc_area[j].entries[i].syscall = 0;
			kmalloc_area[j].entries[i].num_args = 0;
			kmalloc_area[j].entries[i].return_code = 0;
			kmalloc_area[j].entries[i].args[0] = 0;
			kmalloc_area[j].entries[i].args[1] = 0;
			kmalloc_area[j].entries[i].args[2] = 0;
			kmalloc_area[j].entries[i].args[3] = 0;
			kmalloc_area[j].entries[i].args[4] = 0;
			kmalloc_area[j].entries[i].args[5] = 10000 + i;
		}

		shared_syscall_page = (struct syscall_page*) kmalloc_area; // kmalloced area is the actual area.
		printk("Allocated Memory!\n");
	}

	for (i = 0; i < MAX_SYSCALL_THREAD; i++)
	{
		print_entry(i);
	}

	/*
	 * Create Character Device
	 * */

	if (flexsc_device_created == 0)
	{
		//We implemented a character device called mmap
		/* get the major number of the character device */
		if ((ret = alloc_chrdev_region(&mmap_dev, 0, 1, "flexsc")) < 0)
		{
			printk("could not allocate major number for mmap\n");
			goto out_kfree;
		}

		/* initialize the device structure and register the device with the kernel */
		cdev_init(&mmap_cdev, &mmap_fops);
		if ((ret = cdev_add(&mmap_cdev, mmap_dev, 1)) < 0)
		{
			printk("could not allocate chrdev for mmap\n");
			goto out_unalloc_region;
		}

		flexsc_device_created = 1;
	}

	// KThread Implementation
	if (thread_type)//Non Zero== Kthread
	{
		printk("Using kthread as syscall thread\n");
		register_kthread_version();
	}
	else
	{
		printk("Using workqueue as syscall thread\n");
		stop_syscall_threads();
		register_workqueue_version();
	}
	printk("flexsc_registration Complete.\n");
	return NULL;

	out_unalloc_region: printk("out_unalloc_region\n");
	unregister_chrdev_region(mmap_dev, 1);
	//
	//out_vfree: vfree(vmalloc_area);
	//
	out_kfree: printk("out_kfree\n");
	kfree(kmalloc_ptr);
	//
	out: printk("out\n");
	return NULL;

}

asmlinkage long sys_flexsc_wait(void)
{
	return current->pid;
}

/*
 * Using it as an unregister option.
 * */
asmlinkage void* sys_flexsc_register(void)
{
	//	int i;
	//	valid_wq = 0;

	/* remove the character deivce */
	//	cdev_del(&mmap_cdev);
	//	unregister_chrdev_region(mmap_dev, 1);

	//	/* unreserve the pages */
	//	for (i = 0; i < NPAGES * PAGE_SIZE; i += PAGE_SIZE)
	//	{
	//		ClearPageReserved(virt_to_page(((unsigned long) kmalloc_area) + i));
	//	}
	//	/* free the memory areas */
	//	kfree(kmalloc_ptr);
	//
	stop_syscall_threads();

	return NULL;
}

