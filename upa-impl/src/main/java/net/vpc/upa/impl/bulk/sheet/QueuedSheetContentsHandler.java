/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.sheet;

import java.io.IOException;
import java.util.ArrayList;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.impl.bulk.xml.BlockingVal;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class QueuedSheetContentsHandler implements SheetContentsHandlerExt {

    private static final Logger log = Logger.getLogger(QueuedSheetContentsHandler.class.getName());
    private ArrayList<Object> values = new ArrayList<Object>();
    int rowNum;
    int minColumns;
    boolean skipEmptyRows;
    private BlockingQueue<BlockingVal> queue;

    public QueuedSheetContentsHandler(int minColumns, boolean skipEmptyRows, int bufferSize) {
        queue = new ArrayBlockingQueue<BlockingVal>(bufferSize);
        this.minColumns = minColumns;
        this.skipEmptyRows = skipEmptyRows;
    }

    public void startRow(int rowNum) {
        values.clear();
        ensureColumnsCount(0);
        this.rowNum = rowNum;
    }

    public void endRow() {
        try {
            if (skipEmptyRows) {
                boolean empty = true;
                for (Object o : values) {
                    if (o != null) {
                        empty = false;
                        break;
                    }
                }
                if (empty) {
                    return;
                }
            }
            queue.put(new BlockingVal(BlockingVal.TYPE_VALUE, values.toArray()));
        } catch (InterruptedException ex) {
            log.log(Level.SEVERE, null, ex);
        }
    }

    public void cell(int col, int row, String cellReference, String formattedValue, xssfDataType type, Object value) {
        ensureColumnsCount(col);
        values.set(col, value);
    }

    public void startSheet(int sheetIndex) {

    }

    public void endSheet() {
    }

    public void startDocument() {

    }

    public void endDocument() {
        try {
            queue.put(new BlockingVal(BlockingVal.TYPE_EOF, null));
        } catch (InterruptedException ex) {
            log.log(Level.SEVERE, null, ex);
        }
    }

    public void picture(int col, int row, XLSXDrawingPicture pic) {
        try {
            ensureColumnsCount(col);
            values.set(col, pic.getMedia().getInputStream());
        } catch (IOException ex) {
            log.log(Level.SEVERE, null, ex);
            try {
                queue.put(new BlockingVal(BlockingVal.TYPE_THROWABLE, ex));
            } catch (InterruptedException ex1) {
                log.log(Level.SEVERE, null, ex1);
            }
        }
    }

    protected void ensureColumnsCount(int col) {
        while (values.size() <= col || values.size() <= minColumns) {
            values.add(null);
        }
    }

    public void headerFooter(String text, boolean isHeader, String tagName) {
    }

    public BlockingQueue<BlockingVal> getQueue() {
        return queue;
    }

    public void throwError(Throwable ex) {
        log.log(Level.SEVERE, null, ex);
        try {
            getQueue().put(new BlockingVal(BlockingVal.TYPE_THROWABLE, ex));
        } catch (InterruptedException ex1) {
            log.log(Level.SEVERE, null, ex1);
        }
    }
}
