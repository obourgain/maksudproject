package org.maksud.dms.client;

import org.maksud.dms.client.model.DocFolder;

import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.event.dom.client.ClickEvent;
import com.google.gwt.event.dom.client.ClickHandler;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.rpc.AsyncCallback;
import com.google.gwt.user.client.ui.Button;
import com.google.gwt.user.client.ui.RootPanel;

/**
 * Entry point classes define <code>onModuleLoad()</code>.
 */
public class DMSDemo implements EntryPoint {
	private Button clickMeButton;

	public void onModuleLoad() {
		DirectoryServiceAsync service = DirectoryService.Util.getInstance();

		service.getFileList("/", new AsyncCallback<DocFolder[]>() {

			@Override
			public void onSuccess(DocFolder[] result) {
				System.out.println("Server Returned: " + result.length + " files");
				for (int i = 0; i < result.length; i++) {
					System.out.println(result[i].getFilename());
				}
			}

			@Override
			public void onFailure(Throwable caught) {
				// TODO Auto-generated method stub

			}
		});
	}
}
