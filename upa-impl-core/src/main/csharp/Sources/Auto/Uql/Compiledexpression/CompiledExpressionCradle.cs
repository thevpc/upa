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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class CompiledExpressionCradle : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression;

        public CompiledExpressionCradle() {
        }

        public CompiledExpressionCradle(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            this.expression = expression;
            PrepareChildren(expression);
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] { expression };
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                this.expression = expression;
                PrepareChildren(expression);
            } else {
                throw new System.Exception();
            }
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledExpressionCradle(expression);
        }
    }
}
