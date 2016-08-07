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


    public sealed class CompiledNullVal : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledNullVal(Net.Vpc.Upa.Types.DataTypeTransform type)  : base("NullVal"){

            ProtectedAddArgument(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName(type));
            PrepareChildren(this);
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName GetNullTypeExpression() {
            return (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName) GetArgument(0);
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return GetNullTypeExpression().GetTypeTransform();
        }


        public override object Clone() {
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNullVal(GetTypeTransform());
        }


        public override string GetDescription() {
            return "NULL";
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNullVal o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledNullVal(GetNullTypeExpression().GetTypeTransform());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
