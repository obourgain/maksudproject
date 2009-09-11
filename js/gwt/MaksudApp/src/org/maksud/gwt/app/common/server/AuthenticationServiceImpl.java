package org.maksud.gwt.app.common.server;

import org.maksud.gwt.app.common.client.AuthenticationService;
import org.maksud.gwt.app.common.server.dal.UserEntityManager;

import com.google.gwt.user.server.rpc.RemoteServiceServlet;

public class AuthenticationServiceImpl extends RemoteServiceServlet implements AuthenticationService {

	@Override
	public boolean isAuthenticated(String userid, String password) {
		return UserEntityManager.isValidUser(userid, password);
	}
}
