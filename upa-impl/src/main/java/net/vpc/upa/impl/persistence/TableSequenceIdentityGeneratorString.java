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
public class TableSequenceIdentityGeneratorString extends TableSequenceIdentityGenerator {

    public TableSequenceIdentityGeneratorString(Field field, Sequence generatedId) {
        super(field, generatedId);
    }

    protected Object getNewValue(SequenceManager sm, String group, Record record) throws UPAException{
        return  eval(getFormat(), sm.nextValue(getName(), group,getInitialValue(),getAllocationSize()),record);
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
