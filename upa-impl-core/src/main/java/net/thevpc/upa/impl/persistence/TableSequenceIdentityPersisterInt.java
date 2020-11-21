/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.Field;
import net.thevpc.upa.Document;
import net.thevpc.upa.Sequence;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.impl.SequenceManager;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class TableSequenceIdentityPersisterInt extends TableSequenceIdentityPersister {

    public TableSequenceIdentityPersisterInt(Field field, Sequence generatedId) {
        super(field, generatedId);
    }

    @Override
    protected Object getNewValue(SequenceManager sm, String group, Document document) throws UPAException {
        return sm.nextValue(getName(), group,getInitialValue(),getAllocationSize());
    }

    @Override
    public boolean equals(Object o) {
        return super.equals(o) && o instanceof TableSequenceIdentityPersisterInt;
    }

    @Override
    public int hashCode() {
        int hash = 5;
        return hash;
    }
}
