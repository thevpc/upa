package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;

import java.sql.SQLException;

/**
 * User: vpc Date: 8/16/12 Time: 6:41 AM To change this template use File |
 * Settings | File Templates.
 */
public class SingleEntityQueryResultSelectFetchStrategy<R> extends SingleEntityQueryResultNonJoinFetchStrategy<R> {

    public SingleEntityQueryResultSelectFetchStrategy(NativeSQL nativeSQL, String aliasName) throws SQLException {
        super(nativeSQL,aliasName);
    }

    protected Object loadObject(final Entity e, final Object id){
        NamedId cacheId = new NamedId(id, e.getName());
        Object existingValue = referencesCache.get(cacheId);
        if(existingValue==null && !referencesCache.containsKey(cacheId)){
            existingValue=e.createQueryBuilder().byId(id).setHints(hints).getEntity();
            referencesCache.put(cacheId,existingValue);
        }
        return existingValue;
    }

}
