package org.maksud.dms.client;

import org.maksud.dms.client.model.DocFolder;

import com.google.gwt.user.client.rpc.AsyncCallback;

public interface DirectoryServiceAsync {
	public void getFileList(String root, AsyncCallback<DocFolder[]> callback);
}
