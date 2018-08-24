/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.tree;

import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author vpc
 */
public class NativeObjectPersistenceTable extends NativeObjectPersistenceNode {

    private String tableName;
    private final List<NativeObjectPersistenceColumn> columns = new ArrayList<>();
    private NativeObjectPersistencePrimaryKey primaryKey;
    private final List<NativeObjectPersistenceForeignKey> foreignKeys = new ArrayList<>();
    private final List<NativeObjectPersistenceIndex> indexes = new ArrayList<>();

    public List<NativeObjectPersistenceColumn> getColumns() {
        return columns;
    }

    public String getTableName() {
        return tableName;
    }

    public void setTableName(String tableName) {
        this.tableName = tableName;
    }

    public NativeObjectPersistencePrimaryKey getPrimaryKey() {
        return primaryKey;
    }

    public List<NativeObjectPersistenceForeignKey> getForeignKeys() {
        return foreignKeys;
    }

    public List<NativeObjectPersistenceIndex> getIndexes() {
        return indexes;
    }

    public void setPrimaryKey(NativeObjectPersistencePrimaryKey primaryKey) {
        this.primaryKey = primaryKey;
    }
    

}
