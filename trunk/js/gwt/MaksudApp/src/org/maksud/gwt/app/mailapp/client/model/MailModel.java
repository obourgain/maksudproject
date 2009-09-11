/*
 * Ext GWT - Ext for GWT
 * Copyright(c) 2007-2009, Ext JS, LLC.
 * licensing@extjs.com
 * 
 * http://extjs.com/license
 */
package org.maksud.gwt.app.mailapp.client.model;

import java.util.ArrayList;
import java.util.List;

import org.maksud.gwt.app.common.client.TestData;
import org.maksud.gwt.app.common.client.gxtmodel.Folder;
import org.maksud.gwt.app.common.client.gxtmodel.MailItem;

import com.extjs.gxt.ui.client.data.BaseTreeModel;

public class MailModel extends BaseTreeModel {

	private Folder inbox;
	private Folder sent;
	private Folder trash;

	public MailModel() {
		inbox = new Folder("Inbox");
		sent = new Folder("Sent Items");
		trash = new Folder("Trash");

		List<MailItem> items = TestData.getMailItems();
		int count = items.size();

		List<MailItem> inlist = new ArrayList<MailItem>();
		List<MailItem> sentlist = new ArrayList<MailItem>();

		for (int i = 0; i < count; i++) {
			MailItem item = (MailItem) items.get(i);
			if (i < (count / 2)) {
				inlist.add(item);
			} else {
				sentlist.add(item);
			}
		}

		inbox.set("children", inlist);
		sent.set("children", sentlist);
		trash.set("children", new ArrayList<MailItem>());

		add(inbox);
		add(sent);
		add(trash);

	}

	public Folder getInbox() {
		return inbox;
	}

}
