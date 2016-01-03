/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import java.util.Set;
import net.vpc.upa.Field;
import net.vpc.upa.Record;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityExecutionContext;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public interface FieldPersister {

    public void prepareFieldForPersist(Field field, Object value, Record userRecord, Record persistentRecord, EntityExecutionContext executionContext, Set<Field> persistNonNullable, Set<Field> persistWithDefaultValue) throws UPAException;

    public void prepareFieldForUpdate(Field field, Object value, Record userRecord, Record persistentRecord, EntityExecutionContext executionContext) throws UPAException;
}
