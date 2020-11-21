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
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 10 juin 2003
     * Time: 16:29:33
     * To change this template use Options | File Templates.
     */
    public class CompiledUplet : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {



        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] expressions;

        public CompiledUplet(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] expressions)  : base(){

            this.expressions = expressions;
            PrepareChildren(expressions);
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetExpressions() {
            return expressions;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] expressions2 = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[expressions.Length];
            for (int i = 0; i < expressions2.Length; i++) {
                expressions2[i] = expressions[i].Copy();
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(expressions2);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] r = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[expressions.Length];
            System.Array.Copy(expressions, 0, r, 0, expressions.Length);
            return r;
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            expressions[index] = expression;
            PrepareChildren(expression);
        }
    }
}
