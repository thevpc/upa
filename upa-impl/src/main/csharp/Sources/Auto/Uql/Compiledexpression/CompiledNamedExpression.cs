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
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/16/12
     * Time: 5:55 AM
     * To change this template use File | Settings | File Templates.
     */
    public class CompiledNamedExpression {

        private string name;

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression;

        public CompiledNamedExpression(string name, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            this.name = name;
            this.expression = expression;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetExpression() {
            return expression;
        }

        public virtual void SetExpression(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            this.expression = expression;
        }
    }
}
