package org.maksud.gwt.maxwebservice.server.jdo;

import javax.jdo.annotations.IdGeneratorStrategy;
import javax.jdo.annotations.IdentityType;
import javax.jdo.annotations.PersistenceCapable;
import javax.jdo.annotations.Persistent;
import javax.jdo.annotations.PrimaryKey;

@PersistenceCapable(identityType = IdentityType.APPLICATION)
public class TimeZone {
    @PrimaryKey
    @Persistent(valueStrategy = IdGeneratorStrategy.IDENTITY)
    private Long   id;
    
    @Persistent
    private String zone;
    
    @Persistent
    private String name;
    
    @Persistent
    private double latitude;
    
    @Persistent
    private String longitude;
    
    

}
