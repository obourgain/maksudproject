package org.maksud.gwt.app.dsestockapp.client.widget;

import org.maksud.gwt.app.dsestockapp.client.DSEStockManager;

import com.extjs.gxt.ui.client.Style.ButtonArrowAlign;
import com.extjs.gxt.ui.client.Style.ButtonScale;
import com.extjs.gxt.ui.client.Style.IconAlign;
import com.extjs.gxt.ui.client.Style.LayoutRegion;
import com.extjs.gxt.ui.client.util.Margins;
import com.extjs.gxt.ui.client.widget.ContentPanel;
import com.extjs.gxt.ui.client.widget.LayoutContainer;
import com.extjs.gxt.ui.client.widget.Status;
import com.extjs.gxt.ui.client.widget.TabItem;
import com.extjs.gxt.ui.client.widget.TabPanel;
import com.extjs.gxt.ui.client.widget.Viewport;
import com.extjs.gxt.ui.client.widget.button.Button;
import com.extjs.gxt.ui.client.widget.button.ButtonGroup;
import com.extjs.gxt.ui.client.widget.layout.BorderLayout;
import com.extjs.gxt.ui.client.widget.layout.BorderLayoutData;
import com.extjs.gxt.ui.client.widget.layout.FitLayout;
import com.extjs.gxt.ui.client.widget.layout.TableData;
import com.extjs.gxt.ui.client.widget.menu.Menu;
import com.extjs.gxt.ui.client.widget.menu.MenuItem;
import com.extjs.gxt.ui.client.widget.toolbar.FillToolItem;
import com.extjs.gxt.ui.client.widget.toolbar.LabelToolItem;
import com.extjs.gxt.ui.client.widget.toolbar.ToolBar;

public class DSEWebUI extends Viewport {

	private Status charCount;
	private Status wordCount;
	private Status status;

	public DSEWebUI() {
		super();

		this.setLayout(new BorderLayout());

		createToolPanel(this);
		// createWest(viewport);
		createCenter(this);
		createStatusPanel(this);

	}

	private void createToolPanel(Viewport viewport) {
		ToolBar toolBar = new ToolBar();

		ButtonGroup group = new ButtonGroup(3);
		group.setHeading("Users");
		toolBar.add(group);

		Button btn = new Button("Paste", DSEStockManager.ICONS.add32());
		btn.addStyleName("x-btn-as-arrow");
		btn.setScale(ButtonScale.LARGE);
		btn.setIconAlign(IconAlign.TOP);
		btn.setArrowAlign(ButtonArrowAlign.BOTTOM);
		TableData data = new TableData();
		data.setRowspan(3);

		group.add(btn, data);

		btn = new Button("Format", DSEStockManager.ICONS.add32());
		btn.setScale(ButtonScale.LARGE);
		btn.setIconAlign(IconAlign.TOP);
		btn.setArrowAlign(ButtonArrowAlign.BOTTOM);
		Menu menu = new Menu();
		menu.add(new MenuItem("Cool"));
		btn.setMenu(menu);
		group.add(btn, data);

		btn = new Button("Copy", DSEStockManager.ICONS.add16());
		menu = new Menu();
		menu.add(new MenuItem("Copy me"));
		btn.setMenu(menu);
		group.add(btn);

		btn = new Button("Cut", DSEStockManager.ICONS.add16());
		group.add(btn);

		btn = new Button("Paste", DSEStockManager.ICONS.add16());
		group.add(btn);

		group = new ButtonGroup(3);
		group.setHeading("Clipboard");
		toolBar.add(group);

		btn = new Button("Paste", DSEStockManager.ICONS.add32());
		btn.addStyleName("x-btn-as-arrow");
		btn.setScale(ButtonScale.LARGE);
		btn.setIconAlign(IconAlign.TOP);
		btn.setArrowAlign(ButtonArrowAlign.BOTTOM);
		data = new TableData();
		data.setRowspan(3);

		group.add(btn, data);

		btn = new Button("Format", DSEStockManager.ICONS.add32());
		btn.setScale(ButtonScale.LARGE);
		btn.setIconAlign(IconAlign.TOP);
		btn.setArrowAlign(ButtonArrowAlign.BOTTOM);
		menu = new Menu();
		menu.add(new MenuItem("Cool"));
		btn.setMenu(menu);
		group.add(btn, data);

		btn = new Button("Copy", DSEStockManager.ICONS.add16());
		menu = new Menu();
		menu.add(new MenuItem("Copy me"));
		btn.setMenu(menu);
		group.add(btn);

		btn = new Button("Cut", DSEStockManager.ICONS.add16());
		group.add(btn);

		btn = new Button("Paste", DSEStockManager.ICONS.add16());
		group.add(btn);

		BorderLayoutData data2 = new BorderLayoutData(LayoutRegion.NORTH, 96);
		data2.setMargins(new Margins());
		viewport.add(toolBar, data2);

	}

	private void createUsersPanel(Viewport viewport) {
		BorderLayoutData eastData = new BorderLayoutData(LayoutRegion.WEST, 150);
		eastData.setSplit(true);
		eastData.setCollapsible(true);

		// eastData.setMargins(new Margins(5));

		ContentPanel east = new ContentPanel();
		east.setTitle("User Information");
		viewport.add(east, eastData);
	}

	private void createTabContentsPanel(Viewport viewport) {
		TabPanel advanced = new TabPanel();
		// advanced.setSize(600, 250);

		advanced.setMinTabWidth(115);
		advanced.setResizeTabs(true);
		advanced.setAnimScroll(true);
		advanced.setTabScroll(true);
		advanced.setCloseContextMenu(true);

		BorderLayoutData data = new BorderLayoutData(LayoutRegion.CENTER);
		data.setMargins(new Margins(0, 0, 0, 5));
		viewport.add(advanced, data);

		addTab(advanced);
	}

	private void addTab(TabPanel advanced) {
		TabItem item = new TabItem();
		item.setText("New Tab ");

		item.addText("Tab Body ");
		item.addStyleName("pad-text");
		advanced.add(item);
	}

	private void createCenter(Viewport viewport) {
		LayoutContainer center = new LayoutContainer();
		center.setLayout(new FitLayout());

		BorderLayoutData data = new BorderLayoutData(LayoutRegion.CENTER);
		data.setMargins(new Margins(5, 5, 5, 5));

		viewport.add(center, data);

		Viewport viewport2 = new Viewport();
		center.add(viewport2);
		viewport2.setLayout(new BorderLayout());

		// createToolPanel(viewport2);

		createUsersPanel(viewport2);
		createTabContentsPanel(viewport2);

	}

	private void createStatusPanel(Viewport viewport) {
		ToolBar toolBar = new ToolBar();

		status = new Status();
		status.setText("Not writing");
		status.setWidth(150);
		toolBar.add(status);
		toolBar.add(new FillToolItem());

		charCount = new Status();
		charCount.setWidth(100);
		charCount.setText("0 Chars");
		charCount.setBox(true);
		toolBar.add(charCount);
		toolBar.add(new LabelToolItem(" "));
		wordCount = new Status();
		wordCount.setWidth(100);
		wordCount.setText("0 Words");
		wordCount.setBox(true);
		toolBar.add(wordCount);

		BorderLayoutData data = new BorderLayoutData(LayoutRegion.SOUTH, 24);
		data.setMargins(new Margins());
		viewport.add(toolBar, data);
	}
}
