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



namespace Net.TheVpc.Upa.Impl.Persistence.Result
{


    /**
     * Created by vpc on 6/26/16.
     */
    public class QueryRelationLoaderSelectObject : Net.TheVpc.Upa.Impl.Persistence.Result.QueryResultRelationLoader {

        public virtual object LoadObject(Net.TheVpc.Upa.Entity e, object id, bool record, Net.TheVpc.Upa.Impl.Persistence.Result.LoaderContext context) {
            Net.TheVpc.Upa.NamedId cacheId = new Net.TheVpc.Upa.NamedId(id, e.GetName());
            Net.TheVpc.Upa.Impl.Util.CacheMap<Net.TheVpc.Upa.NamedId , object> referencesCache = context.GetReferencesCache();
            object existingValue = referencesCache.Get(cacheId);
            if (existingValue == null && !referencesCache.ContainsKey(cacheId)) {
                Net.TheVpc.Upa.Query query = e.CreateQueryBuilder().ById(id).SetHints(context.GetHints());
                existingValue = record ? ((object)(query.GetRecord())) : query.GetEntity<object>();
                referencesCache.Put(cacheId, existingValue);
            }
            return existingValue;
        }
    }
}
