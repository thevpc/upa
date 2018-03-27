/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.Document;
import net.vpc.upa.Field;
import net.vpc.upa.Sequence;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.SequenceManager;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class TableSequenceIdentityPersisterString extends TableSequenceIdentityPersister {

    public TableSequenceIdentityPersisterString(Field field, Sequence generatedId) {
        super(field, generatedId);
    }

    protected Object getNewValue(SequenceManager sm, String group, Document document) throws UPAException{
        return  eval(getFormat(), sm.nextValue(getName(), group,getInitialValue(),getAllocationSize()), document);
    }

    @Override
    public boolean equals(Object o) {
        return super.equals(o) && o.getClass().equals(getClass());
    }

    @Override
    public int hashCode() {
        int hash = 3;
        return hash;
    }

}
