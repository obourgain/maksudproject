package org.maksud.gwt.app.maksudapp.client;

import java.util.List;

import org.maksud.gwt.app.common.client.model.Employee;
import org.maksud.gwt.app.common.client.model.User;
import org.maksud.gwt.app.maksudapp.client.model.*;

import com.extjs.gxt.ui.client.data.BasePagingLoadResult;
import com.google.gwt.user.client.rpc.AsyncCallback;

public interface BasicRPCAsync {
	void getUsers(AsyncCallback<List<User>> callback);

	void getEmployees(AsyncCallback<List<Employee>> callback);

}
