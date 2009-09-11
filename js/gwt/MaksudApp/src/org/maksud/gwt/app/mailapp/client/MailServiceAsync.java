package org.maksud.gwt.app.mailapp.client;

import java.util.List;

import org.maksud.gwt.app.common.client.gxtmodel.Folder;
import org.maksud.gwt.app.common.client.gxtmodel.MailItem;

import com.google.gwt.user.client.rpc.AsyncCallback;

public interface MailServiceAsync {
	public void getMailFolders(String userId, AsyncCallback<Folder> callback);
	  public void getMailItems(Folder folder, AsyncCallback<List<MailItem>> callback);
}
