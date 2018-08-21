/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import java.io.File;
import java.io.IOException;
import java.util.Enumeration;
import java.util.HashMap;
import java.util.Map;
import java.util.zip.ZipEntry;
import java.util.zip.ZipFile;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.PortabilityHint;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class XLSXFile {

    ZipFile zip;
    File file;
    Map<String, XLSXPackagePart> entries = new HashMap<String, XLSXPackagePart>();
    ObjectFactory factory;
    public XLSXFile(File file, ObjectFactory factory) throws IOException {
        this.file = file;
        this.factory = factory;
        zip = new ZipFile(file);
        Enumeration<? extends ZipEntry> e = zip.entries();
        while (e.hasMoreElements()) {
            ZipEntry r = e.nextElement();
            XLSXPackagePart p = createXLSXPackagePart(r);
            this.entries.put("/"+r.getName(), p);
        }
        for (XLSXPackagePart xLSXPackagePart : entries.values()) {
            xLSXPackagePart.compile();
        }
    }

    public XLSXPackagePart createXLSXPackagePart(ZipEntry r) {
        String n = "/"+r.getName();
        if (n.matches("/xl/workbook\\.xml")) {
            return new XLSXWorkbookPart(this, r, factory);
        }
        if (n.matches("/xl/worksheets/sheet.*\\.xml")) {
            return new XLSXSheetPart(this, r, factory);
        }
        if (n.matches("/xl/drawings/drawing.*\\.xml")) {
            return new XLSXDrawingPart(this, r, factory);
        }
        if (n.matches("/xl/media/.*")) {
            return new XLSXMediaPart(this, r, factory);
        }
        return new XLSXPackagePart(this, r, factory);
    }

    public XLSXPackagePart findEntry(String path) {
        XLSXPackagePart r = entries.get(path);
        if(r==null){
            ZipEntry e = zip.getEntry(path.substring(1));
        }
        return r;
    }
    
    public XLSXPackagePart getEntry(String path) {
        XLSXPackagePart t = findEntry(path);
        if(t==null){
            throw new net.vpc.upa.exceptions.NoSuchUPAElementException("XlsxPartNotFound",path);
        }
        return t;
    }

    public XLSXWorkbookPart getWorkbook() {
        return (XLSXWorkbookPart) getEntry("/xl/workbook.xml");
    }

    @Override
    public String toString() {
        return "XLSXFile{" + file + '}';
    }
    
}
