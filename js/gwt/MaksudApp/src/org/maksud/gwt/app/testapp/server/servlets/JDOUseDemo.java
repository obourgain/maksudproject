package org.maksud.gwt.app.maksudapp.server.servlets.demo;

import java.io.IOException;

import javax.jdo.PersistenceManager;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.maksud.gwt.app.common.server.model.jdo.PMF;
import org.maksud.gwt.app.maksudapp.server.data.entities.demo.Employee;
import org.maksud.gwt.app.testapp.server.model.ADummyEntityClass;

public class JDOUseDemo extends HttpServlet {

	public void doGet(HttpServletRequest req, HttpServletResponse resp) throws IOException {
		PersistenceManager pm = PMF.get().getPersistenceManager();

		/**
		 * To store a simple data object in the datastore, you call the
		 * PersistenceManager's makePersistent() method, passing it the
		 * instance.
		 * 
		 * The call to makePersistent() is synchronous, and doesn't return until
		 * the object is saved and indexes are updated.
		 */

		Employee e = new Employee("Alfred", "Smith");

		try {
			pm.makePersistent(e);
		} finally {
			pm.close();
		}

	}
}
