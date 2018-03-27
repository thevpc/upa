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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/17/12
     * Time: 2:56 AM
     * To change this template use File | Settings | File Templates.
     */
    public class CompiledExpressionFactory {

        public static Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ToExpression(object e, System.Type defaultInstance) {
            if (e == null) {
                return new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(null, null);
            } else if (e is Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) {
                return (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) e;
            } else if ((e.GetType()).IsArray) {
                int l = ((System.Array)(e)).Length;
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] eitems = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[l];
                for (int i = 0; i < eitems.Length; i++) {
                    eitems[i] = ToExpression(((System.Array)(e)).GetValue(i), defaultInstance);
                }
                return eitems.Length == 1 ? ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression)(eitems[0])) : new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUplet(eitems);
            } else {
                System.Reflection.ConstructorInfo c = null;
                try {
                    c = defaultInstance.GetConstructor(new System.Type[] { e.GetType() });
                } catch (System.Exception e1) {
                    try {
                        c = defaultInstance.GetConstructor(new System.Type[] { typeof(object) });
                    } catch (System.Exception e2) {
                        throw new System.ArgumentException ("Could not cast " + e + " as Expression");
                    }
                }
                try {
                    return (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) c.Invoke(new object[] { e });
                } catch (System.Exception e1) {
                    throw new System.ArgumentException (e1.ToString());
                }
            }
        }

        public static Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ToLiteral(object @value) {
            return ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) (@value == null || !(@value is Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) ? ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression)(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledLiteral(@value, null))) : (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) @value));
        }

        public static Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ToVar(object @value) {
            return ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) (@value == null || !(@value is Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) ? ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression)(new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar((string) (@value)))) : (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) @value));
        }
    }
}
