package org.maksud.gwt.app.maksudapp.server;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Date;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

import org.maksud.gwt.app.maksudapp.client.BasicRPC;
import org.maksud.gwt.app.maksudapp.client.overlay.Employee;
import org.maksud.gwt.app.maksudapp.client.overlay.UserEntity;

import com.google.gwt.user.server.rpc.RemoteServiceServlet;

public class BasicRPCImpl extends RemoteServiceServlet implements BasicRPC {

	
	@Override
	public List<UserEntity> getUsers() {
		List<UserEntity> lst = new ArrayList<UserEntity>();

		UserEntity demo = new UserEntity();
		demo.setName("maksud");
		demo.setLogin("login");
		lst.add(demo);

		return lst;
	}

	public List<Employee> getEmployees() {
		List<Employee> employees = new ArrayList<Employee>();


		employees.add(new Employee("Hollie Voss", "General Administration",
				"Executive Dir  ector", 150000, new Date()));
//		employees.add(new Employee("Emerson Milton", "Information Technology",
//				"CTO", 120000, f.parse("2007-03-01")));
//		employees.add(new Employee("Christina Blake", "Information Technology",
//				"Project M  anager", 90000, f.parse("2008-08-01")));
//		employees.add(new Employee("Heriberto Rush", "Information Technology",
//				"Senior S/W  Engineer", 70000, f.parse("2009-02-07")));
//		employees.add(new Employee("Candice Carson", "Information Technology",
//				"S/W Engine  er", 60000, f.parse("2007-11-01")));
//		employees.add(new Employee("Chad Andrews", "Information Technology",
//				"Senior S/W E  ngineer", 70000, f.parse("2008-02-01")));
//		employees.add(new Employee("Dirk Newman", "Information Technology",
//				"S/W Engineer", 62000, f.parse("2009-03-01")));
//		employees.add(new Employee("Bell Snedden", "Information Technology",
//				"S/W Engineer  ", 73000, f.parse("2007-07-07")));
//		employees.add(new Employee("Benito Meeks", "Marketing",
//				"General Manager", 105000, f.parse("2008-02-01")));
//		employees.add(new Employee("Gail Horton", "Marketing", "Executive",
//				55000, f.parse("  2009-05-01")));
//		employees.add(new Employee("Claudio Engle", "Marketing", "Executive",
//				58000, f.parse("2008-09-03")));
//		employees.add(new Employee("Buster misjenou", "Accounts", "Executive",
//				52000, f.parse("2008-02-07")));

		return employees;
	}
	
}
