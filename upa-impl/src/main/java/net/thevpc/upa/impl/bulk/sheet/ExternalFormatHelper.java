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

/**
 *
 * @author vpc
 */
public interface ExternalFormatHelper {

    String[] getXLSFileSheetNames(File file, ObjectFactory factory) throws IOException;

    void parseXLSFile(File file, Integer sheetIndex, SheetContentsHandlerExt contentsHandler, ObjectFactory factory) throws IOException;

    void parseXLSFile(InputStream file, Integer sheetIndex, SheetContentsHandlerExt contentsHandler, ObjectFactory objectFactory) throws IOException;
    
    DataWriter createXLSWriter(File target, SheetFormatter formatter) ;
    
    DataWriter createXLSWriter(OutputStream target, SheetFormatter formatter) ;
}
