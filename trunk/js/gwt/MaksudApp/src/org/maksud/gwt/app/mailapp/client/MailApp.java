package org.maksud.gwt.app.mailapp.client;

import org.maksud.gwt.app.mailapp.client.mvc.AppController;
import org.maksud.gwt.app.mailapp.client.mvc.ContactController;
import org.maksud.gwt.app.mailapp.client.mvc.MailController;
import org.maksud.gwt.app.mailapp.client.mvc.TaskController;

import com.extjs.gxt.ui.client.GXT;
import com.extjs.gxt.ui.client.Registry;
import com.extjs.gxt.ui.client.mvc.Dispatcher;
import com.extjs.gxt.ui.client.util.Theme;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.core.client.GWT;
import com.google.gwt.user.client.rpc.ServiceDefTarget;
import com.google.gwt.user.client.ui.Button;

/**
 * Entry point classes define <code>onModuleLoad()</code>.
 */
public class MailApp implements EntryPoint {
	private Button clickMeButton;

	 public static final String SERVICE = "mailservice";
	  
	  public void onModuleLoad() {
	    //GXT.setDefaultTheme(Theme.GRAY, true);

	    MailServiceAsync service = (MailServiceAsync) GWT.create(MailService.class);
	    ServiceDefTarget endpoint = (ServiceDefTarget) service;
	    String moduleRelativeURL = SERVICE;
	    endpoint.setServiceEntryPoint(moduleRelativeURL);
	    Registry.register(SERVICE, service);

	    Dispatcher dispatcher = Dispatcher.get();
	    dispatcher.addController(new AppController());
	    dispatcher.addController(new MailController());
	    dispatcher.addController(new TaskController());
	    dispatcher.addController(new ContactController());

	    dispatcher.dispatch(AppEvents.Login);
	    
	    GXT.hideLoadingPanel("loading");
	  }

}
