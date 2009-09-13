package org.maksud.gwt.app.maksudapp.server;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.maksud.gwt.app.common.client.model.Employee;
import org.maksud.gwt.app.common.client.model.User;
import org.maksud.gwt.app.common.server.dal.UserEntityManager;
import org.maksud.gwt.app.maksudapp.client.BasicRPC;

import com.google.gwt.user.server.rpc.RemoteServiceServlet;

public class BasicRPCImpl extends RemoteServiceServlet implements BasicRPC {

	@Override
	public List<User> getUsers() {

		List<User> userModels = new ArrayList<User>();
		List<org.maksud.gwt.app.common.server.model.jdo.entities.User> userEntities = UserEntityManager.getAllUsers();
		for (int i = 0; i < userEntities.size(); i++) {
			org.maksud.gwt.app.common.server.model.jdo.entities.User user = userEntities.get(i);
			try {
				User demo = new User(user.getLogin(), user.getPassword(), user.getName(), user.getEmail(), user.getUrl(), user.getRegister_date(), user
						.getActivationKey(), user.getLevel(), user.getStatus());
				userModels.add(demo);
			} catch (Exception e) {
				System.out.println("getUsers():  " + e.getMessage());
				// pm.deletePersistent(user);
			}
		}
		return userModels;
	}

	public List<Employee> getEmployees() {
		List<Employee> employees = new ArrayList<Employee>();

		employees.add(new Employee("Hollie Voss", "General Administration", "Executive Dir  ector", 150000, new Date()));

		return employees;
	}

	@Override
	public boolean registerUser(User user) {
		System.out.print("registerUser");
		return UserEntityManager.registerUser(user.getLogin(), user.getPassword(), user.getPassword(), user.getEmail(), user.getUrl());
	}

	@Override
	public void test() {
		String str = getThreadLocalRequest().getRealPath("/");
		System.out.println("|" + str + "|");

	}

}
