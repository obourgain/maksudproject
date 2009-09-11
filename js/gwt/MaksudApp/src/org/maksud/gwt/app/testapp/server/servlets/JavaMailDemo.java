package org.maksud.gwt.app.testapp.server.servlets;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.logging.Logger;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import javax.mail.*;
import javax.mail.internet.*;

import org.maksud.gwt.app.testapp.server.servlets.TestServlet;

import java.util.*;


public class JavaMailDemo extends HttpServlet {

	//Works..
	private static final Logger log = Logger.getLogger(TestServlet.class.getName());

	public void doGet(HttpServletRequest req, HttpServletResponse resp) throws IOException {
		PrintWriter out = resp.getWriter();

		Properties props = new Properties();
		Session session = Session.getDefaultInstance(props, null);

		String msgBody = "...";

		try {
			Message msg = new MimeMessage(session);
			msg.setFrom(new InternetAddress("maksud.buet@gmail.com", "Gmail account"));
			msg.addRecipient(Message.RecipientType.TO, new InternetAddress("maksud@csebuet.org", "Maksud"));
			msg.setSubject("Your Example.com account has been activated");
			msg.setText(msgBody);
			Transport.send(msg);

		} catch (AddressException e) {
			out.write(e.getMessage());
			// ...
		} catch (MessagingException e) {
			out.write(e.getMessage());
			// ...
		}
	}
}
