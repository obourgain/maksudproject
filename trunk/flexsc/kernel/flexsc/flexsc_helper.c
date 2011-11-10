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


/*
 * flexsc_helper.c
 *
 *  Created on: Nov 10, 2011
 *      Author: maksud
 */

struct task_struct *flexsc_registered = NULL;
struct mm_struct *flexsc_registered_mm = NULL;

char my_kernel_buf[1024];

int my_loop = 0;

int kt_func(void *p)
{
	while (my_loop > 0)
	{

		int kk = access_process_vm(flexsc_registered, (long unsigned int)p, my_kernel_buf, 10, 0);
		if (kk > 0)
		{
			printk("1. Line: %d,%d\n", my_kernel_buf[0], my_kernel_buf[1]);
		}
		else
			printk("0. Line: %d,%d\n", my_kernel_buf[0], my_kernel_buf[1]);

		my_loop--;
		msleep(1000);
	}
	return 0;
}

void sys_340(void* p)
{
	kthread_run("kth", kt_func, p);
	//might also store process context as I am in system call!! How?
}

asmlinkage void* sys_flexsc_sc1(void* p)
{
	my_loop = 10;

	flexsc_registered = current;
	flexsc_registered_mm = get_task_mm(current);

	sys_340(p);

	return (void*) 1;
}

asmlinkage void* sys_flexsc_sc2(void* p)
{
	return (void*) 2;
}
asmlinkage void* sys_flexsc_sc3(void* p)
{
	return (void*) 3;
}
asmlinkage void* sys_flexsc_sc4(void* p)
{
	return (void*) 4;
}
asmlinkage void* sys_flexsc_sc5(void* p)
{
	return (void*) 5;
}
