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



namespace Net.Vpc.Upa.Impl.Extension
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/7/13 2:00 AM*/
    internal class EntityRemoveOperationHelper : Net.Vpc.Upa.Persistence.EntityRemoveOperation {

        private Net.Vpc.Upa.Impl.Extension.DefaultUnionEntityExtension defaultUnionEntityExtensionSupport;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Entity> updatableTables;

        public EntityRemoveOperationHelper(Net.Vpc.Upa.Impl.Extension.DefaultUnionEntityExtension defaultUnionEntityExtensionSupport, System.Collections.Generic.IList<Net.Vpc.Upa.Entity> updatableTables) {
            this.defaultUnionEntityExtensionSupport = defaultUnionEntityExtensionSupport;
            this.updatableTables = updatableTables;
        }


        public virtual int Delete(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Expressions.Expression condition, bool recurse, Net.Vpc.Upa.RemoveTrace deleteInfo) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            for (int i = 0; i < (updatableTables).Count; i++) {
                updatableTables[i].Remove(Net.Vpc.Upa.RemoveOptions.ForExpression(defaultUnionEntityExtensionSupport.GetViewElementExpressionAt(i, condition)).SetFollowLinks(recurse).SetSimulate(false).SetRemoveTrace(deleteInfo));
            }
            return 0;
        }

        public virtual Net.Vpc.Upa.Query CreateQuery(Net.Vpc.Upa.Entity e, Net.Vpc.Upa.Expressions.Delete query, Net.Vpc.Upa.Persistence.EntityExecutionContext context) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            throw new System.Exception("Not supported yet.");
        }
    }
}
