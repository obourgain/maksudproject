package org.maksud.gwt.app.common.client;

import com.google.gwt.core.client.GWT;
import com.google.gwt.user.client.rpc.RemoteService;
import com.google.gwt.user.client.rpc.RemoteServiceRelativePath;

@RemoteServiceRelativePath("AuthenticationService")
public interface AuthenticationService extends RemoteService {
	/**
	 * Utility class for simplifying access to the instance of async service.
	 */
	public static class Util {
		private static AuthenticationServiceAsync instance;

		public static AuthenticationServiceAsync getInstance() {
			if (instance == null) {
				instance = GWT.create(AuthenticationService.class);
			}
			return instance;
		}
	}

	public boolean isAuthenticated(String userid, String password);
}
