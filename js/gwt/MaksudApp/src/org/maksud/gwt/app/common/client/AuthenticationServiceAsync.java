package org.maksud.gwt.app.common.client;

import com.google.gwt.user.client.rpc.AsyncCallback;

public interface AuthenticationServiceAsync {

	void isAuthenticated(String userid, String password, AsyncCallback<Boolean> callback);

}
