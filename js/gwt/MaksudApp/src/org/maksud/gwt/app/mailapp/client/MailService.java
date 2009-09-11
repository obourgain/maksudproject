package org.maksud.gwt.app.mailapp.client;

import java.util.List;

import org.maksud.gwt.app.common.client.gxtmodel.Folder;
import org.maksud.gwt.app.common.client.gxtmodel.MailItem;

import com.google.gwt.core.client.GWT;
import com.google.gwt.user.client.rpc.RemoteService;
import com.google.gwt.user.client.rpc.RemoteServiceRelativePath;

@RemoteServiceRelativePath("MailService")
public interface MailService extends RemoteService {
	/**
	 * Utility class for simplifying access to the instance of async service.
	 */
	public static class Util {
		private static MailServiceAsync instance;
		public static MailServiceAsync getInstance(){
			if (instance == null) {
				instance = GWT.create(MailService.class);
			}
			return instance;
		}
	}
	
	  public Folder getMailFolders(String userId);
	  public List<MailItem> getMailItems(Folder folder);
}
