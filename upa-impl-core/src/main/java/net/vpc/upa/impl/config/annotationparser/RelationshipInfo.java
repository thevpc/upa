package net.vpc.upa.impl.config.annotationparser;

import net.vpc.upa.RelationshipType;
import net.vpc.upa.config.ManyToOne;

import java.lang.reflect.Field;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.Collections;
import java.util.List;
import net.vpc.upa.RelationshipDescriptor;
import net.vpc.upa.config.Hierarchy;
import net.vpc.upa.config.OneToOne;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.expressions.UserExpression;
import net.vpc.upa.config.Decoration;
import net.vpc.upa.impl.config.decorations.DecorationRepository;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.UPAUtils;
import net.vpc.upa.types.ManyToOneType;
import net.vpc.upa.types.DataType;
import net.vpc.upa.types.OneToOneType;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/15/12 11:46 AM
 */
class RelationshipInfo implements RelationshipDescriptor {

    private DecorationFieldDescriptor baseFieldInfo;
    private String name;
    private String entityField;
    private String[] mappedTo = new String[0];
    private RelationshipType relationType;
    private String targetEntity;
    private String filter;
    private Class targetEntityType;
    private int manyToOneConfigOrder;
    private int hierarchyConfigOrder;
    private String hierarchyPathSeparator;
    private boolean hierarchy;
    private boolean oneToOne;
    private boolean manyToOne;
    private boolean nullable=true;//TODO FIX ME
    private String hierarchyPathField;
    private boolean specified = false;
    private boolean producesRelation = true;
    private List<Field> fieldsList;
    private DecorationRepository repo;
    private DataType preferredDataType;

    public RelationshipInfo(DecorationFieldDescriptor baseFieldInfo, DecorationRepository repo) {
        this.baseFieldInfo = baseFieldInfo;
        this.repo = repo;
    }

    public void parse(List<Field> fields, boolean nullable) {
        fieldsList = fields;
        List<Decoration> manyToOneDecorations = new ArrayList<Decoration>();
        List<Decoration> oneToOneDecorations = new ArrayList<Decoration>();
        List<Decoration> hierarchyDecorations = new ArrayList<Decoration>();
        for (Field javaField : fields) {
            Decoration gid = repo.getFieldDecoration(javaField, ManyToOne.class);
            Decoration gid2 = repo.getFieldDecoration(javaField, Hierarchy.class);
            Decoration gid3 = repo.getFieldDecoration(javaField, OneToOne.class);

            if (gid != null) {
//                ConfigInfo config = gid.getConfig();
                manyToOneDecorations.add(gid);
            }
            if (gid2 != null) {
//                ConfigInfo config = gid.getConfig();
                hierarchyDecorations.add(gid2);
            }
            if (gid3 != null) {
//                ConfigInfo config = gid.getConfig();
                oneToOneDecorations.add(gid3);
            }
        }
        if (manyToOneDecorations.size() > 1) {
            Collections.sort(manyToOneDecorations, DecorationComparator.INSTANCE);
        }
        if (hierarchyDecorations.size() > 1) {
            Collections.sort(hierarchyDecorations, DecorationComparator.INSTANCE);
        }
        for (Decoration gid : manyToOneDecorations) {
            mergeManyToOne(gid);
        }
        for (Decoration gid : oneToOneDecorations) {
            mergeOneToOne(gid);
        }
        for (Decoration gid : hierarchyDecorations) {
            mergeHierarchy(gid);
        }
        if (getTargetEntityType() == null || getTargetEntityType().equals(void.class)) {
            setTargetEntityType(getFieldType());
        }
        if (isManyToOne()) {
            Class<?> nativeClass = getFieldType();
            if (!UPAUtils.isSimpleFieldType(nativeClass)) {
                ManyToOneType pdt = new ManyToOneType(name, nativeClass, null, true, nullable);
                preferredDataType = (pdt);
            }
        }
        if (isOneToOne()) {
            Class<?> nativeClass = getFieldType();
            if (!UPAUtils.isSimpleFieldType(nativeClass)) {
                OneToOneType pdt = new OneToOneType(name, nativeClass, null, true, nullable);
                preferredDataType = (pdt);
            }
        }
    }

    public DataType getPreferredDataType() {
        return preferredDataType;
    }

    private Class getFieldType() {
        for (Field f : fieldsList) {
            return f.getType();
        }
        return null;
    }

    public void mergeHierarchy(Decoration gid) {
        if (gid.getConfig().getOrder() >= hierarchyConfigOrder) {
            specified = true;
            hierarchy = true;
            manyToOne = true;
            oneToOne = false;
            targetEntity = baseFieldInfo.getEntityInfo().getName();
            Class entityType = baseFieldInfo.getEntityInfo().getEntityType();
            targetEntityType = entityType;
            if(PlatformUtils.isUndefinedEnumValue(RelationshipType.class,relationType)) {
                relationType = RelationshipType.COMPOSITION;
            }
            Class<?> nativeClass = getFieldType();
            if (!nativeClass.equals(entityType)) {
                throw new UPAIllegalArgumentException("Hierarchy Relationship invalid as " + nativeClass + " <> " + entityType);
            }
            if (gid.getString("path").length() > 0) {
                hierarchyPathField = gid.getString("path");
            }
            if (gid.getString("separator").length() > 0) {
                hierarchyPathSeparator = gid.getString("separator");
            }
            if (gid.getConfig().getOrder() > hierarchyConfigOrder) {
                hierarchyConfigOrder = gid.getConfig().getOrder();
            }
        }
    }

    public void mergeManyToOne(Decoration gid) {
        mergeAnyToOne(gid,true);
    }

    public void mergeOneToOne(Decoration gid) {
        mergeAnyToOne(gid,false);
    }

