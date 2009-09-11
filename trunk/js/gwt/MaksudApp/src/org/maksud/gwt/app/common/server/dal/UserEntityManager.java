package org.maksud.gwt.app.common.server.dal;

import java.util.ArrayList;
import java.util.List;

import javax.jdo.PersistenceManager;

import org.maksud.gwt.app.common.client.constants.UserStatus;
import org.maksud.gwt.app.common.server.model.jdo.PMF;
import org.maksud.gwt.app.common.server.model.jdo.entities.User;

import com.google.appengine.api.datastore.KeyFactory;

public class UserEntityManager {

	public static List<User> getAllUsers() {
		PersistenceManager pm = PMF.get().getPersistenceManager();

		List<User> userEntities = new ArrayList<User>();
		String query = "select from " + User.class.getName();
		try {
			userEntities = (List<User>) pm.newQuery(query).execute();
			System.err.println("Total Records Found: " + userEntities.size());
			pm.close();
		} catch (Exception e) {
			System.out.println("getAllUsers():  " + e.getMessage());
		} finally {
		}
		return userEntities;
	}

	public static boolean isValidUser(String userid, String password) {
		PersistenceManager pm = PMF.get().getPersistenceManager();
		try {
			User user = (User) pm.getObjectById(User.class, KeyFactory.createKey(User.class.getSimpleName(), userid));
			if (user != null && user.getPassword() == password && user.getStatus() == UserStatus.Active)
				return true;
			else
				return false;

		} catch (Exception e) {
			return false;
		}
	}
}
