/*
 * Note: this file originally auto-generated by mib2c using
 *       version : 14170 $ of $ 
 *
 * $Id:$
 */
/** \page MFD helper for wmanIfBsProvisionedSfTable
 *
 * \section intro Introduction
 * Introductory text.
 *
 */
/*
 * standard Net-SNMP includes 
 */
#include <net-snmp/net-snmp-config.h>
#include <net-snmp/net-snmp-includes.h>
#include <net-snmp/agent/net-snmp-agent-includes.h>

/*
 * include our parent header 
 */
#include "wmanIfBsProvisionedSfTable.h"

#include <net-snmp/agent/mib_modules.h>

#include "wmanIfBsProvisionedSfTable_interface.h"

oid             wmanIfBsProvisionedSfTable_oid[] =
    { WMANIFBSPROVISIONEDSFTABLE_OID };
int             wmanIfBsProvisionedSfTable_oid_size =
OID_LENGTH(wmanIfBsProvisionedSfTable_oid);

wmanIfBsProvisionedSfTable_registration
    wmanIfBsProvisionedSfTable_user_context;

void            initialize_table_wmanIfBsProvisionedSfTable(void);
void            shutdown_table_wmanIfBsProvisionedSfTable(void);


/**
 * Initializes the wmanIfBsProvisionedSfTable module
 */
void
init_wmanIfBsProvisionedSfTable(void)
{
    DEBUGMSGTL(("verbose:wmanIfBsProvisionedSfTable:init_wmanIfBsProvisionedSfTable", "called\n"));

    /*
     * TODO:300:o: Perform wmanIfBsProvisionedSfTable one-time module initialization.
     */

    /*
     * here we initialize all the tables we're planning on supporting
     */
    if (should_init("wmanIfBsProvisionedSfTable"))
        initialize_table_wmanIfBsProvisionedSfTable();

}                               /* init_wmanIfBsProvisionedSfTable */

/**
 * Shut-down the wmanIfBsProvisionedSfTable module (agent is exiting)
 */
void
shutdown_wmanIfBsProvisionedSfTable(void)
{
    if (should_init("wmanIfBsProvisionedSfTable"))
        shutdown_table_wmanIfBsProvisionedSfTable();

}

/**
 * Initialize the table wmanIfBsProvisionedSfTable 
 *    (Define its contents and how it's structured)
 */
void
initialize_table_wmanIfBsProvisionedSfTable(void)
{
    wmanIfBsProvisionedSfTable_registration *user_context;
    u_long          flags;

    DEBUGMSGTL(("verbose:wmanIfBsProvisionedSfTable:initialize_table_wmanIfBsProvisionedSfTable", "called\n"));

    /*
     * TODO:301:o: Perform wmanIfBsProvisionedSfTable one-time table initialization.
     */

    /*
     * TODO:302:o: |->Initialize wmanIfBsProvisionedSfTable user context
     * if you'd like to pass in a pointer to some data for this
     * table, allocate or set it up here.
     */
    /*
     * a netsnmp_data_list is a simple way to store void pointers. A simple
     * string token is used to add, find or remove pointers.
     */
    user_context =
        netsnmp_create_data_list("wmanIfBsProvisionedSfTable", NULL, NULL);

    /*
     * No support for any flags yet, but in the future you would
     * set any flags here.
     */
    flags = 0;

    /*
     * call interface initialization code
     */
    _wmanIfBsProvisionedSfTable_initialize_interface(user_context, flags);
}                               /* initialize_table_wmanIfBsProvisionedSfTable */

/**
 * Shutdown the table wmanIfBsProvisionedSfTable 
 */
void
shutdown_table_wmanIfBsProvisionedSfTable(void)
{
    /*
     * call interface shutdown code
     */
    _wmanIfBsProvisionedSfTable_shutdown_interface
        (&wmanIfBsProvisionedSfTable_user_context);
}

/**
 * extra context initialization (eg default values)
 *
 * @param rowreq_ctx    : row request context
 * @param user_init_ctx : void pointer for user (parameter to rowreq_ctx_allocate)
 *
 * @retval MFD_SUCCESS  : no errors
 * @retval MFD_ERROR    : error (context allocate will fail)
 */
int
wmanIfBsProvisionedSfTable_rowreq_ctx_init
    (wmanIfBsProvisionedSfTable_rowreq_ctx * rowreq_ctx,
     void *user_init_ctx)
{
    DEBUGMSGTL(("verbose:wmanIfBsProvisionedSfTable:wmanIfBsProvisionedSfTable_rowreq_ctx_init", "called\n"));

    netsnmp_assert(NULL != rowreq_ctx);

    /*
     * TODO:210:o: |-> Perform extra wmanIfBsProvisionedSfTable rowreq initialization. (eg DEFVALS)
     */

    return MFD_SUCCESS;
}                               /* wmanIfBsProvisionedSfTable_rowreq_ctx_init */

/**
 * extra context cleanup
 *
 */
void
wmanIfBsProvisionedSfTable_rowreq_ctx_cleanup
    (wmanIfBsProvisionedSfTable_rowreq_ctx * rowreq_ctx)
{
    DEBUGMSGTL(("verbose:wmanIfBsProvisionedSfTable:wmanIfBsProvisionedSfTable_rowreq_ctx_cleanup", "called\n"));

    netsnmp_assert(NULL != rowreq_ctx);

    /*
     * TODO:211:o: |-> Perform extra wmanIfBsProvisionedSfTable rowreq cleanup.
     */
}                               /* wmanIfBsProvisionedSfTable_rowreq_ctx_cleanup */

/**
 * pre-request callback
 *
 *
 * @retval MFD_SUCCESS              : success.
 * @retval MFD_ERROR                : other error
 */
int
wmanIfBsProvisionedSfTable_pre_request
    (wmanIfBsProvisionedSfTable_registration * user_context)
{
    DEBUGMSGTL(("verbose:wmanIfBsProvisionedSfTable:wmanIfBsProvisionedSfTable_pre_request", "called\n"));

    /*
     * TODO:510:o: Perform wmanIfBsProvisionedSfTable pre-request actions.
     */

    return MFD_SUCCESS;
}                               /* wmanIfBsProvisionedSfTable_pre_request */

/**
 * post-request callback
 *
 * Note:
 *   New rows have been inserted into the container, and
 *   deleted rows have been removed from the container and
 *   released.
 *
 * @param user_context
 * @param rc : MFD_SUCCESS if all requests succeeded
 *
 * @retval MFD_SUCCESS : success.
 * @retval MFD_ERROR   : other error (ignored)
 */
int
wmanIfBsProvisionedSfTable_post_request
    (wmanIfBsProvisionedSfTable_registration * user_context, int rc)
{
    DEBUGMSGTL(("verbose:wmanIfBsProvisionedSfTable:wmanIfBsProvisionedSfTable_post_request", "called\n"));

    /*
     * TODO:511:o: Perform wmanIfBsProvisionedSfTable post-request actions.
     */

    /*
     * check to set if any rows were changed.
     */
    if (wmanIfBsProvisionedSfTable_dirty_get()) {
        /*
         * check if request was successful. If so, this would be
         * a good place to save data to its persistent store.
         */
        if (MFD_SUCCESS == rc) {
            /*
             * save changed rows, if you haven't already
             */
        }

        wmanIfBsProvisionedSfTable_dirty_set(0);        /* clear table dirty flag */
    }

    return MFD_SUCCESS;
}                               /* wmanIfBsProvisionedSfTable_post_request */


/** @{ */