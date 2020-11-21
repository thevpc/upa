/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.config.annotationparser;

import net.thevpc.upa.PersistenceUnit;
import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.events.EntityEvent;
import net.thevpc.upa.events.EntityDefinitionListener;
import net.thevpc.upa.events.PersistenceUnitListener;
import net.thevpc.upa.events.DefinitionListenerAdapter;
import net.thevpc.upa.events.PersistenceUnitEvent;
import net.thevpc.upa.DefaultRelationshipDescriptor;
import net.thevpc.upa.Entity;
import net.thevpc.upa.Field;
import net.thevpc.upa.exceptions.IllegalUPAArgumentException;
import net.thevpc.upa.impl.SerializableOrManyToOneType;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.types.ManyToOneType;
import net.thevpc.upa.types.DataType;
import net.thevpc.upa.types.SerializableType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class FieldSerializableOrEntityProcessor extends DefinitionListenerAdapter implements EntityDefinitionListener,
        PersistenceUnitListener {

    private PersistenceUnit persistenceUnit;
    private Field field;
    private Class relationshipTargetEntityType;

    public FieldSerializableOrEntityProcessor(PersistenceUnit persistenceUnit, Field field) {
        this.persistenceUnit = persistenceUnit;
        this.field = field;
    }

    public void process() {
        DataType dataType = field.getDataType();
        if (dataType instanceof SerializableOrManyToOneType) {
            SerializableOrManyToOneType master = (SerializableOrManyToOneType) dataType;
            relationshipTargetEntityType = master.getEntityType();
            if (persistenceUnit.containsEntity(relationshipTargetEntityType)) {
                Entity tt = persistenceUnit.getEntity(relationshipTargetEntityType);
                bindRelation(tt);
            } else {
                persistenceUnit.addDefinitionListener(relationshipTargetEntityType, this, true);
                persistenceUnit.addPersistenceUnitListener(this);
            }
        }
    }

    @Override
    public void onModelChanged(PersistenceUnitEvent event) {
        DataType dataType = field.getDataType();
        if (dataType instanceof SerializableOrManyToOneType) {
            SerializableOrManyToOneType masterDatatype = (SerializableOrManyToOneType) dataType;
            Class tt = masterDatatype.getEntityType();
            if (PlatformUtils.isSerializable(tt)) {
                field.setDataType(new SerializableType(masterDatatype.getName(), tt, masterDatatype.isNullable()));
                field.setTypeTransform(null);
//                field.setTypeTransform(new IdentityDataTypeTransform(field.getDataType()));
            } else {
                throw new IllegalUPAArgumentException("Type " + tt + " is neither Entity nor Serializable for " + field);
            }
        }
    }

    @Override
    public void onCreateEntity(EntityEvent event) {
        bindRelation(event.getEntity());
    }

    private void bindRelation(Entity masterEntity) {
        DataType dataType = field.getDataType();
        if (dataType instanceof SerializableOrManyToOneType) {
            field.setDataType(new ManyToOneType(dataType.getName(), dataType.getPlatformType(), masterEntity.getName(), true, dataType.isNullable()));
            field.setTypeTransform(null);
            field.setTypeTransform(IdentityDataTypeTransform.ofType(field.getDataType()));
            DefaultRelationshipDescriptor relationDescriptor = new DefaultRelationshipDescriptor();
            relationDescriptor.setBaseField(field.getName());
            relationDescriptor.setTargetEntityType(masterEntity.getEntityType());
            relationDescriptor.setTargetEntity(masterEntity.getName());
            relationDescriptor.setSourceEntityType(field.getEntity().getEntityType());
            relationDescriptor.setSourceEntity(field.getEntity().getName());
            field.getPersistenceUnit().addRelationship(relationDescriptor);
        }
    }

    @Override
    public void onStorageChanged(PersistenceUnitEvent event) {
    }

    @Override
    public void onStart(PersistenceUnitEvent event) {
    }

    @Override
    public void onPreDropEntity(EntityEvent event) {
    }

    @Override
    public void onDropEntity(EntityEvent event) {
    }

    @Override
    public void onPreMoveEntity(EntityEvent event) {
    }

    @Override
    public void onMoveEntity(EntityEvent event) {
    }

    @Override
    public void onPreModelChanged(PersistenceUnitEvent event) {

    }

    @Override
    public void onPreStorageChanged(PersistenceUnitEvent event) {

    }

    @Override
    public void onPreStart(PersistenceUnitEvent event) {

    }

    @Override
    public void onPreClear(PersistenceUnitEvent event) {

    }

    @Override
    public void onClear(PersistenceUnitEvent event) {

    }

    @Override
    public void onPreReset(PersistenceUnitEvent event) {

    }

    @Override
    public void onReset(PersistenceUnitEvent event) {

    }

    @Override
    public void onPreClose(PersistenceUnitEvent event) {

    }

    @Override
    public void onClose(PersistenceUnitEvent event) {

    }

    @Override
    public void onPreUpdateFormulas(PersistenceUnitEvent event) {
    
    }

    @Override
    public void onUpdateFormulas(PersistenceUnitEvent event) {
    
    }
    
}
