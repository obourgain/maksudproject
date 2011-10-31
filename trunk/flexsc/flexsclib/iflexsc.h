/*
 * iflexsc.h
 *
 *  Created on: Oct 24, 2011
 *      Author: maksud
 */

#ifndef IFLEXSC_H_
#define IFLEXSC_H_
#include <flexsc/flexsc.h>

#define sys_flexsc_register 303
#define sys_flexsc_wait 304
#define sys_flexsc_register2 305

//Explicit System Calls
struct syscall_page* flexsc_register();

//FlexSC Helpers
//void flexsc_prereg(struct syscall_page* page);
struct syscall_page* flexsc_register2();
struct syscall_entry* free_syscall_entry();
void flexsc_wait();

#endif /* IFLEXSC_H_ */
