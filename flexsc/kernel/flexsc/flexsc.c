#include <linux/linkage.h>
#include <linux/kernel.h>
#include <linux/ioport.h>
#include <linux/workqueue.h>
#include <linux/wait.h>
#include <linux/kthread.h>
#include <linux/slab.h>
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

static struct workqueue_struct *my_wq = NULL;
my_work_t flex_work_data[64];
my_work_t* flex_work[64];

//int loop_counter = 100;

struct task_struct* syscall_threads[2];//64 Syscall Threads.
struct syscall_page* shared_syscall_page = NULL;
struct syscall_entry* shared_entries[64];
//
struct syscall_entry kernel_entries_data[64];
struct syscall_entry* kernel_entries[64];

int perform_flex_system_call(struct syscall_entry* entry, void* user_entry)
{
	if (entry->status == SUBMITTED)
	{
		printk("~~~~~~~~~~~~~FOUND~~~~~~~~~~~~~~~~\n");
		if (entry->syscall == 2)
		{ // open
			entry->return_code = file_open((char*) entry->args[0], entry->args[1], entry->args[2]);
			printk("file_open returned= %d\n");
		}
		else if (entry->syscall == 1)
		{ // write
			entry->return_code = file_write((struct file*) entry->args[0], entry->args[1], (char*) entry->args[2], entry->args[3]);
			printk("file_open returned= %d\n");
		}
		else if (entry->syscall == 3)
		{ // close
			entry->return_code = 0;
			file_close((struct file*) entry->args[0]);
			printk("file_open returned= %d\n");
		}
		entry->status = DONE;
		printk("ENTRY %d:%d\n", entry->status, entry->return_code);
		int ret = copy_to_user(user_entry, entry, sizeof(struct syscall_entry));
		if (ret == 0)
		{
			printk("Successfully copied to user\n");
		}
		else
		{
			printk("Copy to user is problematic: %d\n", ret);
		}
	}

	return 0;
}

//int do_flex_system_call(void* data)
//{
//
//	int i = (int) data, ret = 0;
//	printk("Entry No: %d\n", i);
//
//	struct syscall_entry* e_data = &shared_syscall_page->entries[i];//(struct syscall_entry*)data;
//	printk("User Address: %d\n", e_data);
//	//printk("User Address :) :%d\n", shared_syscall_page->entries[i]);
//	printk("Shared Entries :%d\n", shared_entries[i]);
//
//	struct syscall_entry* entry = kmalloc(sizeof(struct syscall_entry), GFP_KERNEL);
//	if (!entry)
//	{
//		printk(">>>>>>>>>>>kmalloc Failed!");
//		return;
//	}
//	while (1)
//	{
//		printk("[%d]=PID=%d $$$$$$$$$$$$ In do_flex_system_call Address: %d\n", i, current->pid, entry);
//
//		//		loop_counter--;// only testing purpose.
//		//		if (loop_counter < 0)
//		//			break;
//
//		printk("Checking Memory Access.\n");
//		if (access_ok(VERIFY_WRITE, e_data, sizeof(struct syscall_entry)))
//		{
////			int ret = copy_from_user(entry, e_data, sizeof(struct syscall_entry));
//			printk("***---+++*** copy_from_user=%d\n", ret);
//			printk("************ENTRY[%d] = %d, [5]=%ld\n", entry->index, entry->syscall, entry->args[5]);
//		}
//		else
//		{
//			printk("Cannot access memory.");
//			break;
//		}
//
//		perform_flex_system_call(e_data, e_data);
//
//		if (kthread_should_stop())
//			break;
//		printk("@@@@@@@@@ Going to Sleep.");
//		msleep(200);// Just sleep the kernel thread.
//	}
//	//do_exit();
//	printk("///////////////////////////////Bye Bye While 1");
//	return 0;
//}

//


//struct task_struct *ts_kth;
//
//int mma_thread(void *data)
//{
//	while (1)
//	{
//		printk("Hi I am kernel thread!\n");
//		msleep(100);
//		break;
//		//if (kthread_should_stop())
//		//	break;
//	}
//	return 0;
//}

//Not using it.
asmlinkage void* sys_flexsc_register()
{
	struct syscall_page *page;

	page = kmalloc(sizeof(struct syscall_page), GFP_USER);
	if (!page)
	{
		printk("Memory Allocation Failed.\n");
		return (void *) NULL;
	}
	printk("Memory Allocation Successfull.\n");
	printk("init_module() called\n");
	//ts_kth = kthread_run(mma_thread, NULL, "kthread");

	return (void *) page;
}

unsigned long MAX_I = 1000;
int counter_i = 0;

