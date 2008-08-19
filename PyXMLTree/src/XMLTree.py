#!/usr/bin/env python


#Common part. Just including gtk
import sys, string
from xml.dom import minidom, Node


try:
    import pygtk
    pygtk.require("2.0")
except:
    pass
try:
    import gtk
    import gtk.glade
except:
    sys.exit(1)

class XMLTree:
    """This is an XML Test GTK application"""
    def __init__(self):
        #Set the Glade file
        self.gladefile = "../glade/pyxml.glade"
        self.wTree = gtk.glade.XML(self.gladefile, "MainWindow") 
        
        #Create our dictionay and connect it
        dic = { "delete_event" : self.delete_event,
                "on_MainWindow_destroy" : gtk.main_quit }
        self.wTree.signal_autoconnect(dic)
        
        #Get Tree Widget
        self.treeView = self.wTree.get_widget("xmlTree")
        #Add Columns
        self.AddWineListColumn("Name", 0)

        #Create the listStore Model to use with the wineView
        self.treestore = gtk.TreeStore(str)
        #Attatch the model to the treeView
        self.treeView.set_model(self.treestore) 
           
        #outFile = sys.stdout
        doc = minidom.parse('DPF.xml')
        rootNode = doc.documentElement
        self.walk(rootNode, None)
        
        
    def walk(self, parent, present):                               # [1]
        for node in parent.childNodes:
            if node.nodeType == Node.ELEMENT_NODE:
                ## Write out the element name.
                ## Defer till Getting Node Attributes
                ##children = self.treestore.append(present,[node.nodeName])

                ##outFile.write('Element: %s\n' % node.nodeName)
                ## Write out the attributes.
                attrs = node.attributes                             # [2]
                for attrName in attrs.keys():
                    attrNode = attrs.get(attrName)
                    attrValue = attrNode.nodeValue
                    #self.treestore.append(children, [attrName])
                    #printLevel(outFile, level + 2)
                    ##outFile.write('Attribute -- Name: %s  Value: %s\n' % (attrName, attrValue))
                    
                children = self.treestore.append(present, [attrs.get("name").nodeValue])
                # Walk over any text nodes in the current node.
                content = []                                        # [3]
                for child in node.childNodes:
                    if child.nodeType == Node.TEXT_NODE:
                        content.append(child.nodeValue)
                if content:
                    strContent = string.join(content)
                    #printLevel(outFile, level)
                    ##outFile.write('Content: "')
                    ##outFile.write(strContent)
                    ##outFile.write('"\n')
                # Walk the child nodes.
                children
                self.walk(node, children)

    def AddWineListColumn(self, title, columnId):      
        column = gtk.TreeViewColumn(title, gtk.CellRendererText(), text=columnId)
        column.set_resizable(True)
        column.set_sort_column_id(columnId)
        self.treeView.append_column(column)

    def delete_event(self, widget, event, data=None):
        gtk.main_quit()
        return False
    
if __name__ == "__main__":
    hwg = XMLTree()
    gtk.main()
