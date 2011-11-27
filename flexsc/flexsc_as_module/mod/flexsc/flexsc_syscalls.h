/*
 * flex_syscalls.h
 *
 *  Created on: Oct 29, 2011
 *      Author: maksud
 */

#ifndef _FLEXSC_MOD_FLEX_SYSCALLS_H_
#define _FLEXSC_MOD_FLEX_SYSCALLS_H_

#include <linux/sched.h>
#include <linux/fs.h>

struct file* __mod_file_open(const char* path, int flags, int rights);
void __mod_file_close(struct file* file);
int __mod_file_write(struct file* file, unsigned long long offset, unsigned char* data, unsigned int size);
int __mod_file_read(struct file* file, unsigned long long offset, unsigned char* data, unsigned int size);

#endif /* _FLEXSC_MOD_FLEX_SYSCALLS_H_ */
