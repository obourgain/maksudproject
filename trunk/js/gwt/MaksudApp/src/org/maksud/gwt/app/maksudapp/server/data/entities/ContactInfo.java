package org.maksud.gwt.app.maksudapp.server.data.entities;

import javax.jdo.annotations.*;
import com.google.appengine.api.datastore.Key;

@PersistenceCapable(identityType = IdentityType.APPLICATION)
public class ContactInfo {
	@PrimaryKey
	@Persistent(valueStrategy = IdGeneratorStrategy.IDENTITY)
	private Key key;

	@Persistent
	private String streetAddress;

	@Persistent
	private String city;

	@Persistent
	private String stateOrProvince;

	@Persistent
	private String zipCode;

	// ... accessors ...
}