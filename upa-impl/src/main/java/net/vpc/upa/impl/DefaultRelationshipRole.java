package net.vpc.upa.impl;

import net.vpc.upa.*;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * User: taha Date: 28 aout 2003 Time: 20:28:38
 */
public class DefaultRelationshipRole extends AbstractUPAObject implements RelationshipRole {

    private Field entityField;
    private Field[] fields;
    private Entity entity;
    private Relationship relation;
    private RelationshipRoleType relationRoleType;
    private RelationshipUpdateType relationUpdateType;

    //    public Icon getIcon() {
//        return entity.getIcon();
//    }
    public DefaultRelationshipRole() {
    }

    @Override
    public String getAbsoluteName() {
        return getName();
    }

    public Relationship getRelationship() {
        return relation;
    }

    public void setRelationship(Relationship relation) {
        this.relation = relation;
    }

    public RelationshipRoleType getRelationshipRoleType() {
        return relationRoleType;
    }

    public void setRelationshipRoleType(RelationshipRoleType relationRoteType) {
        this.relationRoleType = relationRoteType;
    }

    public Entity getEntity() {
        return entity;
    }

    public void setEntity(Entity entity) {
        this.entity = entity;
    }

    public int indexOf(String fieldName) {
        for (int i = 0; i < fields.length; i++) {
            if (fields[i].getName().equals(fieldName)) {
                return i;
            }
        }
        return -1;
    }

    public Field getEntityField() {
        return entityField;
    }

    public void setEntityField(Field entityField) {
        this.entityField = entityField;
    }

    public Field getField(int i) {
        return fields[i];
    }

    public List<Field> getFields() {
        return new ArrayList<Field>(Arrays.asList(fields));
    }

    public void setFields(Field[] fields) {
        this.fields = fields;
        entity = fields[0].getEntity();
    }

    public RelationshipUpdateType getRelationshipUpdateType() {
        return relationUpdateType;
    }

    public void setRelationshipUpdateType(RelationshipUpdateType relationUpdateType) {
        this.relationUpdateType = relationUpdateType;
    }
}
