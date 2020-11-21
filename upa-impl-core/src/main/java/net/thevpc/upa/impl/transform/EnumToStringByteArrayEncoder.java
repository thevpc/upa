/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import java.util.logging.Level;
import java.util.logging.Logger;
import net.thevpc.upa.types.ByteArrayEncoder;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class EnumToStringByteArrayEncoder implements ByteArrayEncoder {

    private static final Logger log = Logger.getLogger(EnumToStringByteArrayEncoder.class.getName());
    private Class enumClass;

    public EnumToStringByteArrayEncoder(Class enumClass) {
        this.enumClass = enumClass;
    }

    public byte[] encode(Object o) {
        if (o == null) {
            return null;
        }
        return String.valueOf(o).getBytes();
    }

    public Object decode(byte[] bytes) {
        if (bytes == null) {
            return null;
        }
        String sval = new String(bytes);
        if (sval.isEmpty()) {
            return null;
        }
        try {
            return Enum.valueOf(enumClass, sval);
        } catch (Exception ex) {
            log.log(Level.SEVERE, "Unable to parse" + sval + " as enum " + enumClass.getName(),ex);
            return null;
        }
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        EnumToStringByteArrayEncoder that = (EnumToStringByteArrayEncoder) o;

        return enumClass != null ? enumClass.equals(that.enumClass) : that.enumClass == null;
    }

    @Override
    public int hashCode() {
        return enumClass != null ? enumClass.hashCode() : 0;
    }
}
