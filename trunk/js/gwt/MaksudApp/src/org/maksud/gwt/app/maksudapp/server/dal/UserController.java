package org.maksud.gwt.app.maksudapp.server.dal;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import javax.jdo.PersistenceManager;

import org.maksud.gwt.app.common.client.model.User;
import org.maksud.gwt.app.maksudapp.server.data.PMF;
import org.maksud.gwt.app.maksudapp.server.data.entities.UserEntity;

public class UserController {

	public static List<UserEntity> getAllUsers() {

		List<UserEntity> userEntities = new ArrayList<UserEntity>();

		// List<UserModel> lstUserModel = new ArrayList<UserModel>();
		PersistenceManager pm = PMF.get().getPersistenceManager();

		String query = "select from " + UserEntity.class.getName();
		try {
			userEntities = (List<UserEntity>) pm.newQuery(query).execute();
			System.err.println("Total Records Found: " + userEntities.size());

			pm.close();
		} catch (Exception e) {
			System.out.println("getAllUsers():  " + e.getMessage());
		} finally {
		}
		return userEntities;
	}

}
