package org.maksud.gwt.app.maksudapp.server;

import org.maksud.gwt.app.maksudapp.client.BasicRPC;
import com.google.gwt.user.server.rpc.RemoteServiceServlet;

public class BasicRPCImpl extends RemoteServiceServlet implements BasicRPC {

	@Override
	public String dummy() {
		return "Dummy Returns.";
	}
}
