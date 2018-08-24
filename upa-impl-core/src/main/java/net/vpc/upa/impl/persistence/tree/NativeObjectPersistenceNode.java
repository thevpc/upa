/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence.tree;

import net.vpc.upa.PersistenceState;
import net.vpc.upa.UPAObject;
import net.vpc.upa.config.PersistenceNameType;
import net.vpc.upa.persistence.NativeObjectPersistenceDefinition;

/**
 *
 * @author vpc
 */
public class NativeObjectPersistenceNode {

    private PersistenceState state = PersistenceState.DEFAULT;
    private UPAObject modelObject;
    private PersistenceNameType modelObjectSpec;
    private NativeObjectPersistenceDefinition storeDefinition;
    private NativeObjectPersistenceDefinition modelDefinition;

    public UPAObject getModelObject() {
        return modelObject;
    }

    public void setModelObject(UPAObject modelObject) {
        this.modelObject = modelObject;
    }

    public PersistenceNameType getModelObjectSpec() {
        return modelObjectSpec;
    }

    public void setModelObjectSpec(PersistenceNameType modelObjectSpec) {
        this.modelObjectSpec = modelObjectSpec;
    }

    public PersistenceState getPersistenceState() {
        return state;
    }

    public PersistenceState getState() {
        return state;
    }

    public void setState(PersistenceState state) {
        this.state = state;
    }

    public NativeObjectPersistenceDefinition getStoreDefinition() {
        return storeDefinition;
    }

    public void setStoreDefinition(NativeObjectPersistenceDefinition storeDefinition) {
        this.storeDefinition = storeDefinition;
    }

    public NativeObjectPersistenceDefinition getModelDefinition() {
        return modelDefinition;
    }

    public void setModelDefinition(NativeObjectPersistenceDefinition modelDefinition) {
        this.modelDefinition = modelDefinition;
    }

}
