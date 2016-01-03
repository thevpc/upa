/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.Field;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.FieldPersister;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class NativeIdentityGenerator implements FieldPersister {
    private Field field;

    public NativeIdentityGenerator(Field field) {
        this.field = field;
    }

    public void beforePersist(Record record, EntityExecutionContext context) throws UPAException{
        context.addGeneratedValue(field.getName(), field.getDataType());
        //manual id values are ignored
        record.remove(field.getName());
    }

    public void afterPersist(Record record, EntityExecutionContext context) {
        record.setObject(field.getName(),context.getGeneratedValue(field.getName()).getValue());
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        NativeIdentityGenerator that = (NativeIdentityGenerator) o;

        if (!field.equals(that.field)) return false;

        return true;
    }

    @Override
    public int hashCode() {
        return field.hashCode();
    }
}
