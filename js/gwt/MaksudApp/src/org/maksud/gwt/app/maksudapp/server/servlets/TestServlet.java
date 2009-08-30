package org.maksud.gwt.app.maksudapp.server.servlets;

import java.io.IOException;
import java.util.logging.Logger;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import com.google.appengine.api.users.User;
import com.google.appengine.api.users.UserService;
import com.google.appengine.api.users.UserServiceFactory;

public class TestServlet extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private static final Logger log = Logger.getLogger(TestServlet.class
			.getName());

	public void doGet(HttpServletRequest req, HttpServletResponse resp)
			throws IOException {

		log.info("Got the Get..");

		UserService userService = UserServiceFactory.getUserService();
		User user = userService.getCurrentUser();
		if (user != null) {
			resp.setContentType("text/plain");
			resp.getWriter().println("Hello, " + user.getNickname());
		} else {
			log.severe("User is not logged in.");
			resp.sendRedirect(userService.createLoginURL(req.getRequestURI()));
		}
		// resp.setContentType("text/plain");
		// resp.getWriter().println("Hello, world");
	}

}
