/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import net.thevpc.upa.impl.util.Base64;
import net.thevpc.upa.types.StringEncoder;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class Base64Encoder implements StringEncoder {
    public static final Base64Encoder INSTANCE=new Base64Encoder();
    public String encode(byte[] bytes) {
        return Base64.encode(bytes);
    }

    public byte[] decode(String value) {
        return Base64.decode(value);
    }

    @Override
    public String toString() {
        return "Base64StringEncoder";
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
