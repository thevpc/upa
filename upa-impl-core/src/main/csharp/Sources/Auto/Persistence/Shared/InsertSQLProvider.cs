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
     * Date: 8/17/12
     * Time: 12:52 AM
     * To change this template use File | Settings | File Templates.
     */
    public class InsertSQLProvider : Net.TheVpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public InsertSQLProvider()  : base(typeof(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert)){

        }


        public override string GetSQL(object oo, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert o = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert) oo;
            //        PersistenceUnitManager persistenceManager = context.getPersistenceStore();
            Net.TheVpc.Upa.Entity entity = context.GetPersistenceUnit().GetEntity(o.GetEntity().GetName());
            string n = context.GetPersistenceStore().GetValidIdentifier(context.GetPersistenceStore().GetPersistenceName(entity));
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Insert Into " + n);
            sb.Append("(");
            System.Text.StringBuilder sbVals = new System.Text.StringBuilder();
            bool isFirst = true;
            int max = o.CountFields();
            for (int i = 0; i < max; i++) {
                if (isFirst) {
                    isFirst = false;
                } else {
                    sb.Append(", ");
                    sbVals.Append(", ");
                }
                sb.Append(sqlManager.GetSQL(o.GetField(i), context, declarations));
                sbVals.Append(sqlManager.GetSQL(o.GetFieldValue(i), context, declarations));
            }
            return sb.Append(") Values (").Append(sbVals).Append(")").ToString();
        }
    }
}
