package org.maksud.gwt.app.common.client.constants;

import java.io.Serializable;

import javax.jdo.annotations.EmbeddedOnly;
import javax.jdo.annotations.PersistenceCapable;
import javax.jdo.annotations.Persistent;

@PersistenceCapable
@EmbeddedOnly
public class UserLevel implements Serializable {
	@Persistent
	private int _level;

	public static final int Admin = 0;
	public static final int Editor = 1;
	public static final int Contributor = 2;

	public UserLevel() {
		_level = UserLevel.Contributor;
	}

	public UserLevel(int level) {
		_level = level;
	}

	public int getLevel() {
		return _level;
	}

	public void setLevel(int status) {
		_level = status;
	}

	@Override
	public String toString() {
		switch (_level) {
		case UserLevel.Admin:
			return "Admin";
		case UserLevel.Contributor:
			return "Contributor";
		case UserLevel.Editor:
			return "Editor";
		}
		return "Unknown";
	}
}
