/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl;

import net.thevpc.upa.EntityItem;
import net.thevpc.upa.EventPhase;
import net.thevpc.upa.UPAObject;
import net.thevpc.upa.UPAObjectListener;
import net.thevpc.upa.impl.ext.EntityExt;


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
