/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.Field;
import net.vpc.upa.Record;
import net.vpc.upa.Sequence;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.SequenceManager;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class TableSequenceIdentityPersisterInt extends TableSequenceIdentityPersister {

    public TableSequenceIdentityPersisterInt(Field field, Sequence generatedId) {
        super(field, generatedId);
    }

    @Override
    protected Object getNewValue(SequenceManager sm, String group, Record record) throws UPAException {
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
