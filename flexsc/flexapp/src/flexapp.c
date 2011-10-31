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
#include <gnu/libc-version.h>
#include <linux/mman.h>
#include <fcntl.h>

int main(void)
{

	int a = ('D' << 32) & ('A' << 24) & ('B' << 16) & ('C' << 8);

	printf("Call Tests\n");
	printf("%d, %d, %d\n", FREE, SUBMITTED, DONE);

	//	flexsc_register();
	//	return -1;

	struct syscall_page* page = flexsc_register2();

	printf("Syscall: Args[0][4]=%lld\n", page->entries[0].args[4]);
	printf("Syscall: Args[1][4]=%lld\n", page->entries[0].args[4]);

	//	const char fname[] = "/home/maksud/testfile4";
	int i1 = 33345, i2 = 438;
	struct syscall_entry* entry1 = flexsc_open(1, i1, i2);

	//	const char fname2[] = "/home/maksud/testfile";
	struct syscall_entry* entry2 = flexsc_open(0, i1, i2);

	//Can not proceed while status is not DONE
	while (entry1->status != DONE)
	{
		printf("WAITING... for entry 1 return_code=%d, status=%d\n", entry1->return_code);
		//Nothing to Do.
	}
	long long fd1 = entry1->return_code; //flexsc_open returns file descriptor.
	entry1->status = FREE;

	while (entry2->status != DONE)
	{
		printf("WAITING... for entry 2\n");
		//Nothing to Do.
	}
	long long fd2 = entry2->return_code; //flexsc_open returns file descriptor.
	entry2->status = FREE;

	entry1 = flexsc_write(fd1, 0, a, 4);
	entry2 = flexsc_write(fd2, 0, "ABCD", 4);

	//Can not proceed while status is not DONE
	while (entry1->status != DONE)
	{
		printf("WAITING... for entry 1 return_code=%d, status=%d\n", entry1->return_code);
		//Nothing to Do.
	}
	entry1->status = FREE;

	//Can not proceed while status is not DONE
	while (entry2->status != DONE)
	{
		printf("WAITING... for entry 2 return_code=%d, status=%d\n", entry2->return_code);
		//Nothing to Do.
	}
	entry2->status = FREE;

	entry1 = flexsc_close(fd1);
	entry2 = flexsc_close(fd2);

	//Can not proceed while status is not DONE
	while (entry1->status != DONE)
	{
		printf("WAITING... for close entry 1\n");
		printstack();
		//Nothing to Do.
	}
	entry1->status = FREE;

	while (entry2->status != DONE)
	{
		printf("WAITING... for close entry 2\n");
		printstack();
		//Nothing to Do.
	}
	entry2->status = FREE;
	///

	int i22 = 0;
	printf("Waiting For and entry.");
	scanf("%d", &i22);

	flexsc_register();

	puts("!!!Hello World!!!"); /* prints !!!Hello World!!! */
	return EXIT_SUCCESS;
}
