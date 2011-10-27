/*
 * flexsc_syscalls.c
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#include "iflexsc.h"
#include "flexsc_syscalls.h"
#include <stdlib.h>

void getpid_flex() {
	struct syscall_entry* entry = free_syscall_entry();
	if (entry != NULL) {
		entry->syscall = 39;
		entry->num_args = 0;
		entry->status = SUBMITTED;
	}
}

void flexsc_open(const char* filename, int mode, int rights) {
	struct syscall_entry* entry = free_syscall_entry();
	printf("Searching Entry!");
	if (entry != NULL) {
		entry->syscall = 2;
		entry->num_args = 3;
		entry->args[0] = filename;
		entry->args[1] = mode;
		entry->args[2] = rights;
		entry->status = SUBMITTED;
		printf("Submitted Entry%d", entry->index);
	}
}

void flexsc_close(long long fileid) {
	struct syscall_entry* entry = free_syscall_entry();
	if (entry != NULL) {
		entry->syscall = 3;
		entry->num_args = 1;
		entry->args[0] = fileid;
		entry->status = SUBMITTED;
	}
}
void flexsc_write(long long fileid, unsigned long long offset,
		unsigned char* data, unsigned int size) {
	struct syscall_entry* entry = free_syscall_entry();
	if (entry != NULL) {
		entry->syscall = 1;
		entry->num_args = 4;
		entry->args[0] = fileid;
		entry->args[1] = offset;
		entry->args[2] = data;
		entry->args[3] = size;
		entry->status = SUBMITTED;
	}
}
