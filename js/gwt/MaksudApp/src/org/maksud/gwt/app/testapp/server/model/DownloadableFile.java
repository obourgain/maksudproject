package org.maksud.gwt.app.testapp.server.model;

import java.io.Serializable;

public class DownloadableFile implements Serializable {
	private byte[] content;
	private String filename;
	private String mimeType;

	// ... accessors ...
}