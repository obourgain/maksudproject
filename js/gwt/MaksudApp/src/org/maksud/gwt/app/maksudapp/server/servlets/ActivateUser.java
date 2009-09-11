package org.maksud.gwt.app.maksudapp.server.servlets;

import java.io.IOException;

import javax.jdo.PersistenceManager;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.maksud.gwt.app.maksudapp.server.data.PMF;
import org.maksud.gwt.app.maksudapp.server.data.entities.UserEntity;
import org.maksud.gwt.app.maksudapp.server.data.entities.UserStatus;

import com.google.appengine.api.datastore.KeyFactory;

public class ActivateUser extends HttpServlet {

	public void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
		String login = (String) req.getParameter("user");
		String activateString = (String) req.getParameter("key");

		PersistenceManager pm = PMF.get().getPersistenceManager();

		UserEntity user = (UserEntity) pm.getObjectById(UserEntity.class, KeyFactory.createKey(UserEntity.class.getSimpleName(), login));

		if (user.getActivationKey().equals(activateString)) {
			user.setStatus(UserStatus.Active);
			pm.makePersistent(user);
			pm.close();
			res.getWriter().print("User is activated!");
			res.sendRedirect("/login.jsp");
		} else {
			res.getWriter().print("Activation Problem!");
		}
		//pm.close();
	}
}
