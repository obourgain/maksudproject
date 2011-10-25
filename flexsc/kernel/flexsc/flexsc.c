#include<linux/linkage.h>
#include<flexsc/flexsc.h>
#include <linux/kernel.h>
#include <linux/ioport.h>

#include <linux/wait.h>
#include <linux/kthread.h>
#include <linux/slab.h>

struct task_struct *ts_kth;

int mma_thread(void *data) {
	while (1) {
		printk("Hi I am kernel thread!\n");
		msleep(100);
		break;
		//if (kthread_should_stop())
		//	break;
	}
	return 0;
}


asmlinkage void* sys_flexsc_register()
{
	struct syscall_page *page;

	page = kmalloc(sizeof (struct syscall_page), GFP_USER);
	if (!page)
	{
		printk(KERN_INFO "Memory Allocation Failed.\n");
		return (void *)NULL;
	}
	printk(KERN_INFO "Memory Allocation Successfull.\n");
	printk(KERN_INFO "init_module() called\n");
	ts_kth = kthread_run(mma_thread, NULL, "kthread");

	return (void *)page;
}


int syscall_thread_run(void* data)
{
	printk(KERN_INFO "In SyscallThread Run.\n");
	struct syscall_entry* entry = (struct syscall_entry*)data;
	printk(KERN_INFO "Casted Data.\n");
	printk(KERN_INFO "Status: %d.\n", entry->syscall );

	return 0;
}

struct task_struct* syscall_threads[64];//64 Syscall Threads.
struct syscall_page* shared_syscall_page = NULL;

asmlinkage void* sys_flexsc_register2(void* user_pages)
{
	printk(KERN_INFO "Casting.\n");
	shared_syscall_page = (struct syscall_page*)user_pages;
	printk(KERN_INFO "Casting Successfull. Creating syscall threads.\n");
	
	int i;
	for(i=0; i<64; i++)
	{
		printk(KERN_INFO "Spawning syscall thread: %d.\n", i);
		syscall_threads[i] = kthread_run(syscall_thread_run, &shared_syscall_page->entries[i], "syscall_thread");//Spwan a thread with a entry
	}
	return NULL;
}

asmlinkage long sys_flexsc_wait()
{
	return 7;
}


