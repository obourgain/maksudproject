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
import org.maksud.gwt.app.common.server.model.jdo.PMF;
import org.maksud.gwt.app.common.server.model.jdo.entities.User;
import org.maksud.gwt.app.common.server.utility.MailHelper;

import com.google.appengine.api.datastore.KeyFactory;

public class UserRegistration extends HttpServlet {

	public void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {

		try {
			String login = req.getParameter("userid");
			String password = req.getParameter("password");
			String retype = req.getParameter("retype");
			String email = req.getParameter("email");
			String url = req.getParameter("web");

			/*
			 * MessageDigest md = MessageDigest.getInstance("SHA");
			 * 
			 * try { md.update(toChapter1); MessageDigest tc1 = md.clone();
			 * byte[] toChapter1Digest = tc1.digest(); md.update(toChapter2);
			 * ...etc. } catch (CloneNotSupportedException cnse) { throw new
			 * DigestException("couldn't make digest of partial content"); }
			 */
			String activationKey = UUID.randomUUID().toString().replace("-", "");

			if (password.equals(retype) && password.length() > 0) {

				User user = new User();
				user.setLogin(login);
				user.setEmail(email);
				user.setPassword(password);
				user.setLevel(UserLevel.Contributor);
				user.setName(login);
				user.setRegister_date(new Date());
				user.setStatus(UserStatus.Inactive);
				user.setUrl(url);
				user.setActivationKey(activationKey);
				user.setId(KeyFactory.createKey(User.class.getSimpleName(), login));

				PersistenceManager pm = PMF.get().getPersistenceManager();
				pm.makePersistent(user);
				pm.close();

				MailHelper.sendEmail("maksud.buet@gmail.com", "MaksudApp Admin", email, login, "Activate",
						"Please Activate by <a href='http://maksudapp.appspot.com/activate?user="+login+"&key=" + activationKey + "'>Clicking here</a>");

				// res.getWriter().print("Success");

			} else {
				req.setAttribute("error", "Error Occured");
				getServletContext().getRequestDispatcher("/register.jsp").forward(req, res);
			}
		} catch (Exception e) {
			req.setAttribute("error", "Error Occured");
			getServletContext().getRequestDispatcher("/register.jsp").forward(req, res);
		}
		req.setAttribute("error", "Success");
		getServletContext().getRequestDispatcher("/register.jsp").forward(req, res);
	}
}
