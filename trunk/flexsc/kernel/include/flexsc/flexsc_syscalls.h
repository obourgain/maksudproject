/*
 * flex_syscalls.h
 *
 *  Created on: Oct 29, 2011
 *      Author: maksud
 */

#ifndef _FLEXSC_FLEXSC_SYSCALLS_H_
#define _FLEXSC_FLEXSC_SYSCALLS_H_

#include <linux/sched.h>
#include <linux/fs.h>

struct file* __flexsc_file_open(const char* path, int flags, int rights);
void __flexsc_file_close(struct file* file);
int __flexsc_file_write(struct file* file, unsigned long offset, unsigned char* data, unsigned int size);
int __flexsc_file_read(struct file* file, unsigned long offset, unsigned char* data, unsigned int size);

#endif /* _FLEXSC_FLEXSC_SYSCALLS_H_ */
