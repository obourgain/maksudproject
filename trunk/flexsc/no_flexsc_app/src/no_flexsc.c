/*
 ============================================================================
 Name        : no_flexsc.c
 Author      : Maksud
 Version     :
 Copyright   : Your copyright notice
 Description : Hello World in C, Ansi-style
 ============================================================================
 */

#include <stdio.h>
#include <stdlib.h>
#include <fcntl.h>
#include <sys/time.h>
#include<time.h>
#include <fcntl.h>
#include <pthread.h>

typedef struct str_thdata
{
	int i;
} thdata;

long long timeval_diff(struct timeval *difference, struct timeval *end_time, struct timeval *start_time)
{
	struct timeval temp_diff;

	if (difference == NULL)
	{
		difference = &temp_diff;
	}

	difference->tv_sec = end_time->tv_sec - start_time->tv_sec;
	difference->tv_usec = end_time->tv_usec - start_time->tv_usec;

	/* Using while instead of if below makes the code slightly more robust. */

	while (difference->tv_usec < 0)
	{
		difference->tv_usec += 1000000;
		difference->tv_sec -= 1;
	}

	return 1000000LL * difference->tv_sec + difference->tv_usec;

} /* timeval_diff() */

void print_message_function(void *ptr)
{
	thdata *data;
	data = (thdata *) ptr; /* type cast to a pointer to thdata */

	char buf[4] =
	{ 'A', 'B', 'C', 'D' };

	char filename[64] =
	{ 0 };

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

	sprintf(filename, "/home/maksud/file%d.txt", i);
	fd = open(filename, i1, i2);
//	write(fd, buf, 4);
//	close(fd);

	pthread_exit(0);
}

#define MAX_T 64

pthread_t thread[MAX_T]; /* thread variables */
thdata data[MAX_T]; /* structs to be passed to threads */
int main(void)
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
	for (i = 0; i < MAX_T; i++)
	{
		data[i].i = i;
		pthread_create(&thread[i], NULL, (void *) &print_message_function, (void *) &data[i]);
	}

	for (i = 0; i < MAX_T; i++)
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

	return 0;
}

int main2(void)
{
	clock_t start_c, end_c;

	char buf[4] =
	{ 'A', 'B', 'C', 'D' };

	char filename[64] =
	{ 0 };

	long long fd[64];

	int i;
	int i1 = O_WRONLY | O_CREAT, i2 = 0644;

	struct timeval start, end, interval;
	if (gettimeofday(&start, NULL))
	{
		perror("error gettimeofday() #1");
		exit(1);
	}

	start_c = clock();
	////
	//Open System Call
	for (i = 0; i < 64; i++)
	{
		sprintf(filename, "/home/maksud/file%d.txt", i);
		fd[i] = open(filename, i1, i2);
		write(fd[i], buf, 4);
		close(fd[i]);
	}
	//
	//	//Write System Call
	//	for (i = 0; i < 64; i++)
	//	{
	//	}
	//
	//	//Write System Call
	//	for (i = 0; i < 64; i++)
	//	{
	//
	//	}
	end_c = clock();

	if (gettimeofday(&end, NULL))
	{
		perror("error gettimeofday() #2");
		exit(1);
	}

	long long elapsed = timeval_diff(&interval, &end, &start);

	printf("\nElapsed time is %lld microseconds\n", elapsed); // output format: # microseconds
	//	printf("\n\nClock: %lf seconds\n", ((double) end_c - start_c));

	int i22 = 0;
	printf("\nDone System Calls.\n");
	scanf("%d", &i22);

	return EXIT_SUCCESS;
}
