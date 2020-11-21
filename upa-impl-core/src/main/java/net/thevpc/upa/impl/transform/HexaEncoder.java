/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import net.thevpc.upa.impl.util.StringUtils;
import net.thevpc.upa.types.StringEncoder;

/**
 * @author taha.bensalah@gmail.com
 */
public class HexaEncoder implements StringEncoder {

    public static final HexaEncoder INSTANCE = new HexaEncoder();

    public String encode(byte[] bytes) {
        if (bytes == null) {
            return null;
        }
        return StringUtils.toHexString(bytes);
    }

    public byte[] decode(String value) {
        if (value == null) {
            return null;
        }
        return StringUtils.parseHexString(value);
    }

    @Override
    public String toString() {
        return "HexadecimalStringEncoder";
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
