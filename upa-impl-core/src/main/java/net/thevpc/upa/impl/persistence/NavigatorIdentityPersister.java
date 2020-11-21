/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.Entity;
import net.thevpc.upa.Document;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.persistence.FieldPersister;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class NavigatorIdentityPersister implements FieldPersister {
    public void beforePersist(Document document, EntityExecutionContext context) throws UPAException{
        //K key = entity.getBuilder().documentToId(document);
        Entity entity = context.getEntity();
        Object key = entity.nextId();
        entity.getBuilder().setDocumentId(document, key);
    }

    public void afterPersist(Document document, EntityExecutionContext context) {
        
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
