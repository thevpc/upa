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
    private String validSeparator;
    private char preferredEscapeChar='"';

    public DefaultTextCSVWriter(TextCSVFormatter p, Writer writer) {
        super(new TextCSVColumn(), p.isWriteHeader(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]));
        this.p = p;
        this.writer = (writer instanceof BufferedWriter) ? ((BufferedWriter) writer) : new BufferedWriter(writer);
        //prepareHeader(p.isWriteHeader());
        supportsBackSlash = p.isSupportsBackSlash();
        supportsSimpleQuote = p.isSupportsSimpleQuote();
        supportsDoubleQuote = p.isSupportsDoubleQuote();
        trimValues = p.isTrimValues();
        if(supportsDoubleQuote) {
            preferredEscapeChar = '"';
        }else if(supportsSimpleQuote){
            preferredEscapeChar='\'';
        }else if(supportsBackSlash){
            preferredEscapeChar='\\';
        }else{
            preferredEscapeChar = '"';
        }
    }

    @Override
    public void startDocument() {
        String nl = p.getNewLine();
        if (nl == null) {
            nl = PlatformUtils.getSystemLineSeparator();
        }
        String separator = p.getSeparators();
        if (separator == null) {
            separator = ";";
        }
        validSeparator=separator;
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
            write(validSeparator);
        }
        String cellString = cell == null ? "" : String.valueOf(cell);
        if (trimValues) {
            cellString = cellString.trim();
        }
        boolean needEscape=false;
        boolean needEscapeSep=false;
        boolean needEscapeBackSlash=false;
        boolean needEscapeDblQuote=false;
        boolean needEscapeSimpleQuote=false;

        char[] chars = cellString.toCharArray();

        for (char c : chars) {
            for (char c2 : validSeparator.toCharArray()) {
                if(c==c2){
                    needEscapeSep=true;
                    break;
                }
            }
            switch (c){
                case '\\':{needEscapeBackSlash=true;break;}
                case '\n':{needEscapeBackSlash=true;break;}
                case '\'':{needEscapeSimpleQuote=true;break;}
                case '\"':{needEscapeDblQuote=true;break;}
            }
        }
        needEscape=(needEscapeBackSlash || needEscapeDblQuote || needEscapeSimpleQuote || needEscapeSep);

        StringBuilder s = new StringBuilder();
        boolean escape = false;
        boolean smpQuotes = false;
        boolean dblQuotes = false;
        for (char c : chars) {
            switch (c) {
                case '\\': {
//                    if (supportsBackSlash) {
                        if (escape) {
                            s.append(c);
                        } else {
                            escape = true;
                        }
//                    } else {
//                        s.append(c);
//                    }
                    break;
                }
                case '\'': {
                    if(preferredEscapeChar=='"'){
                        if(needEscape) {
                            s.append(c);
                        }else{
                            s.append('\\').append(c);
                        }
                    }else if(preferredEscapeChar=='\''){
                        s.append('\\').append(c);
                    }else if(preferredEscapeChar=='\\'){
                        s.append('\\').append(c);
                    }else{
                        s.append(c);
                    }
                    break;
                }
                case '"': {
                    if(preferredEscapeChar=='"'){
                        s.append('\\').append(c);
                    }else if(preferredEscapeChar=='\''){
                        if(needEscape) {
                            s.append(c);
                        }else{
                            s.append('\\').append(c);
                        }
                    }else if(preferredEscapeChar=='\\'){
                        s.append('\\').append(c);
                    }else{
                        s.append(c);
                    }

//                    if (escape) {
//                        s.append(c);
//                    } else {
//                        escape = true;
//                        if (dblQuotes) {
//                            dblQuotes = false;
//                        } else {
//                            if (supportsDoubleQuote && !smpQuotes) {
//                                dblQuotes = true;
//                            } else {
//                                s.append(c);
//                            }
//                        }
//                    }
                    break;
                }
                case '\n': {
                    s.append("\\n");
                    break;
                }
                case '\r': {
                    s.append("\\r");
                    break;
                }
                case '\t': {
                    if(needEscapeSep){
                        s.append("\\t");
                    }else{
                        s.append(c);
                    }
                    break;
                }
                case ' ': {
                    if(needEscapeSep){
                        s.append("\\ ");
                    }else{
                        s.append(c);
                    }
                    break;
                }
                default: {
                    s.append(c);
                }
            }
        }
        if(needEscape){
            s.insert(0, '\"');
            s.append('\"');
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
