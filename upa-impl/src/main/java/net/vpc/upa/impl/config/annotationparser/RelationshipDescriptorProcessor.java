/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.callbacks.EntityEvent;
import net.vpc.upa.callbacks.EntityDefinitionListener;
import net.vpc.upa.callbacks.PersistenceUnitListener;
import net.vpc.upa.callbacks.FieldDefinitionListener;
import net.vpc.upa.callbacks.FieldEvent;
import net.vpc.upa.callbacks.PersistenceUnitEvent;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.DefaultPersistenceUnit;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.Strings;
import net.vpc.upa.types.ManyToOneType;
import net.vpc.upa.types.DataType;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class RelationshipDescriptorProcessor implements EntityDefinitionListener, FieldDefinitionListener, PersistenceUnitListener {

    PersistenceUnit persistenceUnit;
    RelationshipDescriptor relationDescriptor;
    Entity detailEntity;
    Entity masterEntity;
    Relationship relation;
    Field manyToOneField = null;
    RelationshipUpdateType detailUpdateType;
    List<String> detailFieldNames;
    boolean nullable;
    Expression filter;

    public RelationshipDescriptorProcessor(PersistenceUnit persistenceUnit, RelationshipDescriptor relationInfo) {
        this.persistenceUnit = persistenceUnit;
        this.relationDescriptor = relationInfo;
    }

    public void process() {
        if (!processRelation(false)) {
            if (!Strings.isNullOrEmpty(relationDescriptor.getSourceEntity())) {
                persistenceUnit.addDefinitionListener(relationDescriptor.getSourceEntity(), this, true);
            }
            if (!Strings.isNullOrEmpty(relationDescriptor.getTargetEntity())) {
                persistenceUnit.addDefinitionListener(relationDescriptor.getTargetEntity(), this, true);
            }
            if (relationDescriptor.getSourceEntityType() != null) {
                persistenceUnit.addDefinitionListener(relationDescriptor.getSourceEntityType(), this, true);
            }
            if (relationDescriptor.getTargetEntityType() != null) {
                persistenceUnit.addDefinitionListener(relationDescriptor.getTargetEntityType(), this, true);
            }
            persistenceUnit.addPersistenceUnitListener(this);
        }
    }

    public void onModelChanged(PersistenceUnitEvent event) {
        if (!build(true)) {
            throw new UPAException("UnknownError");
        }
    }

    public void onCreateEntity(EntityEvent event) {
        Entity e = event.getEntity();
        if (isDetailOrMasterEntity(e)) {
            processRelation(false);
//                event.getPersistenceUnit().removeDefinitionListener(relationDescriptor.getTargetEntity(), this);
        }
    }

    protected boolean isDetailOrMasterEntity(Entity e) {
        String n = e.getName();
        Class t = e.getEntityType();
        if (n.equals(relationDescriptor.getSourceEntity()) || t.equals(relationDescriptor.getSourceEntityType())) {
            return true;
        }
        if (n.equals(relationDescriptor.getTargetEntity()) || t.equals(relationDescriptor.getTargetEntityType())) {
            return true;
        }
        return false;
    }

    public void onCreateField(FieldEvent event) throws UPAException {
//            if (event.getField().getAbsoluteName().equals("User.id")) {
//                System.out.println("Here");
//            }
        Entity entity = event.getEntity();
        if (isDetailOrMasterEntity(entity)) {
            processRelation(false);
//                event.getPersistenceUnit().removeDefinitionListener(relationDescriptor.getTargetEntity(), this);
        }
    }

    private boolean build(boolean throwErrors) {
        if (detailEntity == null) {
            if (relationDescriptor.getSourceEntity() != null) {
                if (persistenceUnit.containsEntity(relationDescriptor.getSourceEntity())) {
                    detailEntity = persistenceUnit.getEntity(relationDescriptor.getSourceEntity());
                }
            }
        }
        if (detailEntity == null) {
            if (relationDescriptor.getSourceEntityType() != null) {
                if (persistenceUnit.containsEntity(relationDescriptor.getSourceEntityType())) {
                    detailEntity = persistenceUnit.getEntity(relationDescriptor.getSourceEntityType());
                }
            }
        }
        if (masterEntity == null) {
            if (relationDescriptor.getTargetEntity() != null) {
                if (persistenceUnit.containsEntity(relationDescriptor.getTargetEntity())) {
                    masterEntity = persistenceUnit.getEntity(relationDescriptor.getTargetEntity());
                }
            }
        }
        if (masterEntity == null) {
            if (relationDescriptor.getTargetEntityType() != null) {
                if (persistenceUnit.containsEntity(relationDescriptor.getTargetEntityType())) {
                    masterEntity = persistenceUnit.getEntity(relationDescriptor.getTargetEntityType());
                }
            }
        }
        if (detailEntity == null) {
            if (throwErrors) {
                throw new UPAException("InvalidRelationEntityNotFound", relationDescriptor.getSourceEntityType());
            } else {
                return false;
            }
        }
        if (masterEntity == null) {
            if (throwErrors) {
                throw new UPAException("InvalidRelationEntityNotFound", relationDescriptor.getTargetEntityType());
            } else {
                return false;
            }
        }
        detailUpdateType = RelationshipUpdateType.FLAT;
        detailFieldNames = new ArrayList<String>();
        if (relationDescriptor.getBaseField() == null) {
            detailFieldNames.addAll(Arrays.asList(relationDescriptor.getSourceFields()));
            if (relationDescriptor.getMappedTo() != null && relationDescriptor.getMappedTo().length > 0) {
                if (relationDescriptor.getMappedTo().length > 1) {
                    throw new IllegalArgumentException("mappedTo cannot only apply to single Entity Field");
                }
                manyToOneField = detailEntity.getField(relationDescriptor.getMappedTo()[0]);
            }
        } else {
            Field baseField = detailEntity.getField(relationDescriptor.getBaseField());
            DataType baseFieldType = baseField.getDataType();
            if (baseFieldType instanceof ManyToOneType) {
                ManyToOneType et = (ManyToOneType) baseFieldType;
                if (et.getReferencedEntityName() == null || et.getReferencedEntityName().isEmpty()) {
                    et.setReferencedEntityName(masterEntity.getName());
                }
                detailUpdateType = RelationshipUpdateType.COMPOSED;
                List<Field> masterPK = masterEntity.getPrimaryFields();
                if (relationDescriptor.getMappedTo() == null || relationDescriptor.getMappedTo().length == 0) {
                    if (masterPK.isEmpty()) {
                        if (throwErrors) {
                            throw new UPAException("PrimaryFieldsNotFoundException", masterEntity.getName());
                        } else {
                            return false;
                        }
                    } else {
                        for (Field masterField : masterPK) {
                            String f = masterField.getName();
                            if (f.length() == 1) {
                                f = f.toUpperCase();
                            } else if (f.length() > 1) {
                                f = f.substring(0, 1).toUpperCase() + f.substring(1);
                            }
                            String extraName = baseField.getName() + f;
                            detailFieldNames.add(extraName);
                        }
                    }
                } else {
                    detailFieldNames.addAll(Arrays.asList(relationDescriptor.getMappedTo()));
                }
                if (detailFieldNames.size() != masterPK.size()) {
                    if (throwErrors) {
                        throw new IllegalArgumentException("Incorrect parameters");
                    } else {
                        return false;
                    }
                }
                if (detailFieldNames.isEmpty()) {
                    if (throwErrors) {
                        throw new IllegalArgumentException("Incorrect parameters");
                    } else {
                        return false;
                    }
                }
                for (int i = 0; i < detailFieldNames.size(); i++) {
                    String extraName = detailFieldNames.get(i);
                    Field idField = detailEntity.findField(extraName);
                    if (idField == null) {
                        DataType dt = (DataType) masterPK.get(i).getDataType().clone();
                        boolean nullable = baseFieldType.isNullable();
                        dt.setNullable(nullable);
                        idField = detailEntity.addField(extraName, "system", FlagSets.of(UserFieldModifier.SYSTEM), FlagSets.of(UserFieldModifier.UPDATE), null, dt, -1);
                        idField.setAccessLevel(AccessLevel.PRIVATE);
                    } else {
                        idField.setUserExcludeModifiers(idField.getUserExcludeModifiers().add(UserFieldModifier.UPDATE));
                    }
                }
                manyToOneField = baseField;
            } else {
                detailFieldNames.add(baseField.getName());
                if (relationDescriptor.getMappedTo() != null && relationDescriptor.getMappedTo().length > 0) {
                    if (relationDescriptor.getMappedTo().length > 1) {
                        throw new IllegalArgumentException("mappedTo cannot only apply to single Entity Field");
                    }
                    manyToOneField = detailEntity.getField(relationDescriptor.getMappedTo()[0]);
                }
            }
        }
        nullable = true;//TODO FIX ME
        for (int i = 0; i < detailFieldNames.size(); i++) {
            Field slaveField = detailEntity.getField(detailFieldNames.get(i));
            DataType dataType = slaveField.getDataType();
            if (dataType == null) {
                //inherit master DataType
                if (masterEntity.getPrimaryFields().size() > i) {
                    DataType d = masterEntity.getPrimaryFields().get(i).getDataType();
                    d = (DataType) d.clone();
                    d.setNullable(nullable);
                    slaveField.setDataType(d);
                    //reset transform!
                    slaveField.setTypeTransform(null);
                } else {
                    throw new IllegalArgumentException("Invalid Relation");
                }
            }
        }
        filter = relationDescriptor.getFilter();
//        if (baseFieldType instanceof ManyToOneType) {
//            manyToOneField = baseField;
//        } else if (detailFieldNames.size() == 1) {
//            DataType slaveType = slaveField.getDataType();
//            if (slaveType instanceof ManyToOneType) {
//                manyToOneField = slaveField;
//            }
//        }
        return true;
    }

    public boolean processImmediate() {
        return processRelation(false);
    }

    private boolean processRelation(boolean throwErrors) {
        if (!build(throwErrors)) {
            return false;
        }
        PersistenceUnit pu = detailEntity.getPersistenceUnit();
        if (relation == null) {
            DefaultRelationshipDescriptor rd = new DefaultRelationshipDescriptor();
            rd.setName(relationDescriptor.getName());
            rd.setBaseField(relationDescriptor.getBaseField());
            rd.setRelationshipType(relationDescriptor.getRelationshipType());
            rd.setSourceEntity(detailEntity.getName());
            rd.setTargetEntity(masterEntity.getName());
            rd.setSourceFields(detailFieldNames.toArray(new String[detailFieldNames.size()]));
            rd.setFilter(relationDescriptor.getFilter());
            rd.setHierarchy(relationDescriptor.isHierarchy());
            rd.setHierarchyPathField(relationDescriptor.getHierarchyPathField());
            rd.setHierarchyPathSeparator(relationDescriptor.getHierarchyPathSeparator());
            rd.setNullable(relationDescriptor.isNullable());

            relation = ((DefaultPersistenceUnit) pu).addRelationshipImmediate(rd);
//                    relationDescriptor.getName(),
//                    relationDescriptor.getRelationType(),
//                    detailEntity.getName(),
//                    masterEntity.getName(),
//                    manyToOneField == null ? null : manyToOneField.getName(),
//                    null,
//                    detailUpdateType,
//                    null,
//                    detailFieldNames.toArray(new String[detailFieldNames.size()]),
//                    nullable,
//                    filter);
//            if(relationDescriptor.hierarchy()){
//                detailEntity.addExtensionDefinition(
//                        TreeEntityExtensionDefinition.class, 
//                        new DefaultTreeEntityExtensionDefinition(
//                        manyToOneField!=null?manyToOneField.getName():detailFieldNames.get(0),
//                        relation.getName(),
//                        relationDescriptor.getHierarchyPathField(),
//                        relationDescriptor.getHierarchyPathSeparator()
//                ));
//            }
        } else {
            if (!Strings.isNullOrEmpty(relationDescriptor.getName())) {
                relation.setName(relationDescriptor.getName());
            }
            relation.setRelationshipType(relationDescriptor.getRelationshipType() == null ? RelationshipType.DEFAULT : relationDescriptor.getRelationshipType());
            relation.getSourceRole().setEntityField(manyToOneField);
            relation.getSourceRole().setRelationshipUpdateType(detailUpdateType);
            List<Field> slaveFields = new ArrayList<Field>();
            for (String n : detailFieldNames) {
                Field f = detailEntity.getField(n);
                slaveFields.add(f);
            }
            relation.getSourceRole().setFields(slaveFields.toArray(new Field[slaveFields.size()]));

            relation.getTargetRole().setEntityField(null);
            relation.getTargetRole().setRelationshipUpdateType(PlatformUtils.getUndefinedValue(RelationshipUpdateType.class));
            relation.setFilter(filter);
            relation.setNullable(nullable);
        }
        return true;
    }

    public void onStorageChanged(PersistenceUnitEvent event) {
    }

    public void onStart(PersistenceUnitEvent event) {
    }

    public void onClose(PersistenceUnitEvent event) {
    }

    public void onDropEntity(EntityEvent event) {
        //                            if (event.isAfter()) {
        //                                processImmediate(foreignInfo);
        //                            }
    }

    public void onMoveEntity(EntityEvent event) {
    }

    public void onDropField(FieldEvent event) throws UPAException {
    }

    public void onMoveField(FieldEvent event) throws UPAException {
    }

    @Override
    public void onPreCreateEntity(EntityEvent event) {

    }

    @Override
    public void onPreDropEntity(EntityEvent event) {

    }

    @Override
    public void onPreMoveEntity(EntityEvent event) {

    }

    @Override
    public void onPreCreateField(FieldEvent event) throws UPAException {

    }

    @Override
    public void onPreDropField(FieldEvent event) throws UPAException {

    }

    @Override
    public void onPreMoveField(FieldEvent event) throws UPAException {

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
    public void onPreUpdateFormulas(PersistenceUnitEvent event) {
    }

    @Override
    public void onUpdateFormulas(PersistenceUnitEvent event) {

    }

    @Override
    public void onInitEntity(EntityEvent event) {

    }

    @Override
    public void onPreInitEntity(EntityEvent event) {

    }

}
