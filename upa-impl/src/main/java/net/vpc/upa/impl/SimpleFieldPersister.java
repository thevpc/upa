/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import java.util.Set;
import net.vpc.upa.Field;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.Param;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class SimpleFieldPersister implements FieldPersister {

    public void prepareFieldForPersist(Field field, Object value, Record userRecord, Record persistentRecord, EntityExecutionContext executionContext, Set<Field> persistNonNullable, Set<Field> persistWithDefaultValue) throws UPAException {
        Expression valueExpression = (value instanceof Expression) ? (Expression) value : new Param(field.getName(), value);
        persistentRecord.setObject(field.getName(), valueExpression);
    }

    public void prepareFieldForUpdate(Field field, Object value, Record userRecord, Record persistentRecord, EntityExecutionContext executionContext) throws UPAException {
        persistentRecord.setObject(field.getName(), value);
    }

}
