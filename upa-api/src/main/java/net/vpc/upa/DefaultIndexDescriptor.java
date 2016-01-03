package net.vpc.upa;

/**
 * Created by vpc on 7/26/15.
 */
public class DefaultIndexDescriptor implements IndexDescriptor {
    private String name;

    private String[] fieldNames;

    private boolean unique;

    @Override
    public String getName() {
        return name;
    }

    public DefaultIndexDescriptor setName(String name) {
        this.name = name;
        return this;
    }

    @Override
    public String[] getFieldNames() {
        return fieldNames;
    }

    public DefaultIndexDescriptor setFieldNames(String... fieldNames) {
        this.fieldNames = fieldNames;
        return this;
    }

    @Override
    public boolean isUnique() {
        return unique;
    }

    public DefaultIndexDescriptor setUnique(boolean unique) {
        this.unique = unique;
        return this;
    }
}
