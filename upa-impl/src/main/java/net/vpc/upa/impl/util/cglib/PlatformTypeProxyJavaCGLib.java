package net.vpc.upa.impl.util.cglib;

import net.vpc.upa.PortabilityHint;

import net.vpc.upa.impl.util.PlatformMethodProxy;
import net.vpc.upa.impl.util.PlatformTypeProxy;

/**
 * Created by vpc on 8/6/15.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class PlatformTypeProxyJavaCGLib implements PlatformTypeProxy {
    @Override
    public <T> T create(Class<T> type, Class[] interfaces, final PlatformMethodProxy pmethodProxy) {
        return (T) net.sf.cglib.proxy.Enhancer.create(
                type, interfaces,
                new ProxyMethodInterceptorCGLib(pmethodProxy));
    }

}
