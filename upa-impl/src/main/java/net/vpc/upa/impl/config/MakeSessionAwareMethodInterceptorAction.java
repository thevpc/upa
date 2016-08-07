package net.vpc.upa.impl.config;

import net.vpc.upa.Action;
import net.vpc.upa.exceptions.ExecutionException;
import net.vpc.upa.impl.util.PlatformMethodProxyEvent;

/**
 * @author taha.bensalah@gmail.com on 7/6/16.
 */
class MakeSessionAwareMethodInterceptorAction<T> implements Action<Object> {
    private MakeSessionAwareMethodInterceptor<T> makeSessionAwareMethodInterceptor;
    private final PlatformMethodProxyEvent<T> event;

    public MakeSessionAwareMethodInterceptorAction(MakeSessionAwareMethodInterceptor<T> makeSessionAwareMethodInterceptor, PlatformMethodProxyEvent<T> event) {
        this.makeSessionAwareMethodInterceptor = makeSessionAwareMethodInterceptor;
        this.event = event;
    }

    @Override
    public Object run() {
        try {
            return event.invokeBase(makeSessionAwareMethodInterceptor.instance, event.getArguments());
        } catch (Throwable ex) {
            throw new ExecutionException(ex);
        }
    }
}
