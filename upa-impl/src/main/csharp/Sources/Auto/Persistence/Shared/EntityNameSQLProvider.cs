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



namespace Net.Vpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/15/12
     * Time: 11:46 PM
     * To change this template use File | Settings | File Templates.
     */
    public class EntityNameSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public EntityNameSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) oo;
            Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore = context.GetPersistenceStore();
            string entityName = o.GetName();
            Net.Vpc.Upa.Entity e = context.GetPersistenceUnit().GetEntity(entityName);
            if (o.IsUseView() && e.NeedsView() && persistenceStore.IsViewSupported()) {
                return persistenceStore.GetValidIdentifier(persistenceStore.GetPersistenceName(e, Net.Vpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW));
            } else {
                return persistenceStore.GetValidIdentifier(persistenceStore.GetPersistenceName(e));
            }
        }
    }
}
