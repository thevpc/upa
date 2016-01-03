package net.vpc.upa.impl.bulk.text;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.io.OutputStream;
import java.io.OutputStreamWriter;
import java.io.Writer;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.DataWriter;
import net.vpc.upa.bulk.TextCSVFormatter;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.I18NString;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultTextCSVFormatter extends TextCSVFormatter {

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
            DefaultTextCSVWriter w = new DefaultTextCSVWriter(this, new FileWriter((File) target));
            w.setDataSerializer(getDataSerializer());
            return w;
        } else if (target instanceof OutputStream) {
            DefaultTextCSVWriter w = new DefaultTextCSVWriter(this, new OutputStreamWriter((OutputStream) target));
            w.setDataSerializer(getDataSerializer());
            return w;
        } else if (target instanceof Writer) {
            DefaultTextCSVWriter w = new DefaultTextCSVWriter(this, ((Writer) target));
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

}
