package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.impl.util.PlatformBeanProperty;

/**
 * Created by vpc on 7/2/17.
 */
class PlatformBeanFieldInfoSetter implements FieldInfoSetter {
    private final PlatformBeanProperty prop;

    public PlatformBeanFieldInfoSetter(PlatformBeanProperty prop) {
        this.prop = prop;
    }

    @Override
    public void set(Object instance, Object value) {
        prop.setValue(instance, value);
    }
}
