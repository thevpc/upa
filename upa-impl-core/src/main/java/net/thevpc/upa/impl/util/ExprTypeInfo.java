/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.util;

import net.thevpc.upa.types.DataTypeTransform;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class ExprTypeInfo {
    private DataTypeTransform transform;
    private Object oldReferrer;
    private Object referrer;

    public ExprTypeInfo() {
    }

    public DataTypeTransform getTypeTransform() {
        return transform;
    }

    public void setTransform(DataTypeTransform transform) {
        this.transform = transform;
    }

    public Object getOldReferrer() {
        return oldReferrer;
    }

    public void setOldReferrer(Object oldReferrer) {
        this.oldReferrer = oldReferrer;
    }

    public Object getReferrer() {
        return referrer;
    }

    public void setReferrer(Object referrer) {
        this.referrer = referrer;
    }
    
}
