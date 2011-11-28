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
#include <string.h>
//
extern char* buffers;
//
typedef struct str_thdata
{
	int i;
} thdata;
//

int jj = 100000;
pthread_t thread[NUM_THREADS]; /* thread variables */
thdata data[NUM_THREADS]; /* structs to be passed to threads */

long wait_and_return2(struct syscall_entry* entry)
{
	//Can not proceed while status is not DONE
	while (entry->status != DONE)
	{
		//		printf("WAITING... for entry 1 return_code=%d, status=%d\n", entry1->return_code);
		//Nothing to Do.
	}
	long fd1 = (unsigned long) entry->return_code; //flexsc_open returns file descriptor.
	entry->status = FREE;
	return fd1;
}

//
void print_message_function(void *ptr)
{
	int i, j, offset = 0;
	thdata *data;
	long fd = 0, rv;
	struct syscall_entry* entry;
	//
	int i1 = O_RDWR | O_CREAT | O_APPEND, i2 = 0777;
	unsigned char* buffer;
	//
	data = (thdata *) ptr; /* type cast to a pointer to thdata */
	i = data->i;
	buffer = buffers + 384 * i;
	//
	for (j = 0; j < 1000; j++)
	{
		//
		sprintf(buffer, "/home/maksud/FILE-%d.txt", i);
		//		printf("%s\n", buffer);
		//
		{
			//Open
			entry = flexsc_open_i(buffer, i1, i2, i);
			fd = wait_and_return2(entry);
		}
		//
		{
			//Read
			//			entry = flexsc_read_i(fd, 0 + 4 * j, buffer, 384, i);
			//			rv = wait_and_return2(entry);
			//			printf("ReturnValue-Read: %d:%d\n", i, rv);
			//			printf("READ:%s\n", buffer);
		}
		//
		{
			//Write
			sprintf(buffer, "This is a test. Hello from %d.", i);
			entry = flexsc_write_i(fd, 0 + 4 * j, buffer, strlen(buffer), i);
			rv = wait_and_return2(entry);
			//			printf("ReturnValue-Write: %d:%d\n", i, rv);
		}
		//
		{
			//Close
			entry = flexsc_close_i(fd, i);
			wait_and_return2(entry);
		}
	}

	//	printf("Thread %d returned\n", i);
	pthread_exit(0); /* exit */
} /* print_message_function ( void *ptr ) */

void flexapp_threaded(void)
{
	long long elapsed;
	struct timeval start, end, interval;
	int i, j;

	//
	if (gettimeofday(&start, NULL))
	{
		perror("error gettimeofday() #1");
		exit(1);
	}
	for (i = 0; i < NUM_THREADS; i++)
	{
		data[i].i = i;
		pthread_create(&thread[i], NULL, (void *) &print_message_function, (void *) &data[i]);
	}

	for (i = 0; i < NUM_THREADS; i++)
	{
		pthread_join(thread[i], NULL);
	}

	//	for (i = 0; i < 64; i++)
	//	{
	//		for (j = 0; j < 384; j++)
	//			printf("%d ", buffers[i * 384 + j]);
	//		printf("\n");
	//	}

	if (gettimeofday(&end, NULL))
	{
		perror("error gettimeofday() #2");
		exit(1);
	}

	elapsed = timeval_diff(&interval, &end, &start);
	printf("\nTime for syscall tasks and synchronization is %lld microseconds\n\n", elapsed); // output format: # microseconds


	printf("Last Action!\n");

}
