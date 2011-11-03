/*
 * flexsc_syscalls.h
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#ifndef FLEXSC_SYSCALLS_H_
#define FLEXSC_SYSCALLS_H_

struct test
{
	int a;
	int b;
};

struct syscall_entry* flexsc_getpid();
struct syscall_entry* flexsc_open(const char* filename, int mode, int rights);
struct syscall_entry* flexsc_close(long long fileid);
struct syscall_entry* flexsc_write(long long fileid, unsigned long long offset, unsigned char* data, unsigned int size);

struct syscall_entry* flexsc_open_i(const char* filename, int mode, int rights, int i);
struct syscall_entry* flexsc_close_i(long long fileid, int i);
struct syscall_entry* flexsc_write_i(long long fileid, unsigned long long offset, unsigned char* data, unsigned int size, int i);

#endif /* FLEXSC_SYSCALLS_H_ */
