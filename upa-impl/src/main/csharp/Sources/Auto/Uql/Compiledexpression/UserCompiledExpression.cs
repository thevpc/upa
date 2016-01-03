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


    public class UserCompiledExpression : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {



        private string expression;

        private Net.Vpc.Upa.Types.DataTypeTransform type;

        public UserCompiledExpression(string qlString, Net.Vpc.Upa.Types.DataTypeTransform type) {
            this.expression = qlString;
            this.type = type;
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return type;
        }

        public virtual string GetExpression() {
            return expression;
        }


        public override void SetDataType(Net.Vpc.Upa.Types.DataTypeTransform type) {
            this.type = type;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.UserCompiledExpression o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.UserCompiledExpression(expression, type);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override string ToString() {
            return System.Convert.ToString(expression);
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return null;
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            throw new System.Exception("Not supported.");
        }
    }
}
