/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.persistence.IndexPersistenceDefinition;

/**
 *
 * @author vpc
 */
public class DefaultIndexPersistenceDefinition implements IndexPersistenceDefinition {

    private final String indexName;
    private final String tableName;
    private final boolean unique;

    public DefaultIndexPersistenceDefinition(String indexName, String tableName, boolean unique) {
        this.tableName = tableName;
        this.indexName = indexName;
        this.unique = unique;
    }

    @Override
    public String getIndexName() {
        return indexName;
    }

    @Override
    public boolean isUnique() {
        return unique;
    }

    @Override
    public String getTableName() {
        return tableName;
    }

}
