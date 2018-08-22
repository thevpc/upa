/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.persistence;

/**
 *
 * @author vpc
 */
public interface ColumnPersistenceDefinition extends NativeObjectPersistenceDefinition {

    public int getColumnType();

    public String getColumnTypeName();

    public String getColumnName();

    public String getTableName();

    public String getSchemaName();

    public String getCatalogName();

    Boolean getAutoIncrement();

    String getDefaultDefinition();

    Boolean getNullable();

    int getScale();

    int getSize();

}
