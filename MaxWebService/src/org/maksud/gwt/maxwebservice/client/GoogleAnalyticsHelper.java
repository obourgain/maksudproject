package org.maksud.gwt.maxwebservice.client;

public class GoogleAnalyticsHelper {

    //pageTracker._trackEvent('Videos', 'Play', 'Gone With the Wind');

    //_trackEvent(category, action, optional_label, optional_value)
    public static native void trackEvent(String category, String action)/*-{
        try
        {
            $wnd.pageTracker._trackEvent(category, action);
        }
        catch(err)
        {
            $wnd.alert(err);
        }
    }-*/;
    
    public static native void trackEvent(String category, String action, String optional_label)/*-{
        try
        {
            $wnd.pageTracker._trackEvent(category, action, optional_label);
        }
        catch(err)
        {
            $wnd.alert(err);
        }
    }-*/;
    
    public static native void trackEvent(String category, String action, String optional_label, int optional_value)/*-{
        try
        {
            $wnd.pageTracker._trackEvent(category, action, optional_label, optional_value);
        }
        catch(err)
        {
            $wnd.alert(err);
        }
    }-*/;
}
