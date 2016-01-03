package net.vpc.upa.impl.config;

import net.vpc.upa.MethodFilter;
import net.vpc.upa.UPA;
import net.vpc.upa.impl.util.PlatformMethodProxy;
import net.vpc.upa.impl.util.PlatformMethodProxyEvent;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/7/13 2:32 PM
 */
class MakeSessionAwareMethodInterceptor2<T> implements PlatformMethodProxy<T> {

    private final MethodFilter methodFilter;

    public MakeSessionAwareMethodInterceptor2(MethodFilter methodFilter) {
        this.methodFilter = methodFilter;
    }

    @Override
    public Object intercept(PlatformMethodProxyEvent<T> event) throws Throwable {
        if (methodFilter == null || methodFilter.accept(event.getMethod())) {
            return UPA.getContext().invoke(new MakeSessionAwareMethodInterceptor2Action(event), null);
        } else {
            return event.invokeBase(event.getObject(), event.getArguments());
        }
    }

}
