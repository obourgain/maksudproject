package org.maksud.gwt.maxwebservice.server.servlets;

import java.io.IOException;
import java.io.InputStream;
import java.util.Date;

import javax.jdo.PersistenceManager;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.apache.commons.fileupload.FileItemIterator;
import org.apache.commons.fileupload.FileItemStream;
import org.apache.commons.fileupload.FileUploadBase.SizeLimitExceededException;
import org.apache.commons.fileupload.servlet.ServletFileUpload;
import org.apache.commons.io.IOUtils;

import com.google.appengine.api.datastore.Blob;
import com.google.appengine.api.datastore.KeyFactory;

public class TimeZoneUploader extends HttpServlet {
    private static final long serialVersionUID = 2066442822396319950L;

    @Override
    protected void doPost(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException {
        try {

            resp.setContentType("text/html");
            ServletFileUpload upload = new ServletFileUpload();
            upload.setSizeMax(500000);

            try {
                FileItemIterator iterator = upload.getItemIterator(req);
                while (iterator.hasNext()) {
                    FileItemStream item = iterator.next();
                    InputStream in = item.openStream();

                    if (item.isFormField()) {
                    }
                    else {
                        try {
                            //PersistenceManager pm = PMF.get().getPersistenceManager();

                            // UserEntity user = (UserEntity) pm.getObjectById(UserEntity.class, KeyFactory.createKey(UserEntity.class.getSimpleName(), "maksud"));

                            // if (user == null) {

                            // }

                            // UploadedFile fileEntity = new UploadedFile();
                            // fileEntity.setUploader(user.getId());

                            byte[] data = IOUtils.toByteArray(in);
                            // fileEntity.setData(new Blob(data));
                            // fileEntity.setDate(new Date());
                            // fileEntity.setFilename(item.getName());
                            // fileEntity.setFilesize(data.length);
                            // fileEntity.setFiletype(item.getContentType());

                            // Save The file into database
                            // pm.makePersistent(fileEntity);

                        }
                        catch (Exception e) {

                        }
                        finally {
                            IOUtils.closeQuietly(in);
                        }

                    }
                }
            }
            catch (SizeLimitExceededException e) {

            }
        }
        catch (Exception ex) {
            throw new ServletException(ex);
        }
    }
}
