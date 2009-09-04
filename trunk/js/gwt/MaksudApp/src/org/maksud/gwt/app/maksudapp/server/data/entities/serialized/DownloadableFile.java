package org.maksud.gwt.app.maksudapp.server.data.entities.serialized;

import java.io.Serializable;

public class DownloadableFile implements Serializable {
	private byte[] content;
	private String filename;
	private String mimeType;

	// ... accessors ...
}