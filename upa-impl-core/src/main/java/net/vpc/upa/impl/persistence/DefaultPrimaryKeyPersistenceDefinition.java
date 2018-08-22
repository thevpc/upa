/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.PrimaryKeyPersistenceDefinition;

/**
 *
 * @author vpc
 */
public class DefaultPrimaryKeyPersistenceDefinition implements PrimaryKeyPersistenceDefinition{
    private final String primaryKeyName;

    public DefaultPrimaryKeyPersistenceDefinition(String primaryKeyName) {
        this.primaryKeyName = primaryKeyName;
    }
    
    @Override
    public String getPrimaryKeyName() {
        return primaryKeyName;
    }
    
}
