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



namespace Net.TheVpc.Upa.Impl.Extension
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/7/13 2:00 AM*/
    internal class EntityRemoveOperationHelper : Net.TheVpc.Upa.Persistence.EntityRemoveOperation {

        private Net.TheVpc.Upa.Impl.Extension.DefaultUnionEntityExtension defaultUnionEntityExtensionSupport;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> updatableTables;

        public EntityRemoveOperationHelper(Net.TheVpc.Upa.Impl.Extension.DefaultUnionEntityExtension defaultUnionEntityExtensionSupport, System.Collections.Generic.IList<Net.TheVpc.Upa.Entity> updatableTables) {
            this.defaultUnionEntityExtensionSupport = defaultUnionEntityExtensionSupport;
            this.updatableTables = updatableTables;
        }


        public virtual int Delete(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Expressions.Expression condition, bool recurse, Net.TheVpc.Upa.RemoveTrace deleteInfo) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            for (int i = 0; i < (updatableTables).Count; i++) {
                updatableTables[i].Remove(Net.TheVpc.Upa.RemoveOptions.ForExpression(defaultUnionEntityExtensionSupport.GetViewElementExpressionAt(i, condition)).SetFollowLinks(recurse).SetSimulate(false).SetRemoveTrace(deleteInfo));
            }
            return 0;
        }

        public virtual Net.TheVpc.Upa.Query CreateQuery(Net.TheVpc.Upa.Entity e, Net.TheVpc.Upa.Expressions.Delete query, Net.TheVpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            throw new System.Exception("Not supported yet.");
        }
    }
}
