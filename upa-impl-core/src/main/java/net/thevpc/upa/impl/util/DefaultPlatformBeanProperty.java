package net.thevpc.upa.impl.util;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:20 PM
 */
class DefaultPlatformBeanProperty extends AbstractPlatformBeanProperty {

    private PlatformBeanPropertyGetter getter;
    private PlatformBeanPropertySetter setter;

    DefaultPlatformBeanProperty(String field, Class fieldType, PlatformBeanPropertyGetter getter, PlatformBeanPropertySetter setter) {
        super(field, fieldType);
        this.getter = getter;
        this.setter = setter;
    }

    @Override
    public Object getValue(Object o) {
        if (getter == null) {
            throw new RuntimeException("Field inaccessible : no getter found for field " + getName());
        }
        return getter.getValue(o);
    }



    @Override
    public void setValue(Object o, Object value) {
        if (setter == null) {
            throw new RuntimeException("Field readonly : no setter found for " + getName() + " in class " + o.getClass());
        }
        setter.setValue(o,value);
    }

    @Override
    public boolean isWriteSupported() {
        return setter!=null;
    }

    @Override
    public boolean isReadSupported() {
        return getter!=null;
    }
}
