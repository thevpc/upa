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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * Created by vpc on 6/17/16.
     */
    internal class FindByIdAction : Net.Vpc.Upa.Action<object> {

        private readonly Net.Vpc.Upa.Entity e;

        private readonly object id;

        private readonly System.Collections.Generic.IDictionary<string , object> hints;

        public FindByIdAction(Net.Vpc.Upa.Entity e, object id, System.Collections.Generic.IDictionary<string , object> hints) {
            this.e = e;
            this.id = id;
            this.hints = hints;
        }


        public virtual object Run() {
            return e.CreateQueryBuilder().ById(id).SetHints(hints).GetEntity<R>();
        }
    }
}
