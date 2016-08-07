/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Impl.Persistence.Result
{


    /**
     * Created by vpc on 6/26/16.
     */
    public class QueryRelationLoaderSelectObject : Net.Vpc.Upa.Impl.Persistence.Result.QueryResultRelationLoader {

        public virtual object LoadObject(Net.Vpc.Upa.Entity e, object id, bool record, Net.Vpc.Upa.Impl.Persistence.Result.LoaderContext context) {
            Net.Vpc.Upa.NamedId cacheId = new Net.Vpc.Upa.NamedId(id, e.GetName());
            Net.Vpc.Upa.Impl.Util.CacheMap<Net.Vpc.Upa.NamedId , object> referencesCache = context.GetReferencesCache();
            object existingValue = referencesCache.Get(cacheId);
            if (existingValue == null && !referencesCache.ContainsKey(cacheId)) {
                Net.Vpc.Upa.Query query = e.CreateQueryBuilder().ById(id).SetHints(context.GetHints());
                existingValue = record ? ((object)(query.GetRecord())) : query.GetEntity<object>();
                referencesCache.Put(cacheId, existingValue);
            }
            return existingValue;
        }
    }
}
