/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl;

import java.util.Set;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.Key;
import net.vpc.upa.Document;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.types.ManyToOneType;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class EntityTypeFieldPersister implements FieldPersister {

    public void prepareFieldForPersist(Field field, Object value, Document userDocument, Document persistentDocument, EntityExecutionContext executionContext, Set<Field> persistNonNullable, Set<Field> persistWithDefaultValue) throws UPAException {
        ManyToOneType e = (ManyToOneType) field.getDataType();
        if (e.isUpdatable()) {
            for (Field fk : e.getRelationship().getSourceRole().getFields()) {
                persistNonNullable.remove(fk);
                persistWithDefaultValue.remove(fk);
                Object k = userDocument.get(fk.getName());
                persistentDocument.setObject(fk.getName(), k);
            }
        }
    }
    
    public void prepareFieldForUpdate(Field field, Object value, Document userDocument, Document persistentDocument, EntityExecutionContext executionContext) throws UPAException {
        persistentDocument.setObject(field.getName(), value);
    }

}
