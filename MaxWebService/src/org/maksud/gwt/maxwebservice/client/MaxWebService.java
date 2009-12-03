package org.maksud.gwt.maxwebservice.client;

import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.maps.client.InfoWindowContent;
import com.google.gwt.maps.client.MapWidget;
import com.google.gwt.maps.client.control.LargeMapControl;
import com.google.gwt.maps.client.event.MarkerClickHandler;
import com.google.gwt.maps.client.geom.LatLng;
import com.google.gwt.maps.client.overlay.Marker;
import com.google.gwt.user.client.ui.RootPanel;

public class MaxWebService implements EntryPoint {
    private MapWidget          map;
    public static final String mapKey = "ABQIAAAAh6DdyRsqG5CV5oCb3WsQPBTmCjuWZ4T7i_snh5KYRyySQLjymhR6UhlfMvv5ijxguE7jUK9Y3DNkZA";

    public void onModuleLoad() {
        LatLng dhakaity = LatLng.newInstance(23 + 43.0 / 60.0, 90 + 25.0 / 60.0);
        map = new MapWidget(dhakaity, 8);
        map.setSize("100%", "100%");
        map.addControl(new LargeMapControl());

        Marker marker = new Marker(dhakaity);
        marker.addMarkerClickHandler(new MarkerClickHandler() {
            @Override
            public void onClick(MarkerClickEvent event) {
                JavaScriptHelper.alert("Marker");
                GoogleAnalyticsHelper.trackEvent("Marker", event.toString());
            }
        });
        map.addOverlay(marker);

        // Add an info window to highlight a point of interest
        map.getInfoWindow().open(map.getCenter(), new InfoWindowContent("World's Largest Ball of Sisal Twine"));
        RootPanel.get("gmap").add(map);
    }
}
