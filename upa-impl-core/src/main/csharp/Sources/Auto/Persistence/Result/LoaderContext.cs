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
    public class LoaderContext {

        protected internal Net.TheVpc.Upa.Impl.Util.CacheMap<Net.TheVpc.Upa.NamedId , object> referencesCache;

        protected internal System.Collections.Generic.IDictionary<string , object> hints;

        public LoaderContext(Net.TheVpc.Upa.Impl.Util.CacheMap<Net.TheVpc.Upa.NamedId , object> referencesCache, System.Collections.Generic.IDictionary<string , object> hints) {
            this.referencesCache = referencesCache;
            this.hints = hints;
        }

        public virtual Net.TheVpc.Upa.Impl.Util.CacheMap<Net.TheVpc.Upa.NamedId , object> GetReferencesCache() {
            return referencesCache;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetHints() {
            return hints;
        }
    }
}
