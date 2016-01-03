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
    public class CompiledDateAdd : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledDateAdd(Net.Vpc.Upa.Expressions.DatePartType type, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression count, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression date)  : base("DateAdd"){

            ProtectedAddArgument(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCst(type));
            ProtectedAddArgument(count);
            ProtectedAddArgument(date);
        }

        public virtual Net.Vpc.Upa.Expressions.DatePartType GetDatePartType() {
            return (Net.Vpc.Upa.Expressions.DatePartType) GetDatePartTypeExpression().GetValue();
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCst GetDatePartTypeExpression() {
            return (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCst) GetArgument(0);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetCount() {
            return GetArgument(1);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetDate() {
            return GetArgument(2);
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDateAdd o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDateAdd(GetDatePartType(), GetCount().Copy(), GetDate().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
