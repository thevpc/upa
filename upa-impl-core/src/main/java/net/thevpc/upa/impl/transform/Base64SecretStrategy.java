/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.transform;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.SecretStrategy;
import net.thevpc.upa.impl.util.Base64;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class Base64SecretStrategy implements SecretStrategy {

    public static final Base64SecretStrategy INSTANCE = new Base64SecretStrategy();

    public void init(PersistenceUnit persistenceUnit, String encodingKey, String decodingKey) {
    }

    public Base64SecretStrategy() {
    }

    public byte[] encode(byte[] value) {
        if (value == null) {
            return null;
        }
        return Base64.encode(value).getBytes();
    }

    public byte[] decode(byte[] value) {
        if (value == null) {
            return null;
        }
        return Base64.decode(new String(value));
    }

}
