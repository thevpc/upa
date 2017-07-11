package net.vpc.upa.impl;

import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.Index;
import net.vpc.upa.exceptions.UPAException;

import java.util.ArrayList;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.filters.FieldFilters;

public class DefaultIndex extends AbstractUPAObject implements Index {

    private Entity entity;
    private String[] fieldNames;
    private Field[] fields;
    private boolean unique;

    public DefaultIndex() {
    }

    @Override
    public String getAbsoluteName() {
        return getName();
    }

    public boolean isUnique() {
        return unique;
    }

    public Field[] getFields() {
        if (fields == null) {
            throw new UPAIllegalArgumentException("Model Changes are not yet committed");
        }
        return fields;
    }

    public Entity getEntity() {
        if (entity == null) {
            throw new UPAIllegalArgumentException("Model Changes are not yet committed");
        }
        return entity;
    }

    public String[] getFieldNames() {
        return fieldNames;
    }

    @Override
    public void commitModelChanges() {
        ArrayList<Field> fields = new ArrayList<Field>(entity.getFields(FieldFilters.byName(fieldNames)));
        this.fields = fields.toArray(new Field[fields.size()]);
    }

    //called by injection
    public void setEntity(Entity entity) {
        this.entity = entity;
    }

    //called by injection
    public void setFieldNames(String[] fieldNames) {
        this.fieldNames = fieldNames;
    }

    //called by injection
    protected void setUnique(boolean unique) {
        this.unique = unique;
    }

    @Override
    public void close() throws UPAException {
    }
}
