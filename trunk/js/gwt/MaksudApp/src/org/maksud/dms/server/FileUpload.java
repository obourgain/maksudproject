package org.maksud.dms.server;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.fileupload.FileItemIterator;
import org.apache.commons.fileupload.FileItemStream;
import org.apache.commons.fileupload.FileUploadBase.SizeLimitExceededException;
import org.apache.commons.fileupload.servlet.ServletFileUpload;
import org.apache.commons.io.IOUtils;

public class FileUpload extends HttpServlet {

	public void doGet(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
		res.getWriter().print("Test");
	}

	public void doPost(HttpServletRequest req, HttpServletResponse res) throws ServletException, IOException {
		try {

			String root = getServletContext().getRealPath("/") + "files";
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
					} else {
						try {

							String basename = item.getName();
							basename = basename.substring(basename.lastIndexOf("\\") + 1);

							File f = new File(root + "\\" + basename);
							f.createNewFile();
							FileOutputStream fos = new FileOutputStream(f);

							item.getName();
							byte[] data = IOUtils.toByteArray(in);
							fos.write(data);
							fos.close();

						} catch (Exception e) {
							out.print(e.getMessage());
						} finally {
							IOUtils.closeQuietly(in);
						}
					}
				}
			} catch (SizeLimitExceededException e) {
				out.print(e.getMessage());
			}

		} catch (Exception ex) {
			throw new ServletException(ex);
		}
	}
}
