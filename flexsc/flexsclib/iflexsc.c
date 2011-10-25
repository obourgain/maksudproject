/*
 * iflexsc.c
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#include "iflexsc.h"
#include <sys/syscall.h>
#include <stdlib.h>

struct syscall_page* flexsc_register() {
	struct syscall_page* page;
	printf("Before System Call: %d\n", page);
	page = (struct syscall_page*) syscall(sys_flexsc_register);
	printf("After System Call: %d\n", page);

	printf("%d\n", page->entries[0].syscall);

	return page;
	//return (struct syscall_page*) syscall(sys_flexsc_register);
}

void flexsc_register2(struct syscall_page* page) {
//	struct syscall_page* page;
	printf("Calling 2: %d\n", page);
	page = syscall(sys_flexsc_register2, page);
	printf("After System Call 2: %d\n", page);
}

void flexsc_wait() {
	syscall(sys_flexsc_wait);
}

struct syscall_page* allocate_register() {

	return malloc(sizeof(struct syscall_page));
}
