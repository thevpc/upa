/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

/**
 *
 * @author vpc
 */
class IdentifierStoreTranslatorLower implements IdentifierStoreTranslator {

    public IdentifierStoreTranslatorLower() {
    }

    public String translateIdentifier(String identifier) {
        return identifier.toLowerCase();
    }
    
}
