/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.types.ByteArrayEncoder;

/**
 *
 * @author vpc
 */
public class ChainByteArrayEncoder implements ByteArrayEncoder {

    private ByteArrayEncoder a;
    private ByteArrayEncoder b;

    public ChainByteArrayEncoder(ByteArrayEncoder a, ByteArrayEncoder b) {
        this.a = a;
        this.b = b;
    }

    public byte[] encode(Object bytes) {
        return b.encode(a.encode(bytes));
    }

    public Object decode(byte[] value) {
        return a.decode((byte[]) b.decode(value));
    }

}
