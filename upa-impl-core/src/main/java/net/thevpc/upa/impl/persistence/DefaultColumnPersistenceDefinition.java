/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.persistence.ColumnPersistenceDefinition;

/**
 *
 * @author vpc
 */
public class DefaultColumnPersistenceDefinition implements ColumnPersistenceDefinition {

    private final int columnType;
    private final String columnTypeName;
    private final String columnName;
    private final String tableName;
    private final String schemaName;
    private final String catalogName;
    private final int size;
    private final int scale;
    private final Boolean nullable;
    private final Boolean autoIncrement;
    private final String defaultDefinition;

    public DefaultColumnPersistenceDefinition(String columnName, String tableName, String schemaName, String catalogName, int columnType, String columnTypeName,
            int size, int scale, Boolean nullable, Boolean autoIncrement, String defaultDefinition) {
        this.columnType = columnType;
        this.columnTypeName = columnTypeName;
        this.columnName = columnName;
        this.tableName = tableName;
        this.schemaName = schemaName;
        this.catalogName = catalogName;
        this.size = size;
        this.scale = scale;
        this.autoIncrement = autoIncrement;
        this.nullable = nullable;
        this.defaultDefinition = defaultDefinition;
    }

    public Boolean getAutoIncrement() {
        return autoIncrement;
    }

    public String getDefaultDefinition() {
        return defaultDefinition;
    }

    public int getScale() {
        return scale;
    }

    public int getSize() {
        return size;
    }

    public Boolean getNullable() {
        return nullable;
    }

    public int getColumnType() {
        return columnType;
    }

    public String getColumnTypeName() {
        return columnTypeName;
    }

    public String getColumnName() {
        return columnName;
    }

    public String getTableName() {
        return tableName;
    }

    public String getSchemaName() {
        return schemaName;
    }

    public String getCatalogName() {
        return catalogName;
    }

    @Override
    public String toString() {
        return "ColumnDef{" 
                + "columnName=" + columnName + ", tableName=" + tableName 
                + ", columnTypeName=" + columnTypeName + ", size=" + size + ", scale=" + scale + ", nullable=" + nullable + ", autoIncrement=" + autoIncrement + ", defaultDefinition=" + defaultDefinition 
                + ", columnType=" + columnType 
                + ", schemaName=" + schemaName + ", catalogName=" + catalogName 
                + '}';
    }
    

}
