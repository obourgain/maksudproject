package org.maksud.dms.client.model;

import java.io.Serializable;
import java.util.Date;

public class DocFolder implements Serializable{

	private String path;
	private String filename;
	private String title;
	private String type;
	private boolean folder;
	private Date modified;

	public DocFolder() {

	}

	public String getPath() {
		return path;
	}

	public void setPath(String path) {
		this.path = path;
	}

	public String getFilename() {
		return filename;
	}

	public void setFilename(String filename) {
		this.filename = filename;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getType() {
		return type;
	}

	public void setType(String type) {
		this.type = type;
	}

	public boolean isFolder() {
		return folder;
	}

	public void setFolder(boolean isFolder) {
		this.folder = isFolder;
	}

	public Date getModified() {
		return modified;
	}

	public void setModified(Date modified) {
		this.modified = modified;
	}

}
