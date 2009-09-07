package org.maksud.gwt.app.maksudapp.client.overlay;



import com.extjs.gxt.ui.client.data.BaseModel;

import java.util.*;

public class UserEntity extends BaseModel{
	private String login;

	private String password;

	private String name;

	private String email;

	private String url;

	private Date register_date;

	private String activation_key;

	private UserLevelEnum level;

	private UserStatusEnum status;

	public UserEntity() {

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

	public UserLevelEnum getLevel() {
		return level;
	}

	public void setLevel(UserLevelEnum level) {
		this.level = level;
	}

	public UserStatusEnum getStatus() {
		return status;
	}

	public void setStatus(UserStatusEnum status) {
		this.status = status;
	}

}
