package net.vpc.upa;

import java.util.List;

public class PersistenceUnitInfo extends UPAObjectInfo {
    private PackageInfo root;
    private List<RelationshipInfo> relationships;

    public PersistenceUnitInfo() {
        super("persistenceUnit");
    }

    public PackageInfo getRoot() {
        return root;
    }

    public void setRoot(PackageInfo root) {
        this.root = root;
    }

    public List<RelationshipInfo> getRelationships() {
        return relationships;
    }

    public void setRelationships(List<RelationshipInfo> relationships) {
        this.relationships = relationships;
    }
}
