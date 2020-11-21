package net.thevpc.upa.impl;

import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.PlatformObjectFactory;

public class DefaultPlatformObjectFactory implements PlatformObjectFactory {
    public static final DefaultPlatformObjectFactory INSTANCE=new DefaultPlatformObjectFactory();
    @Override
    public <T> T createObject(Class<T> type, String name) {
        return (T) PlatformUtils.newInstance(type);
    }
}
