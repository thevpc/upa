/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.text;

import java.io.BufferedWriter;
import java.io.IOException;
import java.io.Writer;
import net.vpc.upa.PortabilityHint;

import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.DataRow;
import net.vpc.upa.bulk.TextCSVColumn;
import net.vpc.upa.bulk.TextCSVFormatter;
import net.vpc.upa.impl.bulk.AbstractDataWriter;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@TextCSVFormatter
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultTextCSVWriter extends AbstractDataWriter {

    private TextCSVFormatter p;
    private BufferedWriter writer;
    boolean supportsBackSlash;
    boolean supportsSimpleQuote;
    boolean supportsDoubleQuote;
    boolean trimValues;
    private String newLine;

    public DefaultTextCSVWriter(TextCSVFormatter p, Writer writer) {
        super(new TextCSVColumn(), p.isContainsHeader(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]));
        this.p = p;
        this.writer = (writer instanceof BufferedWriter) ? ((BufferedWriter) writer) : new BufferedWriter(writer);
        //prepareHeader(p.isContainsHeader());
        supportsBackSlash = p.isSupportsBackSlash();
        supportsSimpleQuote = p.isSupportsSimpleQuote();
        supportsDoubleQuote = p.isSupportsDoubleQuote();
        trimValues = p.isTrimValues();
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
        //do nothing
    }

    @Override
    protected void writeCell(long rowIndex, DataRow row, int cellIndex, Object cell) {
        if (cellIndex > 0) {
            String separator = p.getSeparators();
            if (separator == null) {
                separator = ";";
            }
            write(separator);
        }
        String charsString = cell == null ? "" : String.valueOf(cell);
        if (trimValues) {
            charsString = charsString.trim();
        }
        char[] chars = charsString.toCharArray();
        StringBuilder s = new StringBuilder();
        boolean escape = false;
        boolean smpQuotes = false;
        boolean dblQuotes = false;
        for (char c : chars) {
            switch (c) {
                case '\\': {
                    if (supportsBackSlash) {
                        if (escape) {
                            s.append(c);
                        } else {
                            escape = true;
                        }
                    } else {
                        s.append(c);
                    }
                    break;
                }
                case '\'': {
                    if (escape) {
                        s.append(c);
                    } else {
                        escape = true;
                        if (smpQuotes) {
                            smpQuotes = false;
                        } else {
                            if (supportsSimpleQuote && !dblQuotes) {
                                smpQuotes = true;
                            } else {
                                s.append(c);
                            }
                        }
                    }
                    break;
                }
                case '"': {
                    if (escape) {
                        s.append(c);
                    } else {
                        escape = true;
                        if (dblQuotes) {
                            dblQuotes = false;
                        } else {
                            if (supportsDoubleQuote && !smpQuotes) {
                                dblQuotes = true;
                            } else {
                                s.append(c);
                            }
                        }
                    }
                    break;
                }
                default: {
                    s.append(c);
                }
            }
        }
        write(s);
    }

    @Override
    protected void endRow(DataRow row) {
        write("\n");
    }

    private void write(Object s) {
        try {
            String v = s == null ? "" : String.valueOf(s);
            writer.write(v, 0, v.length());
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