static void my_wq_function(struct work_struct *work)
{
	my_work_t *my_work = (my_work_t *) work;

	int i = 0, j = my_work->x, ret = 0;

	struct syscall_entry* e_data = &shared_syscall_page->entries[j]; //User
	struct syscall_entry* entry = kernel_entries[i]; //Kernel temporary storage.

	//	entry = e_data;

	//	while (i < 10) {
	printk("PID->%d\n", current->pid);
	printk("my_work.x %d\n", my_work->x);
	//	}


	//	if (access_ok(VERIFY_WRITE, e_data, sizeof(struct syscall_entry)))
	//	{
	ret = copy_from_user(entry, e_data, sizeof(struct syscall_entry));
	if (ret == 0) // Valid Data.
	{
		printk("***---+++*** copy_from_user in Worker Thread=%d\n", ret);
		printk("************ENTRY From Worker Thread. [%d] = %d, [5]=%ld\n", entry->index, entry->syscall, entry->args[5]);
		perform_flex_system_call(entry, e_data);
		//			//
	}
	else
	{
		printk("copy_from_user: FAAAIIILLSS for %d\n", my_work->x);
	}
	//	}
	//	else
	//	{
	//		printk("Cannot access memory.");
	//		//	break;
	//	}

	//	counter_i++;
	//	if (counter_i > MAX_I)
	//		return;

	msleep(100);

	printk("Queue Work\n");
	//Queue this again.
	queue_work(my_wq, (struct work_struct *) work);

	//	kfree((void *) work);
	return;
}

asmlinkage void* sys_flexsc_register2(void* user_pages)
{
	int i, ret;
	printk("SysPID: PID = %d\n", current->pid);
	printk("Syscall Page Address: %p\n", user_pages);

	if (my_wq != NULL)
	{
		printk("Destroy Previous Work Queue");
		destroy_workqueue(my_wq);
		//my_wq = NULL;
	}
	else
	{
		//		for (i = 0; i < 64; i++)
		//		{

		//		}
	}

	printk("Creating Work Queue\n");
	my_wq = create_workqueue("flexsc_queue");

	//Store malloc-ed syscall_page in kernel.
	shared_syscall_page = (struct syscall_page*) user_pages; // Do Share.

	counter_i = 0; // Reset Test Counter.
	//	loop_counter = 1000;
	//Creaing Works
	if (my_wq)
	{
		for (i = 0; i < 2; i++)
		{
			printk("Allocating necessary memories: %d\n", i);
			printk("+++++++++++++++++[%d] = S: %d, #: %d, St: %d, Args[5]=%ld\n", shared_syscall_page->entries[i].index, shared_syscall_page->entries[i].syscall, shared_syscall_page->entries[i].num_args, shared_syscall_page->entries[i].status,
					shared_syscall_page->entries[i].args[5]);
			shared_syscall_page->entries[i].args[4] = 2011; // Test value. Check this on user side.
			shared_entries[i] = &shared_syscall_page->entries[i];
			//			kernel_entries[i] = (struct syscall_entry *) kmalloc(sizeof(struct syscall_entry), GFP_KERNEL);
			flex_work[i] = &flex_work_data[i];
			kernel_entries[i] = &kernel_entries_data[i];
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

	printk("flexsc_registration Complete.\n");

	//	printk("Casting Successfull. Creating syscall threads.\n");

	//	for (i = 0; i < 2; i++)
	//	{
	//shared_syscall_page->entries[i].status = 0;
	//shared_syscall_page->entries[i].index = i;

	//		printk("Spawning syscall thread: %d.\n", i);
	//		printk("Address of Entry %d\n", &shared_syscall_page->entries[i]);
	//		printk("+++++++++++++++++[%d] = S: %d, #: %d, St: %d, Args[5]=%ld\n", shared_syscall_page->entries[i].index, shared_syscall_page->entries[i].syscall, shared_syscall_page->entries[i].num_args, shared_syscall_page->entries[i].status,
	//				shared_syscall_page->entries[i].args[5]);

	//		shared_syscall_page->entries[i].args[4] = 2005;//Testing, check this value on the user program.
	//if(access_ok(VERIFY_WRITE, &shared_syscall_page->entries[i], sizeof(struct syscall_entry))) {
	//	printk("Accessible memory.");
	//}
	//else {
	//	printk("Cannot access memory.");
	//}
	//		syscall_threads[i] = kthread_run(do_flex_system_call, i, "flexapp");//Spawn a thread with a entry
	//	}
	return NULL;
}

asmlinkage long sys_flexsc_wait()
{
	int i;
	for (i = 0; i < 2; i++)
	{
		queue_work(my_wq, flex_work[i]);
	}
	return current->pid;
}

