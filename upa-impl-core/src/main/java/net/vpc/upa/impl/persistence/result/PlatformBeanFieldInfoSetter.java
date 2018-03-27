package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.PlatformBeanType;
import net.vpc.upa.PropertyAccessType;

/**
 * Created by vpc on 7/2/17.
 */
class PlatformBeanFieldInfoSetter implements ResultFieldParseDataSetter {
    private final PlatformBeanType type;
    private final String property;

    public PlatformBeanFieldInfoSetter(String property,PlatformBeanType type) {
        this.type = type;
        this.property = property;
    }

    @Override
    public void set(Object instance, Object value) {
        type.setPropertyValue(instance, property,value);
    }
}
