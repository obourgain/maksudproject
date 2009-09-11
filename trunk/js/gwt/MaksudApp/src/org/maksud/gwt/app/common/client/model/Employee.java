package org.maksud.gwt.app.common.client.model;

import com.extjs.gxt.ui.client.data.BaseModel;
import java.util.Date;

public class Employee extends BaseModel {
	private static final long serialVersionUID = 1L;

	public Employee() {
	}

	public Employee(String name, String department, String designation,
			double salary, Date joiningdate) {
		set("name", name);
		set("department", department);
		set("designation", designation);
		set("salary", salary);
		set("joiningdate", joiningdate);
	}

	public Date getJoiningdate() {
		return (Date) get("joiningdate");
	}

	public String getName() {
		return (String) get("name");
	}

	public String getDepartment() {
		return (String) get("department");
	}

	public String getDesignation() {
		return (String) get("designation");
	}

	public double getSalary() {
		Double salary = (Double) get("salary");
		return salary.doubleValue();
	}

	public String toString() {
		return getName();
	}
}