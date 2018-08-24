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
public class DefaultForeignKeyPersistenceDefinition implements ForeignKeyPersistenceDefinition {

    private final String tableName;
    private final String foreignKeyName;

    public DefaultForeignKeyPersistenceDefinition(String tableName, String foreignKeyName) {
        this.foreignKeyName = foreignKeyName;
        this.tableName = tableName;
    }

    public String getTableName() {
        return tableName;
    }

    @Override
    public String getForeignKeyName() {
        return foreignKeyName;
    }

}
