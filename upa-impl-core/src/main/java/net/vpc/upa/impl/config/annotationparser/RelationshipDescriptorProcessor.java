/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.events.FieldEvent;
import net.vpc.upa.events.EntityEvent;
import net.vpc.upa.events.PersistenceUnitEvent;
import net.vpc.upa.events.EntityDefinitionListener;
import net.vpc.upa.events.PersistenceUnitListener;
import net.vpc.upa.events.FieldDefinitionListener;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.exceptions.IllegalUPAArgumentException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.impl.SerializableOrManyToOneType;
import net.vpc.upa.impl.ext.PersistenceUnitExt;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.ManyToOneType;
import net.vpc.upa.types.OneToOneType;
import net.vpc.upa.types.RelationDataType;

import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class RelationshipDescriptorProcessor implements EntityDefinitionListener, FieldDefinitionListener, PersistenceUnitListener {

    PersistenceUnit persistenceUnit;
    RelationshipDescriptor relationDescriptor;
    Entity sourceEntity;
    Entity targetEntity;
    Relationship relation;
    Field manyToOneField = null;
    RelationshipUpdateType sourceUpdateType;
    List<String> sourceFieldNames;
    boolean nullable;
    Expression filter;

    public RelationshipDescriptorProcessor(PersistenceUnit persistenceUnit, RelationshipDescriptor relationInfo) {
        this.persistenceUnit = persistenceUnit;
        this.relationDescriptor = relationInfo;
        if (StringUtils.isNullOrEmpty(relationDescriptor.getTargetEntity()) && relationDescriptor.getTargetEntityType() == null) {
            throw new UPAException("NoneOfTargetEntityAndTargetEntityTypeDefined");
        }
        if (StringUtils.isNullOrEmpty(relationDescriptor.getSourceEntity()) && relationDescriptor.getSourceEntityType() == null) {
            throw new UPAException("NoneOfSourceEntityAndSourceEntityTypeDefined");
        }
    }

    public void process() {
        if (!processRelation(false)) {
            if (!StringUtils.isNullOrEmpty(relationDescriptor.getSourceEntity())) {
                persistenceUnit.addDefinitionListener(relationDescriptor.getSourceEntity(), this, true);
            }
            if (!StringUtils.isNullOrEmpty(relationDescriptor.getTargetEntity())) {
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
        if (sourceEntity == null) {
            if (relationDescriptor.getSourceEntity() != null) {
                if (persistenceUnit.containsEntity(relationDescriptor.getSourceEntity())) {
                    sourceEntity = persistenceUnit.getEntity(relationDescriptor.getSourceEntity());
                }
            }
        }
        if (sourceEntity == null) {
            if (relationDescriptor.getSourceEntityType() != null) {
                if (persistenceUnit.containsEntity(relationDescriptor.getSourceEntityType())) {
                    sourceEntity = persistenceUnit.getEntity(relationDescriptor.getSourceEntityType());
                }
            }
        }
        if (targetEntity == null) {
            if (relationDescriptor.getTargetEntity() != null) {
                if (persistenceUnit.containsEntity(relationDescriptor.getTargetEntity())) {
                    targetEntity = persistenceUnit.getEntity(relationDescriptor.getTargetEntity());
                }
            }
        }
        if (targetEntity == null) {
            if (relationDescriptor.getTargetEntityType() != null) {
                if (persistenceUnit.containsEntity(relationDescriptor.getTargetEntityType())) {
                    targetEntity = persistenceUnit.getEntity(relationDescriptor.getTargetEntityType());
                }
            }
        }
        if (sourceEntity == null) {
            if (throwErrors) {
                throw new UPAException("InvalidRelationEntityNotFound", relationDescriptor.getSourceEntityType());
            } else {
                return false;
            }
        }
        if (targetEntity == null) {
            if (throwErrors) {
                throw new UPAException("InvalidRelationEntityNotFound", relationDescriptor.getTargetEntityType());
            } else {
                return false;
            }
        }
        sourceUpdateType = RelationshipUpdateType.FLAT;
        sourceFieldNames = new ArrayList<String>();
        if (relationDescriptor.getBaseField() == null) {
            sourceFieldNames.addAll(Arrays.asList(relationDescriptor.getSourceFields()));
            if (relationDescriptor.getMappedTo() != null && relationDescriptor.getMappedTo().length > 0) {
                if (relationDescriptor.getMappedTo().length > 1) {
                    throw new IllegalUPAArgumentException("mappedTo cannot only apply to single Entity Field");
                }
                manyToOneField = sourceEntity.getField(relationDescriptor.getMappedTo()[0]);
            }
        } else {
            Field baseField = sourceEntity.getField(relationDescriptor.getBaseField());
            DataType baseFieldType = baseField.getDataType();
            if (baseFieldType instanceof ManyToOneType || baseFieldType instanceof OneToOneType) {
                if (baseFieldType instanceof ManyToOneType) {
                    ManyToOneType met = (ManyToOneType) baseFieldType;
                    if (met.getTargetEntityName() == null || met.getTargetEntityName().isEmpty()) {
                        met.setTargetEntityName(targetEntity.getName());
                    }
                } else if (baseFieldType instanceof OneToOneType) {
                    OneToOneType met = (OneToOneType) baseFieldType;
                    if (met.getTargetEntityName() == null || met.getTargetEntityName().isEmpty()) {
                        met.setTargetEntityName(targetEntity.getName());
                    }
                }
                sourceUpdateType = RelationshipUpdateType.COMPOSED;
                List<Field> masterPK = targetEntity.getIdFields();
                if (relationDescriptor.getMappedTo() == null || relationDescriptor.getMappedTo().length == 0) {
                    if (masterPK.isEmpty()) {
                        if (throwErrors) {
                            throw new UPAException("PrimaryFieldsNotFoundException", targetEntity.getName());
                        } else {
                            return false;
                        }
                    } else {
                        for (Field masterField : masterPK) {
                            List<Field> mfields = null;
                            try {
                                mfields = resolveBaseFields(masterField);
                            } catch (RuntimeException e) {
                                if (throwErrors) {
                                    throw e;
                                }
                                return false;
                            }
                            if (mfields.size() == 1 && mfields.get(0).equals(masterField)) {
                                String f = masterField.getName();
                                if (f.length() == 1) {
                                    f = f.toUpperCase();
                                } else if (f.length() > 1) {
                                    f = f.substring(0, 1).toUpperCase() + f.substring(1);
                                }
                                String extraName = baseField.getName() + f;
                                sourceFieldNames.add(extraName);
                            } else {
                                for (Field mfield : mfields) {
                                    String f = mfield.getName();
                                    if (f.length() == 1) {
                                        f = f.toUpperCase();
                                    } else if (f.length() > 1) {
                                        f = f.substring(0, 1).toUpperCase() + f.substring(1);
                                    }
                                    String extraName = baseField.getName() + f;
                                    sourceFieldNames.add(extraName);
                                }
                            }
                        }
                    }
                } else {
                    sourceFieldNames.addAll(Arrays.asList(relationDescriptor.getMappedTo()));
                }
                if (sourceFieldNames.size() != masterPK.size()) {
                    if (throwErrors) {
                        throw new IllegalUPAArgumentException("Incorrect parameters");
                    } else {
                        return false;
                    }
                }
                if (sourceFieldNames.isEmpty()) {
                    if (throwErrors) {
                        throw new IllegalUPAArgumentException("Incorrect parameters");
                    } else {
                        return false;
                    }
                }
                for (int i = 0; i < sourceFieldNames.size(); i++) {
                    String extraName = sourceFieldNames.get(i);
                    Field idField = sourceEntity.findField(extraName);
                    if (idField == null) {
                        Field field = masterPK.get(i);
                        List<Field> referencedFields2 = null;
                        try {
                            referencedFields2 = resolveBaseFields(field);
                        } catch (RuntimeException rt) {
                            if (throwErrors) {
                                throw rt;
                            }
                            return false;
                        }
                        int ii = 0;
                        for (Field field1 : referencedFields2) {
                            DataType dt = (DataType) field1.getDataType().copy();
                            boolean nullable = baseFieldType.isNullable();
                            dt.setNullable(nullable);
                            sourceEntity.addField(
                                    new DefaultFieldBuilder().setName(extraName + (ii == 0 ? "" : (ii + 1))).setPath("system").addModifier(UserFieldModifier.SYSTEM)
                                            .addExcludeModifier(UserFieldModifier.UPDATE)
                                            .setDataType(dt).setProtectionLevel(ProtectionLevel.PRIVATE)
                            );
                            ii++;
                        }
                    } else {
                        idField.setUserExcludeModifiers(idField.getUserExcludeModifiers().add(UserFieldModifier.UPDATE));
                    }
                }
                manyToOneField = baseField;
            } else {
                sourceFieldNames.add(baseField.getName());
                if (relationDescriptor.getMappedTo() != null && relationDescriptor.getMappedTo().length > 0) {
                    if (relationDescriptor.getMappedTo().length > 1) {
                        throw new IllegalUPAArgumentException("mappedTo cannot only apply to single Entity Field");
                    }
                    manyToOneField = sourceEntity.getField(relationDescriptor.getMappedTo()[0]);
                }
            }
        }
        nullable = true;//TODO FIX ME
        for (int i = 0; i < sourceFieldNames.size(); i++) {
            Field slaveField = sourceEntity.getField(sourceFieldNames.get(i));
            DataType dataType = slaveField.getDataType();
            if (dataType == null) {
                //inherit master DataType
                if (targetEntity.getIdFields().size() > i) {
                    DataType d = targetEntity.getIdFields().get(i).getDataType();
                    d = (DataType) d.copy();
                    d.setNullable(nullable);
                    slaveField.setDataType(d);
                    //reset transform!
                    slaveField.setTypeTransform(null);
                } else {
                    throw new IllegalUPAArgumentException("Invalid Relation");
                }
            }
        }
        filter = relationDescriptor.getFilter();
//        if (baseFieldType instanceof ManyToOneType) {
//            manyToOneField = baseField;
//        } else if (sourceFieldNames.size() == 1) {
//            DataType slaveType = slaveField.getDataType();
//            if (slaveType instanceof ManyToOneType) {
//                manyToOneField = slaveField;
//            }
//        }
        return true;
    }

    private List<Field> resolveBaseFields(Field f) {
        List<Field> all = new ArrayList<>();
        if (f.getDataType() instanceof SerializableOrManyToOneType) {
            throw new IllegalUPAArgumentException("Unable to resolve type");
        } else if (f.isManyToOne()) {
            Relationship manyToOneRelationship = f.getManyToOneRelationship();
            for (Field field : manyToOneRelationship.getTargetEntity().getIdFields()) {
                all.addAll(resolveBaseFields(field));
            }
        } else {
            all.add(f);
        }
        return all;
    }

    public boolean processImmediate() {
        return processRelation(false);
    }

    private boolean processRelation(boolean throwErrors) {
        if (!build(throwErrors)) {
            return false;
        }
        PersistenceUnit pu = sourceEntity.getPersistenceUnit();
        if (relation == null) {
            DefaultRelationshipDescriptor rd = new DefaultRelationshipDescriptor();
            rd.setName(relationDescriptor.getName());
            rd.setBaseField(relationDescriptor.getBaseField());
            rd.setRelationshipType(relationDescriptor.getRelationshipType());
            rd.setSourceEntity(sourceEntity.getName());
            rd.setTargetEntity(targetEntity.getName());
            rd.setSourceFields(sourceFieldNames.toArray(new String[sourceFieldNames.size()]));
            rd.setFilter(relationDescriptor.getFilter());
            rd.setHierarchy(relationDescriptor.isHierarchy());
            rd.setHierarchyPathField(relationDescriptor.getHierarchyPathField());
            rd.setHierarchyPathSeparator(relationDescriptor.getHierarchyPathSeparator());
            rd.setNullable(relationDescriptor.isNullable());

            relation = ((PersistenceUnitExt) pu).addRelationshipImmediate(rd);
//                    relationDescriptor.getName(),
//                    relationDescriptor.getRelationType(),
//                    sourceEntity.getName(),
//                    targetEntity.getName(),
//                    manyToOneField == null ? null : manyToOneField.getName(),
//                    null,
//                    sourceUpdateType,
//                    null,
//                    sourceFieldNames.toArray(new String[sourceFieldNames.size()]),
//                    nullable,
//                    filter);
//            if(relationDescriptor.hierarchy()){
//                sourceEntity.addExtensionDefinition(
//                        TreeEntityExtensionDefinition.class, 
//                        new DefaultTreeEntityExtensionDefinition(
//                        manyToOneField!=null?manyToOneField.getName():sourceFieldNames.get(0),
//                        relation.getName(),
//                        relationDescriptor.getHierarchyPathField(),
//                        relationDescriptor.getHierarchyPathSeparator()
//                ));
//            }
        } else {
            if (!StringUtils.isNullOrEmpty(relationDescriptor.getName())) {
                relation.setName(relationDescriptor.getName());
            }
            relation.setRelationshipType(relationDescriptor.getRelationshipType() == null ? RelationshipType.DEFAULT : relationDescriptor.getRelationshipType());
            relation.getSourceRole().setEntityField(manyToOneField);
            relation.getSourceRole().setRelationshipUpdateType(sourceUpdateType);
            List<Field> slaveFields = new ArrayList<Field>();
            for (String n : sourceFieldNames) {
                Field f = sourceEntity.getField(n);
                slaveFields.add(f);
            }
            relation.getSourceRole().setFields(slaveFields.toArray(new Field[slaveFields.size()]));

            relation.getTargetRole().setEntityField(null);
            relation.getTargetRole().setRelationshipUpdateType(PlatformUtils.getUndefinedValue(RelationshipUpdateType.class));
            relation.setNullable(nullable);
            if (relation instanceof ManyToOneRelationship) {
                ((ManyToOneRelationship) relation).setFilter(filter);
            }
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
    public void onPrepareEntity(EntityEvent event) {

    }

    @Override
    public void onPrePrepareEntity(EntityEvent event) {

    }

    public PersistenceUnit getPersistenceUnit() {
        return persistenceUnit;
    }

    public RelationshipDescriptor getRelationDescriptor() {
        return relationDescriptor;
    }

    public Entity getSourceEntity() {
        return sourceEntity;
    }

    public Entity getTargetEntity() {
        return targetEntity;
    }

    public Relationship getRelation() {
        return relation;
    }

    public Field getManyToOneField() {
        return manyToOneField;
    }

    public RelationshipUpdateType getSourceUpdateType() {
        return sourceUpdateType;
    }

    public List<String> getSourceFieldNames() {
        return sourceFieldNames;
    }

    public boolean isNullable() {
        return nullable;
    }

    public Expression getFilter() {
        return filter;
    }
}
