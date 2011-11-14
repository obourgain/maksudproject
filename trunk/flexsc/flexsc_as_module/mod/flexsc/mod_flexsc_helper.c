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

struct task_struct *flexsc_mod_flexsc_registered = NULL;
struct mm_struct *flexsc_mod_flexsc_registered_mm = NULL;

char flexsc_mod_my_kernel_buf[4096 * 2];
int flexsc_mod_my_loop = 0;
struct page **flexsc_mod_my_pages;


int flexsc_mod_kt_func1(void *p);
int flexsc_mod_kt_func2(void *p);

int flexsc_mod_kt_func1(void *p)
{
	//	while (flexsc_mod_my_loop > 0)
	//	{
	//
	//		int kk = access_process_vm(flexsc_mod_flexsc_registered, (long unsigned int) p, flexsc_mod_my_kernel_buf, 10, 0);
	//		if (kk > 0)
	//		{
	//			printk("1. Line: %d,%d\n", flexsc_mod_my_kernel_buf[0], flexsc_mod_my_kernel_buf[1]);
	//		}
	//		else
	//			printk("0. Line: %d,%d\n", flexsc_mod_my_kernel_buf[0], flexsc_mod_my_kernel_buf[1]);
	//
	//		flexsc_mod_my_loop--;
	//		msleep(1000);
	//	}
	return 0;
}

int flexsc_mod_kt_func2(void *p)
{
	int rr;
	while (flexsc_mod_my_loop > 0)
	{
		printk("Accessing: PID=%d\n", flexsc_mod_flexsc_registered->pid);

		down_read(&flexsc_mod_flexsc_registered->mm->mmap_sem);
		rr = get_user_pages(flexsc_mod_flexsc_registered, flexsc_mod_flexsc_registered->mm, (long) p, 1, 1, 0, flexsc_mod_my_pages, NULL);
		up_read(&current->mm->mmap_sem);

		printk("get_user_pages %d\n", rr);

		flexsc_mod_my_loop--;
		msleep(1000);
	}
	return 0;
}

void flexsc_mod_sys_1(void* p)
{
	kthread_run("kth1", flexsc_mod_kt_func1, p);
	//might also store process context as I am in system call!! How?
}

void flexsc_mod_sys_2(void* p)
{
	flexsc_mod_my_pages = kmalloc(1 * sizeof(*flexsc_mod_my_pages), GFP_KERNEL);

	kthread_run("kth2", flexsc_mod_kt_func2, p);
	//might also store process context as I am in system call!! How?
}

void* flexsc_mod_sc1(void* p)
{
	flexsc_mod_my_loop = 10;

	flexsc_mod_flexsc_registered = current;
	flexsc_mod_flexsc_registered_mm = get_task_mm(current);

	flexsc_mod_sys_1(p);

	return (void*) 1;
}

void* flexsc_mod_sc2(void* p)
{
	flexsc_mod_my_loop = 10;

	flexsc_mod_flexsc_registered = current;
	flexsc_mod_flexsc_registered_mm = get_task_mm(current);

	flexsc_mod_sys_2(p);
	return (void*) 2;
}
