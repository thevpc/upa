/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.Relationship;
import net.vpc.upa.impl.DefaultPersistenceUnit;
import net.vpc.upa.impl.OnHoldCommitActionType;

/**
 *
 * @author vpc
 */
public class DefaultOnHoldCommitActionRelationship extends DefaultOnHoldCommitAction{

    public DefaultOnHoldCommitActionRelationship(Relationship object, OnHoldCommitActionType type) {
        super(object, type, DefaultPersistenceUnit.COMMIT_ORDER_RELATION);
    }

    @Override
    public int getOrder() {
        Relationship e=(Relationship)getObject();
        if(e.isTransient()){
            return DefaultPersistenceUnit.COMMIT_ORDER_VIEW;
        }
        return super.getOrder();
    }
    
    
    
}
