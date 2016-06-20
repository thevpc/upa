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
public class StringToCharArrayEncoder implements CharArrayEncoder {

    public static final StringToCharArrayEncoder INSTANCE = new StringToCharArrayEncoder();

    public char[] encode(Object o) {
        if (o == null) {
            return null;
        }
        return (((String) o)).toCharArray();
    }

    public Object decode(char[] bytes) {
        if (bytes == null) {
            return null;
        }
        return new String(bytes);
    }

}
