package org.maksud.gwt.app.maksudapp.server.servlets.demo;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.Enumeration;
import java.util.logging.Logger;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.maksud.gwt.app.maksudapp.server.utility.FetchUrlContents;

import com.google.appengine.api.users.User;
import com.google.appengine.api.users.UserService;
import com.google.appengine.api.users.UserServiceFactory;
import com.google.appengine.api.xmpp.JID;
import com.google.appengine.api.xmpp.Message;
import com.google.appengine.api.xmpp.MessageBuilder;
import com.google.appengine.api.xmpp.SendResponse;
import com.google.appengine.api.xmpp.XMPPService;
import com.google.appengine.api.xmpp.XMPPServiceFactory;

public class TestServlet extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	private static final Logger log = Logger.getLogger(TestServlet.class.getName());

	public void doGet(HttpServletRequest req, HttpServletResponse resp) throws IOException {
		PrintWriter out = resp.getWriter();
		try {
			JID jid = new JID("maksud.buet@gmail.com");
			String msgBody = "Someone has sent you a gift on Example.com. To view: http://example.com/gifts/";
			Message msg = new MessageBuilder().withRecipientJids(jid).withBody(msgBody).build();

			boolean messageSent = false;
			XMPPService xmpp = XMPPServiceFactory.getXMPPService();
			if (xmpp.getPresence(jid).isAvailable()) {
				SendResponse status = xmpp.sendMessage(msg);
				messageSent = (status.getStatusMap().get(jid) == SendResponse.Status.SUCCESS);
			}

			if (!messageSent) {
				// Send an email message instead...
			}
		} catch (Exception e) {
			out.println(e.getMessage());
		}

		// log.info("Got the Get..");
		// resp.setContentType("text/html;charset=UTF-8");
		// Enumeration en = req.getParameterNames();
		// String el;
		// while (en.hasMoreElements()) {
		//
		// String paramName = (String) en.nextElement();
		// out.println(paramName + " = " + req.getParameter(paramName) +
		// "<br/>");
		//
		// }

		// String str =
		// FetchUrlContents.getContents("http://admin.dsebd.org/admin-real/mst.txt");

		// UserService userService = UserServiceFactory.getUserService();
		// User user = userService.getCurrentUser();
		// if (user != null) {
		// resp.setContentType("text/plain");
		// resp.getWriter().println("Hello, " + user.getNickname());
		// } else {
		// log.severe("User is not logged in.");
		// resp.sendRedirect(userService.createLoginURL(req.getRequestURI()));
		// }
		// resp.setContentType("text/plain");
		// resp.getWriter().println("Hello, world");

	}
}
