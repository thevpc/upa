package net.vpc.upa.impl.bulk;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.DataDeserializer;
import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.DataReader;
import net.vpc.upa.bulk.DataRow;
import net.vpc.upa.bulk.ValueConverter;
import net.vpc.upa.bulk.ValueValidator;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.types.StringType;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public abstract class AbstractDataReader implements DataReader {

    protected DataColumn[] parserColumns;
    protected DataColumn[] header;
    protected DataColumn columnPrototype;
    protected boolean containsHeader;
    protected int skipRows;
    protected DataDeserializer objectDeserializer;

    public AbstractDataReader(DataColumn columnPrototype, DataColumn[] parserColumns, boolean containsHeader, int skipRows) {
        this.parserColumns = parserColumns;
        this.columnPrototype = columnPrototype;
        this.containsHeader = containsHeader;
        this.skipRows = skipRows;
    }

    public DataDeserializer getObjectDeserializer() {
        return objectDeserializer;
    }

    public void setObjectDeserializer(DataDeserializer objectDeserializer) {
        this.objectDeserializer = objectDeserializer;
    }

    protected void prepareHeader() {
        if (skipRows > 0) {
            int s = skipRows;
            while (s > 0) {
                if (hasNext()) {
                    nextHeader();
                }
                s--;
            }
        }
        if (containsHeader) {
            if (hasNext()) {
                header = nextHeader();
            } else {
                header = new DataColumn[parserColumns.length];
                for (int i = 0; i < header.length; i++) {
                    header[i] = (DataColumn) parserColumns[i].copy();
                    header[i].setIndex(i);
                }
            }
        } else {
            header = new DataColumn[parserColumns.length];
            for (int i = 0; i < header.length; i++) {
                header[i] = (DataColumn) parserColumns[i].copy();
                header[i].setIndex(i);
            }
        }

    }

    public DataColumn[] getColumns() {
        return header;
    }

    public Object readObject() {
        DataDeserializer od = getObjectDeserializer();
        if (od == null) {
            throw new UPAIllegalArgumentException("Missing Object deserializer");
        }
        return od.rowToObject(readRow());
    }

    public DataRow readRow() {
        Object[] rawValues = nextRowArray();
        DataColumn[] columns1 = getColumns();
        Object[] values = new Object[rawValues.length > header.length ? rawValues.length : header.length];
        for (int i = 0; i < values.length; i++) {
            DataColumn columnInfo = i < columns1.length ? (DataColumn) columns1[i] : null;

            Object rawValue = i < rawValues.length ? rawValues[i] : null;
            Object value = rawValue;
            if (columnInfo != null) {
                if (columnInfo.isTrimValue()) {
                    rawValue = rawValue == null ? null : ((rawValue instanceof String) ? ((String) rawValue).trim() : rawValue);
                }
                ValueConverter r = columnInfo.getRawValueConverter();
                if (r == null) {
                    if (columnInfo.getDataType() != null) {
                        value = ValueParser.parse(rawValue, columnInfo.getDataType());
                    }
                } else {
                    value = r.convert(rawValue);
                }
                r = columnInfo.getValueConverter();
                if (r != null) {
                    value = r.convert(value);
                }
                ValueValidator valueValidator = columnInfo.getValueValidator();
                if (valueValidator != null) {
                    valueValidator.validateValue(value);
                }
            } else {
                value = ValueParser.parse(rawValue, StringType.UNLIMITED);
            }
            values[i] = value;
        }
        return new DefaultDataRow(header, values);
    }

    protected abstract Object[] nextRowArray();

    protected DataColumn createColumn(int col) {
        DataColumn copy = (DataColumn) columnPrototype.copy();
        copy.setIndex(col);
        return copy;
    }

//    public Iterator<DataRow> iterator() {
//        return this;
//    }
    private DataColumn[] nextHeader() {
        Object[] all = nextRowArray();
        DataColumn[] columns = new DataColumn[all.length];
        for (int i = 0; i < columns.length; i++) {
            if (i < parserColumns.length && !StringUtils.isNullOrEmpty(parserColumns[i].getName())) {
                columns[i] = (DataColumn) parserColumns[i].copy();
            } else {
                columns[i] = createColumn(i);
                columns[i].setName(String.valueOf(all[i]));
            }
            columns[i].setTitle(String.valueOf(all[i]));
            columns[i].setIndex(i);
        }
        return columns;
    }

    public void remove() {
        throw new UnsupportedOperationException("Not supported.");
    }
}
