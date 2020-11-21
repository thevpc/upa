/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

/**
 *
 * @author taha.bensalah@gmail.com
 */
class IdentifierStoreTranslatorUPPER implements IdentifierStoreTranslator {

    public IdentifierStoreTranslatorUPPER() {
    }

    public String translateIdentifier(String identifier) {
        return identifier.toUpperCase();
    }
    
}
