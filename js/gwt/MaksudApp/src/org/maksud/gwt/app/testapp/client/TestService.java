package org.maksud.gwt.app.testapp.client;

import com.google.gwt.core.client.GWT;
import com.google.gwt.user.client.rpc.RemoteService;
import com.google.gwt.user.client.rpc.RemoteServiceRelativePath;

@RemoteServiceRelativePath("TestService")
public interface TestService extends RemoteService {
	/**
	 * Utility class for simplifying access to the instance of async service.
	 */
	public static class Util {
		private static TestServiceAsync instance;
		public static TestServiceAsync getInstance(){
			if (instance == null) {
				instance = GWT.create(TestService.class);
			}
			return instance;
		}
	}
}
