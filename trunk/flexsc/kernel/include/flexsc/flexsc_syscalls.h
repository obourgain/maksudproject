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

struct file* file_open(const char* path, int flags, int rights);
void file_close(struct file* file);
int file_write(struct file* file, unsigned long long offset, unsigned char* data, unsigned int size);
int file_read(struct file* file, unsigned long long offset, unsigned char* data, unsigned int size);

#endif /* _FLEXSC_FLEXSC_SYSCALLS_H_ */
