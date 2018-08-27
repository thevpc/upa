package net.vpc.upa.impl;

import net.vpc.upa.ManyToOneRelationship;
import net.vpc.upa.HierarchyExtension;

public class DefaultManyToOneRelationship extends DefaultRelationship implements ManyToOneRelationship{
    private HierarchyExtension hierarchyExtension;
    public HierarchyExtension getHierarchyExtension() {
        return hierarchyExtension;
    }

    public void setHierarchyExtension(HierarchyExtension hierarchyExtension) {
        this.hierarchyExtension = hierarchyExtension;
    }
}
