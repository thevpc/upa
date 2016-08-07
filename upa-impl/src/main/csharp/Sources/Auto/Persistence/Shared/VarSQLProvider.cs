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
     * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
     * this template use File | Settings | File Templates.
     */
    public class VarSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public VarSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) oo;
            Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore = qlContext.GetPersistenceStore();
            object referrer = o.GetReferrer();
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (referrer is Net.Vpc.Upa.Field) {
                Net.Vpc.Upa.Field field = (Net.Vpc.Upa.Field) referrer;
                string name = persistenceStore.GetPersistenceName(field);
                sb.Append(persistenceStore.GetValidIdentifier(name));
            } else if (referrer is Net.Vpc.Upa.Entity) {
                Net.Vpc.Upa.Entity entity = (Net.Vpc.Upa.Entity) referrer;
                //            if ("this".equals(o.getName())) {
                //                throw new IllegalArgumentException("Unexpected this alias");
                //                //this must be resolved to the ancestor alias
                //                ExpressionDeclarationList declarationList = o.getDeclarationList();
                //                name = persistenceManager.getPersistenceName(declarationList.getValue(null).getName(), PersistenceNameStrategyNames.ALIAS);
                //            } else {
                string name = persistenceStore.GetPersistenceName(o.GetName(), Net.Vpc.Upa.Persistence.PersistenceNameType.ALIAS);
                sb.Append(persistenceStore.GetValidIdentifier(name));
            } else {
                string name = persistenceStore.GetPersistenceName(o.GetName(), Net.Vpc.Upa.Persistence.PersistenceNameType.ALIAS);
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
