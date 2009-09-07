package org.maksud.gwt.app.maksudapp.client.ui;

import java.util.ArrayList;
import java.util.List;

import org.maksud.gwt.app.maksudapp.client.BasicRPC;
import org.maksud.gwt.app.maksudapp.client.overlay.*;

import com.extjs.gxt.ui.client.Style.HorizontalAlignment;
import com.extjs.gxt.ui.client.store.ListStore;
import com.extjs.gxt.ui.client.widget.ContentPanel;
import com.extjs.gxt.ui.client.widget.LayoutContainer;
import com.extjs.gxt.ui.client.widget.grid.ColumnConfig;
import com.extjs.gxt.ui.client.widget.grid.ColumnData;
import com.extjs.gxt.ui.client.widget.grid.ColumnModel;
import com.extjs.gxt.ui.client.widget.grid.Grid;
import com.extjs.gxt.ui.client.widget.grid.GridCellRenderer;
import com.extjs.gxt.ui.client.widget.layout.FitLayout;
import com.extjs.gxt.ui.client.widget.layout.FlowLayout;
import com.extjs.gxt.ui.client.widget.table.NumberCellRenderer;
import com.google.gwt.i18n.client.DateTimeFormat;
import com.google.gwt.i18n.client.NumberFormat;
import com.google.gwt.user.client.Element;
import com.google.gwt.user.client.rpc.AsyncCallback;

public class UserGridSample extends LayoutContainer {

	@Override
	protected void onRender(Element parent, int index) {
		super.onRender(parent, index);
		setLayout(new FlowLayout(10));

		final NumberFormat currency = NumberFormat.getCurrencyFormat();
		final NumberFormat number = NumberFormat.getFormat("0.00");
		final NumberCellRenderer<Grid<UserEntity>> numberRenderer = new NumberCellRenderer<Grid<UserEntity>>(currency);

		GridCellRenderer<UserEntity> change = new GridCellRenderer<UserEntity>() {
			public String render(UserEntity model, String property, ColumnData config, int rowIndex, int colIndex, ListStore<UserEntity> store, Grid<UserEntity> grid) {
				double val = (Double) model.get(property);
				String style = val < 0 ? "red" : "green";
				return "<span style='color:" + style + "'>" + number.format(val) + "</span>";
			}
		};

		GridCellRenderer<UserEntity> gridNumber = new GridCellRenderer<UserEntity>() {
			public String render(UserEntity model, String property, ColumnData config, int rowIndex, int colIndex, ListStore<UserEntity> store, Grid<UserEntity> grid) {
				return numberRenderer.render(null, property, model.get(property));
			}
		};

		final List<ColumnConfig> configs = new ArrayList<ColumnConfig>();

		ColumnConfig column = new ColumnConfig();
		column.setId("name");
		column.setHeader("Company");
		column.setWidth(200);
		configs.add(column);

		column = new ColumnConfig();
		column.setId("symbol");
		column.setHeader("Symbol");
		column.setWidth(100);
		configs.add(column);

		column = new ColumnConfig();
		column.setId("last");
		column.setHeader("Last");
		column.setAlignment(HorizontalAlignment.RIGHT);
		column.setWidth(75);
		column.setRenderer(gridNumber);
		configs.add(column);

		column = new ColumnConfig("change", "Change", 100);
		column.setAlignment(HorizontalAlignment.RIGHT);
		column.setRenderer(change);
		configs.add(column);

		column = new ColumnConfig("date", "Last Updated", 100);
		column.setAlignment(HorizontalAlignment.RIGHT);
		column.setDateTimeFormat(DateTimeFormat.getShortDateFormat());
		configs.add(column);

		final ListStore<UserEntity> store = new ListStore<UserEntity>();
		
		
		BasicRPC.Util.getInstance().getUsers(new AsyncCallback<List<UserEntity>>() {
			
			@Override
			public void onSuccess(List<UserEntity> result) {
				// TODO Auto-generated method stub
				store.add(result);
				ColumnModel cm = new ColumnModel(configs);

				ContentPanel cp = new ContentPanel();
				cp.setBodyBorder(false);
				//cp.setIcon(Examples.ICONS.table());
				cp.setHeading("Basic Grid");
				cp.setButtonAlign(HorizontalAlignment.CENTER);
				cp.setLayout(new FitLayout());
				cp.setSize(600, 300);

				Grid<UserEntity> grid = new Grid<UserEntity>(store, cm);
				grid.setStyleAttribute("borderTop", "none");
				grid.setAutoExpandColumn("name");
				grid.setBorders(true);
				grid.setStripeRows(true);
				cp.add(grid);

				add(cp);
				
			}
			
			@Override
			public void onFailure(Throwable caught) {
				// TODO Auto-generated method stub
				
			}
		});
	}
}