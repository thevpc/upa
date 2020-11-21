package net.thevpc.upa.impl.config;

import net.thevpc.upa.MethodFilter;
import net.thevpc.upa.UPA;
import net.thevpc.upa.exceptions.ExecutionException;
import net.thevpc.upa.impl.util.PlatformMethodProxy;
import net.thevpc.upa.impl.util.PlatformMethodProxyEvent;

import java.util.logging.Logger;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/7/13 2:32 PM
 */
public class MakeSessionAwareMethodInterceptor<T> implements PlatformMethodProxy<T> {

    private final MethodFilter methodFilter;
    final T instance;
    private DefaultUPAContext defaultUPAContext;
    private static final Logger log = Logger.getLogger(MakeSessionAwareMethodInterceptor.class.getName());

    public MakeSessionAwareMethodInterceptor(DefaultUPAContext defaultUPAContext, MethodFilter methodFilter, T instance) {
        this.defaultUPAContext = defaultUPAContext;
        this.methodFilter = methodFilter;
        this.instance = instance;
    }

    @Override
    public Object intercept(final PlatformMethodProxyEvent<T> event) throws Throwable {
        if (methodFilter == null || methodFilter.accept(event.getMethod())) {
//            HashMap<String, Object> properties = new HashMap<String, Object>();
            try {
                return UPA.getContext().invoke(new MakeSessionAwareMethodInterceptorAction<T>(this, event));
            }catch(ExecutionException e){
                throw e.getCause();
            }
        } else {
            return event.invokeBase(instance, event.getArguments());
        }
    }

}
