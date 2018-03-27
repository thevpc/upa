/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */


package net.vpc.upa.impl.bulk.sheet;

//import com.sun.rowset.internal.Row;
import java.io.File;
import java.io.InputStream;
import java.util.logging.Level;
import java.util.logging.Logger;

import net.vpc.upa.ObjectFactory;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.SheetColumn;
import net.vpc.upa.bulk.SheetParser;
import net.vpc.upa.impl.bulk.AbstractDataReader;
import net.vpc.upa.impl.bulk.xml.BlockingVal;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultSheetSAXReader extends AbstractDataReader {

    private static final Logger log = Logger.getLogger(DefaultSheetSAXReader.class.getName());
    SheetParser parser;
    private Thread thread;
    QueuedSheetContentsHandler sheetContentsHandler;
    private boolean eof = false;
    private Object[] lastValue;
    private Object source;
    private ObjectFactory factory;

    public DefaultSheetSAXReader(SheetParser p, InputStream inputStream, ObjectFactory factory) {
        super(new SheetColumn(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]), p.isContainsHeader(), p.getSkipRows());
        init(p, inputStream, factory);
    }

    public DefaultSheetSAXReader(SheetParser p, File file, ObjectFactory factory) {
        super(new SheetColumn(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]), p.isContainsHeader(), p.getSkipRows());
        init(p, file, factory);
    }

    private void init(SheetParser p, Object source, ObjectFactory factory) {
        this.parser = p;
        this.source = source;
        this.factory = factory;
        if(source==null){
            throw new NullPointerException("Invalid source");
        }
        sheetContentsHandler = new QueuedSheetContentsHandler(Math.max(p.getColumns().size(), p.getMinColumns()), p.isSkipEmptyRows(), 10);
        prepareHeader();
    }

    public Object getSource() {
        return source;
    }

    public boolean hasNext() {
        if (eof) {
            return false;
        }
        if (thread == null) {
            log.log(Level.FINE,"Creating Thread DefaultExcelDataSAXReaderThread");
            thread = new DefaultExcelDataSAXReaderThreadThread(this, factory);
            thread.start();

        }
        BlockingVal take;
        try {
            take = sheetContentsHandler.getQueue().take();
        } catch (InterruptedException ex) {
            throw new RuntimeException(ex);
        }
        if (take == null) {
            eof = true;
            return false;
        }
        switch (take.getBlockingValType()) {
            case BlockingVal.TYPE_EOF: {
                eof = true;
                return false;
            }
            case BlockingVal.TYPE_THROWABLE: {
                eof = true;
                if (take.getValue() instanceof RuntimeException) {
                    throw (RuntimeException) take.getValue();
                } else {
                    throw new RuntimeException((Throwable) take.getValue());
                }
            }
            case BlockingVal.TYPE_VALUE: {
                lastValue = (Object[]) take.getValue();
                return true;
            }
        }
        lastValue = null;
        return false;
    }

    @Override
    protected Object[] nextRowArray() {
        return lastValue;
    }

}
