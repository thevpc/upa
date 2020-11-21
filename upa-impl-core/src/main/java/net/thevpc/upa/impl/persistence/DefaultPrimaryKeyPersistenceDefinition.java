/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.persistence.PrimaryKeyPersistenceDefinition;

/**
 *
 * @author vpc
 */
public class DefaultPrimaryKeyPersistenceDefinition implements PrimaryKeyPersistenceDefinition {

    private final String tableName;
    private final String primaryKeyName;

    public DefaultPrimaryKeyPersistenceDefinition(String tableName, String primaryKeyName) {
        this.tableName = tableName;
        this.primaryKeyName = primaryKeyName;
    }

    public String getTableName() {
        return tableName;
    }

    @Override
    public String getPrimaryKeyName() {
        return primaryKeyName;
    }

}
