#include <linux/module.h>
#include <linux/vermagic.h>
#include <linux/compiler.h>

MODULE_INFO(vermagic, VERMAGIC_STRING);

struct module __this_module
__attribute__((section(".gnu.linkonce.this_module"))) = {
 .name = KBUILD_MODNAME,
 .init = init_module,
#ifdef CONFIG_MODULE_UNLOAD
 .exit = cleanup_module,
#endif
 .arch = MODULE_ARCH_INIT,
};

static const struct modversion_info ____versions[]
__used
__attribute__((section("__versions"))) = {
	{ 0x53eda548, "module_layout" },
	{ 0xa4bf0727, "cdev_del" },
	{ 0xba66affe, "kmalloc_caches" },
	{ 0x417e5eb2, "cdev_init" },
	{ 0xf9a482f9, "msleep" },
	{ 0xd6147ae2, "up_read" },
	{ 0x4c4fef19, "kernel_stack" },
	{ 0xa37d4e55, "filp_close" },
	{ 0x7485e15e, "unregister_chrdev_region" },
	{ 0x3c2c5af5, "sprintf" },
	{ 0x592b9cd7, "down_read" },
	{ 0xf526695f, "current_task" },
	{ 0x27e1a049, "printk" },
	{ 0x2c5d459, "kthread_stop" },
	{ 0x593166cc, "get_task_mm" },
	{ 0xb4390f9a, "mcount" },
	{ 0xef14c2d6, "cdev_add" },
	{ 0xf0fdf6cb, "__stack_chk_fail" },
	{ 0xa14249a3, "get_user_pages" },
	{ 0x4b5814ef, "kmalloc_order_trace" },
	{ 0x5c693f09, "wake_up_process" },
	{ 0x33e4cbc6, "kmem_cache_alloc_trace" },
	{ 0xe52947e7, "__phys_addr" },
	{ 0xd2965f6f, "kthread_should_stop" },
	{ 0x37a0cba, "kfree" },
	{ 0x149ae190, "kthread_create" },
	{ 0x55d067, "remap_pfn_range" },
	{ 0x29537c9e, "alloc_chrdev_region" },
	{ 0x31185e82, "vfs_write" },
	{ 0x1f37aa1e, "filp_open" },
};

static const char __module_depends[]
__used
__attribute__((section(".modinfo"))) =
"depends=";


MODULE_INFO(srcversion, "3D9E8F2E9389164E7EAEB9E");
