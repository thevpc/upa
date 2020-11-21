/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk.sheet;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.bulk.DataWriter;
import net.thevpc.upa.bulk.SheetFormatter;
import org.apache.poi.openxml4j.exceptions.OpenXML4JException;
import org.xml.sax.SAXException;

/**
 *
 * @author vpc
 */
public class PoiExternalFormatHelper implements ExternalFormatHelper {

    public String[] getXLSFileSheetNames(File file, ObjectFactory factory) throws IOException {
        try {
            return XLSXHelper.getXLSFileSheetNames(file, factory);
        } catch (OpenXML4JException ex) {
            throw new IOException(ex);
        } catch (SAXException ex) {
            throw new IOException(ex);
        } catch (InterruptedException ex) {
            throw new IOException(ex);
        }
    }

    public void parseXLSFile(File file, Integer sheetIndex, SheetContentsHandlerExt contentsHandler, ObjectFactory factory) throws IOException {
        try {
            XLSXHelper.parseXLSFile(file, sheetIndex, contentsHandler, factory);
        } catch (OpenXML4JException ex) {
            throw new IOException(ex);
        } catch (SAXException ex) {
            throw new IOException(ex);
        } catch (InterruptedException ex) {
            throw new IOException(ex);
        }
    }

    @Override
    public void parseXLSFile(InputStream file, Integer sheetIndex, SheetContentsHandlerExt contentsHandler, ObjectFactory factory) throws IOException {
        try {
            XLSXHelper.parseXLSFile(file, sheetIndex, contentsHandler, factory);
        } catch (OpenXML4JException ex) {
            throw new IOException(ex);
        } catch (SAXException ex) {
            throw new IOException(ex);
        } catch (InterruptedException ex) {
            throw new IOException(ex);
        }
    }

    @Override
    public DataWriter createXLSWriter(File target, SheetFormatter formatter) {
        DefaultSheetWriter w = new DefaultSheetWriter(formatter, (File) target);
        w.setDataRowConverter(formatter.getDataRowConverter());
        return w;
    }

    @Override
    public DataWriter createXLSWriter(OutputStream target, SheetFormatter formatter) {
        DefaultSheetWriter w = new DefaultSheetWriter(formatter, target);
        w.setDataRowConverter(formatter.getDataRowConverter());
        return w;
    }
}
