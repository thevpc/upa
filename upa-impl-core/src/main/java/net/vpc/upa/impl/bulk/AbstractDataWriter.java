/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.DataRowConverter;
import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.DataRow;
import net.vpc.upa.bulk.DataWriter;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public abstract class AbstractDataWriter implements DataWriter {

    protected DataColumn[] parserColumns;
//    protected DataColumn[] header;
    protected DataColumn columnPrototype;
    protected boolean headerSupported;
    protected long rowIndex;
    protected boolean started;
    protected DataRowConverter dataRowConverter;

    public AbstractDataWriter(DataColumn columnPrototype, boolean headerSupported, DataColumn[] parserColumns) {
        this.parserColumns = parserColumns;
        this.columnPrototype = columnPrototype;
        this.headerSupported = headerSupported;
    }

    public DataRowConverter getDataRowConverter() {
        return dataRowConverter;
    }

    public void setDataRowConverter(DataRowConverter dataRowConverter) {
        this.dataRowConverter = dataRowConverter;
    }

    public void writeObject(Object row) {
        DataRowConverter os = getDataRowConverter();
        if (os == null) {
            throw new UPAIllegalArgumentException("Missing DataRowConverter");
        }
        writeRow(os.objectToRow(row));
    }

    public void startDocument() {
        if(dataRowConverter!=null){
            DataColumn[] columns = dataRowConverter.getColumns();
            if(columns==null){
                columns=new DataColumn[0];
            }
            this.parserColumns=columns;
        }
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

    protected DataRow createRow(Object[] values){
        if(parserColumns.length!=values.length){
            if(parserColumns.length>values.length){
                //complete with nulls
                Object[] values2=new Object[parserColumns.length];
                System.arraycopy(values,0,values2,0,values.length);
                values=values2;
            }else{
                throw new UPAException("InvalidRowLength",parserColumns.length,values.length);
            }
        }
        return new DefaultDataRow(parserColumns,values);
    }

    public void writeRow(Object[] values) {
        if (!started) {
            started = true;
            startDocument();
        }
        DataRow row = createRow(values);
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
