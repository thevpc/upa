/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import java.io.File;
import java.io.InputStream;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.bulk.sheet.XLSXHelper;

/**
 *
 * @author vpc
 */
@PortabilityHint(target = "C#",name = "suppress")
class DefaultExcelDataSAXReaderThreadThread extends Thread {
    private static final Logger log = Logger.getLogger(DefaultExcelDataSAXReaderThreadThread.class.getName());
    private final DefaultSheetSAXReader outer;

    public DefaultExcelDataSAXReaderThreadThread(final DefaultSheetSAXReader outer) {
        super("DefaultExcelDataSAXReaderThread");
        this.outer = outer;
    }

    @Override
    public void run() {
        log.log(Level.FINE, "Start parsing source asynchronously : {0}", outer.source);
        try {
            if (outer.source instanceof File) {
                XLSXHelper.parseXLSFile((File) outer.source, outer.parser.getSheetIndex(), outer.sheetContentsHandler);
            } else {
                XLSXHelper.parseXLSFile((InputStream) outer.source, outer.parser.getSheetIndex(), outer.sheetContentsHandler);
            }
        } catch (Throwable ex) {
            log.log(Level.SEVERE, "parseXLSFile " + outer.source + " failed", ex);
            outer.sheetContentsHandler.throwError(ex);
        }
    }
    
}
