/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.persistence;

/**
 *
 * @author vpc
 */
public interface PrimaryKeyPersistenceDefinition extends NativeObjectPersistenceDefinition {
    public String getPrimaryKeyName();
}
