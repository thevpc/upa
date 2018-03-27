/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.text;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.Reader;
import java.util.List;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.TextFixedWidthColumn;
import net.vpc.upa.impl.bulk.AbstractDataReader;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultTextFixedWidthReader extends AbstractDataReader {

    private DefaultTextFixedWidthParser p;
    private BufferedReader reader;
    private String line;

    public DefaultTextFixedWidthReader(DefaultTextFixedWidthParser p, Reader reader) {
        super(new TextFixedWidthColumn(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]), p.isContainsHeader(), p.getSkipRows());
        this.p = p;
        this.reader = (reader instanceof BufferedReader) ? ((BufferedReader) reader) : new BufferedReader(reader);
        prepareHeader();
    }

    public boolean hasNext() {
        try {
            line = reader.readLine();
            return line != null;
        } catch (IOException ex) {
            throw new RuntimeException(ex);
        }
    }

    private String validateValue(String s) {
        if (p.isTrimValues()) {
            return s.trim();
        } else {
            return s;
        }
    }

    @Override
    protected Object[] nextRowArray() {
        int lastIndex = 0;
        List<TextFixedWidthColumn> columns1 = p.getColumns();
        Object[] values = new Object[columns1.size()];
        for (int i = 0; i < columns1.size(); i++) {
            TextFixedWidthColumn columnInfo = columns1.get(i);
            int s = columnInfo.getSkippedColumns();
            int w = columnInfo.getColumnWidth();
            int from = lastIndex + s;
            int to = from + w;

            if (to > line.length()) {
                to = line.length();
            }
            if (from > line.length()) {
                from = line.length();
            }
            String rawValue = validateValue(line.substring(from, to));
            values[i] = rawValue;
            lastIndex = to;
        }
        return values;
    }
}
