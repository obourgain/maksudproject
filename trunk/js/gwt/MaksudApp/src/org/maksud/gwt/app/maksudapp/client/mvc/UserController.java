package org.maksud.gwt.app.maksudapp.client.mvc;

import org.maksud.gwt.app.maksudapp.client.AppEvents;
import org.maksud.gwt.app.maksudapp.client.BasicRPCAsync;
import com.extjs.gxt.ui.client.mvc.AppEvent;
import com.extjs.gxt.ui.client.mvc.Controller;

public class UserController extends Controller {
	private UserView userView;
	private BasicRPCAsync service;

	public UserController() {
		registerEventTypes(AppEvents.Registration);
		registerEventTypes(AppEvents.Login);
		registerEventTypes(AppEvents.RegistrationDialog);
	}

	public void initialize() {
		userView = new UserView(this);
	}

	@Override
	public void handleEvent(AppEvent event) {
		if (event.getType() == AppEvents.RegistrationDialog) {
			showRegistrationDialog(event);
		} else if (event.getType() == AppEvents.Login) {
			showRegistrationDialog(event);
		}
	}

	private void showRegistrationDialog(AppEvent event) {
		forwardToView(userView, event);
	}

	private void onLogin(AppEvent event) {

		// forwardToView(userView, event);
	}

}
