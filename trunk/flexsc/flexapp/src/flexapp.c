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

	//	int fd = open("/dev/zero", O_RDWR);
	//	struct syscall_entry* p = mmap(0, sizeof(struct syscall_entry), PROT_READ
	//			| PROT_WRITE, MAP_PRIVATE | MAP_ANONYMOUS, -1, 0);
	//	close(fd);
	//	p->index = 10;
	//	printf("%d,%d", p,p->index);


	//	return 0;

	//	long long test = 123;
	//	struct syscall_page* page2 = test;
	//	long long again = page2;
	//	printf("%d, %d, %d\n", test, page2, again);

	//	puts(gnu_get_libc_version());

	//	long long b = 102;
	//	int* ip = (int*) b;
	//	printf("a:%ld, ip:%ld\n", b, ip);

	//	FILE* pFile;
	//	char filename1[1024] = "/home/maksud/testfile1";
	//
	//	pFile = fopen(filename1, "w");
	//	printf("%d\n", pFile);
	//	if (pFile != NULL) {
	//		fputs("fopen example", pFile);
	//		fclose(pFile);
	//	}

	//	int p1 = 33345;
	//	int p2 = 438;

	//	char filename[1024] = "/home/maksud/testfile";
	//	FILE* fp = (FILE*) syscall(2, filename, 1, 0, p1);
	//	printf("%d\n", fp);
	//
	//	if (fp != NULL) {
	//		//printf("Open Succeessful.%d\n", fp);
	//		//fputs("syscall example", fp);
	//		//fclose(fp);
	//	}

	//	printf("Filename: %s\n", filename);

	printf("Call Tests\n");

	//	flexsc_wait();

	struct syscall_page* page = malloc(sizeof(struct syscall_page));
	int i;
	for (i = 0; i < 64; i++)
	{
		page->entries[i].index = i;
		page->entries[i].status = FREE;
		page->entries[i].args[5] = 200 + i;
		printf("Entry[%d]=Address: %d\n", &page->entries[i]);
	}

	//	flexsc_prereg(page);
	flexsc_register2(page);

	const char fname[] = "/home/maksud/testfile4";
	int i1 = 33345, i2 = 438;
	flexsc_open(fname, i1, i2);

	const char fname2[] = "/home/maksud/testfile";
	flexsc_open(fname2, i1, i2);

	flexsc_wait();

	/// Call System Calls Now.
	//getpid_flex();

	//	flexsc_open(fname, i1, i2);

	//	printf("FF Test?\n");
	//	page->entries[0].syscall = 1;
	//	printf("FF Test SigFault?\n");

	//	printf("Test?\n");
	//	page->entries[0].syscall = 1;
	//	printf("Test SigFault?\n");


	int i22 = 0;
	scanf("%d", &i22);
	struct test a;

	printf("Syscall: Args[0][4]=%d\n", page->entries[0].args[4]);
	printf("Syscall: Args[1][4]=%d\n", page->entries[0].args[4]);

	puts("!!!Hello World!!!"); /* prints !!!Hello World!!! */
	return EXIT_SUCCESS;
}
