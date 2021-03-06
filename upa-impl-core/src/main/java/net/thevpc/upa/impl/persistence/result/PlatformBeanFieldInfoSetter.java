package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.PlatformBeanType;

/**
 * Created by vpc on 7/2/17.
 */
class PlatformBeanFieldInfoSetter implements ResultFieldParseDataSetter {
    private final PlatformBeanType beanType;
    private final String property;

    public PlatformBeanFieldInfoSetter(String property,PlatformBeanType type) {
        this.beanType = type;
        this.property = property;
    }

    @Override
    public void set(Object instance, Object value) {
        beanType.setPropertyValue(instance, property,value);
    }
}
