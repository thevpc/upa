package net.vpc.upa;

import java.util.List;

public class EntityInfo extends PersistenceUnitPartInfo{
    private List<EntityPartInfo> children;
    private EntityModifier[] modifiers;
    private boolean hierarchical;
    private boolean hasAssociatedView;
    private boolean system;
    private boolean singleton;
    private boolean union;
    private boolean view;
    private String[] manyToOneRelationships;
    private String[] oneToManyRelationships;
    private List<IndexInfo> indexes;
    private String compositionRelationship;
    private String parentEntity;

    public EntityInfo() {
        super("entity");
    }

    public boolean isSingleton() {
        return singleton;
    }

    public void setSingleton(boolean singleton) {
        this.singleton = singleton;
    }

    public boolean isUnion() {
        return union;
    }

    public void setUnion(boolean union) {
        this.union = union;
    }

    public boolean isView() {
        return view;
    }

    public void setView(boolean view) {
        this.view = view;
    }

    public EntityModifier[] getModifiers() {
        return modifiers;
    }

    public void setModifiers(EntityModifier[] modifiers) {
        this.modifiers = modifiers;
    }

    public boolean isHierarchical() {
        return hierarchical;
    }

    public void setHierarchical(boolean hierarchical) {
        this.hierarchical = hierarchical;
    }

    public boolean isHasAssociatedView() {
        return hasAssociatedView;
    }

    public void setHasAssociatedView(boolean hasAssociatedView) {
        this.hasAssociatedView = hasAssociatedView;
    }

    public boolean isSystem() {
        return system;
    }

    public void setSystem(boolean system) {
        this.system = system;
    }

    public String[] getManyToOneRelationships() {
        return manyToOneRelationships;
    }

    public void setManyToOneRelationships(String[] manyToOneRelationships) {
        this.manyToOneRelationships = manyToOneRelationships;
    }

    public String[] getOneToManyRelationships() {
        return oneToManyRelationships;
    }

    public void setOneToManyRelationships(String[] oneToManyRelationships) {
        this.oneToManyRelationships = oneToManyRelationships;
    }

    public List<IndexInfo> getIndexes() {
        return indexes;
    }

    public void setIndexes(List<IndexInfo> indexes) {
        this.indexes = indexes;
    }

    public String getCompositionRelationship() {
        return compositionRelationship;
    }

    public void setCompositionRelationship(String compositionRelationship) {
        this.compositionRelationship = compositionRelationship;
    }

    public String getParentEntity() {
        return parentEntity;
    }

    public void setParentEntity(String parentEntity) {
        this.parentEntity = parentEntity;
    }

    public List<EntityPartInfo> getChildren() {
        return children;
    }

    public void setChildren(List<EntityPartInfo> children) {
        this.children = children;
    }
}
