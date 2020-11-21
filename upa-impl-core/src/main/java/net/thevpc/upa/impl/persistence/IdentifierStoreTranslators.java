/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class IdentifierStoreTranslators {
    public static IdentifierStoreTranslator UPPER=new IdentifierStoreTranslatorUPPER();
    public static IdentifierStoreTranslator LOWER=new IdentifierStoreTranslatorLower();
    public static IdentifierStoreTranslator MIXED=new IdentifierStoreTranslatorMixed();
    public static IdentifierStoreTranslator MIXED_DBL_QUOTE=new IdentifierStoreTranslatorMixedDoubleQuote();
}
