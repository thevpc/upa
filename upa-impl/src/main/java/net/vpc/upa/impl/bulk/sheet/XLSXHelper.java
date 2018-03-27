/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.PortabilityHint;

import net.vpc.upa.impl.util.IOUtils;
import net.vpc.upa.impl.util.xml.XmlFactory;
import net.vpc.upa.impl.util.xml.XmlSAXParser;
import org.apache.poi.openxml4j.exceptions.InvalidFormatException;
import org.apache.poi.openxml4j.exceptions.OpenXML4JException;
import org.apache.poi.openxml4j.opc.OPCPackage;
import org.apache.poi.ss.usermodel.DataFormatter;
import org.apache.poi.xssf.eventusermodel.ReadOnlySharedStringsTable;
import org.apache.poi.xssf.eventusermodel.XSSFReader;
import org.apache.poi.xssf.model.StylesTable;
import org.xml.sax.SAXException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#", name = "suppress")
public class XLSXHelper {

    private static final Logger log = Logger.getLogger(XLSXHelper.class.getName());

    public static String[] getXLSFileSheetNames(File file, ObjectFactory factory) throws IOException, OpenXML4JException, SAXException, InterruptedException {
        log.log(Level.FINE, "OPCPackage.opening : {0}", file.getPath());
        OPCPackage pkg = OPCPackage.open(file.getPath());
        log.log(Level.FINE, "OPCPackage open successfully. now parsing");
        XSSFReader reader = new XSSFReader(pkg);
        StylesTable styles = reader.getStylesTable();
        ReadOnlySharedStringsTable sharedStrings = new ReadOnlySharedStringsTable(pkg);
        log.log(Level.FINE, "creating XLSXFile");
        XLSXFile xFile = new XLSXFile(file, factory);
        List<XLSXSheetPart> sheets = xFile.getWorkbook().getSheets();
        ArrayList<String> names = new ArrayList<String>();
        for (XLSXSheetPart sheet : sheets) {
            names.add(sheet.sheetName);
        }
        return names.toArray(new String[names.size()]);
    }

    public static void parseXLSFile(File file, Integer sheetIndex, SheetContentsHandlerExt contentsHandler, ObjectFactory factory) throws IOException, OpenXML4JException, SAXException, InterruptedException {

        log.log(Level.FINE, "OPCPackage.opening : {0}", file.getPath());
        OPCPackage pkg = OPCPackage.open(file.getPath());
        log.log(Level.FINE, "OPCPackage open successfully. now parsing");
        XSSFReader reader = new XSSFReader(pkg);
        StylesTable styles = reader.getStylesTable();
        ReadOnlySharedStringsTable sharedStrings = new ReadOnlySharedStringsTable(pkg);
        log.log(Level.FINE, "creating XLSXFile");
        XLSXFile xFile = new XLSXFile(file, factory);
        List<XLSXSheetPart> sheets = xFile.getWorkbook().getSheets();
        log.log(Level.FINE, "parsed {0} sheets", sheets.size());
        contentsHandler.startDocument();
        for (XLSXSheetPart sh : sheets) {
            log.log(Level.FINE, "Processing sheets", sh);
            if (sheetIndex == null || sheetIndex.equals(sh.getSheetIndex() - 1)) {
                log.log(Level.FINE, "Parsing sheet : {0}", sh.getSheetIndex());
                List<XLSXDrawingPicture> pics = new ArrayList<XLSXDrawingPicture>();
                List<XLSXDrawingPart> drawings = sh.getDrawings();
                for (XLSXDrawingPart xLSXDrawingPart : drawings) {
                    pics.addAll(xLSXDrawingPart.getPictures());
                }
                XmlSAXParser handler = new XSSFSheetXMLHandlerExt(styles, sharedStrings, contentsHandler, new DataFormatter(), false, xFile, pics, sh.getSheetIndex());
                XmlFactory xmlfactory = factory.createObject(XmlFactory.class);
                xmlfactory.parse(reader.getSheet(sh.getRelationshipId()),handler);
            } else {
                log.log(Level.FINE, "Ignoring sheet : {0}", sh.getSheetIndex());
            }
        }
        log.log(Level.FINE, "End document");
        contentsHandler.endDocument();
    }

    public static void parseXLSFile(InputStream stream, Integer sheetIndex, SheetContentsHandlerExt contentsHandler, ObjectFactory factory) throws InvalidFormatException, IOException, OpenXML4JException, SAXException, InterruptedException {
        File f = File.createTempFile("upa-", ".xlsx");
        IOUtils.copyToFile(stream, f, 1024);
        parseXLSFile(f, sheetIndex, contentsHandler, factory);
        f.delete();
    }
}
