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



namespace Net.TheVpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/15/12
     * Time: 11:46 PM
     * To change this template use File | Settings | File Templates.
     */
    public class EntityNameSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public EntityNameSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName)){

        }


        public override string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName) oo;
            Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore = context.GetPersistenceStore();
            string entityName = o.GetName();
            Net.TheVpc.Upa.Entity e = context.GetPersistenceUnit().GetEntity(entityName);
            if (o.IsUseView() && e.NeedsView() && persistenceStore.IsViewSupported()) {
                return persistenceStore.GetValidIdentifier(persistenceStore.GetPersistenceName(e, Net.TheVpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW));
            } else {
                return persistenceStore.GetValidIdentifier(persistenceStore.GetPersistenceName(e));
            }
        }
    }
}
