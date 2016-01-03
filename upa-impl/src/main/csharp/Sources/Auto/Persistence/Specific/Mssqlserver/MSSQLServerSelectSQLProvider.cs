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



namespace Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/17/12 Time: 12:52 AM To change
     * this template use File | Settings | File Templates.
     */
    public class MSSQLServerSelectSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.SelectSQLProvider {

        public MSSQLServerSelectSQLProvider() {
        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledSelect) oo;
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Select ");
            if (o.GetTop() > 0) {
                sb.Append(" TOP ").Append(o.GetTop());
            }
            AppendDistinct(o, sb, context, sqlManager, declarations);
            AppendFields(o, sb, context, sqlManager, declarations);
            AppendFrom(o, sb, context, sqlManager, declarations);
            AppendJoins(o, sb, context, sqlManager, declarations);
            AppendWhere(o, sb, context, sqlManager, declarations);
            AppendGroupBy(o, sb, context, sqlManager, declarations);
            AppendHaving(o, sb, context, sqlManager, declarations);
            AppendOrderBy(o, sb, context, sqlManager, declarations);
            return sb.ToString();
        }


        public override string GetFromNullString() {
            return null;
        }
    }
}
