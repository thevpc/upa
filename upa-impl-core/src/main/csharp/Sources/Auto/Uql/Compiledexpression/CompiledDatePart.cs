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
    public class CompiledDatePart : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledDatePart(Net.TheVpc.Upa.Expressions.DatePartType type, Net.TheVpc.Upa.Types.Temporal date)  : this(type, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(date)){

        }

        public CompiledDatePart(Net.TheVpc.Upa.Expressions.DatePartType type, string varDate)  : this(type, new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.UserCompiledExpression(varDate, Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.DATETIME)){

        }

        public CompiledDatePart(Net.TheVpc.Upa.Expressions.DatePartType type, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression @value)  : base("Datepart"){

            ProtectedAddArgument(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst(type));
            ProtectedAddArgument(@value);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst GetDatePartTypeExpression() {
            return (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst) GetArgument(0);
        }

        public virtual Net.TheVpc.Upa.Expressions.DatePartType GetDatePartType() {
            return (Net.TheVpc.Upa.Expressions.DatePartType) GetDatePartTypeExpression().GetValue();
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetValue() {
            return GetArgument(1);
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDatePart o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDatePart(GetDatePartType(), GetValue().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
