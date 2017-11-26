package net.vpc.upa;

public class IndexInfo extends UPAObjectInfo{
    private boolean unique;
    private String entity;
    private String[] fields;

    public IndexInfo() {
        super("index");
    }

    public boolean isUnique() {
        return unique;
    }

    public void setUnique(boolean unique) {
        this.unique = unique;
    }

    public String getEntity() {
        return entity;
    }

    public void setEntity(String entity) {
        this.entity = entity;
    }

    public String[] getFields() {
        return fields;
    }

    public void setFields(String[] fields) {
        this.fields = fields;
    }
}
