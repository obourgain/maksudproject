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
//
ssize_t __mod_file_pread(struct file* file, void* data, size_t size, off_t offset);
ssize_t __mod_file_pwrite(struct file* file, const void* data, size_t size, off_t offset);
ssize_t __mod_file_read(struct file* file, void* data, size_t size, off_t offset);
ssize_t __mod_file_write(struct file* file, const void* data, size_t size, off_t offset);

//ssize_t      pread(int, void *, size_t, off_t);
//ssize_t      pwrite(int, const void *, size_t, off_t);
//ssize_t      read(int, void *, size_t);
//ssize_t      write(int, const void *, size_t);

#endif /* _FLEXSC_MOD_FLEX_SYSCALLS_H_ */
