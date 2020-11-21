package net.thevpc.upa.impl.util.jdk;

import java.lang.reflect.Proxy;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import net.thevpc.upa.impl.util.PlatformMethodProxy;
import net.thevpc.upa.impl.util.PlatformTypeProxy;
import net.thevpc.upa.PortabilityHint;

import net.thevpc.upa.exceptions.UPAException;

/**
 * Created by vpc on 8/6/15.
 */
@PortabilityHint(target = "C#", name = "suppress")
public class PlatformTypeProxyJavaJdk implements PlatformTypeProxy {

    public static ByteClassLoader loader;

    @Override
    public <T> T create(Class<T> type, Class[] interfaces, final PlatformMethodProxy pmethodProxy) {
        if (type.isInterface()) {
            if(interfaces==null){
                return (T) Proxy.newProxyInstance(type.getClassLoader(), new Class[]{type}, new PlatformTypeProxyJavaJdkInvocationHandler(pmethodProxy));
            }
            List<Class> all=new ArrayList<>(1+(interfaces.length));
            all.add(type);
            all.addAll(Arrays.asList(interfaces));
            return (T) Proxy.newProxyInstance(type.getClassLoader(), all.toArray(new Class[0]), new PlatformTypeProxyJavaJdkInvocationHandler(pmethodProxy));
        }
        throw new UPAException("UnableToCreateProxyForClass", type);
    }

}
