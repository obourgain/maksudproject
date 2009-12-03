package org.maksud.gwt.maxwebservice.client;

public class JavaScriptHelper {
    public static native void alert(String msg)/*-{
        $wnd.alert(msg);        
    }-*/;
}
