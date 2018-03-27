package net.vpc.upa.impl.persistence.result;

import net.vpc.upa.impl.util.PlatformMethodInfo;
import net.vpc.upa.impl.util.PlatformMethodProxy;
import net.vpc.upa.impl.util.PlatformMethodProxyEvent;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.persistence.QueryResult;


/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 3:02 AM
*/
class UpdatableObjectInterceptor implements PlatformMethodProxy<Object> {
    private final Object object;
    private final QueryResult result;
    private ResultFieldFamily singleEntityQueryResult;

    public UpdatableObjectInterceptor(ResultFieldFamily singleEntityQueryResult, Object object, QueryResult result) {
        this.singleEntityQueryResult = singleEntityQueryResult;
        this.object = object;
        this.result = result;
    }

    @Override
    public Object intercept(PlatformMethodProxyEvent<Object> event) throws Throwable {
        PlatformMethodInfo mi = PlatformUtils.getMethodInfo(event.getMethod());
        switch (mi.getMethodType()){
            case SETTER:{
                ResultFieldParseData prop = singleEntityQueryResult.fieldsMap.get(mi.getPropertyName());
                if (prop == null) {
                    return event.invokeBase(object, event.getArguments());
                } else {
                    Object o = event.invokeBase(object, event.getArguments());
                    result.write(prop.dbIndex,event.getArguments()[0]);
                    return o;
                }
            }
        }
        return event.invokeBase(object, event.getArguments());
    }
}
