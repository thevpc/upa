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
public class IdentityByteArrayEncoder implements ByteArrayEncoder {

    public static final IdentityByteArrayEncoder INSTANCE = new IdentityByteArrayEncoder();

    public byte[] encode(Object o) {
        return (byte[]) o;
    }

    public Object decode(byte[] bytes) {
        return (byte[]) bytes;
    }

    @Override
    public String toString() {
        return "IdentityByteArrayEncoder";
    }

    
}
