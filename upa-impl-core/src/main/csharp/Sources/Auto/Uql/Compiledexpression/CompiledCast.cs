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
     * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 12:21:56 To
     * change this template use Options | File Templates.
     */
    public class CompiledCast : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledCast(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression @value, Net.TheVpc.Upa.Types.DataTypeTransform primitiveType)  : base("Cast"){

            ProtectedAddArgument(@value);
            ProtectedAddArgument(new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName(primitiveType));
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetValue() {
            return GetArgument(0);
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName GetTargetType() {
            return ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName) GetArgument(1));
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return GetTargetType().GetTypeTransform();
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCast o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCast(GetValue().Copy(), GetTypeTransform());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
