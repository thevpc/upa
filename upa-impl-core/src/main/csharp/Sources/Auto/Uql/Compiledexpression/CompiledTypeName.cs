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
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 11:04 PM To change
     * this template use File | Settings | File Templates.
     */
    public class CompiledTypeName : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        private Net.TheVpc.Upa.Types.DataTypeTransform type;

        public CompiledTypeName(Net.TheVpc.Upa.Types.DataTypeTransform type) {
            this.type = type;
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return type;
        }


        public override bool IsValid() {
            return true;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName(type);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return null;
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            throw new System.Exception("Not supported.");
        }


        public override string ToString() {
            return System.Convert.ToString(type);
        }
    }
}
