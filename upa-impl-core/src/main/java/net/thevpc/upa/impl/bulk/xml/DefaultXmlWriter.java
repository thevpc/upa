/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk.xml;

import net.thevpc.upa.bulk.DataColumn;
import net.thevpc.upa.bulk.DataRow;
import net.thevpc.upa.bulk.TextCSVColumn;
import net.thevpc.upa.bulk.XmlFormatter;
import net.thevpc.upa.bulk.*;
import net.thevpc.upa.impl.bulk.AbstractDataWriter;

import java.io.BufferedWriter;
import java.io.IOException;
import java.io.Writer;
import net.thevpc.upa.PortabilityHint;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultXmlWriter extends AbstractDataWriter {

    private XmlFormatter p;
    private BufferedWriter writer;

    public DefaultXmlWriter(XmlFormatter p, Writer writer) {
        super(new TextCSVColumn(), p.isContainsHeader(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]));
        this.p = p;
        this.writer = (writer instanceof BufferedWriter) ? ((BufferedWriter) writer) : new BufferedWriter(writer);
        //prepareHeader(p.isWriteHeader());
    }

    @Override
    protected void startRow(DataRow row) {
        //do nothing
    }

    @Override
    protected void writeCell(long rowIndex, DataRow row, int cellIndex, Object cell) {
    }

    @Override
    protected void endRow(DataRow row) {

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
