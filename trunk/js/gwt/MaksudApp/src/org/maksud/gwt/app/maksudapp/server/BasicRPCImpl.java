package org.maksud.gwt.app.maksudapp.server;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

import javax.jdo.PersistenceManager;

import org.maksud.gwt.app.maksudapp.client.BasicRPC;
import org.maksud.gwt.app.maksudapp.client.overlay.Employee;
import org.maksud.gwt.app.maksudapp.client.overlay.UserLevel;
import org.maksud.gwt.app.maksudapp.client.overlay.UserModel;
import org.maksud.gwt.app.maksudapp.client.overlay.UserStatus;
import org.maksud.gwt.app.maksudapp.server.dal.UserController;
import org.maksud.gwt.app.maksudapp.server.data.PMF;
import org.maksud.gwt.app.maksudapp.server.data.entities.UserEntity;

import com.google.gwt.user.server.rpc.RemoteServiceServlet;

public class BasicRPCImpl extends RemoteServiceServlet implements BasicRPC {

	@Override
	public List<UserModel> getUsers() {

		List<UserModel> userModels = new ArrayList<UserModel>();
		List<UserEntity> userEntities = UserController.getAllUsers();
		for (int i = 0; i < userEntities.size(); i++) {
			UserEntity user = userEntities.get(i);
			try {
				UserModel demo = new UserModel(user.getLogin(), user.getPassword(), user.getName(), user.getEmail(), user.getUrl(), user.getRegister_date(),
						user.getActivationKey(), user.getLevel(), user.getStatus());
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

}
