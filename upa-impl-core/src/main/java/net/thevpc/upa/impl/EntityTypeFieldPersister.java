/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.thevpc.upa.impl;

import java.util.Set;

import net.thevpc.upa.Field;
import net.thevpc.upa.Document;
import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.persistence.EntityExecutionContext;
import net.thevpc.upa.types.RelationDataType;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class EntityTypeFieldPersister implements FieldPersister {

    public void prepareFieldForPersist(Field field, Object value, Document userDocument, Document persistentDocument, EntityExecutionContext executionContext, Set<Field> persistNonNullable, Set<Field> persistWithDefaultValue) throws UPAException {
        RelationDataType e = (RelationDataType) field.getDataType();
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
