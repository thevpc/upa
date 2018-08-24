/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.persistence.TablePersistenceDefinition;

/**
 *
 * @author vpc
 */
public class DefaultTablePersistenceDefinition implements TablePersistenceDefinition {

    private final String tableName;
    private final String catalogName;
    private final String schemaName;

    public DefaultTablePersistenceDefinition(String tableName, String catalogName, String schemaName) {
        this.tableName = tableName;
        this.schemaName = schemaName;
        this.catalogName = catalogName;
    }

    public String getCatalogName() {
        return catalogName;
    }

    public String getSchemaName() {
        return schemaName;
    }

    @Override
    public String getTableName() {
        return tableName;
    }

}
