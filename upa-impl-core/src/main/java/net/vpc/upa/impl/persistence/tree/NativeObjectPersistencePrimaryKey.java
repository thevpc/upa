/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.tree;

/**
 *
 * @author vpc
 */
public class NativeObjectPersistencePrimaryKey extends NativeObjectPersistenceNode{
    private String tableName;
    private String primaryKeyName;

    public NativeObjectPersistencePrimaryKey(String tableName, String primaryKeyName) {
        this.tableName = tableName;
        this.primaryKeyName = primaryKeyName;
    }

    public String getTableName() {
        return tableName;
    }

    public String getPrimaryKeyName() {
        return primaryKeyName;
    }
    
}
