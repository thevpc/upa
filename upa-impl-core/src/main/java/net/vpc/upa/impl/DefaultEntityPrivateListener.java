/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import net.vpc.upa.*;
import net.vpc.upa.impl.ext.EntityExt;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultEntityPrivateListener implements UPAObjectListener {

    private EntityExt entity;

    public DefaultEntityPrivateListener(EntityExt entity) {
        this.entity = entity;
    }

    
    public void itemRemoved(UPAObject object, int position, EventPhase eventPhase) {
    }

    public void itemMoved(UPAObject object, int position, int toPosition, EventPhase eventPhase) {
    }

    public void itemAdded(UPAObject object, int position, UPAObject parent, EventPhase eventPhase) {
        if (eventPhase==EventPhase.BEFORE) {
            entity.beforeItemAdded((EntityItem)parent, (EntityItem) object, position);
        }else{
            entity.afterItemAdded((EntityItem)parent, (EntityItem) object, position);
        }
    }
}
