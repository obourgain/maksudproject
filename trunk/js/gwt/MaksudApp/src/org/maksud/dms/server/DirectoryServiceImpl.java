package org.maksud.dms.server;

import org.maksud.dms.client.DirectoryService;
import org.maksud.dms.client.model.DocFolder;

import com.google.gwt.user.server.rpc.RemoteServiceServlet;

public class DirectoryServiceImpl extends RemoteServiceServlet implements DirectoryService {

	@Override
	public DocFolder[] getFileList(String root) {
		DocFolder[] docFolder = new DocFolder[0];
		String base = getServletContext().getRealPath("/") + "files";
		System.out.println(base);
		try {
			docFolder = FolderUtility.getFolders(base, root);
			return docFolder;
		} catch (Exception e) {
			return docFolder;
		}
	}
}
