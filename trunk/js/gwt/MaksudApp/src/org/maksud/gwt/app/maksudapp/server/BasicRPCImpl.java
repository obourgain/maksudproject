package org.maksud.gwt.app.maksudapp.server;

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
import org.maksud.gwt.app.maksudapp.server.data.PMF;
import org.maksud.gwt.app.maksudapp.server.data.entities.UserEntity;

import com.google.gwt.user.server.rpc.RemoteServiceServlet;

public class BasicRPCImpl extends RemoteServiceServlet implements BasicRPC {

	@Override
	public List<UserModel> getUsers() {

		List<UserModel> lstUserModel = new ArrayList<UserModel>();
		PersistenceManager pm = PMF.get().getPersistenceManager();

		String query = "select from " + UserEntity.class.getName();

		try {
			List<UserEntity> lstUsers = (List<UserEntity>) pm.newQuery(query).execute();
			System.out.println("Total Records Found: " + lstUsers.size());

			for (int i = 0; i < lstUsers.size(); i++) {
				UserEntity user = lstUsers.get(i);
				try {

					// System.out.println("Id: " + em.getId().toString() +
					// "  :::  "
					// + em.getLogin() + " " + em.getActivation_key()+ " " +
					// em.getStatus());

					UserModel demo = new UserModel(user.getLogin(), user.getPassword(), user.getName(), user.getEmail(), user.getUrl(),
							user.getRegister_date(), user.getActivation_key(), user.getLevel(), user.getStatus());
					lstUserModel.add(demo);
				} catch (Exception e) {
					System.out.println("RPCImpl1:  " + e.getMessage());
					pm.deletePersistent(user);
				}
			}
			pm.close();
		} catch (Exception e) {

			System.out.println("RPCImpl2:  " + e.getMessage());
		} finally {
		}
		return lstUserModel;
	}

	public List<Employee> getEmployees() {
		List<Employee> employees = new ArrayList<Employee>();

		employees.add(new Employee("Hollie Voss", "General Administration", "Executive Dir  ector", 150000, new Date()));

		return employees;
	}

}
