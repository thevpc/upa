/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.ByteArrayEncoder;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class LongToStringByteArrayEncoder implements ByteArrayEncoder {
    public static final LongToStringByteArrayEncoder INSTANCE=new LongToStringByteArrayEncoder();
    public byte[] encode(Object o) {
        if (o == null) {
            return null;
        }
        return String.valueOf(((Number) o).longValue()).getBytes();
    }

    public Object decode(byte[] bytes) {
        if (bytes == null) {
            return null;
        }
        return Long.parseLong(new String(bytes));
    }

}
