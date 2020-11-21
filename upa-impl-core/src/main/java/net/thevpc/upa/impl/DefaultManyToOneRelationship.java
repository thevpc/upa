package net.thevpc.upa.impl;

import net.thevpc.upa.ManyToOneRelationship;
import net.thevpc.upa.HierarchyExtension;

public class DefaultManyToOneRelationship extends DefaultRelationship implements ManyToOneRelationship{
    private HierarchyExtension hierarchyExtension;
    public HierarchyExtension getHierarchyExtension() {
        return hierarchyExtension;
    }

    public void setHierarchyExtension(HierarchyExtension hierarchyExtension) {
        this.hierarchyExtension = hierarchyExtension;
    }
}
