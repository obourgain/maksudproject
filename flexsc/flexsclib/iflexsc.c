/*
 * iflexsc.c
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#include "iflexsc.h"
#include <sys/syscall.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdio.h>
#include <sys/types.h>

struct syscall_page* basepage;

struct syscall_page* flexsc_register() {
	struct syscall_page* page = NULL;
	printf("Before System Call: %d\n", page);
	page = (struct syscall_page*) syscall(sys_flexsc_register);
	printf("After System Call: %d\n", page);

	basepage = page;

	printf("%d\n", page->entries[0].syscall);

	return page;
	//return (struct syscall_page*) syscall(sys_flexsc_register);
}

void flexsc_register2(struct syscall_page* page) {
	//	struct syscall_page* page;
	basepage = page;
	printf("Calling 2: %d\n", page);
	page = syscall(sys_flexsc_register2, page);
	printf("After System Call 2: %d\n", page);
}

void flexsc_wait() {
	long pid = (long) getpid();
	printf("getpid returned: %d\n", pid);
	pid = syscall(304);
	printf("syscall(304) returned: %d\n", pid);
	pid = syscall(39);
	printf("syscall(39) returned: %d\n", pid);
	long ret = syscall(sys_flexsc_wait);
	printf("flexscwait returned: %d\n", ret);
}

struct syscall_page* allocate_register() {

	return malloc(sizeof(struct syscall_page));
}

struct syscall_entry* free_syscall_entry() {
	int i = 0;
	for (i = 0; i < 64; i++) {
		if (basepage->entries[i].status == FREE) {
			return &basepage->entries[i];
		}
	}
	return NULL; // Sorry, No Free Entry.
}
