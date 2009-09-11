package org.maksud.gwt.app.common.client.model;

import com.extjs.gxt.ui.client.data.BaseModel;

import java.util.*;

public class User extends BaseModel {
	
//	private String login;
//	private String password;
//	private String name;
//	private String email;
//	private String url;
//	private Date register_date;
//	private String activation_key;
//	private UserLevelEnum level;
//	private UserStatusEnum status;

	/**
	 * 
	 */
	private static final long serialVersionUID = -2586208348201224917L;

	public User() {

	}

	public User(String login, String password, String name, String email, String url, Date registerDate, String activationKey, int level,
			int status) {
		super();
		set("login", login);
		set("password", password);
		set("name", name);
		set("email", email);
		set("url", url);
		set("register_date", registerDate);
		set("activation_key", activationKey);
		set("level", level);
		set("status", status);
	}

	public String getLogin() {
		return get("login");
	}

	public void setLogin(String login) {
		set("login", login);
	}

	public String getPassword() {
		return get("password");
	}

	public void setPassword(String password) {
		set("password", password);
	}

	public String getName() {
		return get("name");
	}

	public void setName(String name) {
		set("name", name);
	}

	public String getEmail() {
		return get("email");
	}

	public void setEmail(String email) {
		set("email", email);
	}

	public String getUrl() {
		return get("url");
	}

	public void setUrl(String url) {
		set("url", url);
	}

	public Date getRegister_date() {
		return get("register_date");
	}

	public void setRegister_date(Date registerDate) {
		set("register_date", registerDate);
	}

	public String getActivation_key() {
		return get("activation_key");
	}

	public void setActivation_key(String activationKey) {
		set("activation_key", activationKey);
	}

	public int getLevel() {
		return get("level");
	}

	public void setLevel(int level) {
		set("level", level);
	}

	public int getStatus() {
		return get("status");
	}

	public void setStatus(int status) {
		set("status", status);
	}

}
