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
public class StringToByteArrayEncoder implements ByteArrayEncoder {
    public static final StringToByteArrayEncoder INSTANCE=new StringToByteArrayEncoder();
    public byte[] encode(Object o) {
        if (o == null) {
            return null;
        }
        return (((String) o)).getBytes();
    }

    public Object decode(byte[] bytes) {
        if (bytes == null) {
            return null;
        }
        return new String(bytes);
    }

}
