package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.EntityBuilder;

/**
 * Created by vpc on 7/2/17.
 */
class EntityBuilderFieldInfoSetter implements FieldInfoSetter {
    private final EntityBuilder builder;
    private final String fieldName;

    public EntityBuilderFieldInfoSetter(String fieldName, EntityBuilder builder) {
        this.builder = builder;
        this.fieldName = fieldName;
    }

    @Override
    public void set(Object instance, Object value) {
        builder.setProperty(instance, fieldName, value);
    }
}
