/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.FieldPersister;
import net.vpc.upa.types.ManyToOneType;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ComposedToFlatFieldPersister implements FieldPersister {

    private Field field;
    private EntityBuilder relationshipTargetConverter;
    private List<Field> flatFields;

    public ComposedToFlatFieldPersister(Field field) {
        this.field = field;
        ManyToOneType t = (ManyToOneType) field.getDataType();
        Entity master = t.getRelationship().getTargetRole().getEntity();
        RelationshipRole detailRole = t.getRelationship().getSourceRole();
        flatFields = detailRole.getFields();
        relationshipTargetConverter = master.getBuilder();
    }

    public void beforePersist(Record record, EntityExecutionContext context) throws UPAException {
        Object o = record.getObject(field.getName());
        Key key = relationshipTargetConverter.objectToKey(o);
        if (key == null) {
            for (Field ff : flatFields) {
                record.setObject(ff.getName(), ff.getUnspecifiedValueDecoded());
            }
        } else {
            int i = 0;
            for (Field ff : flatFields) {
                record.setObject(ff.getName(), key.getObjectAt(i));
                i++;
            }
        }
    }

    public void afterPersist(Record record, EntityExecutionContext context) throws UPAException {
    }
}
