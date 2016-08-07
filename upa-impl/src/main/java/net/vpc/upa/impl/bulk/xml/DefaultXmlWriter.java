/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.xml;

import net.vpc.upa.bulk.*;
import net.vpc.upa.impl.bulk.AbstractDataWriter;

import java.io.BufferedWriter;
import java.io.IOException;
import java.io.Writer;
import net.vpc.upa.PortabilityHint;

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
        //prepareHeader(p.isContainsHeader());
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

    public void close() {
        try {
            writer.close();
        } catch (IOException ex) {
            throw new RuntimeException(ex);
        }
    }
}
