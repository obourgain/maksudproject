package org.maksud.dms.server;

import java.io.File;
import java.util.Date;

import org.maksud.dms.client.model.DocFolder;

public class FolderUtility {

	public static DocFolder[] getFolders(String root, String rel_path) {
		DocFolder[] docs = new DocFolder[0];
		try {
			
			String path = root + rel_path;
			File f = new File(path);
			File[] files = f.listFiles();

			docs = new DocFolder[files.length];

			System.out.println("Total files in this folder " + files.length);
			for (int i = 0; i < files.length; i++) {
				docs[i] = new DocFolder();

				if (files[i].isDirectory())
					docs[i].setFilename(files[i].getAbsolutePath().substring(path.length()));
				else
					docs[i].setFilename(files[i].getName());

				docs[i].setTitle(files[i].getName());
				docs[i].setFolder(files[i].isDirectory());
				docs[i].setModified(new Date(files[i].lastModified()));

				try {
					docs[i].setType(files[i].getName().substring(files[i].getName().lastIndexOf('.')));
				} catch (Exception e) {
					docs[i].setType("");
				}

				System.out.println(files[i].getName());
			}
			return docs;
		} catch (Exception e) {
			System.out.println(e.getMessage());
		}
		return docs;
	}
}
