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
#include <flexsc/flex_syscalls.h>

//#include <sys/syscall.h>
//
typedef struct
{
	struct work_struct my_work;
	int x;
} my_work_t;

int valid_wq = 0;
static struct workqueue_struct *my_wq = NULL;
my_work_t flex_work_data[64];
my_work_t* flex_work[64];

//int loop_counter = 100;

struct task_struct* syscall_threads[64];//64 Syscall Threads.
//
struct syscall_page* shared_syscall_page = NULL;
struct syscall_entry* shared_entries[64];
//
//struct syscall_entry kernel_entries_data[64];
//struct syscall_entry* kernel_entries[64];

const char* file1 = "/home/maksud/file1.txt";
const char* file2 = "/home/maksud/file2.txt";

char fw_buff[4];

int perform_flex_system_call(struct syscall_entry* entry)
{
	if (entry->status == SUBMITTED)
	{
		printk("~~~~~~~~~~~~~FOUND~~~~~~~~~~~~~~~~\n");
		printk("##ENTRY From Worker Thread. [%d] = %d, [0]=%ld, [1]=%ld, [2]=%ld\n", entry->index, entry->syscall, entry->args[0], entry->args[1], entry->args[2]);
		if (entry->syscall == 2)
		{ // open
			printk("Filename%d\n", entry->args[0]);

			if (entry->args[5])
			{
				if (entry->args[0])
					entry->return_code = file_open(file1, entry->args[1], entry->args[2]);
				else
					entry->return_code = file_open(file2, entry->args[1], entry->args[2]);
			}
			printk("file_open returned= %d\n");
		}
		else if (entry->syscall == 1)
		{ // write
			if (entry->args[5])
			{
				printk("Buffer", entry->args[0]);
				fw_buff[0] = (entry->args[2] >> 8) && 0xFFFF;
				fw_buff[1] = (entry->args[2] >> 16) && 0xFFFF;
				fw_buff[2] = (entry->args[2] >> 24) && 0xFFFF;
				fw_buff[3] = (entry->args[2] >> 32) && 0xFFFF;

				entry->return_code = file_write((struct file*) entry->args[0], entry->args[1], fw_buff, 4);
				printk("file_open returned= %d\n");
			}
		}
		else if (entry->syscall == 3)
		{ // close
			if (entry->args[5])
			{
				entry->return_code = 0;
				file_close((struct file*) entry->args[0]);
				printk("file_open returned= %d\n");
			}
		}
		entry->status = DONE;
		printk("ENTRY %d:%d\n", entry->status, entry->return_code);
	}
	return 0;
}

unsigned long MAX_I = 1000;
int counter_i = 0;

