package net.vpc.upa.types;

import net.vpc.upa.DataTypeInfo;
import net.vpc.upa.Relationship;

public class RelationDataType extends DefaultDataType{
    private Relationship relationship;
    private boolean updatable;

    public RelationDataType(String name, Class platformType) {
        super(name, platformType);
    }

    public RelationDataType(String name, Class platformType, boolean nullable) {
        super(name, platformType, nullable);
    }

    public RelationDataType(String name, Class platformType, int scale, int precision, boolean nullable) {
        super(name, platformType, scale, precision, nullable);
    }

    public boolean isUpdatable() {
        return updatable;
    }

    public void setUpdatable(boolean updatable) {
        this.updatable = updatable;
    }

    public Relationship getRelationship() {
        return relationship;
    }

    public void setRelationship(Relationship relationship) {
        this.relationship = relationship;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        if (!super.equals(o)) return false;

        RelationDataType that = (RelationDataType) o;

        if (updatable != that.updatable) return false;
        return relationship != null ? relationship.equals(that.relationship) : that.relationship == null;
    }

    @Override
    public int hashCode() {
        int result = super.hashCode();
        result = 31 * result + (updatable ? 1 : 0);
        result = 31 * result + (relationship != null ? relationship.hashCode() : 0);
        return result;
    }

    @Override
    public DataTypeInfo getInfo() {
        DataTypeInfo d = super.getInfo();
        d.getProperties().put("updatable", String.valueOf(updatable));
        if(relationship!=null) {
            d.getProperties().put("relationship", String.valueOf(relationship.getName()));
        }
        return d;
    }

}
