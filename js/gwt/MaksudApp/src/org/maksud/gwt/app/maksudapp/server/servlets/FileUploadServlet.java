package org.maksud.gwt.app.maksudapp.server.servlets;

import java.io.*;
import java.util.Date;

import javax.jdo.PersistenceManager;
import javax.servlet.*;
import javax.servlet.http.*;

import org.apache.commons.fileupload.*;
import org.apache.commons.fileupload.FileUploadBase.SizeLimitExceededException;
import org.apache.commons.fileupload.servlet.ServletFileUpload;
import org.apache.commons.io.IOUtils;
import org.maksud.gwt.app.maksudapp.client.utility.MAResponseResult;
import org.maksud.gwt.app.maksudapp.client.utility.MAServerResponse;
import org.maksud.gwt.app.maksudapp.server.data.PMF;
import org.maksud.gwt.app.maksudapp.server.data.entities.FileEntity;
import org.maksud.gwt.app.maksudapp.server.data.entities.UserEntity;

import com.google.appengine.api.datastore.Blob;
import com.google.appengine.api.datastore.KeyFactory;

public class FileUploadServlet extends HttpServlet {

	public void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
		try {
			MAServerResponse maResp = new MAServerResponse();

			// res.setContentType("application/octet-stream");
			res.setContentType("text/html");
			ServletFileUpload upload = new ServletFileUpload();
			upload.setSizeMax(500000);

			PrintWriter out = res.getWriter();

			try {
				FileItemIterator iterator = upload.getItemIterator(req);
				while (iterator.hasNext()) {
					FileItemStream item = iterator.next();
					InputStream in = item.openStream();

					if (item.isFormField()) {
						// out.println("Got a form field: " +
						// item.getFieldName());
					} else {
						try {
							PersistenceManager pm = PMF.get().getPersistenceManager();

							UserEntity user = (UserEntity) pm.getObjectById(UserEntity.class, KeyFactory.createKey(UserEntity.class.getSimpleName(), "maksud"));

							FileEntity fileEntity = new FileEntity();
							fileEntity.setUploader(user);

							byte[] data = IOUtils.toByteArray(in);
							fileEntity.setData(new Blob(data));
							fileEntity.setDate(new Date());
							fileEntity.setFilename(item.getName());
							fileEntity.setFilesize(data.length);
							fileEntity.setFiletype(item.getContentType());

							// Save The file into database
							pm.makePersistent(fileEntity);

							maResp.setResult(MAResponseResult.Success);

							/*
							 * for (int i = 0; i < file.length; i++) {
							 * out.write((file[i] & 0xFF)); }
							 */
							// out.write(fileContents);
							// out.print(fileContents);
							// out.print();
						} catch (Exception e) {
							maResp.setResult(MAResponseResult.Fail);
							maResp.setData(e.getMessage());
						} finally {
							IOUtils.closeQuietly(in);
						}

					}
				}
			} catch (SizeLimitExceededException e) {
				maResp.setResult(MAResponseResult.Fail);
				maResp.setData(e.getMessage());
				// out.print(e.getMessage());
				// out.println("You exceeded the maximu size (" +
				// e.getPermittedSize() + ") of the file (" + e.getActualSize()
				// + ")");
			}
		} catch (Exception ex) {
			throw new ServletException(ex);
		}
	}
}
