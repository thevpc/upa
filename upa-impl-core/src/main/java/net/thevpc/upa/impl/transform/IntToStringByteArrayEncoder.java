/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import net.thevpc.upa.types.ByteArrayEncoder;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class IntToStringByteArrayEncoder implements ByteArrayEncoder {
    public static final IntToStringByteArrayEncoder INSTANCE=new IntToStringByteArrayEncoder();
    public byte[] encode(Object o) {
        if (o == null) {
            return null;
        }
        return String.valueOf(((Number) o).intValue()).getBytes();
    }

    public Object decode(byte[] bytes) {
        if (bytes == null) {
            return null;
        }
        return Integer.parseInt(new String(bytes));
    }
    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        return true;
    }

    @Override
    public int hashCode() {
        return getClass().getName().hashCode();
    }

}
