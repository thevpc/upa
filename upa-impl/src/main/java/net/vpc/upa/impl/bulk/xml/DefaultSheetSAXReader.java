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


package net.vpc.upa.impl.bulk.xml;

//import com.sun.rowset.internal.Row;
import java.io.File;
import java.io.InputStream;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.SheetColumn;
import net.vpc.upa.bulk.SheetParser;
import net.vpc.upa.impl.bulk.AbstractDataReader;
import net.vpc.upa.impl.bulk.sheet.QueuedSheetContentsHandler;

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
    Object source;

    public DefaultSheetSAXReader(SheetParser p, InputStream inputStream) {
        super(new SheetColumn(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]), p.isContainsHeader(), p.getSkipRows());
        init(p, inputStream);
    }

    public DefaultSheetSAXReader(SheetParser p, File file) {
        super(new SheetColumn(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]), p.isContainsHeader(), p.getSkipRows());
        init(p, file);
    }

    private void init(SheetParser p, Object source) {
        this.parser = p;
        this.source = source;
        if(source==null){
            throw new NullPointerException("Invalid source");
        }
        sheetContentsHandler = new QueuedSheetContentsHandler(Math.max(p.getColumns().size(), p.getMinColumns()), p.isSkipEmptyRows(), 10);
        prepareHeader();
    }

    public boolean hasNext() {
        if (eof) {
            return false;
        }
        if (thread == null) {
            log.log(Level.FINE,"Creating Thread DefaultExcelDataSAXReaderThread");
            thread = new DefaultExcelDataSAXReaderThreadThread(this);
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
