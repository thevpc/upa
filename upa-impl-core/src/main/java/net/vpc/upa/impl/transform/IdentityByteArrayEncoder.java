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
public class IdentityByteArrayEncoder implements ByteArrayEncoder {

    public static final IdentityByteArrayEncoder INSTANCE = new IdentityByteArrayEncoder();

    public byte[] encode(Object o) {
        return (byte[]) o;
    }

    public Object decode(byte[] bytes) {
        return (byte[]) bytes;
    }

    @Override
    public String toString() {
        return "IdentityByteArrayEncoder";
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
