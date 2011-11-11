/*
 ============================================================================
 Name        : flexapp.c
 Author      : Maksud
 Version     :
 Copyright   : Your copyright notice
 Description : Hello World in C, Ansi-style
 ============================================================================
 */

#include "flexapp_single.h"
#include "flexapp_threaded.h"
#include <stdlib.h>
#include <stdio.h>
#include "iflexsc.h"
#include "flexsc_syscalls.h"

char a[20];

int main(void)
{
//	struct syscall_page* page = flexsc_register2();

	//	flexapp_single();

//	flexapp_threaded();

	a[0] = 1;
	a[1] = 2;
//
	long ret = syscall(307, a);
	printf("flexsc_wait returned: %ld\n", ret);
//
	sleep(1);
	a[0]=5;
	a[1]=10;
//
	sleep(10);



	//	elapsed = timeval_diff(&interval, &end, &start);
	//	printf("\nTime for Threading Approach is %lld microseconds\n", elapsed); // output format: # microseconds

	return EXIT_SUCCESS;
}

