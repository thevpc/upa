/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.ByteArrayEncoder;

/**
 *
 * @author vpc
 */
public class DoubleToStringByteArrayEncoder implements ByteArrayEncoder {
    public static final DoubleToStringByteArrayEncoder INSTANCE=new DoubleToStringByteArrayEncoder();
    public byte[] encode(Object o) {
        if (o == null) {
            return null;
        }
        return String.valueOf(((Number) o).doubleValue()).getBytes();
    }

    public Object decode(byte[] bytes) {
        if (bytes == null) {
            return null;
        }
        return Double.parseDouble(new String(bytes));
    }

}
