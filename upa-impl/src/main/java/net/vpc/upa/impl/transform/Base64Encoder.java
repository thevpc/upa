/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.impl.util.Base64;
import net.vpc.upa.types.StringEncoder;

/**
 *
 * @author vpc
 */
public class Base64Encoder implements StringEncoder {
    public static final Base64Encoder INSTANCE=new Base64Encoder();
    public String encode(byte[] bytes) {
        return Base64.encode(bytes);
    }

    public byte[] decode(String value) {
        return Base64.decode(value);
    }

    @Override
    public String toString() {
        return "Base64StringEncoder";
    }
    
}
