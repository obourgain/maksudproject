CC=gcc
NETSNMPCONFIG=net-snmp-config

# uncomment this if you have GNU make
NETSNMPCFLAGS := $(shell $(NETSNMPCONFIG) --base-cflags)
NETSNMPLIBS := $(shell $(NETSNMPCONFIG) --agent-libs)

LIBS=$(NETSNMPLIBS)


STRICT_FLAGS = -Wall -Wstrict-prototypes
CFLAGS=-I. $(NETSNMPCFLAGS) $(STRICT_FLAGS)

SRCS = 	mibtestTable_src/mibtestTable_data_get.c \
       	mibtestTable_src/mibtestTable_data_set.c \
       	mibtestTable_src/mibtestTable_data_access.c \
		mibtestTable_src/mibtestTable.c \
		mibtestTable_src/mibtestTable_interface.c \
		wmanTestDataHolder_src/wmanTestDataHolder.c \
		wmanDevSsConfigFileEncodingTable_src/wmanDevSsConfigFileEncodingTable_data_get.c \
		wmanDevSsConfigFileEncodingTable_src/wmanDevSsConfigFileEncodingTable_data_set.c \
		wmanDevSsConfigFileEncodingTable_src/wmanDevSsConfigFileEncodingTable_data_access.c \
		wmanDevSsConfigFileEncodingTable_src/wmanDevSsConfigFileEncodingTable.c \
		wmanDevSsConfigFileEncodingTable_src/wmanDevSsConfigFileEncodingTable_interface.c \
		util/Ipc.c \
		util/Utilities.c \
		wimax_snmp_subagent.c

OBJS_DIR = .

OBJS = $(foreach file,$(SRCS),$(OBJS_DIR)/$(file:.c=.o))


TARGETS=wimax_snmp_agent

.SUFFIXES:
.SUFFIXES: .c .o .deps


all: $(TARGETS)

$(TARGETS): $(OBJS) 
	@echo
	$(CC) -o $(TARGETS) $(OBJS) $(LIBS)

$(OBJS):$(OBJS_DIR)/%.o:%.c
	@echo
	$(CC) $(CFLAGS) -c $< -o $@

clean:
	rm -f $(OBJS) $(TARGETS)
