/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import net.thevpc.upa.types.CharArrayEncoder;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class IntToStringCharArrayEncoder implements CharArrayEncoder {
    public static final IntToStringCharArrayEncoder INSTANCE=new IntToStringCharArrayEncoder();
    public char[] encode(Object o) {
        if (o == null) {
            return null;
        }
        return String.valueOf(((Number) o).intValue()).toCharArray();
    }

    public Object decode(char[] bytes) {
        if (bytes == null) {
            return null;
        }
        return Integer.parseInt(new String(bytes));
    }

}
