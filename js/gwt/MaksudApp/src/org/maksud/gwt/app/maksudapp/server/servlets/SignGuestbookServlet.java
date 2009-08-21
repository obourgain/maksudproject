package org.maksud.gwt.app.maksudapp.server.servlets;

import java.io.IOException;
import java.util.Date;
import java.util.logging.Logger;

import javax.jdo.PersistenceManager;
import javax.servlet.http.*;

import org.maksud.gwt.app.maksudapp.data.PMF;
import org.maksud.gwt.app.maksudapp.entities.MaxDataTable;

import com.google.appengine.api.users.*;

public class SignGuestbookServlet extends HttpServlet {
	private static final Logger log = Logger
			.getLogger(SignGuestbookServlet.class.getName());

	public void doPost(HttpServletRequest req, HttpServletResponse resp)
			throws IOException {
		UserService userService = UserServiceFactory.getUserService();
		User user = userService.getCurrentUser();

		String content = req.getParameter("content");
		Date date = new Date();
		MaxDataTable greeting = new MaxDataTable(user, content, date);

		PersistenceManager pm = PMF.get().getPersistenceManager();
		try {
			pm.makePersistent(greeting);
		} finally {

			pm.close();
		}

		if (content == null) {
			content = "(No greeting)";
		}
		if (user != null) {
			log.info("Greeting posted by user " + user.getNickname() + ": "
					+ content);
		} else {
			log.info("Greeting posted anonymously: " + content);
		}
		resp.sendRedirect("/MaksudApp.html");
	}

}
