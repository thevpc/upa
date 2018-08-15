package net.vpc.upa.impl.util.jdk;

import java.lang.reflect.Proxy;
import net.vpc.upa.PortabilityHint;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.PlatformMethodProxy;
import net.vpc.upa.impl.util.PlatformTypeProxy;

/**
 * Created by vpc on 8/6/15.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class PlatformTypeProxyJavaJdk implements PlatformTypeProxy {

    public static ByteClassLoader loader;

    @Override
    public <T> T create(Class<T> type, final PlatformMethodProxy pmethodProxy) {
        if (type.isInterface()) {
            return (T) Proxy.newProxyInstance(type.getClassLoader(), new Class[]{type}, new PlatformTypeProxyJavaJdkInvocationHandler(pmethodProxy));
        }
        throw new UPAException("InableToCreateProxyForClass", type);
    }

}
