package net.vpc.upa.impl.persistence;

import net.vpc.upa.impl.util.PlatformMethodProxy;
import net.vpc.upa.impl.util.PlatformMethodProxyEvent;
import net.vpc.upa.persistence.QueryResult;


/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 3:02 AM
*/
class SingleEntityQueryResultParseMethodInterceptor implements PlatformMethodProxy<Object> {
    private final Object ret;
    private final QueryResult result;
    private TypeInfo singleEntityQueryResult;

    public SingleEntityQueryResultParseMethodInterceptor(TypeInfo singleEntityQueryResult, Object ret, QueryResult result) {
        this.singleEntityQueryResult = singleEntityQueryResult;
        this.ret = ret;
        this.result = result;
    }

    @Override
    public Object intercept(PlatformMethodProxyEvent<Object> event) throws Throwable {
        String name = event.getMethodName();
        FieldInfo prop = singleEntityQueryResult.fields.get(name);
        if (prop == null) {
            return event.invokeBase(ret, event.getArguments());
        } else {
            result.write(prop.index,event.getArguments()[0]);
            return event.invokeBase(ret, event.getArguments());
        }
    }
}
