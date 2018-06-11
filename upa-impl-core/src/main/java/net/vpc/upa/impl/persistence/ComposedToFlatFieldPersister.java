/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.PrimitiveIdImpl;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.persistence.EntityExecutionContext;
import net.vpc.upa.persistence.FieldPersister;
import net.vpc.upa.types.ManyToOneType;
import net.vpc.upa.types.RelationDataType;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class ComposedToFlatFieldPersister implements FieldPersister {

    private Field field;
    private EntityBuilder relationshipTargetConverter;
    private List<Field> flatFields;
    private Entity master;
    private boolean arr;

    public ComposedToFlatFieldPersister(Field field) {
        this.field = field;
        RelationDataType t = (RelationDataType) field.getDataType();
        master = t.getRelationship().getTargetRole().getEntity();
        RelationshipRole detailRole = t.getRelationship().getSourceRole();
        flatFields = detailRole.getFields();
        relationshipTargetConverter = master.getBuilder();
        arr=flatFields.size()>1;
    }

    public void beforePersist(Document document, EntityExecutionContext context) throws UPAException {
        Object o = document.getObject(field.getName());
        EntityBuilder builder = master.getBuilder();
        PrimitiveId primitiveIdImpl = builder.objectToPrimitiveId(o);
        if (primitiveIdImpl == null) {
            for (Field ff : flatFields) {
                document.setObject(ff.getName(), ff.getUnspecifiedValueDecoded());
            }
        } else {
            if(arr){
                Object[] value = (Object[]) primitiveIdImpl.getValue();
                int i = 0;
                for (Field ff : flatFields) {
                    document.setObject(ff.getName(), value[i]);
                    i++;
                }
            }else {
                Object value = primitiveIdImpl.getValue();
                document.setObject(flatFields.get(0).getName(), value);
            }
        }
    }

    public void afterPersist(Document document, EntityExecutionContext context) throws UPAException {
    }
}
