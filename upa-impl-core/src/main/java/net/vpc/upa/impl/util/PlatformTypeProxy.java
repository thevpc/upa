package net.vpc.upa.impl.util;

/**
 * Created by vpc on 8/6/15.
 */
public interface PlatformTypeProxy {
    <T> T create(Class<T> type, Class[] interfaces, PlatformMethodProxy methodProxy);
}
