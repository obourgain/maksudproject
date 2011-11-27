/*
 * flexsc_syscalls.h
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#ifndef FLEXSC_SYSCALLS_H_
#define FLEXSC_SYSCALLS_H_

#define _FLEX_SYSCALL_WRITE 1
#define _FLEX_SYSCALL_READ 0
#define _FLEX_SYSCALL_OPEN 2
#define _FLEX_SYSCALL_CLOSE 3

struct syscall_entry* flexsc_getpid(void);

struct syscall_entry* flexsc_open_e(struct syscall_entry* entry, const char* filename, int mode, int rights);
struct syscall_entry* flexsc_close_e(struct syscall_entry* entry, long fileid);
struct syscall_entry* flexsc_write_e(struct syscall_entry* entry, long fileid, unsigned long offset, unsigned char* data, unsigned int size);
struct syscall_entry* flexsc_read_e(struct syscall_entry* entry, long fileid, unsigned long offset, unsigned char* data, unsigned int size);

struct syscall_entry* flexsc_open(const char* filename, int mode, int rights);
struct syscall_entry* flexsc_close(long fileid);
struct syscall_entry* flexsc_write(long fileid, unsigned long offset, unsigned char* data, unsigned int size);
struct syscall_entry* flexsc_read(long fileid, unsigned long offset, unsigned char* data, unsigned int size);

struct syscall_entry* flexsc_open_i(const char* filename, int mode, int rights, int i);
struct syscall_entry* flexsc_close_i(long fileid, int i);
struct syscall_entry* flexsc_write_i(long fileid, unsigned long offset, unsigned char* data, unsigned int size, int i);
struct syscall_entry* flexsc_read_i(long fileid, unsigned long offset, unsigned char* data, unsigned int size, int i);

#endif /* FLEXSC_SYSCALLS_H_ */
