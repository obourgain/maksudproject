package org.maksud.gwt.app.testapp.server.model;

import javax.jdo.annotations.IdGeneratorStrategy;
import javax.jdo.annotations.IdentityType;
import javax.jdo.annotations.PersistenceCapable;
import javax.jdo.annotations.Persistent;
import javax.jdo.annotations.PrimaryKey;

@PersistenceCapable(identityType = IdentityType.APPLICATION)
public class Employee {
	@PrimaryKey
	@Persistent(valueStrategy = IdGeneratorStrategy.IDENTITY)
	private Long id;

	@Persistent
	private String first;

	@Persistent
	private String last;

	public Employee(String first, String last) {
		this.first = first;
		this.last = last;
	}

	public Long getId() {
		return id;
	}

	public String getFirst() {
		return first;
	}

	public String getLast() {
		return last;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public void setFirst(String first) {
		this.first = first;
	}

	public void setLast(String last) {
		this.last = last;
	}
}
