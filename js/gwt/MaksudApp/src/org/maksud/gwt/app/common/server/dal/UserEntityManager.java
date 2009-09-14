package org.maksud.gwt.app.common.server.dal;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.UUID;

import javax.jdo.PersistenceManager;

import org.maksud.gwt.app.common.client.constants.UserLevel;
import org.maksud.gwt.app.common.client.constants.UserStatus;
import org.maksud.gwt.app.common.server.model.jdo.PMF;
import org.maksud.gwt.app.common.server.model.jdo.entities.UserEntity;
import org.maksud.gwt.app.common.server.utility.MailHelper;

import com.google.appengine.api.datastore.KeyFactory;

public class UserEntityManager {

	public static List<UserEntity> getAllUsers() {
		PersistenceManager pm = PMF.get().getPersistenceManager();

		List<UserEntity> userEntities = new ArrayList<UserEntity>();
		String query = "select from " + UserEntity.class.getName();
		try {
			List<UserEntity> execute = (List<UserEntity>) pm.newQuery(query).execute();
			userEntities = execute;
			System.err.println("Total Records Found: " + userEntities.size());
			pm.close();
		} catch (Exception e) {
			System.out.println("getAllUsers():  " + e.getMessage());
		} finally {
		}
		return userEntities;
	}

	public static UserEntity getUser(String userid) {
		try {
			PersistenceManager pm = PMF.get().getPersistenceManager();
			UserEntity user = (UserEntity) pm.getObjectById(UserEntity.class, KeyFactory.createKey(UserEntity.class.getSimpleName(), userid));
			return user;
		} catch (Exception e) {
			return null;
		}
	}

	public static boolean isUserPresent(String userid) {
		return getUser(userid) != null;
	}

	public static boolean isValidUser(String userid, String password) {
		try {
			UserEntity user = getUser(userid);
			if (user != null && user.getPassword() == password && user.getStatus() == UserStatus.Active)
				return true;
			else
				return false;
		} catch (Exception e) {
			return false;
		}
	}

	public static boolean registerUser(String userid, String password, String retype, String email, String web) {

		String activationKey = UUID.randomUUID().toString().replace("-", "");

		try {

			if (isUserPresent(userid)) {
				System.out.println("User already exists.");
				return false;
			}

			if (password.equals(retype) && password.length() > 0) {

				UserEntity user = new UserEntity();
				user.setLogin(userid);
				user.setEmail(email);
				user.setPassword(password);
				user.setLevel(UserLevel.Contributor);
				user.setName(userid);
				user.setRegister_date(new Date());
				user.setStatus(UserStatus.Inactive);
				user.setUrl(web);
				user.setActivationKey(activationKey);
				user.setId(KeyFactory.createKey(UserEntity.class.getSimpleName(), userid));

				PersistenceManager pm = PMF.get().getPersistenceManager();
				pm.makePersistent(user);
				pm.close();

				MailHelper.sendEmail("maksud.buet@gmail.com", "MaksudApp Admin", email, userid, "Activate",
						"Please Activate by <a href='http://maksudapp.appspot.com/activate?user=" + userid + "&key=" + activationKey + "'>Clicking here</a>");

				System.out.println("User registration successfull.");
				return true;

			} else {
				System.out.println("User registration failed. Password Problem.");
				return false;
			}
		} catch (Exception e) {
			System.out.println("User registration failed. Exception");
			e.printStackTrace();
			return false;
		}
	}

	public static boolean activateUser(String userid, String activationKey) {
		try {
			UserEntity user = getUser(userid);
			if (user.getActivationKey().equals(activationKey)) {
				user.setStatus(UserStatus.Active);
				PMF.get().getPersistenceManager().makePersistent(user);
				System.out.println("User is activated!");
				return true;
			} else {
				System.out.print("Activation Problem!");
				return false;
			}
		} catch (Exception e) {
			e.printStackTrace();
			return false;
		}
	}
}
