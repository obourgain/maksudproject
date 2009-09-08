package org.maksud.gwt.app.maksudapp.client.overlay;

import com.extjs.gxt.ui.client.data.BaseModel;

public class Data extends BaseModel {

	public Data() {

	}

	public Data(String name) {
		setName(name);
	}

	public String getName() {
		return get("name");
	}

	public void setName(String name) {
		set("name", name);
	}
}