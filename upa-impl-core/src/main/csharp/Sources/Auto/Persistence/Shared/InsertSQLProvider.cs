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
     * Date: 8/17/12
     * Time: 12:52 AM
     * To change this template use File | Settings | File Templates.
     */
    public class InsertSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public InsertSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert) oo;
            //        PersistenceUnitManager persistenceManager = context.getPersistenceStore();
            Net.Vpc.Upa.Entity entity = context.GetPersistenceUnit().GetEntity(o.GetEntity().GetName());
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
