/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import net.vpc.upa.impl.util.Strings;
import net.vpc.upa.types.StringEncoder;

/**
 *
 * @author vpc
 */
public class HexaEncoder implements StringEncoder {

    public static final HexaEncoder INSTANCE = new HexaEncoder();

    public String encode(byte[] bytes) {
        if (bytes == null) {
            return null;
        }
        return Strings.toHexString(bytes);
    }

    public byte[] decode(String value) {
        if (value == null) {
            return null;
        }
        return Strings.parseHexString(value);
    }

    @Override
    public String toString() {
        return "HexadecimalStringEncoder";
    }
    
}
