package org.maksud.dms.client;

import org.maksud.dms.client.model.DocFolder;

import com.google.gwt.core.client.GWT;
import com.google.gwt.user.client.rpc.RemoteService;
import com.google.gwt.user.client.rpc.RemoteServiceRelativePath;

@RemoteServiceRelativePath("DirectoryService")
public interface DirectoryService extends RemoteService {
	/**
	 * Utility class for simplifying access to the instance of async service.
	 */
	public static class Util {
		private static DirectoryServiceAsync instance;

		public static DirectoryServiceAsync getInstance() {
			if (instance == null) {
				instance = GWT.create(DirectoryService.class);
			}
			return instance;
		}
	}

	public DocFolder[] getFileList(String root);
}
