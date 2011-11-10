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

void do_something(int i)
{
	printf("Thread21 %d \n", i);
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

	jj--;

//	sleep(1);

	//	//
		entry = flexsc_open_i(i + 100, i1, i2, i);
		if (entry == NULL)
			printf("NULL%d\n", i);
//		fd = wait_and_return(entry);
	//	//
//		flexsc_write_i(fd, 0, a, 4, i);
//		wait_and_return(entry);
	//	//
//		flexsc_close_i(fd, i);
//		wait_and_return(entry);
}
//
void print_message_function(void *ptr)
{
	printf("Testing Testing!\n");
//	sleep(1);
	thdata *data;
	data = (thdata *) ptr; /* type cast to a pointer to thdata */
	printf("%d\n", data->i);
	do_something(data->i);

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

	printf("Last Action!");

	if (gettimeofday(&end, NULL))
	{
		perror("error gettimeofday() #2");
		exit(1);
	}

}
