package org.maksud.gwt.app.maksudapp.server.data.entities;

import javax.jdo.annotations.IdGeneratorStrategy;
import javax.jdo.annotations.IdentityType;
import javax.jdo.annotations.PersistenceCapable;
import javax.jdo.annotations.Persistent;
import javax.jdo.annotations.PrimaryKey;

import com.google.appengine.api.datastore.Key;

import java.util.*;

@PersistenceCapable(identityType = IdentityType.APPLICATION)
public class UserEntity {

	@PrimaryKey
	@Persistent(valueStrategy = IdGeneratorStrategy.IDENTITY)
	private Key id;

	@Persistent
	private String login;

	@Persistent
	private String password;

	@Persistent
	private String name;

	@Persistent
	private String email;

	@Persistent
	private String url;

	@Persistent
	private Date register_date;

	@Persistent
	private String activation_key;

	@Persistent
	private int level;

	@Persistent
	private int status;

	public UserEntity() {

	}

	public UserEntity(String login, String password, String name, String email, String url) {
		super();
		this.login = login;
		this.password = password;
		this.name = name;
		this.email = email;
		this.url = url;
		this.register_date = new Date();
		this.activation_key = "";
		this.level = UserLevel.Contributor;
		this.status = UserStatus.Active;
	}

	public Key getId() {
		return id;
	}

	public void setId(Key id) {
		this.id = id;
	}

	public String getLogin() {
		return login;
	}

	public void setLogin(String login) {
		this.login = login;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public String getUrl() {
		return url;
	}

	public void setUrl(String url) {
		this.url = url;
	}

	public Date getRegister_date() {
		return register_date;
	}

	public void setRegister_date(Date registerDate) {
		register_date = registerDate;
	}

	public String getActivation_key() {
		return activation_key;
	}

	public void setActivation_key(String activationKey) {
		activation_key = activationKey;
	}

	public int getLevel() {
		return level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}

}
