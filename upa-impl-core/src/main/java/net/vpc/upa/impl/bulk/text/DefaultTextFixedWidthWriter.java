/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.text;

import net.vpc.upa.bulk.*;
import net.vpc.upa.impl.bulk.AbstractDataWriter;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.NumberType;

import java.io.BufferedWriter;
import java.io.IOException;
import java.io.Writer;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#", name = "suppress")
public class DefaultTextFixedWidthWriter extends AbstractDataWriter {

    private DefaultTextFixedWidthFormatter p;
    private BufferedWriter writer;
    private String newLine;

    public DefaultTextFixedWidthWriter(DefaultTextFixedWidthFormatter p, Writer writer) {
        super(new TextCSVColumn(), p.isWriteHeader(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]));
        this.p = p;
        this.writer = (writer instanceof BufferedWriter) ? ((BufferedWriter) writer) : new BufferedWriter(writer);
    }

    @Override
    public void startDocument() {
        String nl = p.getNewLine();
        if (nl == null) {
            nl = PlatformUtils.getSystemLineSeparator();
        }
        newLine = nl;
        if (p.getSkipRows() > 0) {
            write(newLine);
        }
        super.startDocument();
    }


    @Override
    protected void startRow(DataRow row) {
        if (row.getColumns().length != row.getValues().length) {
            throw new UPAException("InvalidColumnsCount", row.getColumns(), row.getValues().length);
        }
    }

    @Override
    protected void writeCell(long rowIndex, DataRow row, int cellIndex, Object cell) {
        TextFixedWidthColumn col = (TextFixedWidthColumn) row.getColumns()[cellIndex];
        int skippedColumns = col.getSkippedColumns();
        StringBuilder d = new StringBuilder(cell == null ? "" : cell.toString());
        String skippedColumnsChars = col.getSkippedColumnsChars();
        if (skippedColumnsChars == null || skippedColumnsChars.length() == 0) {
            skippedColumnsChars = " ";
        }
        int columnWidth = col.getColumnWidth();
        if (d.length() > columnWidth) {
            d.delete(columnWidth, d.length());
        }
        TextAlignment alignment = col.getTextAlignment();
        if (alignment == null) {
            if (col.getDataType() != null) {
                if (col.getDataType() instanceof NumberType) {
                    alignment = TextAlignment.RIGHT;
                } else {
                    alignment = TextAlignment.LEFT;
                }
            } else {
                if (cell != null && cell instanceof Number) {
                    alignment = TextAlignment.RIGHT;
                } else {
                    alignment = TextAlignment.LEFT;
                }
            }
        }
        switch (alignment) {
            case LEFT: {
                String whiteChars = col.getRightPaddingChars();
                if (whiteChars == null || whiteChars.isEmpty()) {
                    whiteChars = col.getDefaultPaddingChars();
                    if (whiteChars == null || whiteChars.isEmpty()) {
                        whiteChars = " ";
                    }
                }
                int v = 0;
                while (d.length() < columnWidth) {
                    d.append(whiteChars.charAt(v));
                    v = (v + 1) % whiteChars.length();
                }
                break;
            }
            case RIGHT: {
                String whiteChars = col.getLeftPaddingChars();
                if (whiteChars == null || whiteChars.isEmpty()) {
                    whiteChars = col.getDefaultPaddingChars();
                    if (whiteChars == null || whiteChars.isEmpty()) {
                        whiteChars = " ";
                    }
                }
                int v = 0;
                while (d.length() < columnWidth) {
                    d.insert(0, whiteChars.charAt(v));
                    v = (v + 1) % whiteChars.length();
                }
                break;
            }
            case CENTER: {
                String whiteChars = col.getLeftPaddingChars();
                if (whiteChars == null || whiteChars.isEmpty()) {
                    whiteChars = col.getDefaultPaddingChars();
                    if (whiteChars == null || whiteChars.isEmpty()) {
                        whiteChars = " ";
                    }
                }
                int v = 0;
                while (d.length() < columnWidth) {
                    d.insert(0, whiteChars.charAt(v));
                    if (d.length() < columnWidth) {
                        d.append(whiteChars.charAt(v));
                    }
                    v = (v + 1) % whiteChars.length();
                }
                break;
            }
        }

        int v0 = 0;
        while (skippedColumns > 1) {
            write(String.valueOf(skippedColumnsChars.charAt(v0)));
            v0 = (v0 + 1) % skippedColumnsChars.length();
            skippedColumns--;
        }
        write(d.toString());
    }

    @Override
    protected void endRow(DataRow row) {
        write(newLine);
    }

    private void write(Object s) {
        try {
            String v = s == null ? "" : String.valueOf(s);
            writer.write(v, 0, v.length());
        } catch (IOException ex) {
            throw new RuntimeException(ex);
        }
    }

    public void flush() {
        try {
            writer.flush();
        } catch (IOException ex) {
            throw new RuntimeException(ex);
        }
    }

    public void close() {
        try {
            writer.close();
        } catch (IOException ex) {
            throw new RuntimeException(ex);
        }
    }
}
