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
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 12:14 AM*/
    public class CompiledOrderItem {

        private Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression;

        private bool asc;

        internal CompiledOrderItem(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression, bool asc) {
            this.SetExpression(expression);
            this.SetAsc(asc);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetExpression() {
            return expression;
        }

        public virtual void SetExpression(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            this.expression = expression;
        }

        public virtual bool IsAsc() {
            return asc;
        }

        public virtual void SetAsc(bool asc) {
            this.asc = asc;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem Copy() {
            return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledOrderItem(expression.Copy(), asc);
        }
    }
}
