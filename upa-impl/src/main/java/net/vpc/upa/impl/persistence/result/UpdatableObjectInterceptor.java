package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.impl.util.PlatformMethodProxy;
import net.vpc.upa.impl.util.PlatformMethodProxyEvent;
import net.vpc.upa.persistence.QueryResult;


/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 3:02 AM
*/
class UpdatableObjectInterceptor implements PlatformMethodProxy<Object> {
    private final Object object;
    private final QueryResult result;
    private TypeInfo singleEntityQueryResult;

    public UpdatableObjectInterceptor(TypeInfo singleEntityQueryResult, Object object, QueryResult result) {
        this.singleEntityQueryResult = singleEntityQueryResult;
        this.object = object;
        this.result = result;
    }

    @Override
    public Object intercept(PlatformMethodProxyEvent<Object> event) throws Throwable {
        String name = event.getMethodName();
        FieldInfo prop = singleEntityQueryResult.fieldsMap.get(name);
        if (prop == null) {
            return event.invokeBase(object, event.getArguments());
        } else {
            result.write(prop.dbIndex,event.getArguments()[0]);
            return event.invokeBase(object, event.getArguments());
        }
    }
}
