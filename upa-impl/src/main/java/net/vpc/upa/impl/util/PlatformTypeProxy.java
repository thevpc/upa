package net.vpc.upa.impl.util;

/**
 * Created by vpc on 8/6/15.
 */
public interface PlatformTypeProxy {
    public <T> T create(Class<T> type,PlatformMethodProxy methodProxy);
}
