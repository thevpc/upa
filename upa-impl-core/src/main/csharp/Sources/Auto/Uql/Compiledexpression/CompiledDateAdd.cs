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
    public class CompiledDateAdd : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledDateAdd(Net.TheVpc.Upa.Expressions.DatePartType type, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression count, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression date)  : base("DateAdd"){

            ProtectedAddArgument(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst(type));
            ProtectedAddArgument(count);
            ProtectedAddArgument(date);
        }

        public virtual Net.TheVpc.Upa.Expressions.DatePartType GetDatePartType() {
            return (Net.TheVpc.Upa.Expressions.DatePartType) GetDatePartTypeExpression().GetValue();
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst GetDatePartTypeExpression() {
            return (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst) GetArgument(0);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetCount() {
            return GetArgument(1);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetDate() {
            return GetArgument(2);
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDateAdd o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDateAdd(GetDatePartType(), GetCount().Copy(), GetDate().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
