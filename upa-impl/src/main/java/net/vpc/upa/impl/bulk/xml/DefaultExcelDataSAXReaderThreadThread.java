/*
 * To change this license header, choose License Headers in Project Properties.
 *
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
 * @author taha.bensalah@gmail.com
 */
@PortabilityHint(target = "C#",name = "suppress")
class DefaultExcelDataSAXReaderThreadThread extends Thread {
    private static final Logger log = Logger.getLogger(DefaultExcelDataSAXReaderThreadThread.class.getName());
    private final DefaultSheetSAXReader saxReader;

    public DefaultExcelDataSAXReaderThreadThread(DefaultSheetSAXReader saxReader) {
        super("DefaultExcelDataSAXReaderThread");
        this.saxReader = saxReader;
    }

    @Override
    public void run() {
        log.log(Level.FINE, "Start parsing source asynchronously : {0}", saxReader.source);
        try {
            if (saxReader.source instanceof File) {
                XLSXHelper.parseXLSFile((File) saxReader.source, saxReader.parser.getSheetIndex(), saxReader.sheetContentsHandler);
            } else {
                XLSXHelper.parseXLSFile((InputStream) saxReader.source, saxReader.parser.getSheetIndex(), saxReader.sheetContentsHandler);
            }
        } catch (Throwable ex) {
            log.log(Level.SEVERE, "parseXLSFile " + saxReader.source + " failed", ex);
            saxReader.sheetContentsHandler.throwError(ex);
        }
    }
    
}
