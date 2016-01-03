/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.text;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.Reader;
import java.util.ArrayList;
import java.util.List;
import java.util.StringTokenizer;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.DataColumn;
import net.vpc.upa.bulk.TextCSVColumn;
import net.vpc.upa.bulk.TextCSVParser;
import net.vpc.upa.impl.bulk.AbstractDataReader;
import net.vpc.upa.impl.util.Strings;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#", name = "suppress")
public class DefaultTextCSVReader extends AbstractDataReader {

    private TextCSVParser p;
    private BufferedReader reader;
    private String line;
    private char[] separators;

    public DefaultTextCSVReader(TextCSVParser p, Reader reader) {
        super(new TextCSVColumn(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]), p.isContainsHeader(), p.getSkipRows());
        this.p = p;
        this.reader = (reader instanceof BufferedReader) ? ((BufferedReader) reader) : new BufferedReader(reader);
        separators = Strings.isNullOrEmpty(p.getSeparators()) ? new char[]{';'} : p.getSeparators().toCharArray();
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
        List<Object> all = new ArrayList<Object>();
        if (!p.isSupportsBackSlash() && !p.isSupportsDoubleQuote() && !p.isSupportsSimpleQuote()) {
            for (String s : line.split(p.getSeparators())) {
                if (s.length() > 0) {
                    all.add(validateValue(s));
                }
            }

            StringTokenizer st = new StringTokenizer(line, p.getSeparators());
            while (st.hasMoreElements()) {
                all.add(validateValue(st.nextToken()));
            }
        } else {
            //should support " and ' etc...
            StringBuilder current = new StringBuilder();
            int max = line.length();
            char[] lineChars = line.toCharArray();
            boolean inString = false;
            for (int i = 0; i < max; i++) {
                char c = lineChars[i];
                if (inString) {
                    switch (c) {
                        case '\"': {
                            if (i + 1 < max && lineChars[i + 1] == '\"') {
                                current.append(c);
                                i++;
                            } else {
                                inString = false;
                            }
                            break;
                        }
                        default: {
                            current.append(c);
                            break;
                        }
                    }
                } else {
                    switch (c) {
                        case '\"': {
                            if (current.length() > 0) {
                                current.append(c);
                            } else {
                                inString = true;
                            }
                            break;
                        }
                        case '\\': {
                            boolean sepFound = false;
                            for (char sep : separators) {
                                if (i + 1 < max && lineChars[i + 1] == sep) {
                                    current.append(sep);
                                    i++;
                                    sepFound = true;
                                    break;
                                }
                            }
                            if (!sepFound) {
                                current.append(c);
                            }
                            break;
                        }
                        default: {
                            boolean found = false;
                            for (char cc : separators) {
                                if (cc == c) {
                                    all.add(validateValue(current.toString()));
                                    current.delete(0, current.length());
                                    found = true;
                                    break;
                                }
                            }
                            if (!found) {
                                current.append(c);
                            }
                            break;
                        }
                    }
                }
            }
            all.add(validateValue(current.toString()));
        }
        while (all.size() < p.getColumns().size()) {
            all.add(validateValue(""));
        }
        return all.toArray(new Object[all.size()]);
    }
}
