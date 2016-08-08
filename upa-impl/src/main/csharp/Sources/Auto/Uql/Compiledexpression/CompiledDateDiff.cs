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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{


    /**
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 12:07:34
     * To change this template use Options | File Templates.
     */
    public class CompiledDateDiff : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledDateDiff(Net.Vpc.Upa.Expressions.DatePartType datePartType, Net.Vpc.Upa.Types.Temporal date1, Net.Vpc.Upa.Types.Temporal date2)  : this(datePartType, new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(date1), new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(date2)){

        }

        public CompiledDateDiff(Net.Vpc.Upa.Expressions.DatePartType datePartType, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression startDate, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression endDate)  : base("DateDiff"){

            ProtectedAddArgument(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCst(datePartType));
            ProtectedAddArgument(startDate);
            ProtectedAddArgument(endDate);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCst GetDatePartTypeExpression() {
            return (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCst) GetArgument(0);
        }

        public virtual Net.Vpc.Upa.Expressions.DatePartType GetDatePartType() {
            return (Net.Vpc.Upa.Expressions.DatePartType) GetDatePartTypeExpression().GetValue();
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetStart() {
            return GetArgument(1);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetEnd() {
            return GetArgument(1);
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.INT;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDateDiff o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDateDiff(GetDatePartType(), GetStart().Copy(), GetEnd().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
