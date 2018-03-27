/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.Document;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.FieldPersister;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DatabaseIdentityPersister implements FieldPersister {

    private Field field;
    String identityConstraintsEnabledProperty;

    public DatabaseIdentityPersister(Field field) {
        this.field = field;
        identityConstraintsEnabledProperty = "IdentityConstraintsEnabled." + field.getEntity().getName();
    }

    public void beforePersist(Document document, EntityExecutionContext context) throws UPAException {
        if (Boolean.FALSE.equals(context.getConnection().getProperty(identityConstraintsEnabledProperty))) {
            return;
        }
        context.addGeneratedValue(field.getName(), field.getDataType());
        //manual id values are ignored
        document.remove(field.getName());
    }

    public void afterPersist(Document document, EntityExecutionContext context) {
        if (Boolean.FALSE.equals(context.getConnection().getProperty(identityConstraintsEnabledProperty))) {
            return;
        }
        document.setObject(field.getName(), context.getGeneratedValue(field.getName()).getValue());
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) {
            return true;
        }
        if (o == null || getClass() != o.getClass()) {
            return false;
        }

        DatabaseIdentityPersister that = (DatabaseIdentityPersister) o;

        if (!field.equals(that.field)) {
            return false;
        }

        return true;
    }

    @Override
    public int hashCode() {
        return field.hashCode();
    }
}