    public void mergeAnyToOne(Decoration gid,boolean manyToOne) {
        if (gid.getConfig().getOrder() >= manyToOneConfigOrder) {
            specified = true;
            this.manyToOne = manyToOne?true:false;
            oneToOne = manyToOne?false:true;
            Class<?> nativeClass = getFieldType();
            if (nativeClass.isArray()) {
                throw new UPAIllegalArgumentException("Invalid Array type " + nativeClass + " for ManyToOne");
            }
            if (Collection.class.isAssignableFrom(nativeClass)) {
                throw new UPAIllegalArgumentException("Invalid Collection type " + nativeClass + " for ManyToOne");
            }
            if (nativeClass.isEnum()) {
                throw new UPAIllegalArgumentException("Enumerations are not supported in Relations");
            }

            if (gid.getString("name").length() > 0) {
                name = gid.getString("name");
            }
            String[] _mappedTo = gid.getPrimitiveArray("mappedTo", String.class);
            if (_mappedTo.length != 0) {
                mappedTo = _mappedTo;
            }
            if (gid.getEnum("relationType", RelationshipType.class) != RelationshipType.DEFAULT) {
                relationType = gid.getEnum("relationType", RelationshipType.class);
            }
            if (gid.getString("filter").length() > 0) {
                filter = gid.getString("filter");
            }
            entityField = fieldsList.get(0).getName();
            String _targetEntity = gid.getString("targetEntity");
            Class _targetEntityType = gid.getType("targetEntityType");
            if (_targetEntity.length() > 0 && !_targetEntityType.equals(void.class)) {
                //problem
                throw new UPAIllegalArgumentException("Could not support both targetEntity and targetEntityType");
            } else if (_targetEntity.length() > 0) {
                targetEntity = _targetEntity;
                targetEntityType = null;
            } else if (!_targetEntityType.equals(void.class)) {
                targetEntity = null;
                targetEntityType = _targetEntityType;
            }
            if (UPAUtils.isSimpleFieldType(nativeClass)) {
                if ((targetEntityType == null || targetEntityType.equals(void.class))
                        && targetEntity == null) {
                    throw new UPAIllegalArgumentException("Missing targetEntityType in field " + baseFieldInfo.getEntityInfo().getName() + "." + name);
                }
            }
            if (gid.getConfig().getOrder() > manyToOneConfigOrder) {
                manyToOneConfigOrder = gid.getConfig().getOrder();
            }
        }
    }

    public int getHierarchyConfigOrder() {
        return hierarchyConfigOrder;
    }

    public String getHierarchyPathSeparator() {
        return hierarchyPathSeparator;
    }

    public boolean isHierarchy() {
        return hierarchy;
    }

    public String getHierarchyPathField() {
        return hierarchyPathField;
    }

    public String getSourceEntity() {
        return baseFieldInfo.getEntityInfo().getName();
    }

    public Class getSourceEntityType() {
        return null;
    }

    public String getName() {
        return name;
    }

    public String getEntityField() {
        return entityField;
    }

    public String[] getMappedTo() {
        return mappedTo;
    }

    public RelationshipType getRelationshipType() {
        return relationType;
    }

    public String getTargetEntity() {
        return targetEntity;
    }

    public Expression getFilter() {
        return filter == null ? null : new UserExpression(filter);
    }

    public Class getTargetEntityType() {
        return targetEntityType;
    }

    public int getConfigOrder() {
        return manyToOneConfigOrder;
    }

    public boolean isSpecified() {
        return specified;
    }

    public boolean isProducesRelation() {
        return producesRelation;
    }

    public String getBaseField() {
        return baseFieldInfo.name;
    }

    public void setBaseFieldInfo(DecorationFieldDescriptor baseFieldInfo) {
        this.baseFieldInfo = baseFieldInfo;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setEntityField(String entityField) {
        this.entityField = entityField;
    }

    public void setMappedTo(String[] mappedTo) {
        this.mappedTo = mappedTo;
    }

    public void setRelationshipType(RelationshipType relationType) {
        this.relationType = relationType;
    }

    public void setTargetEntity(String targetEntity) {
        this.targetEntity = targetEntity;
    }

    public void setFilter(String filter) {
        this.filter = filter;
    }

    public void setTargetEntityType(Class targetEntityType) {
        this.targetEntityType = targetEntityType;
    }

    public void setConfigOrder(int configOrder) {
        this.manyToOneConfigOrder = configOrder;
    }

    public void setSpecified(boolean specified) {
        this.specified = specified;
    }

    public void setProducesRelation(boolean producesRelation) {
        this.producesRelation = producesRelation;
    }

    public void setFieldsList(List<Field> fieldsList) {
        this.fieldsList = fieldsList;
    }

    public boolean isManyToOne() {
        return manyToOne;
    }

    public boolean isOneToOne() {
        return oneToOne;
    }

    @Override
    public boolean isNullable() {
        return nullable;
    }

    public RelationshipInfo setNullable(boolean nullable) {
        this.nullable = nullable;
        return this;
    }

    /**
     * not used!
     * @return 
     */
    public String[] getSourceFields() {
        return null;
    }
    

    @Override
    public String toString() {
        return "RelationInfo{" + "baseFieldInfo=" + baseFieldInfo + ", name=" + name + ", entityField=" + entityField + ", mappedTo=" + (mappedTo == null ? "" : Arrays.toString(mappedTo)) + ", relationType=" + relationType + ", targetEntity=" + targetEntity + ", filter=" + filter + ", targetEntityType=" + targetEntityType + ", configOrder=" + manyToOneConfigOrder + ", specified=" + specified + ", producesRelation=" + producesRelation + ", fieldsList=" + fieldsList + '}';
    }
}
