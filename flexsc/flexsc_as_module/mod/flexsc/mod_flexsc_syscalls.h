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

struct file* flexsc_mod_file_open(const char* path, int flags, int rights);
void flexsc_mod_file_close(struct file* file);
int flexsc_mod_file_write(struct file* file, unsigned long long offset, unsigned char* data, unsigned int size);

#endif /* _FLEXSC_MOD_FLEX_SYSCALLS_H_ */
