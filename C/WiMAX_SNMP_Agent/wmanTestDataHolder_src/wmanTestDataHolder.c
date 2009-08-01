/*
 * Note: this file originally auto-generated by mib2c using
 *        : mib2c.scalar.conf,v 1.9 2005/01/07 09:37:18 dts12 Exp $
 */

#include <net-snmp/net-snmp-config.h>
#include <net-snmp/net-snmp-includes.h>
#include <net-snmp/agent/net-snmp-agent-includes.h>
#include "wmanTestDataHolder.h"

#include "Ipc.h"

/** Initializes the wmanTestDataHolder module */
int wmanTestDataHolder_val;
void
init_wmanTestDataHolder(void)
{

	struct struct_message dummyMsg;
	dummyMsg.vL_messageType = 555;
	strcpy(dummyMsg.aS8_message, "DUMMY MESSAGE");

	printf("DUMMY MESSAGE SENT\n");

	//int retVal = fS32_enqueue(pvSt_msgQIdForSNMP->vS32_msgQIDRW, dummyMsg.vL_messageType, dummyMsg.aS8_message, sizeof(dummyMsg.aS8_message));


	wmanTestDataHolder_val = 1;
    static oid      wmanTestDataHolder_oid[] = { 1, 0, 8802, 16, 3, 1 };

    DEBUGMSGTL(("wmanTestDataHolder", "Initializing\n"));

    netsnmp_register_scalar(netsnmp_create_handler_registration
                            ("wmanTestDataHolder",
                             handle_wmanTestDataHolder,
                             wmanTestDataHolder_oid,
                             OID_LENGTH(wmanTestDataHolder_oid),
                             HANDLER_CAN_RWRITE));
}

int
handle_wmanTestDataHolder(netsnmp_mib_handler *handler,
                          netsnmp_handler_registration *reginfo,
                          netsnmp_agent_request_info *reqinfo,
                          netsnmp_request_info *requests)
{
    int             ret;
    static char* tmp_ptr;
    /*
     * We are never called for a GETNEXT if it's registered as a
     * "instance", as it's "magically" handled for us.
     */

    /*
     * a instance handler also only hands us one request at a time, so
     * we don't need to loop over a list of requests; we'll only get one.
     */

    printf("handle_wmanTestDataHolder Called\n");

	wmanTestDataHolder_val++;
    switch (reqinfo->mode) {

    case MODE_GET:

    	printf("handle_wmanTestDataHolder MODE_GET...\n");
        snmp_set_var_typed_value(requests->requestvb, ASN_INTEGER,
                                 (u_char *)(&wmanTestDataHolder_val)
                                 /* XXX: a pointer to the scalar's data */
                                 ,sizeof(wmanTestDataHolder_val)
                                 /*
                                  * XXX: the length of the data in bytes
                                  */ );
        break;

        /*
         * SET REQUEST
         *
         * multiple states in the transaction.  See:
         * http://www.net-snmp.org/tutorial-5/toolkit/mib_module/set-actions.jpg
         */
    case MODE_SET_RESERVE1:
        /*
         * or you could use netsnmp_check_vb_type_and_size instead
         */
    	printf("handle_wmanTestDataHolder MODE_SET_RESERVE1...\n");
    	tmp_ptr=NULL;
        ret = netsnmp_check_vb_type(requests->requestvb, ASN_INTEGER);
        if (ret != SNMP_ERR_NOERROR) {
            netsnmp_set_request_error(reqinfo, requests, ret);
        }
        break;

    case MODE_SET_RESERVE2:
        /*
         * XXX malloc "undo" storage buffer
         */
    	printf("handle_wmanTestDataHolder MODE_SET_RESERVE2...\n");
    	tmp_ptr = (char*)malloc(requests->requestvb->val_len);
    	printf("MOD_SET_RESERVE2 [%d]\n", requests->requestvb->val_len);
    	if(tmp_ptr==NULL)
    	{
    		netsnmp_set_request_error(reqinfo, requests, SNMP_ERR_RESOURCEUNAVAILABLE);
    		return SNMP_ERR_RESOURCEUNAVAILABLE;
    	}

        break;

    case MODE_SET_FREE:
        /*
         * XXX: free resources allocated in RESERVE1 and/or
         * RESERVE2.  Something failed somewhere, and the states
         * below won't be called.
         */
    	printf("handle_wmanTestDataHolder MODE_SET_FREE...\n");
    	if(tmp_ptr)
    		free(tmp_ptr);
        break;

    case MODE_SET_ACTION:
        /*
         * XXX: perform the value change here
         */
    	printf("handle_wmanTestDataHolder MODE_SET_ACTION...\n");
    	if(tmp_ptr==NULL)
    	{
    		netsnmp_set_request_error(reqinfo, requests, SNMP_ERR_RESOURCEUNAVAILABLE);
    		return SNMP_ERR_RESOURCEUNAVAILABLE;
    	}
    	printf("MOD_SET_ACTION\n");
    	*(long *)tmp_ptr = *requests->requestvb->val.integer;
        break;

    case MODE_SET_COMMIT:
        /*
         * XXX: delete temporary storage
         */
    	printf("handle_wmanTestDataHolder MODE_SET_COMMIT...\n");
    	wmanTestDataHolder_val = *(long *)tmp_ptr;
    	free(tmp_ptr);
        break;

    case MODE_SET_UNDO:
        /*
         * XXX: UNDO and return to previous value for the object
         */
    	printf("handle_wmanTestDataHolder MODE_SET_UNDO...\n");
    	free(tmp_ptr);
        break;

    default:
        /*
         * we should never get here, so this is a really bad error
         */
    	printf("handle_wmanTestDataHolder ERROR...\n");
        snmp_log(LOG_ERR,
                 "unknown mode (%d) in handle_wmanTestDataHolder\n",
                 reqinfo->mode);
        return SNMP_ERR_GENERR;
    }

    return SNMP_ERR_NOERROR;
}