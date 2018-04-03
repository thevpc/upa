package net.vpc.upa.impl;

import net.vpc.upa.PlatformObjectFactory;
import net.vpc.upa.impl.util.PlatformUtils;

public class DefaultPlatformObjectFactory implements PlatformObjectFactory {
    public static final DefaultPlatformObjectFactory INSTANCE=new DefaultPlatformObjectFactory();
    @Override
    public <T> T createObject(Class<T> type, String name) {
        return (T) PlatformUtils.newInstance(type);
    }
}
