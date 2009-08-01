package org.maksud.gwt.app.maksudapp.client;

import com.extjs.gxt.ui.client.Style.LayoutRegion;
import com.extjs.gxt.ui.client.Style.Scroll;
import com.extjs.gxt.ui.client.util.Margins;
import com.extjs.gxt.ui.client.widget.ContentPanel;
import com.extjs.gxt.ui.client.widget.Viewport;
import com.extjs.gxt.ui.client.widget.Window;
import com.extjs.gxt.ui.client.widget.button.Button;
import com.extjs.gxt.ui.client.widget.button.ToolButton;
import com.extjs.gxt.ui.client.widget.layout.BorderLayout;
import com.extjs.gxt.ui.client.widget.layout.BorderLayoutData;
import com.extjs.gxt.ui.client.widget.layout.MarginData;
import com.google.gwt.core.client.EntryPoint;

import com.google.gwt.user.client.ui.RootPanel;

public class MaksudApp implements EntryPoint {

	public void onModuleLoad() {

		BorderLayout borderLayout = new BorderLayout();

		ContentPanel west = new ContentPanel();
		ContentPanel south = new ContentPanel();
		ContentPanel center = new ContentPanel();
		center.setHeading("BorderLayout Example");
		center.setScrollMode(Scroll.AUTOX);

		BorderLayoutData southData = new BorderLayoutData(LayoutRegion.SOUTH,
				100);
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

		RootPanel.get().add(viewport);
	}
}
