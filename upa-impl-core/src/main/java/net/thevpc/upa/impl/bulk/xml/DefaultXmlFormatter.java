package net.thevpc.upa.impl.bulk.xml;

import net.thevpc.upa.bulk.DataWriter;
import net.thevpc.upa.bulk.XmlFormatter;

import java.io.*;
import net.thevpc.upa.PortabilityHint;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.types.I18NString;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultXmlFormatter extends XmlFormatter {

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
            DefaultXmlWriter w = new DefaultXmlWriter(this, new FileWriter((File) target));
            w.setDataRowConverter(getDataRowConverter());
            return w;
        } else if (target instanceof OutputStream) {
            DefaultXmlWriter w = new DefaultXmlWriter(this, new OutputStreamWriter((OutputStream) target));
            w.setDataRowConverter(getDataRowConverter());
            return w;
        } else if (target instanceof Writer) {
            DefaultXmlWriter w = new DefaultXmlWriter(this, ((Writer) target));
            w.setDataRowConverter(getDataRowConverter());
            return w;
        } else {
            throw new UPAException(new I18NString("InvalidTarget")
                    .setDefaultValue("Invalid Formatter Target. Expected types are  File|OutputStream|Writer"), target.getClass().getSimpleName()
            );
        }
    }

    public void close() {
        if (target != null) {
            try{
                if (target instanceof OutputStream) {
                    ((OutputStream) target).close();
                } else if (target instanceof Writer) {
                    ((Writer) target).close();
                }
            } catch (IOException e) {
                throw new UPAException("IOException",e);
            }
        }
    }

}
