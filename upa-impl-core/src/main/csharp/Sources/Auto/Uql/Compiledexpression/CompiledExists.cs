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


    public sealed class CompiledExists : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledExists()  : base("Exists"){

        }

        public CompiledExists(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement query)  : this(){

            SetQuery(query);
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN;
        }

        public void SetQuery(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement query) {
            if (GetArgumentsCount() == 0) {
                ProtectedAddArgument(query);
            } else {
                ProtectedSetArgument(0, query);
            }
        }

        public Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement GetQuery() {
            return GetArgumentsCount() == 0 ? null : (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) GetArgument(0);
        }


        public override bool IsValid() {
            return GetArgumentsCount() > 0 && base.IsValid();
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement qq = GetQuery();
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledExists o = qq == null ? new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledExists() : new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledExists((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) qq.Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
