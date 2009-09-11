/*
 * Ext GWT - Ext for GWT
 * Copyright(c) 2007-2009, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */
package org.maksud.gwt.app.mailapp.client.mvc;

import org.maksud.gwt.app.mailapp.client.AppEvents;
import org.maksud.gwt.app.mailapp.client.widget.TaskPanel;

import com.extjs.gxt.ui.client.Registry;
import com.extjs.gxt.ui.client.mvc.AppEvent;
import com.extjs.gxt.ui.client.mvc.Controller;
import com.extjs.gxt.ui.client.mvc.View;
import com.extjs.gxt.ui.client.widget.LayoutContainer;

public class TaskView extends View {

  private TaskPanel panel;

  public TaskView(Controller controller) {
    super(controller);
  }

  @Override
  protected void initialize() {
    panel = new TaskPanel();
  }

  @Override
  protected void handleEvent(AppEvent event) {
    if (event.getType() == AppEvents.NavTasks) {
      LayoutContainer wrapper = (LayoutContainer) Registry.get(AppView.CENTER_PANEL);
      wrapper.removeAll();
      wrapper.add(panel);
      wrapper.layout();
    }
  }
}
