package org.maksud.gwt.app.common.client.widget;

import com.google.gwt.user.client.ui.AbsolutePanel;
import com.google.gwt.user.client.ui.Composite;
import com.google.gwt.user.client.ui.HTML;
import com.google.gwt.user.client.ui.VerticalPanel;

public class ReCaptchaField extends Composite {

	private String recaptcha_div;
	private HTML recaptcha;

	public ReCaptchaField(String div) {
		AbsolutePanel panel = new AbsolutePanel();
		recaptcha = new HTML("<div id='" + div + "'></div>");
		panel.add(recaptcha);
		initWidget(panel);

		recaptcha_div = div;
	}

	public void init() {
		init(recaptcha_div);
	}

	private native void init(String id)/*-{
		$wnd.recaptcha_initialize(id);
	}-*/;

	public native String getResponse()/*-{
		return $wnd.Recaptcha.get_response();
	}-*/;

	public native String getChallenge()/*-{
		return $wnd.Recaptcha.get_challenge();
	}-*/;
}
