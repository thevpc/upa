/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.ForeignKeyPersistenceDefinition;

/**
 *
 * @author vpc
 */
public class DefaultForeignKeyPersistenceDefinition implements ForeignKeyPersistenceDefinition{
    private final String foreignKeyName;

    public DefaultForeignKeyPersistenceDefinition(String foreignKeyName) {
        this.foreignKeyName = foreignKeyName;
    }
    
    @Override
    public String getForeignKeyName() {
        return foreignKeyName;
    }
    
}
