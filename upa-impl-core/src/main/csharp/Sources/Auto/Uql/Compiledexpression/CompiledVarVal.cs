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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/29/12 5:52 PM
     */
    public class CompiledVarVal : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar var;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression val;

        public CompiledVarVal(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar var, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression val) {
            this.var = var;
            this.val = val;
            PrepareChildren(var, val);
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] { var, val };
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            switch(index) {
                case 0:
                    {
                        var = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expression;
                        PrepareChildren(var);
                        return;
                    }
                case 1:
                    {
                        val = expression;
                        PrepareChildren(val);
                        return;
                    }
            }
            throw new System.Exception("Invalid index");
        }

        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            return new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal(var == null ? null : ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) var.Copy()), val == null ? null : ((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) val.Copy()));
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar GetVar() {
            return var;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetVal() {
            return val;
        }
    }
}
