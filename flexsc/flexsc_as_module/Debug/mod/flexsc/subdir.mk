################################################################################
# Automatically-generated file. Do not edit!
################################################################################

# Add inputs and outputs from these tool invocations to the build variables 
O_SRCS += \
../mod/flexsc/mod_flexsc.o \
../mod/flexsc/mod_flexsc_helper.o \
../mod/flexsc/mod_flexsc_syscalls.o 

C_SRCS += \
../mod/flexsc/mod_flexsc.c \
../mod/flexsc/mod_flexsc_helper.c \
../mod/flexsc/mod_flexsc_syscalls.c 

OBJS += \
./mod/flexsc/mod_flexsc.o \
./mod/flexsc/mod_flexsc_helper.o \
./mod/flexsc/mod_flexsc_syscalls.o 

C_DEPS += \
./mod/flexsc/mod_flexsc.d \
./mod/flexsc/mod_flexsc_helper.d \
./mod/flexsc/mod_flexsc_syscalls.d 


# Each subdirectory must supply rules for building sources it contributes
mod/flexsc/%.o: ../mod/flexsc/%.c
	@echo 'Building file: $<'
	@echo 'Invoking: GCC C Compiler'
	gcc -O0 -g3 -Wall -c -fmessage-length=0 -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)" -o"$@" "$<"
	@echo 'Finished building: $<'
	@echo ' '


