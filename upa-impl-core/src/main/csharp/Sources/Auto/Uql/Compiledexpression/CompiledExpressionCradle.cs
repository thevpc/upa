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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class CompiledExpressionCradle : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression;

        public CompiledExpressionCradle() {
        }

        public CompiledExpressionCradle(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            this.expression = expression;
            PrepareChildren(expression);
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] { expression };
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                this.expression = expression;
                PrepareChildren(expression);
            } else {
                throw new System.Exception();
            }
        }

        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledExpressionCradle(expression);
        }
    }
}
