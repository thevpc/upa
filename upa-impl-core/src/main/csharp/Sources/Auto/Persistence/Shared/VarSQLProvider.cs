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
     * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
     * this template use File | Settings | File Templates.
     */
    public class VarSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public VarSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar)){

        }


        public override string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext qlContext, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) oo;
            Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore = qlContext.GetPersistenceStore();
            object referrer = o.GetReferrer();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (referrer is Net.TheVpc.Upa.Field) {
                Net.TheVpc.Upa.Field field = (Net.TheVpc.Upa.Field) referrer;
                string name = persistenceStore.GetPersistenceName(field);
                sb.Append(persistenceStore.GetValidIdentifier(name));
            } else if (referrer is Net.TheVpc.Upa.Entity) {
                Net.TheVpc.Upa.Entity entity = (Net.TheVpc.Upa.Entity) referrer;
                //            if ("this".equals(o.getName())) {
                //                throw new IllegalArgumentException("Unexpected this alias");
                //                //this must be resolved to the ancestor alias
                //                ExpressionDeclarationList declarationList = o.getDeclarationList();
                //                name = persistenceManager.getPersistenceName(declarationList.getValue(null).getName(), PersistenceNameStrategyNames.ALIAS);
                //            } else {
                string name = persistenceStore.GetPersistenceName(o.GetName(), Net.TheVpc.Upa.Persistence.PersistenceNameType.ALIAS);
                sb.Append(persistenceStore.GetValidIdentifier(name));
            } else {
                string name = persistenceStore.GetPersistenceName(o.GetName(), Net.TheVpc.Upa.Persistence.PersistenceNameType.ALIAS);
                sb.Append(persistenceStore.GetValidIdentifier(name));
            }
            if (o.GetChild() != null) {
                string cc = GetSQL(o.GetChild(), qlContext, sqlManager, declarations);
                sb.Append(".").Append(cc);
            }
            return sb.ToString();
        }
    }
}
