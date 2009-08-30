package org.maksud.gwt.app.maksudapp.server.utility;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.MalformedURLException;
import java.net.URL;

import com.google.gwt.http.client.Request;
import com.google.gwt.http.client.RequestBuilder;
import com.google.gwt.http.client.RequestCallback;
import com.google.gwt.http.client.RequestException;
import com.google.gwt.http.client.Response;

public class FetchUrlContents {

	public static String getContents(String addr) {
		String line = "";
		try {
			URL url = new URL("http://www.example.com/atom.xml");
			BufferedReader reader = new BufferedReader(new InputStreamReader(
					url.openStream()));

			while ((line = reader.readLine()) != null) {
				// ...
			}
			reader.close();

		} catch (MalformedURLException e) {
			// ...
		} catch (IOException e) {
			// ...
		}
		return line;
	}
	/*
	 * 
	 * public static Response
	 * 
	 * RequestBuilder builder = new RequestBuilder(RequestBuilder.GET,
	 * "../phprpc.php");
	 * 
	 * try { Request response = builder.sendRequest(null, new RequestCallback()
	 * {
	 * 
	 * @Override public void onError(Request request, Throwable exception) {
	 * textArea.setText("Error"); }
	 * 
	 * @Override public void onResponseReceived(Request request, Response
	 * response) { textArea.setText(response.getText()); } }); } catch
	 * (RequestException e) { // Code omitted for clarity }
	 */

}
