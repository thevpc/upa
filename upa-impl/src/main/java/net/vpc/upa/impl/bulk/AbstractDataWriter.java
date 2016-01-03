/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk;

import net.vpc.upa.bulk.DataSerializer;
import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.DataRow;
import net.vpc.upa.bulk.DataWriter;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public abstract class AbstractDataWriter implements DataWriter {

    protected DataColumn[] parserColumns;
//    protected DataColumn[] header;
    protected DataColumn columnPrototype;
    protected boolean headerSupported;
    protected long rowIndex;
    protected boolean started;
    protected DataSerializer dataSerializer;

    public AbstractDataWriter(DataColumn columnPrototype, boolean headerSupported, DataColumn[] parserColumns) {
        this.parserColumns = parserColumns;
        this.columnPrototype = columnPrototype;
        this.headerSupported = headerSupported;
    }

    public DataSerializer getDataSerializer() {
        return dataSerializer;
    }

    public void setDataSerializer(DataSerializer dataSerializer) {
        this.dataSerializer = dataSerializer;
    }

    public void writeObject(Object row) {
        DataSerializer os = getDataSerializer();
        if (os == null) {
            throw new IllegalArgumentException("Missing ObjectSerializer");
        }
        DataRow r = os.objecttoRow(row, parserColumns);
        writeRow(r.getValues());
    }

    public void startDocument() {
        if (headerSupported) {
            Object[] r = new Object[parserColumns.length];
            for (int i = 0; i < r.length; i++) {
                DataColumn c = parserColumns[i];
                String t = null;
                if (c != null) {
                    t = c.getTitle();
                    if (t == null) {
                        t = c.getName();
                    }
                }
                if (t == null) {
                    t = "#" + (i + 1);
                }
                r[i] = t;
            }
            writeRow(r);
        }
    }

    public void writeRow(Object[] values) {
        if (!started) {
            started = true;
            startDocument();
        }
        DataRow row = new DefaultDataRow(parserColumns, values);
        startRow(row);
        for (int i = 0; i < values.length; i++) {
            Object v = values[i];
            writeCell(rowIndex, row, i, v);
        }
        endRow(row);
        rowIndex++;
    }

    public long getRowIndex() {
        return rowIndex;
    }

    protected void setRowIndex(long rowIndex) {
        this.rowIndex = rowIndex;
    }

    protected abstract void startRow(DataRow row);

    protected abstract void writeCell(long rowIndex, DataRow row, int cellIndex, Object cell);

    protected abstract void endRow(DataRow row);
}
