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
    public class DeleteSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public DeleteSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDelete) oo;
            Net.Vpc.Upa.Entity entityManager = context.GetPersistenceUnit().GetEntity(o.GetEntity().GetName());
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Delete From " + sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEntityName(o.GetEntity().GetName()), context, declarations));
            if (o.GetEntityAlias() != null) {
                sb.Append(" ").Append(sqlManager.GetSQL(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(o.GetEntityAlias()), context, declarations));
            }
            if (o.GetCondition() != null && o.GetCondition().IsValid()) {
                sb.Append(" Where ").Append(sqlManager.GetSQL(o.GetCondition(), context, declarations));
            }
            return sb.ToString();
        }
    }
}
