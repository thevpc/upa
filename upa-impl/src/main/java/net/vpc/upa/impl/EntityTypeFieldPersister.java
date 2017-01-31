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
            Entity masterEntity = executionContext.getPersistenceUnit().getEntity(e.getTargetEntityName());
            Key k = null;
            if (value instanceof Document) {
                k = masterEntity.getBuilder().documentToKey((Document) value);
            } else {
                k = masterEntity.getBuilder().objectToKey(value);
            }
            int x = 0;
            for (Field fk : e.getRelationship().getSourceRole().getFields()) {
                persistNonNullable.remove(fk);
                persistWithDefaultValue.remove(fk);
                persistentDocument.setObject(fk.getName(), k == null ? null : k.getObjectAt(x));
                x++;
            }
        }
    }
    
    public void prepareFieldForUpdate(Field field, Object value, Document userDocument, Document persistentDocument, EntityExecutionContext executionContext) throws UPAException {
        persistentDocument.setObject(field.getName(), value);
    }

}
