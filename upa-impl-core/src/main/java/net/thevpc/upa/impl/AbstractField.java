package net.thevpc.upa.impl;

import net.thevpc.upa.*;
import net.thevpc.upa.impl.transform.IdentityDataTypeTransform;
import net.thevpc.upa.impl.util.NamingStrategy;
import net.thevpc.upa.impl.util.NamingStrategyHelper;
import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.types.*;

import net.thevpc.upa.exceptions.UPAException;
import net.thevpc.upa.filters.FieldFilter;
import net.thevpc.upa.types.*;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public abstract class AbstractField extends AbstractUPAObject implements Field, Comparable<Object> {

    protected Entity entity;
    protected EntityItem parent;
    protected DataType dataType;
    protected Formula persistFormula;
    protected int persistFormulaOrder;
    protected Formula updateFormula;
    protected int updateFormulaOrder;
    protected Formula queryFormula;
    protected Object defaultObject;
    protected SearchOperator searchOperator = SearchOperator.DEFAULT;
    protected DataTypeTransform typeTransform;
    protected HashMap<String, Object> properties;
    protected FlagSet<UserFieldModifier> userModifiers = FlagSets.noneOf(UserFieldModifier.class);
    protected FlagSet<UserFieldModifier> userExcludeModifiers = FlagSets.noneOf(UserFieldModifier.class);
    protected FlagSet<FieldModifier> effectiveModifiers = FlagSets.noneOf(FieldModifier.class);
    protected boolean closed;
    protected Object unspecifiedValue = UnspecifiedValue.DEFAULT;
    private AccessLevel persistAccessLevel = AccessLevel.READ_WRITE;
    private AccessLevel updateAccessLevel = AccessLevel.READ_WRITE;
    private AccessLevel readAccessLevel = AccessLevel.READ_WRITE;
    private ProtectionLevel persistProtectionLevel = ProtectionLevel.PUBLIC;
    private ProtectionLevel updateProtectionLevel = ProtectionLevel.PUBLIC;
    private ProtectionLevel readProtectionLevel = ProtectionLevel.PUBLIC;
    private FieldPersister fieldPersister;
    private PropertyAccessType accessType;
    private List<Relationship> manyToOneRelationships;
    private List<Relationship> oneToOneRelationships;
    private boolean _customDefaultObject = false;
    private Object _typeDefaultObject = false;

    protected AbstractField() {
    }

    @Override
    public String getAbsoluteName() {
        return (getEntity() == null ? "?" : getEntity().getName()) + "." + getName();
    }

    public EntityItem getParent() {
        return parent;
    }

    public void setParent(EntityItem item) {
        EntityItem old = this.parent;
        EntityItem recent = item;
        beforePropertyChangeSupport.firePropertyChange("parent", old, recent);
        this.parent = item;
        afterPropertyChangeSupport.firePropertyChange("parent", old, recent);
    }

    @Override
    public void commitModelChanges() {
        manyToOneRelationships = getManyToOneRelationshipsImpl();
        oneToOneRelationships = getOneToOneRelationshipsImpl();
    }

    public boolean is(FieldFilter filter) throws UPAException {
        return filter.accept(this);
    }

    public boolean isId() throws UPAException {
        return getModifiers().contains(FieldModifier.ID);
    }

    @Override
    public boolean isGeneratedId() throws UPAException {
        if (!isId()) {
            return false;
        }
        Formula persistFormula = getPersistFormula();
        return (persistFormula != null);
    }

    public boolean isMain() throws UPAException {
        return getModifiers().contains(FieldModifier.MAIN);
    }

    @Override
    public boolean isSystem() {
        return getModifiers().contains(FieldModifier.SYSTEM);
    }

    public boolean isSummary() throws UPAException {
        return getModifiers().contains(FieldModifier.SUMMARY);
    }

    public List<Relationship> getManyToOneRelationships() {
        return manyToOneRelationships;
    }

    public List<Relationship> getOneToOneRelationships() {
        return oneToOneRelationships;
    }

    protected List<Relationship> getManyToOneRelationshipsImpl() {
        List<Relationship> relations = new ArrayList<Relationship>();
        for (Relationship r : getPersistenceUnit().getRelationshipsBySource(getEntity())) {
            Field entityField = r.getSourceRole().getEntityField();
            if (entityField != null && entityField.equals(this)) {
                relations.add(r);
            } else {
                List<Field> fields = r.getSourceRole().getFields();
                for (Field field : fields) {
                    if (field.equals(this)) {
                        relations.add(r);
                    }
                }
            }
        }
        return PlatformUtils.trimToSize(relations);
    }

    protected List<Relationship> getOneToOneRelationshipsImpl() {
        List<Relationship> relations = new ArrayList<Relationship>();
        for (Relationship r : getPersistenceUnit().getRelationshipsBySource(getEntity())) {
            Field entityField = r.getSourceRole().getEntityField();
            if (entityField != null && entityField.equals(this)) {
                relations.add(r);
            } else {
                List<Field> fields = r.getSourceRole().getFields();
                for (Field field : fields) {
                    if (field.equals(this)) {
                        relations.add(r);
                    }
                }
            }
        }
        return PlatformUtils.trimToSize(relations);
    }

    public void setFormula(Formula formula) {
        setPersistFormula(formula);
        setUpdateFormula(formula);
    }

    @Override
    public void setFormula(String formula) {
        setFormula(formula == null ? null : new ExpressionFormula(formula));
    }

    public void setPersistFormula(Formula formula) {
        this.persistFormula = formula;
    }

    public void setUpdateFormula(Formula formula) {
        this.updateFormula = formula;
    }

    @Override
    public void setFormulaOrder(int order) {
        setPersistFormulaOrder(order);
        setUpdateFormulaOrder(order);
    }

    public int getUpdateFormulaOrder() {
        return updateFormulaOrder;
    }

    @Override
    public void setUpdateFormulaOrder(int order) {
        this.updateFormulaOrder = order;
    }

    public int getPersistFormulaOrder() {
        return persistFormulaOrder;
    }

    @Override
    public void setPersistFormulaOrder(int order) {
        this.persistFormulaOrder = order;
    }

    public Formula getUpdateFormula() {
        return updateFormula;
    }

    @Override
    public void setUpdateFormula(String formula) {
        setUpdateFormula(formula == null ? null : new ExpressionFormula(formula));
    }

    public Formula getSelectFormula() {
        return queryFormula;
    }

    @Override
    public void setSelectFormula(String formula) {
        setSelectFormula(formula == null ? null : new ExpressionFormula(formula));
    }

    public void setSelectFormula(Formula queryFormula) {
        this.queryFormula = queryFormula;
    }

    //    public boolean isRequired() throws UPAException {
//        return (!isReadOnlyOnPersist() || !isReadOnlyOnUpdate()) && !getDataType().isNullable();
//    }
    public String getPath() {
        EntityItem parent = getParent();
        return parent == null ? ("/" + getName()) : (parent.getPath() + "/" + getName());
    }

    @Override
    public PersistenceUnit getPersistenceUnit() {
        return entity.getPersistenceUnit();
    }

    public Formula getPersistFormula() {
        return persistFormula;
    }

    @Override
    public void setPersistFormula(String formula) {
        setPersistFormula(formula == null ? null : new ExpressionFormula(formula));
    }

    public Entity getEntity() {
        return entity;
    }

    public void setEntity(Entity entity) {
        this.entity = entity;
    }

    public DataType getDataType() {
        return dataType;
    }

    /**
     * called by PersistenceUnitFilter / Table You should not use it
     *
     * @param datatype datatype
     */
    @Override
    public void setDataType(DataType datatype) {
        this.dataType = datatype;
        if (!getDataType().isNullable()) {
            _typeDefaultObject = getDataType().getDefaultValue();
        } else {
            _typeDefaultObject = null;
        }
    }

    public Object getDefaultValue() {
        if (_customDefaultObject) {
            Object o = ((CustomDefaultObject) defaultObject).getObject();
            if (o == null) {
                o = _typeDefaultObject;
            }
            return o;
        } else {
            Object o = defaultObject;
            if (o == null) {
                o = _typeDefaultObject;
            }
            return o;
        }
    }

    public Object getDefaultObject() {
        return defaultObject;
    }

    /**
     * called by PersistenceUnitFilter / Table You should not use it
     *
     * @param o default value witch may be san ObjectHandler
     */
    public void setDefaultObject(Object o) {
        defaultObject = o;
        if (o instanceof CustomDefaultObject) {
            _customDefaultObject = true;
        }
    }

    public FlagSet<FieldModifier> getModifiers() {
        return effectiveModifiers;
    }

    public void setEffectiveModifiers(FlagSet<FieldModifier> effectiveModifiers) {
        this.effectiveModifiers = effectiveModifiers;
    }

    //    public void addModifiers(long modifiers) {
//        setModifiers(getModifiers() | modifiers);
//    }
//
//    public void removeModifiers(long modifiers) {
//        setModifiers(getModifiers() & ~modifiers);
//    }
//    public Expression getExpression() {
//        return formula == null ? null : formula.getExpression();
//    }
    @Override
    public boolean equals(Object other) {
        return !(other == null || !(other instanceof Field)) && compareTo(other) == 0;
    }

    public int compareTo(Object other) {
        if (other == this) {
            return 0;
        }
        if (other == null) {
            return 1;
        }
        Field f = (Field) other;
        NamingStrategy comp = NamingStrategyHelper.getNamingStrategy(getEntity().getPersistenceUnit().isCaseSensitiveIdentifiers());

        String s1 = entity != null ? comp.getUniformValue(entity.getName()) : "";
        String s2 = f.getName() != null ? comp.getUniformValue(f.getEntity().getName()) : "";
        int i = s1.compareTo(s2);
        if (i != 0) {
            return i;
        } else {
            String s3 = getName() != null ? comp.getUniformValue(getName()) : "";
            String s4 = f.getName() != null ? comp.getUniformValue(f.getName()) : "";
            i = s3.compareTo(s4);
            return i;
        }
    }

    @Override
    public FlagSet<UserFieldModifier> getUserModifiers() {
        return userModifiers;
    }

    //    public void resetModifiers() {
//        modifiers = 0;
//    }
    public void setUserModifiers(FlagSet<UserFieldModifier> modifiers) {
        this.userModifiers = modifiers == null ? FlagSets.noneOf(UserFieldModifier.class) : modifiers;
    }

    @Override
    public FlagSet<UserFieldModifier> getUserExcludeModifiers() {
        return userExcludeModifiers;
    }

    public void setUserExcludeModifiers(FlagSet<UserFieldModifier> modifiers) {
        this.userExcludeModifiers = modifiers == null ? FlagSets.noneOf(UserFieldModifier.class) : modifiers;
    }

    @Override
    public String toString() {
        return getAbsoluteName();
    }

    @Override
    public void close() throws UPAException {
        this.closed = true;
    }

    public boolean isClosed() {
        return closed;
    }

    @Override
    public Object getUnspecifiedValue() {
        return unspecifiedValue;
    }

    @Override
    public void setUnspecifiedValue(Object o) {
        this.unspecifiedValue = o;
    }

    public Object getUnspecifiedValueDecoded() {
        final Object fuv = getUnspecifiedValue();
        if (UnspecifiedValue.DEFAULT.equals(fuv)) {
            return getDataType().getDefaultUnspecifiedValue();
        } else {
            return fuv;
        }
    }

    public boolean isUnspecifiedValue(Object value) {
        Object v = getUnspecifiedValueDecoded();
        return (v == value || (v != null && v.equals(value)));
    }

    public AccessLevel getPersistAccessLevel() {
        return persistAccessLevel;
    }

    public void setPersistAccessLevel(AccessLevel persistAccessLevel) {
        if (PlatformUtils.isUndefinedEnumValue(AccessLevel.class, persistAccessLevel)) {
            persistAccessLevel = AccessLevel.READ_WRITE;
        }
        this.persistAccessLevel = persistAccessLevel;
    }

    public AccessLevel getUpdateAccessLevel() {
        return updateAccessLevel;
    }

    public void setUpdateAccessLevel(AccessLevel updateAccessLevel) {
        if (PlatformUtils.isUndefinedEnumValue(AccessLevel.class, updateAccessLevel)) {
            updateAccessLevel = AccessLevel.READ_WRITE;
        }
        this.updateAccessLevel = updateAccessLevel;
    }

    public AccessLevel getReadAccessLevel() {
        return readAccessLevel;
    }

    public void setReadAccessLevel(AccessLevel readAccessLevel) {
        if (PlatformUtils.isUndefinedEnumValue(AccessLevel.class, readAccessLevel)) {
            readAccessLevel = AccessLevel.READ_ONLY;
        }
        if (readAccessLevel == AccessLevel.READ_WRITE) {
            readAccessLevel = AccessLevel.READ_ONLY;
        }
        this.readAccessLevel = readAccessLevel;
    }

    public void setAccessLevel(AccessLevel accessLevel) {
        setPersistAccessLevel(accessLevel);
        setUpdateAccessLevel(accessLevel);
        setReadAccessLevel(accessLevel);
    }

    public ProtectionLevel getPersistProtectionLevel() {
        return persistProtectionLevel;
    }

    public void setPersistProtectionLevel(ProtectionLevel persistProtectionLevel) {
        if (PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, persistProtectionLevel)) {
            persistProtectionLevel = ProtectionLevel.PUBLIC;
        }
        this.persistProtectionLevel = persistProtectionLevel;
    }

    public ProtectionLevel getUpdateProtectionLevel() {
        return updateProtectionLevel;
    }

    public void setUpdateProtectionLevel(ProtectionLevel updateProtectionLevel) {
        if (PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, updateProtectionLevel)) {
            updateProtectionLevel = ProtectionLevel.PUBLIC;
        }
        this.updateProtectionLevel = updateProtectionLevel;
    }

    public ProtectionLevel getReadProtectionLevel() {
        return readProtectionLevel;
    }

    public void setReadProtectionLevel(ProtectionLevel readProtectionLevel) {
        if (PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, readProtectionLevel)) {
            readProtectionLevel = ProtectionLevel.PUBLIC;
        }
        this.readProtectionLevel = readProtectionLevel;
    }

    public void setProtectionLevel(ProtectionLevel persistLevel) {
        setPersistProtectionLevel(persistLevel);
        setUpdateProtectionLevel(persistLevel);
        setReadProtectionLevel(persistLevel);
    }

    public SearchOperator getSearchOperator() {
        return searchOperator;
    }

    public void setSearchOperator(SearchOperator searchOperator) {
        this.searchOperator = searchOperator;
    }

    public FieldPersister getFieldPersister() {
        return fieldPersister;
    }

    public void setFieldPersister(FieldPersister fieldPersister) {
        this.fieldPersister = fieldPersister;
    }

    public DataTypeTransform getTypeTransform() {
        return typeTransform;
    }

    @Override
    public DataTypeTransform getEffectiveTypeTransform() {
        DataTypeTransform t = getTypeTransform();
        if (t == null) {
            DataType d = getDataType();
            if (d != null) {
                t = new IdentityDataTypeTransform(d);
            }
        }
        return t;
    }

    public void setTypeTransform(DataTypeTransform transform) {
        this.typeTransform = transform;
    }

    public PropertyAccessType getPropertyAccessType() {
        return accessType;
    }

    public void setPropertyAccessType(PropertyAccessType accessType) {
        this.accessType = accessType;
    }

    @Override
    public Object getMainValue(Object instance) {
        Object v = getValue(instance);
        if (v != null) {
            Relationship manyToOneRelationship = getManyToOneRelationship();
            if (manyToOneRelationship != null) {
                v = manyToOneRelationship.getTargetEntity().getBuilder().getMainValue(v);
            }
        }
        return v;
    }

    @Override
    public Object getValue(Object instance) {
        if (instance instanceof Document) {
            return ((Document) instance).getObject(getName());
        }
        return getEntity().getBuilder().getProperty(instance, getName());
    }

    @Override
    public void setValue(Object instance, Object value) {
        getEntity().getBuilder().setProperty(instance, getName(), value);
    }

    @Override
    public void check(Object value) {
        getDataType().check(value, getName(), null);
    }

    @Override
    public boolean isManyToOne() {
        return getDataType() instanceof ManyToOneType;
    }

    @Override
    public boolean isOneToOne() {
        return getDataType() instanceof OneToOneType;
    }

    @Override
    public ManyToOneRelationship getManyToOneRelationship() {
        DataType dataType = getDataType();
        if (dataType instanceof ManyToOneType) {
            return (ManyToOneRelationship) ((ManyToOneType) dataType).getRelationship();
        }
        return null;
    }

    @Override
    public OneToOneRelationship getOneToOneRelationship() {
        DataType dataType = getDataType();
        if (dataType instanceof OneToOneType) {
            return (OneToOneRelationship) ((OneToOneType) dataType).getRelationship();
        }
        return null;
    }

    protected void fillFieldInfo(FieldInfo i) {
        Field f = this;
        fillObjectInfo(i);
        DataTypeInfo dataType = f.getDataType() == null ? null : f.getDataType().getInfo();
        if (dataType != null) {
            UPAI18n d = getPersistenceGroup().getI18nOrDefault();
            if (f.getDataType() instanceof EnumType) {
                List<Object> values = ((EnumType) f.getDataType()).getValues();
                StringBuilder v = new StringBuilder();
                for (Object o : values) {
                    if (v.length() > 0) {
                        v.append(",");
                    }
                    v.append(d.getEnum(o));
                }
                dataType.getProperties().put("titles", String.valueOf(v));
            }
        }
        i.setDataType(dataType);
        i.setId(f.isId());
        i.setGeneratedId(f.isGeneratedId());
        i.setModifiers(f.getModifiers().toArray());
        i.setPersistAccessLevel(f.getPersistAccessLevel());
        i.setUpdateAccessLevel(f.getUpdateAccessLevel());
        i.setReadAccessLevel(f.getReadAccessLevel());
        i.setPersistProtectionLevel(f.getPersistProtectionLevel());
        i.setUpdateProtectionLevel(f.getUpdateProtectionLevel());
        i.setReadProtectionLevel(f.getReadProtectionLevel());
        i.setEffectivePersistAccessLevel(f.getEffectivePersistAccessLevel());
        i.setEffectiveUpdateAccessLevel(f.getEffectiveUpdateAccessLevel());
        i.setEffectiveReadAccessLevel(f.getEffectiveReadAccessLevel());
        i.setMain(f.isMain());
        i.setSystem(f.getModifiers().contains(FieldModifier.SYSTEM));
        i.setSummary(f.isSummary());
        i.setManyToOne(f.isManyToOne());
        i.setPropertyAccessType(f.getPropertyAccessType());
        Relationship r = f.getManyToOneRelationship();
        i.setManyToOneRelationship(r == null ? null : r.getName());
    }

    @Override
    public AccessLevel getEffectiveAccessLevel(AccessMode mode) {
        if (!PlatformUtils.isUndefinedEnumValue(AccessMode.class, mode)) {
            switch (mode) {
                case READ:
                    return getEffectiveReadAccessLevel();
                case PERSIST:
                    return getEffectivePersistAccessLevel();
                case UPDATE:
                    return getEffectiveUpdateAccessLevel();
            }
        }
        return AccessLevel.INACCESSIBLE;
    }

    @Override
    public AccessLevel getAccessLevel(AccessMode mode) {
        if (!PlatformUtils.isUndefinedEnumValue(AccessMode.class, mode)) {
            switch (mode) {
                case READ:
                    return getReadAccessLevel();
                case PERSIST:
                    return getPersistAccessLevel();
                case UPDATE:
                    return getUpdateAccessLevel();
            }
        }
        return AccessLevel.INACCESSIBLE;
    }

    @Override
    public ProtectionLevel getProtectionLevel(AccessMode mode) {
        if (!PlatformUtils.isUndefinedEnumValue(AccessMode.class, mode)) {
            switch (mode) {
                case READ:
                    return getReadProtectionLevel();
                case PERSIST:
                    return getPersistProtectionLevel();
                case UPDATE:
                    return getUpdateProtectionLevel();
            }
        }
        return ProtectionLevel.PRIVATE;
    }

    public AccessLevel getEffectivePersistAccessLevel() {
        if (isSystem()) {
            return AccessLevel.INACCESSIBLE;
        }
        AccessLevel al = getPersistAccessLevel();
        ProtectionLevel pl = getPersistProtectionLevel();
        if (PlatformUtils.isUndefinedEnumValue(AccessLevel.class, al)) {
            al = AccessLevel.READ_WRITE;
        }
        if (PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, pl)) {
            pl = ProtectionLevel.PUBLIC;
        }
        boolean hasFormula = getPersistFormula() != null;
        if (al == AccessLevel.READ_WRITE && hasFormula) {
            al = AccessLevel.READ_ONLY;
        }
        switch (al) {
            case INACCESSIBLE: {
                break;
            }
            case READ_ONLY: {
                switch (pl) {
                    case PRIVATE: {
                        al = AccessLevel.INACCESSIBLE;
                        break;
                    }
                    case PROTECTED: {
                        break;
                    }
                    case PUBLIC: {
                        break;
                    }
                }
                break;
            }
            case READ_WRITE: {
                switch (pl) {
                    case PRIVATE: {
                        al = AccessLevel.READ_ONLY;
                        break;
                    }
                    case PROTECTED: {
                        if (!getPersistenceUnit().getSecurityManager().isAllowedWrite(this)) {
                            al = AccessLevel.READ_ONLY;
                        }
                        break;
                    }
                    case PUBLIC: {
                        break;
                    }
                }
                break;
            }
        }
        if (al != AccessLevel.INACCESSIBLE) {
            if (isGeneratedId()) {
                al = AccessLevel.INACCESSIBLE;
            }
            if (!getModifiers().contains(FieldModifier.PERSIST_DEFAULT)) {
                al = AccessLevel.INACCESSIBLE;
            }
        }
        return al;
    }

    public AccessLevel getEffectiveUpdateAccessLevel() {
        if (isSystem()) {
            return AccessLevel.INACCESSIBLE;
        }
        AccessLevel al = getUpdateAccessLevel();
        ProtectionLevel pl = getUpdateProtectionLevel();

        if (PlatformUtils.isUndefinedEnumValue(AccessLevel.class, al)) {
            al = AccessLevel.READ_WRITE;
        }
        if (PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, pl)) {
            pl = ProtectionLevel.PUBLIC;
        }
        boolean hasFormula = getUpdateFormula() != null;
        if (al == AccessLevel.READ_WRITE && hasFormula) {
            al = AccessLevel.READ_ONLY;
        }
        switch (al) {
            case INACCESSIBLE: {
                break;
            }
            case READ_ONLY: {
                switch (pl) {
                    case PRIVATE: {
                        al = AccessLevel.INACCESSIBLE;
                        break;
                    }
                    case PROTECTED: {
                        if (!getPersistenceUnit().getSecurityManager().isAllowedRead(this)) {
                            al = AccessLevel.INACCESSIBLE;
                        }
                        break;
                    }
                    case PUBLIC: {
                        break;
                    }
                }
                break;
            }
            case READ_WRITE: {
                switch (pl) {
                    case PRIVATE: {
                        al = AccessLevel.READ_ONLY;
                        break;
                    }
                    case PROTECTED: {
                        if (!getPersistenceUnit().getSecurityManager().isAllowedWrite(this)) {
                            al = AccessLevel.READ_ONLY;
                        }
                        if (!getPersistenceUnit().getSecurityManager().isAllowedRead(this)) {
                            al = AccessLevel.INACCESSIBLE;
                        }
                        break;
                    }
                    case PUBLIC: {
                        break;
                    }
                }
                break;
            }
        }

        if (isId() && al == AccessLevel.READ_WRITE) {
            al = AccessLevel.READ_ONLY;
        }
        if (getModifiers().contains(FieldModifier.UPDATE_DEFAULT)) {
            //
        } else if (getModifiers().contains(FieldModifier.PERSIST_FORMULA) || getModifiers().contains(FieldModifier.PERSIST_SEQUENCE)) {
            if (al == AccessLevel.READ_WRITE) {
                al = AccessLevel.READ_ONLY;
            }
        } else if (getModifiers().contains(FieldModifier.PERSIST_FORMULA) || getModifiers().contains(FieldModifier.PERSIST_SEQUENCE)) {
            if (al == AccessLevel.READ_WRITE) {
                al = AccessLevel.READ_ONLY;
            }
        }
        return al;
    }

    public AccessLevel getEffectiveReadAccessLevel() {
        if (isSystem()) {
            return AccessLevel.INACCESSIBLE;
        }
        AccessLevel al = getReadAccessLevel();
        ProtectionLevel pl = getReadProtectionLevel();
        if (PlatformUtils.isUndefinedEnumValue(AccessLevel.class, al)) {
            al = AccessLevel.READ_WRITE;
        }
        if (PlatformUtils.isUndefinedEnumValue(ProtectionLevel.class, pl)) {
            pl = ProtectionLevel.PUBLIC;
        }
        if (al == AccessLevel.READ_WRITE) {
            al = AccessLevel.READ_ONLY;
        }
        if (al == AccessLevel.READ_ONLY) {
            if (!getModifiers().contains(FieldModifier.SELECT)) {
                al = AccessLevel.INACCESSIBLE;
            }
        }

        switch (al) {
            case INACCESSIBLE: {
                break;
            }
            case READ_ONLY: {
                switch (pl) {
                    case PRIVATE: {
                        al = AccessLevel.INACCESSIBLE;
                        break;
                    }
                    case PROTECTED: {
                        if (!getPersistenceUnit().getSecurityManager().isAllowedRead(this)) {
                            al = AccessLevel.INACCESSIBLE;
                        }
                        break;
                    }
                    case PUBLIC: {
                        break;
                    }
                }
                break;
            }
        }
        return al;
    }
}
