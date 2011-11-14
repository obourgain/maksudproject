/*
 * flexapp_threaded.c
 *
 *  Created on: Nov 10, 2011
 *      Author: maksud
 */

#include "flexapp_threaded.h"
#include <stdio.h>
#include <stdlib.h>
#include "iflexsc.h"
#include "flexsc_syscalls.h"
#include <gnu/libc-version.h>
#include <linux/mman.h>
#include <fcntl.h>
#include <pthread.h>
#include <time.h>
//
typedef struct str_thdata
{
	int i;
} thdata;
//

int jj = 100000;

long long wait_and_return2(struct syscall_entry* entry)
{
	//Can not proceed while status is not DONE
	while (entry->status != DONE)
	{
		//		printf("WAITING... for entry 1 return_code=%d, status=%d\n", entry1->return_code);
		//Nothing to Do.
	}
	long long fd1 = entry->return_code; //flexsc_open returns file descriptor.
	entry->status = FREE;
	return fd1;
}

//
void print_message_function(void *ptr)
{
	thdata *data;
	data = (thdata *) ptr; /* type cast to a pointer to thdata */

	int i = data->i;

	int a = 'A';
	a = a << 8 | 'B';
	a = a << 8 | 'C';
	a = a << 8 | 'D';
	a = a << 8 | 'B';
	a = a << 8 | 'C';
	a = a << 8 | 'D';
	a = a << 8 | 'B';
	a = a << 8 | 'C';
	a = a << 8 | 'D';

	long long fd = 0;
	struct syscall_entry* entry;

	int i1 = O_WRONLY | O_CREAT, i2 = 0644;

	//
	entry = flexsc_open_i(i + 100, i1, i2, i);
	fd = wait_and_return2(entry);
	//
	flexsc_write_i(fd, 0, a, 4, i);
	wait_and_return2(entry);
	//
	flexsc_close_i(fd, i);
	wait_and_return2(entry);

	pthread_exit(0); /* exit */
} /* print_message_function ( void *ptr ) */

pthread_t thread[64]; /* thread variables */
thdata data[64]; /* structs to be passed to threads */

void flexapp_threaded()
{
	long long elapsed;
	struct timeval start, end, interval;
	int i;

	//
	if (gettimeofday(&start, NULL))
	{
		perror("error gettimeofday() #1");
		exit(1);
	}
	for (i = 0; i < 64; i++)
	{
		data[i].i = i;
		pthread_create(&thread[i], NULL, (void *) &print_message_function, (void *) &data[i]);
	}

	for (i = 0; i < 64; i++)
	{
		pthread_join(thread[i], NULL);
	}

	if (gettimeofday(&end, NULL))
	{
		perror("error gettimeofday() #2");
		exit(1);
	}

	elapsed = timeval_diff(&interval, &end, &start);
	printf("\nTime for syscall tasks and synchronization is %lld microseconds\n\n", elapsed); // output format: # microseconds


	printf("Last Action!\n");

}
