/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import java.io.File;
import java.io.InputStream;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.PortabilityHint;

/**
 *
 * @author taha.bensalah@gmail.com
 */
@PortabilityHint(target = "C#",name = "suppress")
class DefaultExcelDataSAXReaderThreadThread extends Thread {
    private static final Logger log = Logger.getLogger(DefaultExcelDataSAXReaderThreadThread.class.getName());
    private final DefaultSheetSAXReader saxReader;
    private final ObjectFactory factory;

    public DefaultExcelDataSAXReaderThreadThread(DefaultSheetSAXReader saxReader, ObjectFactory factory) {
        super("DefaultExcelDataSAXReaderThread");
        this.saxReader = saxReader;
        this.factory = factory;
    }

    @Override
    public void run() {
        log.log(Level.FINE, "Start parsing source asynchronously : {0}", saxReader.getSource());
        try {
            if (saxReader.getSource() instanceof File) {
                factory.createObject(ExternalFormatHelper.class).parseXLSFile((File) saxReader.getSource(), saxReader.parser.getSheetIndex(), saxReader.sheetContentsHandler, factory);
            } else {
                factory.createObject(ExternalFormatHelper.class).parseXLSFile((InputStream) saxReader.getSource(), saxReader.parser.getSheetIndex(), saxReader.sheetContentsHandler, factory);
            }
        } catch (Throwable ex) {
            log.log(Level.SEVERE, "parseXLSFile " + saxReader.getSource() + " failed", ex);
            saxReader.sheetContentsHandler.throwError(ex);
        }
    }
    
}
