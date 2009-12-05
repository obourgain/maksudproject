package org.maksud.gwt.maxwebservice.client;

public class GoogleAnalyticsHelper {

    //pageTracker._trackEvent('Videos', 'Play', 'Gone With the Wind');

    //_trackEvent(category, action, optional_label, optional_value)
    public static native void trackEvent(String category, String action)/*-{
        try
        {
            if($wnd.pageTracker._trackEvent(category, action))
            {
                $wnd.alert("Successful!");
            }
            else
            {
                $wnd.alert("Failed!");
            }
        }
        catch(err)
        {
            $wnd.alert(err);
        }
    }-*/;
    
    public static native void trackEvent(String category, String action, String optional_label)/*-{
        try
        {
            if($wnd.pageTracker._trackEvent(category, action, optional_label))
            {
                $wnd.alert("Successful!");
            }
            else
            {
                $wnd.alert("Failed!");
            }
        }
        catch(err)
        {
            $wnd.alert(err);
        }
    }-*/;
    
    public static native void trackEvent(String category, String action, String optional_label, int optional_value)/*-{
        try
        {
            if($wnd.pageTracker._trackEvent(category, action, optional_label, optional_value))
            {
                $wnd.alert("Successful!");
            }
            else
            {
                $wnd.alert("Failed!");
            }
        }
        catch(err)
        {
            $wnd.alert(err);
        }
    }-*/;
}
