/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.Entity;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.FieldPersister;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class NavigatorIdentityPersister implements FieldPersister {
    public void beforePersist(Record record, EntityExecutionContext context) throws UPAException{
        //K key = entity.getBuilder().recordToId(record);
        Entity entity = context.getEntity();
        Object key = entity.nextId();
        entity.getBuilder().setRecordId(record, key);
    }

    public void afterPersist(Record record, EntityExecutionContext context) {
        
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        return true;
    }

    @Override
    public int hashCode() {
        return 31;
    }
}
