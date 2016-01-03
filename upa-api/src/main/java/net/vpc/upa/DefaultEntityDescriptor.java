package net.vpc.upa;

import net.vpc.upa.extensions.EntityExtensionDefinition;

import java.util.List;
import java.util.Map;

/**
 * Created by vpc on 7/20/15.
 */
public class DefaultEntityDescriptor implements EntityDescriptor {

    private String name;

    private String shortName;

    private Class idType;

    private Class entityType;

    private FlagSet<EntityModifier> modifiers;

    private FlagSet<EntityModifier> excludeModifiers;

    private String packagePath;

    private String listOrder;

    private String archivingOrder;

    private int position;

    private List<EntityExtensionDefinition> entityExtensions;

    private Object source;

    public List<FieldDescriptor> fieldDescriptors;

    public List<IndexDescriptor> indexDescriptors;

    public List<RelationshipDescriptor> relationshipDescriptors;

    public Map<String, Object> properties;

    public String getName() {
        return name;
    }

    public DefaultEntityDescriptor setName(String name) {
        this.name = name;
        return this;
    }

    public String getShortName() {
        return shortName;
    }

    public DefaultEntityDescriptor setShortName(String shortName) {
        this.shortName = shortName;
        return this;
    }

    public Class getIdType() {
        return idType;
    }

    public DefaultEntityDescriptor setIdType(Class idType) {
        this.idType = idType;
        return this;
    }

    public Class getEntityType() {
        return entityType;
    }

    public DefaultEntityDescriptor setEntityType(Class entityType) {
        this.entityType = entityType;
        return this;
    }

    public FlagSet<EntityModifier> getModifiers() {
        return modifiers;
    }

    public DefaultEntityDescriptor setModifiers(FlagSet<EntityModifier> modifiers) {
        this.modifiers = modifiers;
        return this;
    }

    public FlagSet<EntityModifier> getExcludeModifiers() {
        return excludeModifiers;
    }

    public DefaultEntityDescriptor setExcludeModifiers(FlagSet<EntityModifier> excludeModifiers) {
        this.excludeModifiers = excludeModifiers;
        return this;
    }

    public String getPackagePath() {
        return packagePath;
    }

    public DefaultEntityDescriptor setPackagePath(String packagePath) {
        this.packagePath = packagePath;
        return this;
    }

    public int getPosition() {
        return position;
    }

    public DefaultEntityDescriptor setPosition(int position) {
        this.position = position;
        return this;
    }

    public List<EntityExtensionDefinition> getEntityExtensions() {
        return entityExtensions;
    }

    public DefaultEntityDescriptor setEntityExtensions(List<EntityExtensionDefinition> entityExtensions) {
        this.entityExtensions = entityExtensions;
        return this;
    }

    public Object getSource() {
        return source;
    }

    public DefaultEntityDescriptor setSource(Object source) {
        this.source = source;
        return this;
    }

    public List<FieldDescriptor> getFieldDescriptors() {
        return fieldDescriptors;
    }

    public DefaultEntityDescriptor setFieldDescriptors(List<FieldDescriptor> fieldDescriptors) {
        this.fieldDescriptors = fieldDescriptors;
        return this;
    }

    public List<IndexDescriptor> getIndexDescriptors() {
        return indexDescriptors;
    }

    public DefaultEntityDescriptor setIndexDescriptors(List<IndexDescriptor> indexDescriptors) {
        this.indexDescriptors = indexDescriptors;
        return this;
    }

    public List<RelationshipDescriptor> getRelationshipDescriptors() {
        return relationshipDescriptors;
    }

    public DefaultEntityDescriptor setRelationshipDescriptors(List<RelationshipDescriptor> relationshipDescriptors) {
        this.relationshipDescriptors = relationshipDescriptors;
        return this;
    }

    @Override
    public String getListOrder() {
        return listOrder;
    }

    public DefaultEntityDescriptor setListOrder(String listOrder) {
        this.listOrder = listOrder;
        return this;
    }

    public String getArchivingOrder() {
        return archivingOrder;
    }

    public DefaultEntityDescriptor setArchivingOrder(String archivingOrder) {
        this.archivingOrder = archivingOrder;
        return this;
    }

    public Map<String, Object> getProperties() {
        return properties;
    }

    public DefaultEntityDescriptor setProperties(Map<String, Object> properties) {
        this.properties = properties;
        return this;
    }

    @Override
    public String toString() {
        return "DefaultEntityDescriptor{"
                + "name='" + name + '\''
                + ", idType=" + idType
                + ", entityType=" + entityType
                + ", source=" + source
                + ", packagePath='" + packagePath + '\''
                + ", modifiers=" + modifiers
                + '}';
    }
}
