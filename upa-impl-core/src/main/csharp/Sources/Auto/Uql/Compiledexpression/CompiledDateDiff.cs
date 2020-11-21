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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 12:07:34
     * To change this template use Options | File Templates.
     */
    public class CompiledDateDiff : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledDateDiff(Net.TheVpc.Upa.Expressions.DatePartType datePartType, Net.TheVpc.Upa.Types.Temporal date1, Net.TheVpc.Upa.Types.Temporal date2)  : this(datePartType, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(date1), new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(date2)){

        }

        public CompiledDateDiff(Net.TheVpc.Upa.Expressions.DatePartType datePartType, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression startDate, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression endDate)  : base("DateDiff"){

            ProtectedAddArgument(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst(datePartType));
            ProtectedAddArgument(startDate);
            ProtectedAddArgument(endDate);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst GetDatePartTypeExpression() {
            return (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst) GetArgument(0);
        }

        public virtual Net.TheVpc.Upa.Expressions.DatePartType GetDatePartType() {
            return (Net.TheVpc.Upa.Expressions.DatePartType) GetDatePartTypeExpression().GetValue();
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetStart() {
            return GetArgument(1);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetEnd() {
            return GetArgument(1);
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.INT;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDateDiff o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDateDiff(GetDatePartType(), GetStart().Copy(), GetEnd().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
