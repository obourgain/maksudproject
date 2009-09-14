package org.maksud.gwt.app.common.server.servlets;

import java.io.IOException;
import java.util.Date;
import java.util.UUID;

import javax.jdo.PersistenceManager;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.maksud.gwt.app.common.client.constants.UserLevel;
import org.maksud.gwt.app.common.client.constants.UserStatus;
import org.maksud.gwt.app.common.server.dal.UserEntityManager;
import org.maksud.gwt.app.common.server.model.jdo.PMF;
import org.maksud.gwt.app.common.server.model.jdo.entities.UserEntity;
import org.maksud.gwt.app.common.server.utility.MailHelper;

import com.google.appengine.api.datastore.KeyFactory;

public class UserRegistration extends HttpServlet {

	public void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
		String login = req.getParameter("userid");
		String password = req.getParameter("password");
		String retype = req.getParameter("retype");
		String email = req.getParameter("email");
		String web = req.getParameter("web");

		if (UserEntityManager.registerUser(login, password, retype, email, web)) {
			req.removeAttribute("error");
			getServletContext().getRequestDispatcher("/login.jsp").forward(req, res);
		} else {
			req.setAttribute("error", "Error Occured");
			getServletContext().getRequestDispatcher("/register.jsp").forward(req, res);
		}
	}
}
