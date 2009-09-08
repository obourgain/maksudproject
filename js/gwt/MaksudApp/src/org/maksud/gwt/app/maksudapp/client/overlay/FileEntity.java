package org.maksud.gwt.app.maksudapp.client.overlay;

import java.util.Date;

public class FileEntity {

	private Long id;
	private String filename;
	private long filesize;
	private String filetype;
	private UserEntity uploader;
	private Date date;

	public FileEntity() {
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getFilename() {
		return filename;
	}

	public void setFilename(String filename) {
		this.filename = filename;
	}

	public long getFilesize() {
		return filesize;
	}

	public void setFilesize(long filesize) {
		this.filesize = filesize;
	}

	public String getFiletype() {
		return filetype;
	}

	public void setFiletype(String filetype) {
		this.filetype = filetype;
	}

	public UserEntity getUploader() {
		return uploader;
	}

	public void setUploader(UserEntity uploader) {
		this.uploader = uploader;
	}

	public Date getDate() {
		return date;
	}

	public void setDate(Date date) {
		this.date = date;
	}
}
