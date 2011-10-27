#include <linux/linkage.h>
#include <flexsc/flexsc.h>
#include <linux/kernel.h>
#include <linux/ioport.h>

#include <linux/wait.h>
#include <linux/kthread.h>
#include <linux/slab.h>
#include <linux/fs.h>      // Needed by filp
#include <asm/uaccess.h>   // Needed by segment descriptors
//#include <sys/syscall.h>
#define FREE 0
#define SUBMITTED 1
#define DONE 2
//

int loop_counter = 1000;

//INTERNAL_SYSCALL
struct file* file_open(const char* path, int flags, int rights) {
	struct file* filp = NULL;
	mm_segment_t oldfs;
	int err = 0;

	oldfs = get_fs();
	set_fs(get_ds());
	filp = filp_open(path, flags, rights);
	set_fs(oldfs);
	if (IS_ERR(filp)) {
		err = PTR_ERR(filp);
		return NULL;
	}
	return filp;
}

void file_close(struct file* file) {
	filp_close(file, NULL);
}

int file_write(struct file* file, unsigned long long offset,
		unsigned char* data, unsigned int size) {
	mm_segment_t oldfs;
	int ret;

	oldfs = get_fs();
	set_fs(get_ds());

	ret = vfs_write(file, data, size, &offset);

	set_fs(oldfs);
	return ret;
}

int do_flex_system_call(void* data) {
	struct syscall_entry* entry = (struct syscall_entry*)data;


	struct syscall_entry* tmp = kmalloc(sizeof(struct syscall_entry), GFP_KERNEL);	
	if(!tmp){
		printk(">>>>>>>>>>>kmalloc Failed!");
		return;	
	}
	while (1) {
		loop_counter--;
		if(loop_counter<0)
			break;
		printk(KERN_INFO "$$$$$$$$$$$$ In do_flex_system_call Address: %d\n", entry);
		
		printk("Checking Memory Access.");
		if(access_ok(VERIFY_WRITE, entry, sizeof(struct syscall_entry))) {
			copy_from_user(tmp, entry, sizeof(struct syscall_entry));			
			printk(KERN_INFO "************ENTRY[%d] = %d, [5]=%ld\n", tmp->index, tmp->syscall, tmp->args[5]);			
		}
		else {
			printk("Cannot access memory.");		
		}
		
		/*		
		if (entry->status == SUBMITTED) {
			printk("~~~~~~~~~~~~~FOUND~~~~~~~~~~~~~~~~");
			if(entry->syscall == 2){ // open
				entry->return_code = file_open((char*) entry->args[0],
						entry->args[1], entry->args[2]);
				}
			else if(entry->syscall == 1){ // write
				entry->return_code = file_write((struct file*) entry->args[0],
						entry->args[1], (char*) entry->args[2], entry->args[3]);
				}
			else if(entry->syscall == 3){ // close
				entry->return_code = 0;
				file_close((struct file*) entry->args[0]);
			}
			entry->status = DONE;
		}*/
		if (kthread_should_stop())
			break;		
		printk("@@@@@@@@@ Going to Sleep.");
		msleep(200);// Just sleep the kernel thread.
	}
	do_exit();
	printk("///////////////////////////////Bye Bye While 1");
	return 0;	
}

//


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

asmlinkage void* sys_flexsc_register() {
	struct syscall_page *page;

	page = kmalloc(sizeof(struct syscall_page), GFP_USER);
	if (!page) {
		printk(KERN_INFO "Memory Allocation Failed.\n");
		return (void *) NULL;
	}printk(KERN_INFO "Memory Allocation Successfull.\n");
	printk(KERN_INFO "init_module() called\n");
	ts_kth = kthread_run(mma_thread, NULL, "kthread");

	return (void *) page;
}

/*
int syscall_thread_run(void* data) {
	printk(KERN_INFO "In SyscallThread Run.\n");
	struct syscall_entry* entry = (struct syscall_entry*) data;
	//printk(KERN_INFO "Casted Data.\n");
	printk(KERN_INFO "Index: %d.\n", entry->index );
	do_flex_system_call((struct syscall_entry*)data);
	return 0;
}
*/

struct task_struct* syscall_threads[2];//64 Syscall Threads.
struct syscall_page* shared_syscall_page = NULL;

asmlinkage void* sys_flexsc_register2(void* user_pages) {
	printk(KERN_INFO "Syscall Page Address: %d\n", user_pages);
	shared_syscall_page = (struct syscall_page*) user_pages;
	printk(KERN_INFO "Casting Successfull. Creating syscall threads.\n");

	loop_counter = 1000;

	int i;
	for (i = 0; i < 2; i++) {
		//shared_syscall_page->entries[i].status = 0;
		//shared_syscall_page->entries[i].index = i;
		
		printk(KERN_INFO "Spawning syscall thread: %d.\n", i);
		printk(KERN_INFO "Address of Entry %d\n", &shared_syscall_page->entries[i]);
		printk(KERN_INFO "[%d] = %d, [5]=%ld\n", shared_syscall_page->entries[i].index, shared_syscall_page->entries[i].status, shared_syscall_page->entries[i].args[5]);

		if(access_ok(VERIFY_WRITE, &shared_syscall_page->entries[i], sizeof(struct syscall_entry))) {
			printk("Accessible memory.");					
		}
		else {
			printk("Cannot access memory.");		
		}

		syscall_threads[i] = kthread_run(do_flex_system_call, &shared_syscall_page->entries[i], "flexapp");//Spawn a thread with a entry
	}
	return NULL;
}

asmlinkage long sys_flexsc_wait() {
	return 7;
}