static void my_wq_function(struct work_struct *work)
{
	my_work_t *my_work = (my_work_t *) work;

	int i = 0, j = my_work->x, ret = 0;

	struct syscall_entry* entry = &shared_syscall_page->entries[j]; //User

	//	printk("PID->%d\n", current->pid);
	//	printk("Worker: %d\n", my_work->x);

	//	printk("##ENTRY From Worker Thread. [%d] = %d, [5]=%ld\n", entry->index, entry->syscall, entry->args[5]);
	perform_flex_system_call(entry);

	msleep(100);

	//printk("Queue Work\n");
	//Queue this again.

	if (valid_wq)
		queue_work(my_wq, (struct work_struct *) work);

	counter_i = (counter_i + 1) % 1000;

	if (counter_i == 999)
	{
		for (i = 0; i < 64; i++)
		{

			printk("%d ", shared_syscall_page->entries[i].index);
			printk("%d ", shared_syscall_page->entries[i].syscall);
			printk("%d ", shared_syscall_page->entries[i].status);
			printk("%d ", shared_syscall_page->entries[i].num_args);
			printk("%d ", shared_syscall_page->entries[i].return_code);
			printk("%d ", shared_syscall_page->entries[i].args[0]);
			printk("%d ", shared_syscall_page->entries[i].args[1]);
			printk("%d ", shared_syscall_page->entries[i].args[2]);
			printk("%d ", shared_syscall_page->entries[i].args[3]);
			printk("%d ", shared_syscall_page->entries[i].args[4]);
			printk("%d \n", shared_syscall_page->entries[i].args[5]);
		}
	}

	//	kfree((void *) work);
	return;
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
static struct syscall_page *kmalloc_area;
// original pointer for kmalloc'd area as returned by kmalloc
static void *kmalloc_ptr;

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

// helper function, mmap's the kmalloc'd area which is physically contiguous
int mmap_kmem(struct file *filp, struct vm_area_struct *vma)
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

/* character device mmap method */
static int mmap_mmap(struct file *filp, struct vm_area_struct *vma)
{
	/* at offset NPAGES we map the kmalloc'd area */
	if (vma->vm_pgoff == NPAGES)
	{
		return mmap_kmem(filp, vma);
	}
	/* at any other offset we return an error */
	return -EIO;
}

asmlinkage void* sys_flexsc_register2(void* user_pages)
{
	printk("SysPID: PID = %d\n", current->pid);

	int i, j, ret;

	//Allocate Memory
	/* allocate a memory area with kmalloc. Will be rounded up to a page boundary */
	if ((kmalloc_ptr = kmalloc((NPAGES + 2) * PAGE_SIZE, GFP_KERNEL)) == NULL)
	{
		ret = -ENOMEM;
		goto out;
	}
	/* round it up to the page bondary */
	kmalloc_area = (struct syscall_page *) ((((unsigned long) kmalloc_ptr) + PAGE_SIZE - 1) & PAGE_MASK);

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

	/* mark the pages reserved */
	for (i = 0; i < NPAGES * PAGE_SIZE; i += PAGE_SIZE)
	{
		SetPageReserved(virt_to_page(((unsigned long) kmalloc_area) + i));
	}
	//Finished Allocating memories.

	for (i = 0; i < 64; i++)
	{
		kmalloc_area->entries[i].index = i;
		kmalloc_area->entries[i].status = FREE;
		kmalloc_area->entries[i].syscall = 0;
		kmalloc_area->entries[i].num_args = 0;
		kmalloc_area->entries[i].return_code = 0;
		kmalloc_area->entries[i].args[0] = 0;
		kmalloc_area->entries[i].args[1] = 0;
		kmalloc_area->entries[i].args[2] = 0;
		kmalloc_area->entries[i].args[3] = 0;
		kmalloc_area->entries[i].args[4] = 0;
		kmalloc_area->entries[i].args[5] = 200 + i;
	}

	unsigned char *alld = (unsigned char*) kmalloc_area;

	struct syscall_page* pp = (struct syscall_page*) alld;
	for (i = 0; i < 64; i++)
	{

		printk("%d ", pp->entries[i].index);
		printk("%d ", pp->entries[i].status);
		printk("%d ", pp->entries[i].syscall);
		printk("%d ", pp->entries[i].return_code);
		printk("%d ", pp->entries[i].args[0]);
		printk("%d ", pp->entries[i].args[1]);
		printk("%d ", pp->entries[i].args[2]);
		printk("%d ", pp->entries[i].args[3]);
		printk("%d ", pp->entries[i].args[4]);
		printk("%d \n", pp->entries[i].args[5]);
	}

	if (my_wq != NULL)
	{
		valid_wq = 0;
		printk("Destroy Previous Work Queue");
		destroy_workqueue(my_wq);
	}

	valid_wq = 1;
	printk("Creating Work Queue\n");
	my_wq = create_workqueue("flexsc_queue");

	shared_syscall_page = kmalloc_area; // kmalloced area is the actual area.

	//Creaing Works
	if (my_wq)
	{
		for (i = 0; i < 2; i++)
		{
			printk("Allocating necessary memories: %d\n", i);
			printk("+++++++++++++++++[%d] = S: %d, #: %d, St: %d, Args[5]=%ld\n", shared_syscall_page->entries[i].index, shared_syscall_page->entries[i].syscall, shared_syscall_page->entries[i].num_args, shared_syscall_page->entries[i].status,
					shared_syscall_page->entries[i].args[5]);
			//
			shared_entries[i] = &shared_syscall_page->entries[i];
			flex_work[i] = &flex_work_data[i];
			//
			printk("Creating Works:%d\n", i);
			if (flex_work[i])
			{
				INIT_WORK((struct work_struct *) flex_work[i], my_wq_function);
				flex_work[i]->x = i;
				ret = queue_work(my_wq, (struct work_struct *) flex_work[i]);
			}
		}
	}
	else
	{
		printk("Problem Creating Work Queue\n");
	}

	printk("Page: %d\n", (NPAGES + 2) * PAGE_SIZE);
	//ts = kthread_run(thread, NULL, "kthread");

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
	return ret;

}

asmlinkage long sys_flexsc_wait()
{
	return current->pid;
}

//Not using it.
asmlinkage void* sys_flexsc_register()
{
	//	struct syscall_page *page;
	//
	//	page = kmalloc(sizeof(struct syscall_page), GFP_USER);
	//	if (!page)
	//	{
	//		printk("Memory Allocation Failed.\n");
	//		return (void *) NULL;
	//	}
	//	printk("Memory Allocation Successfull.\n");
	//	printk("init_module() called\n");
	//	//ts_kth = kthread_run(mma_thread, NULL, "kthread");
	int i;

	/* remove the character deivce */
	cdev_del(&mmap_cdev);
	unregister_chrdev_region(mmap_dev, 1);

	/* unreserve the pages */
	for (i = 0; i < NPAGES * PAGE_SIZE; i += PAGE_SIZE)
	{
		ClearPageReserved(virt_to_page(((unsigned long) kmalloc_area) + i));
	}
	/* free the memory areas */
	kfree(kmalloc_ptr);

	return NULL;
}
