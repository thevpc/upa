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
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.types.I18NString;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
@PortabilityHint(target = "C#", name = "suppress")
public class DefaultSheetFormatter extends SheetFormatter {

    private Object target;

    @Override
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

    @Override
    public DataWriter createWriter() throws IOException {
        if (!isSupported(getContentType())) {
            throw new UPAException("UnsupportedSheetContentType", getContentType());
        }
        if (target instanceof File) {
            DataWriter w = getFactory().createObject(ExternalFormatHelper.class).createXLSWriter((File) target, this);
            if (w != null) {
                return w;
            }
            throw new UPAException(new I18NString("InvalidTarget")
                    .setDefaultValue("Invalid Formatter Target. Not Supported"), target.getClass().getSimpleName()
            );
        } else if (target instanceof OutputStream) {
            DataWriter w = getFactory().createObject(ExternalFormatHelper.class).createXLSWriter((OutputStream) target, this);
            if (w != null) {
                return w;
            }
            throw new UPAException(new I18NString("InvalidTarget")
                    .setDefaultValue("Invalid Formatter Target. Not Supported"), target.getClass().getSimpleName()
            );
        } else {
            throw new UPAException(new I18NString("InvalidTarget")
                    .setDefaultValue("Invalid Formatter Target. Expected types are  File|OutputStream"), target.getClass().getSimpleName()
            );
        }
    }

    public void close() {
        if (target != null) {
            if (target instanceof OutputStream) {
                try {
                    ((OutputStream) target).close();
                } catch (IOException e) {
                    throw new UPAException("IOException", e);
                }
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
