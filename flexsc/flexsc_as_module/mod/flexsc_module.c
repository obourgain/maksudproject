/*
 * flexsc_module.c
 *
 *  Created on: Nov 13, 2011
 *      Author: maksud
 */

#include <linux/module.h>
#include <linux/kernel.h>
#include "mod/flexsc/flexsc_syscalls.h"
#include "mod/flexsc/flexsc.h"
#include <linux/kernel.h>
#include <linux/init.h>
#include <linux/module.h>
#include <linux/syscalls.h>
#include <linux/fcntl.h>
#include <asm/uaccess.h>
#include <linux/kernel.h>
#include <linux/init.h>
#include <linux/module.h>
#include <linux/syscalls.h>
#include <linux/file.h>
#include <linux/fs.h>
#include <linux/fcntl.h>
#include <asm/uaccess.h>
#include <flexsc/flexsc.h>

#define DRIVER_AUTHOR "Maksudul Alam <maksud@vt.edu>"
#define DRIVER_DESC   "FlexSC Kernel Module"

MODULE_LICENSE("GPL");
MODULE_AUTHOR(DRIVER_AUTHOR);
MODULE_DESCRIPTION(DRIVER_DESC);
MODULE_SUPPORTED_DEVICE("flexscdevice");

static void read_file(char *filename)
{
	//	int fd;
	char buf[1];
	int ret;

	struct file* fd = __mod_file_open(filename, O_RDWR | O_CREAT | O_APPEND, 0777);

	if (fd == NULL)
		return;

	int off = 0;
	while (__mod_file_read(fd, off, buf, 1) == 1)
	{
		off++;
		printk("::%c\n", buf[0]);

		if (off > 100)
			break;
	}
	buf[0] = '*';
	__mod_file_write(fd, off, buf, 1);
	//	printk("Bytes: %d\n", ret);

	//		while (sys_read(fd, buf, 1) == 1)
	//			printk("%c", buf[0]);

	//	mm_segment_t old_fs = get_fs();
	//	set_fs(KERNEL_DS);
	//
	//	fd = sys_open(filename, O_RDONLY, 0);
	//	if (fd >= 0)
	//	{
	//		printk(KERN_DEBUG);
	//		while (sys_read(fd, buf, 1) == 1)
	//			printk("%c", buf[0]);
	//		printk("\n");
	//		sys_close(fd);
	//	}
	//	set_fs(old_fs);
}

int init_module(void)
{
	//	printk("Hello World!");
	//	read_file("/home/maksud/hello.txt");

	printk("Sizeof syscall page is: %d", sizeof(struct syscall_page));
	__mod_register(64 * 128 + 1);

	return 0;// Non zero means modules can not be loaded.
}

void cleanup_module(void)
{
	printk("Bye, World!");
	//flexsc_mod_unregister();
}

