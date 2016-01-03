/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.bulk.text;

import net.vpc.upa.bulk.DataWriter;
import net.vpc.upa.bulk.TextFixedWidthFormatter;

import java.io.*;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.I18NString;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultTextFixedWidthFormatter extends TextFixedWidthFormatter {

    private Object target;

    public void configure(Object target) throws IOException {
        if (target == null) {
            throw new UPAException("NullTarget");
        }
        if (target instanceof File || target instanceof OutputStream || target instanceof Writer) {
            this.target = target;
        } else {
            throw new UPAException(new I18NString("InvalidTarget")
                    .setDefaultValue("Invalid Formatter Target. Expected types are  File|OutputStream|Writer"), target.getClass().getSimpleName()
            );
        }
        this.target = target;
    }

    public DataWriter createWriter() throws IOException {
        if (target instanceof File) {
            DefaultTextFixedWidthWriter w = new DefaultTextFixedWidthWriter(this, new FileWriter((File) target));
            w.setDataSerializer(getDataSerializer());
            return w;
        } else if (target instanceof OutputStream) {
            DefaultTextFixedWidthWriter w = new DefaultTextFixedWidthWriter(this, new OutputStreamWriter((OutputStream) target));
            w.setDataSerializer(getDataSerializer());
            return w;
        } else if (target instanceof Writer) {
            DefaultTextFixedWidthWriter w = new DefaultTextFixedWidthWriter(this, ((Writer) target));
            w.setDataSerializer(getDataSerializer());
            return w;
        } else {
            throw new UPAException(new I18NString("InvalidTarget")
                    .setDefaultValue("Invalid Formatter Target. Expected types are  File|OutputStream|Writer"), target.getClass().getSimpleName()
            );
        }
    }

    public void close() throws Exception {
        if (target != null) {
            if (target instanceof OutputStream) {
                ((OutputStream) target).close();
            } else if (target instanceof Writer) {
                ((Writer) target).close();
            }
        }
    }

    public DataWriter format(OutputStream outputStream) throws IOException {
        return format(new OutputStreamWriter(outputStream));
    }

    public DataWriter format(File file) throws IOException {
        return format(new FileWriter(file));
    }

    public DataWriter format(Writer writer) throws IOException {
        DefaultTextFixedWidthWriter d = new DefaultTextFixedWidthWriter(this, writer);
        d.setDataSerializer(getDataSerializer());
        return d;
    }
}
