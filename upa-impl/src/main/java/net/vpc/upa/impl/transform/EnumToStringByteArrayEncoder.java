/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.types.ByteArrayEncoder;

/**
 *
 * @author vpc
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
        } catch (IllegalArgumentException ex) {
            log.log(Level.SEVERE, "Unable to parse" + sval + " as enum " + enumClass.getName(),ex);
            return null;
        }
    }

}
