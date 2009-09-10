package org.maksud.gwt.app.maksudapp.client.overlay;

import java.util.Date;

import com.extjs.gxt.ui.client.data.BaseModel;

public class FileModel extends BaseModel {

	// private Long id;
	// private String filename;
	// private long filesize;
	// private String filetype;
	// private UserData uploader;
	// private Date date;

	/**
	 * 
	 */
	private static final long serialVersionUID = 3714092182998811208L;

	public FileModel() {
	}

	public FileModel(Long id, String filename, long filesize, String filetype, UserModel uploader, Date date) {
		super();
		set("id", id);
		set("filename", filename);
		set("filesize", filesize);
		set("filetype", filetype);
		set("uploader", uploader);
		set("date", date);
	}

	public Long getId() {
		return get("id");
	}

	public void setId(Long id) {
		set("id", id);
	}

	public String getFilename() {
		return get("filename");
	}

	public void setFilename(String filename) {
		set("filename", filename);
	}

	public long getFilesize() {
		return get("filesize");
	}

	public void setFilesize(long filesize) {
		set("filesize", filesize);
	}

	public String getFiletype() {
		return get("filetype");
	}

	public void setFiletype(String filetype) {
		set("filetype", filetype);
	}

	public UserModel getUploader() {
		return get("uploader");
	}

	public void setUploader(UserModel uploader) {
		set("uploader", uploader);
	}

	public Date getDate() {
		return get("date");
	}

	public void setDate(Date date) {
		set("date", date);
	}
}
