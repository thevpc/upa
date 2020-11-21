/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.impl.DefaultPersistenceUnit;
import net.thevpc.upa.Entity;
import net.thevpc.upa.impl.OnHoldCommitActionType;

/**
 *
 * @author vpc
 */
public class DefaultOnHoldCommitActionEntity extends DefaultOnHoldCommitAction {

    public DefaultOnHoldCommitActionEntity(Entity object, OnHoldCommitActionType type) {
        super(object, type, DefaultPersistenceUnit.COMMIT_ORDER_ENTITY);
    }

    @Override
    public int getOrder() {
        Entity e = (Entity) getObject();
        if (e.isView()) {
            return DefaultPersistenceUnit.COMMIT_ORDER_VIEW;
        }
        return DefaultPersistenceUnit.COMMIT_ORDER_ENTITY;
    }

}
