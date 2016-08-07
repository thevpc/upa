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
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 11:04 PM To change
     * this template use File | Settings | File Templates.
     */
    public class CompiledTypeName : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        private Net.Vpc.Upa.Types.DataTypeTransform type;

        public CompiledTypeName(Net.Vpc.Upa.Types.DataTypeTransform type) {
            this.type = type;
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return type;
        }


        public override bool IsValid() {
            return true;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledTypeName(type);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return null;
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            throw new System.Exception("Not supported.");
        }


        public override string ToString() {
            return System.Convert.ToString(type);
        }
    }
}
