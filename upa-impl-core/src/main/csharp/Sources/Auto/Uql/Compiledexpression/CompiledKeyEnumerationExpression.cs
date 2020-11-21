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
     * User: vpc
     * Date: 22 janv. 2006
     * Time: 09:48:59
     * To change this template use File | Settings | File Templates.
     */
    public class CompiledKeyEnumerationExpression : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        private System.Collections.Generic.IList<object> keys;

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar alias;

        public CompiledKeyEnumerationExpression(System.Collections.Generic.IList<object> keys, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar alias) {
            this.keys = keys;
            this.alias = alias;
            PrepareChildren(alias);
        }

        public virtual System.Collections.Generic.IList<object> GetKeys() {
            return keys;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar GetAlias() {
            return alias;
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.BOOLEAN;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyEnumerationExpression o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledKeyEnumerationExpression(new System.Collections.Generic.List<object>(keys), alias == null ? null : (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) alias.Copy());
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return alias == null ? new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[0] : new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] { alias };
        }


        public override void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                alias = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) expression;
                PrepareChildren(expression);
            } else {
                throw new System.ArgumentException ("Invalid index");
            }
        }
    }
}
