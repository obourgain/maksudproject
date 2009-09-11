package org.maksud.gwt.app.testapp.server.model;

import javax.jdo.annotations.IdGeneratorStrategy;
import javax.jdo.annotations.IdentityType;
import javax.jdo.annotations.NotPersistent;
import javax.jdo.annotations.PersistenceCapable;
import javax.jdo.annotations.Persistent;
import javax.jdo.annotations.PrimaryKey;


/**
 * 
 * @see max To declare a Java class as capable of being stored and retrieved
 *      from the datastore with JDO, give the class a @PersistenceCapable
 *      annotation.
 */

@PersistenceCapable(identityType = IdentityType.APPLICATION)
public class ADummyEntityClass {

	/**
	 * A data class must have one field dedicated to storing the primary key of
	 * the corresponding datastore entity. You can choose between 4 different
	 * kinds of key fields, each using a different value type and annotations.
	 * (See Creating Data: Keys for more information.) The simplest key field is
	 * a long integer value that is automatically populated by JDO with a value
	 * unique across all other instances of the class when the object is saved
	 * to the datastore for the first time. Long integer keys use a @PrimaryKey
	 * annotation, and a @Persistent(valueStrategy =
	 * IdGeneratorStrategy.IDENTITY) annotation:
	 */
	@PrimaryKey
	@Persistent(valueStrategy = IdGeneratorStrategy.IDENTITY)
	private Long id;

	/**
	 * Fields of the data class that are to be stored in the datastore must be
	 * declared as persistent fields. To declare a field as persistent, give it
	 * a @Persistent annotation:
	 */
	@Persistent
	private String name;

	/**
	 * To declare a field as not persistent (it does not get stored in the
	 * datastore, and is not restored when the object is retrieved), give it a @NotPersistent
	 * annotation.
	 */
	@NotPersistent
	private String aha;

	/**
	 * A field value can contain an instance of a Serializable class, storing
	 * the serialized value of the instance in a single property value of the
	 * type Blob. To tell JDO to serialize the value, the field uses the
	 * annotation @Persistent(serialized=true). Blob values are not indexed and
	 * cannot be used in query filters or sort orders.
	 */
	@Persistent(serialized = "true")
	private DownloadableFile file;

	/**
	 * 
	 * A field value that is an instance of a @PersistenceCapable class creates
	 * an owned one-to-one relationship between two objects. A field that is a
	 * collection of such references creates an owned one-to-many relationship.
	 */

	@Persistent
	private ContactInfo myContactInfo;

	// For more details see:
	// http://code.google.com/appengine/docs/java/datastore/dataclasses.html

}
