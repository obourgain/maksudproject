package org.maksud.gwt.maxwebservice.client;

import com.google.gwt.core.client.EntryPoint;
import com.google.gwt.maps.client.InfoWindowContent;
import com.google.gwt.maps.client.MapWidget;
import com.google.gwt.maps.client.control.LargeMapControl;
import com.google.gwt.maps.client.geom.LatLng;
import com.google.gwt.maps.client.overlay.Marker;
import com.google.gwt.user.client.ui.RootPanel;

public class MaxWebService implements EntryPoint {
    private MapWidget map;

    public void onModuleLoad() {
        LatLng cawkerCity = LatLng.newInstance(23 + 43.0 / 60.0, 90 + 25.0 / 60.0);
        map = new MapWidget(cawkerCity, 8);
        map.setSize("100%", "100%");
        map.addControl(new LargeMapControl());

        map.addOverlay(new Marker(cawkerCity));

        // Add an info window to highlight a point of interest
        map.getInfoWindow().open(map.getCenter(), new InfoWindowContent("World's Largest Ball of Sisal Twine"));
        RootPanel.get("gmap").add(map);
    }
}
