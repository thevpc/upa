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
public class IdentityCharArrayEncoder implements CharArrayEncoder {

    public static final IdentityCharArrayEncoder INSTANCE = new IdentityCharArrayEncoder();

    public char[] encode(Object o) {
        return (char[]) o;
    }

    public Object decode(char[] bytes) {
        return (char[]) bytes;
    }

}
