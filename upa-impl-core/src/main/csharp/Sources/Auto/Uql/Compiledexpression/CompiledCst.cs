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

    public sealed class CompiledCst : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {



        private object @value;

        public CompiledCst(object @value) {
            this.@value = @value;
        }


        public override bool IsValid() {
            return true;
        }

        public object GetValue() {
            return @value;
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledCst(@value);
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return null;
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            throw new System.Exception("Not supported.");
        }


        public override string ToString() {
            return System.Convert.ToString(@value);
        }
    }
}
