/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */


package net.vpc.upa.impl.bulk.sheet;

import java.io.File;
import java.io.IOException;
import java.io.OutputStream;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.bulk.DataWriter;
import net.vpc.upa.bulk.SheetContentType;
import net.vpc.upa.bulk.SheetFormatter;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.types.I18NString;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#",name = "suppress")
public class DefaultSheetFormatter extends SheetFormatter {

    private Object target;

    public void configure(Object target) throws IOException {
        if (target == null) {
            throw new UPAException("NullTarget");
        }
        if (target instanceof File || target instanceof OutputStream) {
            this.target = target;
        } else {
            throw new UPAException(new I18NString("InvalidTarget")
                    .setDefaultValue("Invalid Formatter Target. Expected types are  File|OutputStream"), target.getClass().getSimpleName()
            );
        }
        this.target = target;
    }

    public DataWriter createWriter() throws IOException {
        if (!isSupported(getContentType())) {
            throw new UPAException("UnsupportedSheetContentType", getContentType());
        }
        if (target instanceof File) {
            DefaultSheetWriter w = new DefaultSheetWriter(this, (File) target);
            w.setDataRowConverter(getDataRowConverter());
            return w;
        } else if (target instanceof OutputStream) {
            DefaultSheetWriter w = new DefaultSheetWriter(this, (OutputStream) target);
            w.setDataRowConverter(getDataRowConverter());
            return w;
        } else {
            throw new UPAException(new I18NString("InvalidTarget")
                    .setDefaultValue("Invalid Formatter Target. Expected types are  File|OutputStream"), target.getClass().getSimpleName()
            );
        }
    }

    public void close() throws Exception {
        if (target != null) {
            if (target instanceof OutputStream) {
                ((OutputStream) target).close();
            }
        }

    }

    @Override
    public SheetContentType getDefaultContentType() {
        return SheetContentType.XLSX;
    }

    @Override
    public boolean isSupported(SheetContentType contentType) {
        return contentType == null || contentType == getDefaultContentType();
    }

}
