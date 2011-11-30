#include <stdio.h>

#define __USE_GNU
#include <dlfcn.h>
//#include <stdlib.h>
//#include <stdarg.h>
//#include <sys/syscall.h>
//#include <unistd.h>
//#include <sys/types.h>
//#include <sys/stat.h>
//#include <dirent.h>
#include <sys/syscall.h>
#include <unistd.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <dlfcn.h>
#include <dirent.h>
#include <stdarg.h>
#include <fcntl.h>

static void* (*real_malloc)( size_t) = NULL;
//static int (*orig_printf)(const char *format, ...) = NULL;
static void init(void) __attribute__ ((constructor));
int (*real_open)(__const char *name, int flags, ...);
struct dirent *(*real_readdir)(DIR *dir);
int (*real_close)(int fd);

static ssize_t (*real_read)(int fd, void *buf, size_t len);
static ssize_t (*real_write)(int fd, const void *buf, size_t len);
static ssize_t (*real_pread)(int, void *, size_t, off_t);
static ssize_t (*real_pwrite)(int, const void *, size_t, off_t);

static void __mtrace_init(void)
{

	real_malloc = dlsym(RTLD_NEXT, "malloc");
	if (NULL == real_malloc)
	{
		fprintf(stderr, "Error in `dlsym`: %s\n", dlerror());
		return;
	}
}

void *malloc(size_t size)
{

	if (real_malloc == NULL)
		__mtrace_init();

	void *p = NULL;
	fprintf(stderr, "malloc(%d) = ", size);
	p = real_malloc(size);
	fprintf(stderr, "%p\n", p);
	//
	printf("Maksud\n");
	return p;
}

static void init(void)
{
	printf("init()\n");

	real_open = dlsym(RTLD_NEXT, "open");
	real_readdir = dlsym(RTLD_NEXT, "readdir");
	real_close = dlsym(RTLD_NEXT, "close");
	real_read = dlsym(RTLD_NEXT, "read");
	real_write = dlsym(RTLD_NEXT, "write");
	real_pread = dlsym(RTLD_NEXT, "pread");
	real_pwrite = dlsym(RTLD_NEXT, "pwrite");
}
//int open(const char *pathname, int flags, mode_t mode)
//{
//        printf("open called \n");
//        return(real_open(pathname,flags,mode));
//}


int open(const char *path, int flags, ...)
{
	//	int (*real_open)(const char*, int, ...);

	printf("entering open(): %s\n", path);
	real_open = dlsym(RTLD_NEXT, "open");

	if (dlerror())
		return -1;

	if (flags & O_CREAT)
	{
		va_list arg_list;
		mode_t mode;

		va_start(arg_list, flags);
		mode = va_arg(arg_list, mode_t);
		va_end(arg_list);

		return real_open(path, flags, mode);
	}
	else
	{
		return real_open(path, flags);
	}
}

int close(int fd)
{
	printf("close called \n");
	return (real_close(fd));
}

ssize_t read(int fd, void *buf, size_t len)
{
	printf("read called \n");
	return (*real_read)(fd, buf, len);
}

ssize_t write(int fd, const void *buf, size_t len)
{
	printf("write called \n");
	return (*real_write)(fd, buf, len);
}

ssize_t pread(int fd, void *buf, size_t len, off_t off)
{
	printf("pread called \n");
	return (*real_pread)(fd, buf, len, off);
}

ssize_t pwrite(int fd, const void *buf, size_t len, off_t off)
{
	printf("pwrite called \n");
	return (*real_pwrite)(fd, buf, len, off);
}

struct dirent *readdir(DIR *dir)
{
	printf("readdir called");
	return (real_readdir(dir));
}
