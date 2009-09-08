package org.maksud.gwt.app.maksudapp.client;

import java.util.List;

import org.maksud.gwt.app.maksudapp.client.overlay.Employee;
import org.maksud.gwt.app.maksudapp.client.overlay.UserEntity;

import com.google.gwt.user.client.rpc.AsyncCallback;

public interface BasicRPCAsync {

	void getUsers(AsyncCallback<List<UserEntity>> callback);

	void getEmployees(AsyncCallback<List<Employee>> callback);
}
