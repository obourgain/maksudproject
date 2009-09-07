package org.maksud.gwt.app.maksudapp.server;

import java.util.ArrayList;
import java.util.Collection;
import java.util.Iterator;
import java.util.List;
import java.util.ListIterator;

import org.maksud.gwt.app.maksudapp.client.BasicRPC;
import org.maksud.gwt.app.maksudapp.client.overlay.UserEntity;

import com.google.gwt.user.server.rpc.RemoteServiceServlet;

public class BasicRPCImpl extends RemoteServiceServlet implements BasicRPC {

	@Override
	public List<UserEntity> getUsers() {
		List<UserEntity> lst = new ArrayList<UserEntity>();
		
		UserEntity demo = new UserEntity();
		demo.setName("maksud");
		demo.setLogin("login");
		lst.add(demo);
		
		return lst;
	}
}
