package org.maksud.gwt.app.common.server.rpc;

import javax.servlet.http.HttpSession;

import org.maksud.gwt.app.common.client.rpc.AuthenticationService;
import org.maksud.gwt.app.common.server.controller.UserController;

import com.google.apphosting.api.DatastorePb.GetRequest;
import com.google.gwt.user.server.rpc.RemoteServiceServlet;

public class AuthenticationServiceImpl extends RemoteServiceServlet implements AuthenticationService {

	@Override
	public boolean isAuthenticated(String userid, String password) {
		return UserController.isValidUser(userid, password);
	}

	@Override
	public boolean isSessionValid() {
		try {
			HttpSession session = getThreadLocalRequest().getSession(true);
			if (session.getAttribute("userid") != null)
				return true;
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
		return false;
	}

	@Override
	public boolean registerUser(String login, String password, String retype, String email, String web) {
		return UserController.registerUser(login, password, retype, email, web);
	}

}
