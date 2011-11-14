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
#include <mod/flexsc/mod_flexsc_syscalls.h>

void flexsc_mod_stop_syscall_threads(void);

#define MAX_SYSCALL_THREAD 64
#define FLEX_DEV_MAJOR_NO	240
typedef struct
{
	struct work_struct my_work;
	int x;
} my_work_t;

int flexsc_mod_valid_wq = 0;
static struct workqueue_struct *flexsc_mod_my_wq = NULL;
my_work_t flexsc_mod_flex_work_data[MAX_SYSCALL_THREAD];
my_work_t* flexsc_mod_flex_work[MAX_SYSCALL_THREAD];

//int kprint_true = 0;
//int sleep_count = 0;

struct task_struct* flexsc_mod_syscall_threads[MAX_SYSCALL_THREAD] =
{ 0 };//64 Syscall Threads.

struct syscall_page* flexsc_mod_shared_syscall_page = NULL;
struct syscall_entry* flexsc_mod_shared_entries[MAX_SYSCALL_THREAD];

//File Write Buffer. Currently Only write some prefixed code.

int flexsc_mod_perform_flex_system_call(struct syscall_entry* entry)
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
			sprintf(filename, "/home/maksud/file%lld.txt", entry->args[0]);

			if (entry->args[5])
			{
				//				if (entry->args[0])
				entry->return_code = (long long) flexsc_mod_file_open(filename, entry->args[1], entry->args[2]);
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
				entry->return_code = (long long) flexsc_mod_file_write((struct file*) entry->args[0], entry->args[1], fw_buff, 4);
				//kprint_true ? printk("file_open returned= %d\n") : 1;
			}
		}
		else if (entry->syscall == 3)
		{ // close
			if (entry->args[5])
			{
				entry->return_code = 0;
				flexsc_mod_file_close((struct file*) entry->args[0]);
				//				kprint_true ? printk("file_open returned= %d\n") : 1;
			}
		}
		entry->status = DONE;
		//		kprint_true ? printk("ENTRY %d:%d\n", entry->status, entry->return_code) : 1;
	}
	return 0;
}

unsigned long flexsc_mod_MAX_I = 1000;
int flexsc_mod_counter_i = 0;

static void flexsc_mod_my_wq_function(struct work_struct *work)
{
	my_work_t *my_work = (my_work_t *) work;

	int j = my_work->x;

	struct syscall_entry* entry = &flexsc_mod_shared_syscall_page->entries[j]; //User

	flexsc_mod_perform_flex_system_call(entry);

	//if (sleep_count > 0)
	//	msleep(sleep_count);

	if (flexsc_mod_valid_wq)
		queue_work(flexsc_mod_my_wq, (struct work_struct *) work);

	//	counter_i = (counter_i + 1) % 1000;
	//
	//	if (counter_i == 999 && kprint_true)
	//	{
	//		for (i = 0; i < 64; i++)
	//		{
	//
	//			printk("%d ", shared_syscall_page->entries[i].index);
	//			printk("%d ", shared_syscall_page->entries[i].syscall);
	//			printk("%d ", shared_syscall_page->entries[i].status);
	//			printk("%d ", shared_syscall_page->entries[i].num_args);
	//			printk("%d ", shared_syscall_page->entries[i].return_code);
	//			printk("%d ", shared_syscall_page->entries[i].args[0]);
	//			printk("%d ", shared_syscall_page->entries[i].args[1]);
	//			printk("%d ", shared_syscall_page->entries[i].args[2]);
	//			printk("%d ", shared_syscall_page->entries[i].args[3]);
	//			printk("%d ", shared_syscall_page->entries[i].args[4]);
	//			printk("%d \n", shared_syscall_page->entries[i].args[5]);
	//		}
	//	}

	//	kfree((void *) work);
	return;
}

