package org.maksud.gwt.app.common.server.dal;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.UUID;

import javax.jdo.PersistenceManager;

import org.maksud.gwt.app.common.client.constants.UserLevel;
import org.maksud.gwt.app.common.client.constants.UserStatus;
import org.maksud.gwt.app.common.server.model.jdo.PMF;
import org.maksud.gwt.app.common.server.model.jdo.entities.User;
import org.maksud.gwt.app.common.server.utility.MailHelper;

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

	public static boolean registerUser(String login, String password, String retype, String email, String web) {
		String activationKey = UUID.randomUUID().toString().replace("-", "");

		try {
			if (password.equals(retype) && password.length() > 0) {

				User user = new User();
				user.setLogin(login);
				user.setEmail(email);
				user.setPassword(password);
				user.setLevel(UserLevel.Contributor);
				user.setName(login);
				user.setRegister_date(new Date());
				user.setStatus(UserStatus.Inactive);
				user.setUrl(web);
				user.setActivationKey(activationKey);
				user.setId(KeyFactory.createKey(User.class.getSimpleName(), login));

				PersistenceManager pm = PMF.get().getPersistenceManager();
				pm.makePersistent(user);
				pm.close();

				MailHelper.sendEmail("maksud.buet@gmail.com", "MaksudApp Admin", email, login, "Activate",
						"Please Activate by <a href='http://maksudapp.appspot.com/activate?user=" + login + "&key=" + activationKey + "'>Clicking here</a>");

				return true;

			} else {
				return false;

			}
		} catch (Exception e) {
			return false;

		}
	}
}
