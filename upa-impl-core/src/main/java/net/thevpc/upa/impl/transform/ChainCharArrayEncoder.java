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
public class ChainCharArrayEncoder implements CharArrayEncoder {

    private CharArrayEncoder a;
    private CharArrayEncoder b;

    public ChainCharArrayEncoder(CharArrayEncoder a, CharArrayEncoder b) {
        this.a = a;
        this.b = b;
    }

    public char[] encode(Object bytes) {
        return b.encode(a.encode(bytes));
    }

    public Object decode(char[] value) {
        return a.decode((char[]) b.decode(value));
    }

}