int flexsc_mod_syscall_thread_run(void *p)
{
	int j = (int) p;

	struct syscall_entry* entry = &flexsc_mod_shared_syscall_page->entries[j]; //User

	while (1)
	{
		if (entry->status == SUBMITTED)
		{
			flexsc_mod_perform_flex_system_call(entry);
		}

		msleep(1);

		if (kthread_should_stop())
			break;
	}
	return 0;
}

//mmap portion//////////////
/* character device structures */
static dev_t flexsc_mod_mmap_dev;
static struct cdev flexsc_mod_mmap_cdev;

/* methods of the character device */
static int flexsc_mod_mmap_open(struct inode *inode, struct file *filp);
static int flexsc_mod_mmap_release(struct inode *inode, struct file *filp);
static int flexsc_mod_mmap_mmap(struct file *filp, struct vm_area_struct *vma);

/* the file operations, i.e. all character device methods */
static struct file_operations flexsc_mod_mmap_fops =
{ //
		.open = flexsc_mod_mmap_open, //
				.release = flexsc_mod_mmap_release,//
				.mmap = flexsc_mod_mmap_mmap, //
		//		, .owner = THIS_MODULE,
		};

//
// internal data
// length of the two memory areas
#define NPAGES 16
// pointer to the kmalloc'd area, rounded up to a page boundary
static struct syscall_page *flexsc_mod_kmalloc_area;
// original pointer for kmalloc'd area as returned by kmalloc
static void *flexsc_mod_kmalloc_ptr;

/* character device open method */
static int flexsc_mod_mmap_open(struct inode *inode, struct file *filp)
{
	return 0;
}
/* character device last close method */
static int flexsc_mod_mmap_release(struct inode *inode, struct file *filp)
{
	return 0;
}

/* character device mmap method */
static int flexsc_mod_mmap_mmap(struct file *filp, struct vm_area_struct *vma)
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
		if ((ret = remap_pfn_range(vma, vma->vm_start, virt_to_phys((void *) flexsc_mod_kmalloc_area) >> PAGE_SHIFT, length, vma->vm_page_prot)) < 0)
		{
			return ret;
		}

		return 0;
	}
	/* at any other offset we return an error */
	return -EIO;
}

void flexsc_mod_stop_syscall_threads(void)
{
	int i;
	for (i = 0; i < MAX_SYSCALL_THREAD; i++)
	{
		if (flexsc_mod_syscall_threads[i] != NULL)
		{
			kthread_stop(flexsc_mod_syscall_threads[i]);
			flexsc_mod_syscall_threads[i] = NULL;
		}
	}
}

