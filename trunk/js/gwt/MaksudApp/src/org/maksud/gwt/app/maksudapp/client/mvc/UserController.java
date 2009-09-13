package org.maksud.gwt.app.maksudapp.client.mvc;

import org.maksud.gwt.app.common.client.model.User;
import org.maksud.gwt.app.maksudapp.client.AppEvents;
import org.maksud.gwt.app.maksudapp.client.BasicRPC;
import org.maksud.gwt.app.maksudapp.client.BasicRPCAsync;
import com.extjs.gxt.ui.client.mvc.AppEvent;
import com.extjs.gxt.ui.client.mvc.Controller;
import com.extjs.gxt.ui.client.widget.MessageBox;
import com.google.gwt.user.client.rpc.AsyncCallback;

public class UserController extends Controller {
	private UserView userView;
	private BasicRPCAsync service;

	public UserController() {
		service = BasicRPC.Util.getInstance();
		
		
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
		} else if (event.getType() == AppEvents.Registration) {
			registerUser((User) event.getData());
		}
	}

	private void showRegistrationDialog(AppEvent event) {
		forwardToView(userView, event);
	}

	private void onLogin(AppEvent event) {

		// forwardToView(userView, event);
	}

	private void registerUser(User user) {
		service.registerUser(user, new AsyncCallback<Boolean>() {

			@Override
			public void onSuccess(Boolean result) {
				if (result)
					MessageBox.info("Registration", "User registraion is successfull. An activation url is sent to your mail.", null);
				else
					MessageBox.alert("Registration", "User registraion failed.", null);
			}

			@Override
			public void onFailure(Throwable caught) {
				// TODO Auto-generated method stub

			}
		});

	}

}
