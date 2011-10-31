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
#include <stdio.h>
#include <unistd.h>
#include <sys/mman.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <fcntl.h>
#include <stdlib.h>

#define NPAGES 16

struct syscall_page* basepage;

void printstack()
{
	int i = 0;
	printf("\n");
	for (i = 0; i < 64; i++)
	{
		printf("%d ", basepage->entries[i].index);
		printf("%d ", basepage->entries[i].syscall);
		printf("%d ", basepage->entries[i].num_args);
		printf("%d ", basepage->entries[i].status);
		printf("%d ", basepage->entries[i].return_code);
		printf("%d ", basepage->entries[i].args[0]);
		printf("%d ", basepage->entries[i].args[1]);
		printf("%d ", basepage->entries[i].args[2]);
		printf("%d ", basepage->entries[i].args[3]);
		printf("%d ", basepage->entries[i].args[4]);
		printf("%d \n", basepage->entries[i].args[5]);
	}
	printf("\n");
}

struct syscall_page* flexsc_register()
{
	//	int fd;
	//	void* kadr;
	//
	syscall(sys_flexsc_register);
	//
	//	int len = NPAGES * getpagesize();
	//
	//	if ((fd = open("node", O_RDWR | O_SYNC)) < 0)
	//	{
	//		perror("open");
	//		exit(-1);
	//	}
	//	kadr = mmap(0, len, PROT_READ | PROT_WRITE, MAP_SHARED | MAP_LOCKED, fd, len);
	//	if (kadr == MAP_FAILED)
	//	{
	//		perror("mmap");
	//		exit(-1);
	//	}
	//	close(fd);
	//
	//	basepage = kadr;
	//
	//	printf("Basepage: %d\n", basepage);

	return NULL;
	//return (struct syscall_page*) syscall(sys_flexsc_register);
}

//void flexsc_prereg(struct syscall_page* page)
//{
//	//	struct syscall_page* page;
//	basepage = page;
//}

struct syscall_page* flexsc_register2()
{
	//	struct syscall_page* page = malloc(sizeof(struct syscall_page));
	//	if (!page)
	//	{
	//		printf("Problem allocating memory.");
	//		return NULL;
	//	}
	int fd;
	unsigned char* kadr;

	syscall(sys_flexsc_register2, NULL);

	int len = NPAGES * getpagesize();
	//
	//	printf("Here.");
	//
	if ((fd = open("node2", O_RDWR | O_SYNC)) < 0)
	{
		perror("open");
		exit(-1);
	}
	kadr = mmap(0, len, PROT_READ | PROT_WRITE, MAP_SHARED | MAP_LOCKED, fd, len);
	if (kadr == MAP_FAILED)
	{
		perror("mmap");
		exit(-1);
	}
	close(fd);

	basepage = kadr;

	printf("Basepage: %d\n", basepage);

	int i = 0;
	for (i = 0; i < 64 * 72; i++)
	{
		printf("%d ", kadr[i]);
	}
	printstack();
	return (struct syscall_page*) kadr;
}

void flexsc_wait()
{
	long pid = (long) getpid();
	printf("getpid returned: %ld\n", pid);
	//	pid = syscall(304);
	//	printf("syscall(304) returned: %d\n", pid);
	//	pid = syscall(39);
	//	printf("syscall(39) returned: %d\n", pid);
	long ret = syscall(sys_flexsc_wait);
	printf("flexsc_wait returned: %ld\n", ret);
}

struct syscall_page* allocate_register()
{
	return malloc(sizeof(struct syscall_page));
}

struct syscall_entry* free_syscall_entry()
{
	int i = 0;
	for (i = 0; i < 64; i++)
	{
		if (basepage->entries[i].status == FREE)
		{
			return &basepage->entries[i];
		}
	}
	return NULL; // Sorry, No Free Entry.
}
