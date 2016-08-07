/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.CharArrayEncoder;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class IdentityCharArrayEncoder implements CharArrayEncoder {

    public static final IdentityCharArrayEncoder INSTANCE = new IdentityCharArrayEncoder();

    public char[] encode(Object o) {
        return (char[]) o;
    }

    public Object decode(char[] bytes) {
        return (char[]) bytes;
    }

}
