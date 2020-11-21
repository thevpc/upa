package net.thevpc.upa;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/5/13 11:18 PM
 */ 
public interface PlatformBeanProperty {

    String getName();

    Class getPlatformType();

    Object getValue(Object o);

    Object getDefaultValue();

    void setValue(Object o, Object value);

    boolean isDefaultValue(Object o);

    boolean isWriteSupported();

    boolean isReadSupported();
}
