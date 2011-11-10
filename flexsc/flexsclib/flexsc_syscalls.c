/*
 * flexsc_syscalls.c
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#include "iflexsc.h"
#include "flexsc_syscalls.h"
#include <stdlib.h>
#include <stdio.h>
#include <semaphore.h>  /* Semaphore */

extern pthread_mutex_t mutex;

struct syscall_entry* flexsc_getpid()
{
	struct syscall_entry* entry = free_syscall_entry();
	if (entry != NULL)
	{
		entry->syscall = 39;
		entry->num_args = 0;
		entry->status = SUBMITTED;
		//		printf("Submitted Entry: %d\n", entry->index);
		return entry;
	}
	else
	{
		printf("No Free Entry");
		return NULL;
	}
}

struct syscall_entry* flexsc_open(const char* filename, int mode, int rights)
{
	struct syscall_entry* entry = free_syscall_entry();
	//	printf("Searching Entry!");
	if (entry != NULL)
	{
		//		printf("Selected Entry: %d\n", entry->index);
		entry->syscall = 2;
		entry->num_args = 3;
		entry->args[0] = (long long) filename;
		entry->args[1] = mode;
		entry->args[2] = rights;
		entry->status = SUBMITTED;
		//		printf("Submitted Entry: %d\n", entry->index);
		return entry;
	}
	else
	{
		//		printf("No Free Entry");
		return NULL;
	}
}

struct syscall_entry* flexsc_close(long long fileid)
{
	struct syscall_entry* entry = free_syscall_entry();
	if (entry != NULL)
	{
		entry->syscall = 3;
		entry->num_args = 1;
		entry->args[0] = fileid;
		entry->status = SUBMITTED;
		//		printf("Submitted Entry: %d\n", entry->index);
		return entry;
	}
	else
	{
		//		printf("No Free Entry");
		return NULL;
	}
}
struct syscall_entry* flexsc_write(long long fileid, unsigned long long offset, unsigned char* data, unsigned int size)
{
	struct syscall_entry* entry = free_syscall_entry();
	if (entry != NULL)
	{
		entry->syscall = 1;
		entry->num_args = 4;
		entry->args[0] = fileid;
		entry->args[1] = offset;
		entry->args[2] = (long long) data;
		entry->args[3] = size;
		entry->status = SUBMITTED;
		//		printf("Submitted Entry: %d\n", entry->index);
		return entry;
	}
	else
	{
		//		printf("No Free Entry");
		return NULL;
	}
}
//////////////////////////////////////////
struct syscall_entry* flexsc_open_i(const char* filename, int mode, int rights, int i)
{
	printf("Searching Entry!%d,\n", i);
	struct syscall_entry* entry = free_syscall_entry_i(i);
	printf("Found Entry!%ld,\n", entry);

	if (entry != NULL)
	{
		sem_wait(&mutex);
		printf("Selected Entry: %d\n", entry->index);
		entry->syscall = 2;
		entry->num_args = 3;
		entry->args[0] = (long long) filename;
		entry->args[1] = mode;
		entry->args[2] = rights;
		entry->status = SUBMITTED;
		printf("Submitted Entry: %d\n", entry->index);
		sem_post(&mutex);
		return entry;
	}
	else
	{
		//		printf("No Free Entry");
		return NULL;
	}

}

struct syscall_entry* flexsc_close_i(long long fileid, int i)
{
	struct syscall_entry* entry = free_syscall_entry_i(i);
	if (entry != NULL)
	{
		entry->syscall = 3;
		entry->num_args = 1;
		entry->args[0] = fileid;
		entry->status = SUBMITTED;
		//		printf("Submitted Entry: %d\n", entry->index);
		return entry;
	}
	else
	{
		//		printf("No Free Entry");
		return NULL;
	}
}
struct syscall_entry* flexsc_write_i(long long fileid, unsigned long long offset, unsigned char* data, unsigned int size, int i)
{

	struct syscall_entry* entry = free_syscall_entry_i(i);
	if (entry != NULL)
	{
		entry->syscall = 1;
		entry->num_args = 4;
		entry->args[0] = fileid;
		entry->args[1] = offset;
		entry->args[2] = (long long) data;
		entry->args[3] = size;
		entry->status = SUBMITTED;
		//		printf("Submitted Entry: %d\n", entry->index);
		return entry;
	}
	else
	{
		//		printf("No Free Entry");
		return NULL;
	}
	sem_post(&mutex);
}
