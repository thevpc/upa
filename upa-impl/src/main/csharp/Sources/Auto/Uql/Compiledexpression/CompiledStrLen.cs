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
     * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 12:21:56 To
     * change this template use Options | File Templates.
     */
    public class CompiledStrLen : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledStrLen(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression @value)  : base("StrLen"){

            ProtectedAddArgument(@value);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetExpression() {
            return GetArgument(0);
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledStrLen o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledStrLen(GetExpression().Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.INT;
        }
    }
}