void* flexsc_mod_register(void* user_pages)
{
	int i, ret;
	unsigned char *alld;
	struct syscall_page* pp;

	//	kprint_true = ((int) user_pages) % 10 != NULL;
	//	sleep_count = ((int) user_pages) / 10;
	//sleep_count = 0; // No Sleep

	printk("Registering Process: PID = %d\n", current->pid);



	//Allocate Memory
	/* allocate a memory area with kmalloc. Will be rounded up to a page boundary */
	if ((flexsc_mod_kmalloc_ptr = kmalloc((NPAGES + 2) * PAGE_SIZE, GFP_KERNEL)) == NULL)
	{
		ret = -ENOMEM;
		goto out;
	}

	/* round it up to the page bondary */
	flexsc_mod_kmalloc_area = (struct syscall_page *) ((((unsigned long) flexsc_mod_kmalloc_ptr) + PAGE_SIZE - 1) & PAGE_MASK);

	//We implemented a character device called mmap
	/* get the major number of the character device */
	if ((ret = alloc_chrdev_region(&flexsc_mod_mmap_dev, 0, 1, "flexsc_module")) < 0)
	{
		printk("could not allocate major number for mmap\n");
		goto out_kfree;
	}

	/* initialize the device structure and register the device with the kernel */
	cdev_init(&flexsc_mod_mmap_cdev, &flexsc_mod_mmap_fops);
	if ((ret = cdev_add(&flexsc_mod_mmap_cdev, flexsc_mod_mmap_dev, 1)) < 0)
	{
		printk("could not allocate chrdev for mmap\n");
		goto out_unalloc_region;
	}

	/* mark the pages reserved */
	for (i = 0; i < NPAGES * PAGE_SIZE; i += PAGE_SIZE)
	{
		SetPageReserved(virt_to_page(((unsigned long) flexsc_mod_kmalloc_area) + i));
	}
	//Finished Allocating memories.

	for (i = 0; i < MAX_SYSCALL_THREAD; i++)
	{
		flexsc_mod_kmalloc_area->entries[i].index = i;
		flexsc_mod_kmalloc_area->entries[i].status = FREE;
		flexsc_mod_kmalloc_area->entries[i].syscall = 0;
		flexsc_mod_kmalloc_area->entries[i].num_args = 0;
		flexsc_mod_kmalloc_area->entries[i].return_code = 0;
		flexsc_mod_kmalloc_area->entries[i].args[0] = 0;
		flexsc_mod_kmalloc_area->entries[i].args[1] = 0;
		flexsc_mod_kmalloc_area->entries[i].args[2] = 0;
		flexsc_mod_kmalloc_area->entries[i].args[3] = 0;
		flexsc_mod_kmalloc_area->entries[i].args[4] = 0;
		flexsc_mod_kmalloc_area->entries[i].args[5] = 200 + i;
	}

	alld = (unsigned char*) flexsc_mod_kmalloc_area;

	pp = (struct syscall_page*) alld;
	for (i = 0; i < MAX_SYSCALL_THREAD; i++)
	{
		printk("%d ", pp->entries[i].index);
		printk("%d ", pp->entries[i].status);
		printk("%d ", pp->entries[i].syscall);
		printk("%lld ", pp->entries[i].return_code);
		printk("%lld ", pp->entries[i].args[0]);
		printk("%lld ", pp->entries[i].args[1]);
		printk("%lld ", pp->entries[i].args[2]);
		printk("%lld ", pp->entries[i].args[3]);
		printk("%lld ", pp->entries[i].args[4]);
		printk("%lld \n", pp->entries[i].args[5]);
	}

	flexsc_mod_shared_syscall_page = flexsc_mod_kmalloc_area; // kmalloced area is the actual area.

	// KThread Implementation
	flexsc_mod_stop_syscall_threads();

	for (i = 0; i < MAX_SYSCALL_THREAD; i++)
	{
		flexsc_mod_syscall_threads[i] = kthread_run(flexsc_mod_syscall_thread_run, (void *) i, "syscall_mod_thread");
	}

	printk("Page: %ld\n", (NPAGES + 2) * PAGE_SIZE);
	//ts = kthread_run(thread, NULL, "kthread");

	printk("flexsc_registration Complete.\n");
	return NULL;

	out_unalloc_region: printk("out_unalloc_region\n");
	unregister_chrdev_region(flexsc_mod_mmap_dev, 1);
	//
	//out_vfree: vfree(vmalloc_area);
	//
	out_kfree: printk("out_kfree\n");
	kfree(flexsc_mod_kmalloc_ptr);
	//
	out: printk("out\n");
	return NULL;

}

long flexsc_mod_wait(void)
{
	return current->pid;
}

//Not using it.
void* flexsc_mod_unregister(void)
{
	int i;
	//	valid_wq = 0;

	/* remove the character deivce */
	cdev_del(&flexsc_mod_mmap_cdev);
	unregister_chrdev_region(flexsc_mod_mmap_dev, 1);

	/* unreserve the pages */
	for (i = 0; i < NPAGES * PAGE_SIZE; i += PAGE_SIZE)
	{
		ClearPageReserved(virt_to_page(((unsigned long) flexsc_mod_kmalloc_area) + i));
	}
	/* free the memory areas */
	kfree(flexsc_mod_kmalloc_ptr);

	flexsc_mod_stop_syscall_threads();

	return NULL;
}

