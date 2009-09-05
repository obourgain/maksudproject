package org.maksud.gwt.app.maksudapp.server.servlets.utility;

import java.io.*;
import javax.servlet.*;
import javax.servlet.http.*;

import org.apache.commons.fileupload.*;
import org.apache.commons.fileupload.FileUploadBase.SizeLimitExceededException;
import org.apache.commons.fileupload.servlet.ServletFileUpload;
import org.apache.commons.io.IOUtils;

public class FileUploadServlet extends HttpServlet {

	public void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
		try {
			res.setContentType("application/octet-stream");
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
						String fieldName = item.getFieldName();
						String fileName = item.getName();
						String contentType = item.getContentType();

						// out.println("--------------");
						// out.println("fileName = " + fileName);
						// out.println("field name = " + fieldName);
						// out.println("contentType = " + contentType);

						String fileContents = null;
						try {
							//fileContents = IOUtils.toString(in);
							// out.println("lenght: " + fileContents.length());
							// out.println(fileContents);

							byte[] file = IOUtils.toByteArray(in);
							for (int i = 0; i < file.length; i++)
							{
								out.write((file[i] & 0xFF));
							}
							//out.write(fileContents);
							//out.print(fileContents);
							// out.print();
						} finally {
							IOUtils.closeQuietly(in);
						}

					}
				}
			} catch (SizeLimitExceededException e) {
				//out.println("You exceeded the maximu size (" + e.getPermittedSize() + ") of the file (" + e.getActualSize() + ")");
			}
		} catch (Exception ex) {

			throw new ServletException(ex);
		}
	}
}
