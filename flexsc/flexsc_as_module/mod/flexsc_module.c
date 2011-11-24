/*
 * flexsc_module.c
 *
 *  Created on: Nov 13, 2011
 *      Author: maksud
 */

#include <linux/module.h>
#include <linux/kernel.h>
#include "mod/flexsc/flexsc.h"

#define DRIVER_AUTHOR "Maksudul Alam <maksud@vt.edu>"
#define DRIVER_DESC   "FlexSC Kernel Module"

MODULE_LICENSE("GPL");
MODULE_AUTHOR(DRIVER_AUTHOR);
MODULE_DESCRIPTION(DRIVER_DESC);
MODULE_SUPPORTED_DEVICE("flexscdevice");


int init_module(void)
{
	printk("Hello World!");

	flexsc_mod_register(NULL);

	return 0;// Non zero means modules can not be loaded.
}

void cleanup_module(void)
{
	printk("Bye, World!");
	flexsc_mod_unregister();
}

