/*
 ============================================================================
 Name        : flexapp.c
 Author      : Maksud
 Version     :
 Copyright   : Your copyright notice
 Description : Hello World in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include "iflexsc.h"
#include "flexsc_syscalls.h"

int main(void) {

	printf("Call Tests\n");

	flexsc_wait();


	struct syscall_page* page = malloc(sizeof(struct syscall_page));
	int i;
	for(i=0; i<64; i++){
		page->entries[i].syscall = i;	
	}
	flexsc_register2(page);
	printf("FF Test?\n");
	page->entries[0].syscall = 1;
	printf("FF Test SigFault?\n");

	printf("Test?\n");
	page->entries[0].syscall = 1;
	printf("Test SigFault?\n");

	printf("Syscall: syscall=%d\n", page->entries[0].syscall);

	flexsc_wait();

	struct test a;

	puts("!!!Hello World!!!"); /* prints !!!Hello World!!! */
	return EXIT_SUCCESS;
}
