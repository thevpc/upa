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
public class NativeObjectPersistenceForeignKey extends NativeObjectPersistenceNode {

    private final String foreignKeyName;
    private final String primaryKeyTable;

    public NativeObjectPersistenceForeignKey(String foreignKeyName, String primaryKeyTable) {
        this.foreignKeyName = foreignKeyName;
        this.primaryKeyTable = primaryKeyTable;
    }

    public String getForeignKeyName() {
        return foreignKeyName;
    }

    public String getPrimaryKeyTable() {
        return primaryKeyTable;
    }

}
