#include <linux/linkage.h>
#include <linux/kernel.h>
#include <linux/ioport.h>
#include <linux/workqueue.h>
#include <linux/wait.h>
#include <linux/kthread.h>
#include <linux/slab.h>
#include <linux/fs.h>      // Needed by filp
#include <asm/uaccess.h>   // Needed by segment descriptors
#include <flexsc/flex_syscalls.h>
#include <flexsc/flexsc.h>

//INTERNAL_SYSCALL
struct file* file_open(const char* path, int flags, int rights) {
	struct file* filp = NULL;
	mm_segment_t oldfs;
	int err = 0;

	printk("%s, %d, %d\n", path, flags, rights);

	oldfs = get_fs();
	set_fs(get_ds());
	filp = filp_open(path, flags, rights);
	set_fs(oldfs);
	if (IS_ERR(filp)) {
		err = PTR_ERR(filp);
		printk("Problem Opening %d\n", err);
		return NULL;
	}
	printk("Open File Successful: File Pointer: %d\n", filp);
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
