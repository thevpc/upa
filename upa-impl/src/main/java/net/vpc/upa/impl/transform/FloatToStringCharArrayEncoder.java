/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.CharArrayEncoder;

/**
 *
 * @author vpc
 */
public class FloatToStringCharArrayEncoder implements CharArrayEncoder {
    public static final FloatToStringCharArrayEncoder INSTANCE=new FloatToStringCharArrayEncoder();
    public char[] encode(Object o) {
        if (o == null) {
            return null;
        }
        return String.valueOf(((Number) o).floatValue()).toCharArray();
    }

    public Object decode(char[] bytes) {
        if (bytes == null) {
            return null;
        }
        return Float.parseFloat(new String(bytes));
    }

}
