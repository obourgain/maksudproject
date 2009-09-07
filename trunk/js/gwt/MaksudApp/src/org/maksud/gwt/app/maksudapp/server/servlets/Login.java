package org.maksud.gwt.app.maksudapp.server.servlets;

import java.io.IOException;

import javax.jdo.PersistenceManager;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.maksud.gwt.app.maksudapp.server.data.PMF;
import org.maksud.gwt.app.maksudapp.server.data.entities.UserEntity;
import org.maksud.gwt.app.maksudapp.server.data.entities.UserStatusEnum;

import com.google.appengine.api.datastore.KeyFactory;

public class Login extends HttpServlet {
	public void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
		String login = req.getParameter("userid");
		String password = req.getParameter("password");

		try {
			PersistenceManager pm = PMF.get().getPersistenceManager();
			UserEntity user = (UserEntity) pm.getObjectById(UserEntity.class, KeyFactory.createKey(UserEntity.class.getSimpleName(), login));

			if (user.getPassword().equals(password)) {
				res.getWriter().println("Password OK.");
				if (user.getStatus() == UserStatusEnum.Active) {
					res.getWriter().println("Login Ok.");

					HttpSession ses = req.getSession(true);

				} else {
					res.getWriter().println("Inactive / Banned.");
				}
			} else {
				res.getWriter().println("Password Incorrect.");
			}

		} catch (Exception e) {

		}
	}
}
