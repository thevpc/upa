package net.vpc.upa.impl;

import net.vpc.upa.DeletionTraceElement;
import net.vpc.upa.RelationshipType;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:55 AM
*/
class DefaultDeletionTraceElement implements DeletionTraceElement {
    private String name;
    private long count;
    private RelationshipType relationType;

    public DefaultDeletionTraceElement(RelationshipType relationType, String entityName, long count) {
        this.name = entityName;
        this.count = count;
        this.relationType = relationType;
    }

    public String getEntityName() {
        return name;
    }

    public long getCount() {
        return count;
    }

    public RelationshipType getRelationshipType() {
        return relationType;
    }
}
