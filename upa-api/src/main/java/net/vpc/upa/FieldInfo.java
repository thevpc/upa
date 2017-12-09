package net.vpc.upa;


public abstract class FieldInfo extends EntityPartInfo {
    private DataTypeInfo dataType;
    private String kind;
    private PropertyAccessType propertyAccessType;
    private AccessLevel persistAccessLevel;
    private AccessLevel updateAccessLevel;
    private AccessLevel readAccessLevel;
    private ProtectionLevel persistProtectionLevel;
    private ProtectionLevel updateProtectionLevel;
    private ProtectionLevel readProtectionLevel;
    private AccessLevel effectivePersistAccessLevel;
    private AccessLevel effectiveUpdateAccessLevel;
    private AccessLevel effectiveReadAccessLevel;
    private FieldModifier[] modifiers;
    private boolean id;
    private boolean main;
    private boolean system;
    private boolean summary;
    private boolean manyToOne;
    private boolean generatedId;
    private String manyToOneRelationship;

    public FieldInfo(String kind) {
        super("field");
        this.kind=kind;
    }

    public String getKind() {
        return kind;
    }

    public void setKind(String kind) {
    }

    public DataTypeInfo getDataType() {
        return dataType;
    }

    public void setDataType(DataTypeInfo dataType) {
        this.dataType = dataType;
    }

    public PropertyAccessType getPropertyAccessType() {
        return propertyAccessType;
    }

    public void setPropertyAccessType(PropertyAccessType propertyAccessType) {
        this.propertyAccessType = propertyAccessType;
    }

    public AccessLevel getPersistAccessLevel() {
        return persistAccessLevel;
    }

    public void setPersistAccessLevel(AccessLevel persistAccessLevel) {
        this.persistAccessLevel = persistAccessLevel;
    }

    public AccessLevel getUpdateAccessLevel() {
        return updateAccessLevel;
    }

    public void setUpdateAccessLevel(AccessLevel updateAccessLevel) {
        this.updateAccessLevel = updateAccessLevel;
    }

    public AccessLevel getReadAccessLevel() {
        return readAccessLevel;
    }

    public void setReadAccessLevel(AccessLevel readAccessLevel) {
        this.readAccessLevel = readAccessLevel;
    }

    public FieldModifier[] getModifiers() {
        return modifiers;
    }

    public void setModifiers(FieldModifier[] modifiers) {
        this.modifiers = modifiers;
    }

    public boolean isId() {
        return id;
    }

    public void setId(boolean id) {
        this.id = id;
    }

    public boolean isMain() {
        return main;
    }

    public void setMain(boolean main) {
        this.main = main;
    }

    public boolean isSummary() {
        return summary;
    }

    public void setSummary(boolean summary) {
        this.summary = summary;
    }

    public boolean isManyToOne() {
        return manyToOne;
    }

    public void setManyToOne(boolean manyToOne) {
        this.manyToOne = manyToOne;
    }

    public boolean isGeneratedId() {
        return generatedId;
    }

    public void setGeneratedId(boolean generatedId) {
        this.generatedId = generatedId;
    }

    public String getManyToOneRelationship() {
        return manyToOneRelationship;
    }

    public void setManyToOneRelationship(String manyToOneRelationship) {
        this.manyToOneRelationship = manyToOneRelationship;
    }

    public ProtectionLevel getPersistProtectionLevel() {
        return persistProtectionLevel;
    }

    public void setPersistProtectionLevel(ProtectionLevel persistProtectionLevel) {
        this.persistProtectionLevel = persistProtectionLevel;
    }

    public ProtectionLevel getUpdateProtectionLevel() {
        return updateProtectionLevel;
    }

    public void setUpdateProtectionLevel(ProtectionLevel updateProtectionLevel) {
        this.updateProtectionLevel = updateProtectionLevel;
    }

    public ProtectionLevel getReadProtectionLevel() {
        return readProtectionLevel;
    }

    public void setReadProtectionLevel(ProtectionLevel readProtectionLevel) {
        this.readProtectionLevel = readProtectionLevel;
    }

    public AccessLevel getEffectivePersistAccessLevel() {
        return effectivePersistAccessLevel;
    }

    public void setEffectivePersistAccessLevel(AccessLevel effectivePersistAccessLevel) {
        this.effectivePersistAccessLevel = effectivePersistAccessLevel;
    }

    public AccessLevel getEffectiveUpdateAccessLevel() {
        return effectiveUpdateAccessLevel;
    }

    public void setEffectiveUpdateAccessLevel(AccessLevel effectiveUpdateAccessLevel) {
        this.effectiveUpdateAccessLevel = effectiveUpdateAccessLevel;
    }

    public AccessLevel getEffectiveReadAccessLevel() {
        return effectiveReadAccessLevel;
    }

    public void setEffectiveReadAccessLevel(AccessLevel effectiveReadAccessLevel) {
        this.effectiveReadAccessLevel = effectiveReadAccessLevel;
    }

    public boolean isSystem() {
        return system;
    }

    public void setSystem(boolean system) {
        this.system = system;
    }
}
