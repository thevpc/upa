/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.CharArrayEncoder;

/**
 *
 * @author vpc
 */
public class DoubleToStringCharArrayEncoder implements CharArrayEncoder {
    public static final DoubleToStringCharArrayEncoder INSTANCE=new DoubleToStringCharArrayEncoder();
    public char[] encode(Object o) {
        if (o == null) {
            return null;
        }
        return String.valueOf(((Number) o).doubleValue()).toCharArray();
    }

    public Object decode(char[] bytes) {
        if (bytes == null) {
            return null;
        }
        return Double.parseDouble(new String(bytes));
    }

}
