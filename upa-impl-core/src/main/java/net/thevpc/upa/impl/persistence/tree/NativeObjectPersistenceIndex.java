/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence.tree;

/**
 *
 * @author vpc
 */
public class NativeObjectPersistenceIndex extends NativeObjectPersistenceNode {

    private String tableName;
    private String indexName;

    public NativeObjectPersistenceIndex(String tableName, String indexName) {
        this.tableName = tableName;
        this.indexName = indexName;
    }

    
    public String getTableName() {
        return tableName;
    }

    public void setTableName(String tableName) {
        this.tableName = tableName;
    }

    public String getIndexName() {
        return indexName;
    }

    public void setIndexName(String indexName) {
        this.indexName = indexName;
    }
}
