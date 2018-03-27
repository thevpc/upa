/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import java.security.InvalidKeyException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.security.spec.InvalidKeySpecException;
import java.util.logging.Logger;
import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.SecretKey;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.PBEKeySpec;
import javax.crypto.spec.SecretKeySpec;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.PortabilityHint;
import net.vpc.upa.SecretStrategy;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.DefaultVarContext;
import net.vpc.upa.impl.util.VarContext;
import net.vpc.upa.types.I18NString;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DefaultSecretStrategy implements SecretStrategy {

    private static final Logger log = Logger.getLogger(DefaultSecretStrategy.class.getName());
    private Cipher aes;
    private SecretKeySpec encodeKey;
    private SecretKeySpec decodeKey;

    public void init(PersistenceUnit persistenceUnit, String encodingKey, String decodingKey) {
        /**
         * @PortabilityHint(target = "C#", name = "todo")
         */
        try {
            aes = Cipher.getInstance("AES/ECB/PKCS5Padding");
            VarContext c=new DefaultVarContext(persistenceUnit.getProperties());
            Object v = c.eval(encodingKey);
            byte[] k = null;
            if (v != null) {
                if (v instanceof byte[]) {
                    k = (byte[]) v;
                } else if (v instanceof String) {
                    k = ((String) v).getBytes();
                } else {
                    throw new UPAException("UnableToResolveEncodingKey");
                }
            }
            if (k == null || k.length == 0) {
                k = "net.vpc.upa".getBytes();
            }
            encodeKey = createSimpleSymmetricKey(k);
            decodeKey = encodeKey;
        } catch (NoSuchAlgorithmException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        } catch (NoSuchPaddingException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        }
    }

    public DefaultSecretStrategy() {
    }

    /**
     * @PortabilityHint(target = "C#", name = "todo")
     */
    protected SecretKeySpec createSimpleSymmetricKey(byte[] passphrase) {
        try {
            MessageDigest digest = MessageDigest.getInstance("SHA");
            digest.update(passphrase);
            return new SecretKeySpec(digest.digest(), 0, 16, "AES");
        } catch (NoSuchAlgorithmException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        }
    }

    /**
     * @PortabilityHint(target = "C#", name = "todo")
     */
    protected SecretKeySpec createSimpleSymmetricKey(char[] passphrase, byte[] salt) {
        try {
            int iterations = 10000;
            SecretKeyFactory factory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA1");
            SecretKey tmp = factory.generateSecret(new PBEKeySpec(passphrase, salt, iterations, 128));
            return new SecretKeySpec(tmp.getEncoded(), "AES");
        } catch (NoSuchAlgorithmException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        } catch (InvalidKeySpecException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        }
    }

    public byte[] encode(byte[] value) {
        if(value==null){
            return value;
        }
        /**
         * @PortabilityHint(target = "C#", name = "todo")
         * return value;
         */
        try {
            aes.init(Cipher.ENCRYPT_MODE, encodeKey);
            return aes.doFinal(value);
        } catch (IllegalBlockSizeException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        } catch (BadPaddingException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        } catch (InvalidKeyException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        }
    }

    public byte[] decode(byte[] value) {
        if(value==null){
            return value;
        }
        /**
         * @PortabilityHint(target = "C#", name = "todo")
         * return value;
         */
        try {
            aes.init(Cipher.DECRYPT_MODE, decodeKey);
            return aes.doFinal(value);
        } catch (IllegalBlockSizeException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        } catch (BadPaddingException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        } catch (InvalidKeyException ex) {
            throw new UPAException(ex, new I18NString("SecurityException"));
        }
    }

    @Override
    public String toString() {
        return "DefaultSecretStrategy";
    }

    
}
