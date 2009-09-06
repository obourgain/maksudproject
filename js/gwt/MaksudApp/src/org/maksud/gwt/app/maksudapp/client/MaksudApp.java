package org.maksud.gwt.app.maksudapp.client;

import org.maksud.gwt.app.maksudapp.client.content.GWTFileUpload;

import com.extjs.gxt.ui.client.Style.LayoutRegion;
import com.extjs.gxt.ui.client.Style.Scroll;
import com.extjs.gxt.ui.client.core.XDOM;
import com.extjs.gxt.ui.client.util.Margins;
import com.extjs.gxt.ui.client.widget.ContentPanel;
import com.extjs.gxt.ui.client.widget.MessageBox;
import com.extjs.gxt.ui.client.widget.Viewport;
import com.extjs.gxt.ui.client.widget.layout.BorderLayout;
import com.extjs.gxt.ui.client.widget.layout.BorderLayoutData;
import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.rpc.AsyncCallback;
import com.google.gwt.user.client.ui.RootPanel;

public class MaksudApp implements EntryPoint {

	private Viewport viewport;

	public void onModuleLoad() {

		RootPanel rootPanel = RootPanel.get();

		BorderLayout borderLayout = new BorderLayout();

		ContentPanel west = new ContentPanel();
		ContentPanel south = new ContentPanel();
		ContentPanel center = new ContentPanel();
		center.setHeading("BorderLayout Example");
		center.setScrollMode(Scroll.AUTOX);

		BorderLayoutData southData = new BorderLayoutData(LayoutRegion.SOUTH, 100);
		southData.setCollapsible(true);
		southData.setFloatable(true);
		southData.setHideCollapseTool(true);
		southData.setSplit(true);
		southData.setMargins(new Margins(5, 5, 0, 5));

		BorderLayoutData westData = new BorderLayoutData(LayoutRegion.WEST, 150);
		westData.setSplit(true);
		westData.setCollapsible(true);
		westData.setMargins(new Margins(5));

		BorderLayoutData centerData = new BorderLayoutData(LayoutRegion.CENTER);
		centerData.setMargins(new Margins(5, 0, 5, 0));

		Viewport viewport = new Viewport();
		viewport.setLayout(borderLayout);

		viewport.add(south, southData);
		viewport.add(center, centerData);
		viewport.add(west, westData);

		String id = Window.Location.getParameter("id");
		if (id == null) {
			id = XDOM.getBody().getId();
		}

		if (id.equals("fileupload")) {
			GWTFileUpload fupload = new GWTFileUpload();
			center.add(fupload);
		}

		BasicRPC.Util.getInstance().dummy(new AsyncCallback<String>() {

			@Override
			public void onSuccess(String result) {
				MessageBox.info("RPC Returned", result, null);
			}

			@Override
			public void onFailure(Throwable caught) {
				MessageBox.alert("RPC Failure", "Problem", null);

			}
		});

		RootPanel.get().add(viewport);
	}
}
