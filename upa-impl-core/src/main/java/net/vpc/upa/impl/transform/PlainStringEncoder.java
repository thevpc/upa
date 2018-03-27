/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.StringEncoder;

/**
 * @author taha.bensalah@gmail.com
 */
public class PlainStringEncoder implements StringEncoder {

    public static final PlainStringEncoder INSTANCE = new PlainStringEncoder();

    public String encode(byte[] bytes) {
        if (bytes == null) {
            return null;
        }
        return new String(bytes);
    }

    public byte[] decode(String value) {
        if (value == null) {
            return null;
        }
        return value.getBytes();
    }

    @Override
    public String toString() {
        return "PlainStringEncoder";
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
