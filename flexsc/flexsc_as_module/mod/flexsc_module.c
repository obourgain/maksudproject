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
	char buf[1024];
	int ret;
	struct file* fd = __mod_file_open(filename, O_RDWR | O_CREAT | O_APPEND, 0777);
	if (fd == NULL)
		return;
	int off = 0;
	do
	{
		ret = __mod_file_read(fd, off, buf, 384);
		off++;

		printk("#%d\n", ret);

		if (ret != 1)
			break;

		printk("::%c\n", buf[0]);

		if (off > 100)
			break;
	} while (1);
}

int init_module(void)
{
	//	printk("Hello World!");
//	read_file("/home/maksud/FILE-0.txt");
	//	printk("Sizeof syscall page is: %d", sizeof(struct syscall_page));
	__mod_register(64 * 128);

	return 0;// Non zero means modules can not be loaded.
}

void cleanup_module(void)
{
	//	printk("Bye, World!");
	__mod_unregister();
}

