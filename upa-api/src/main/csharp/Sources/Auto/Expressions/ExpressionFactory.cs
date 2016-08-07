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



namespace Net.Vpc.Upa.Expressions
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/17/12
     * Time: 2:56 AM
     * To change this template use File | Settings | File Templates.
     */
    public class ExpressionFactory {

        public static Net.Vpc.Upa.Expressions.Expression ToExpression(object e, System.Type defaultInstance) {
            if (e == null) {
                return new Net.Vpc.Upa.Expressions.Literal(null, null);
            } else if (e is Net.Vpc.Upa.Expressions.Expression) {
                return (Net.Vpc.Upa.Expressions.Expression) e;
            } else if ((e.GetType()).IsArray) {
                int l = ((System.Array)(e)).Length;
                Net.Vpc.Upa.Expressions.Expression[] eitems = new Net.Vpc.Upa.Expressions.Expression[l];
                for (int i = 0; i < eitems.Length; i++) {
                    eitems[i] = ToExpression(((System.Array)(e)).GetValue(i), defaultInstance);
                }
                return eitems.Length == 1 ? ((Net.Vpc.Upa.Expressions.Expression)(eitems[0])) : new Net.Vpc.Upa.Expressions.Uplet(eitems);
            } else {
                System.Reflection.ConstructorInfo c = null;
                try {
                    c = defaultInstance.GetConstructor(new System.Type[] { e.GetType() });
                } catch (System.Exception e1) {
                    try {
                        c = defaultInstance.GetConstructor(new System.Type[] { typeof(object) });
                    } catch (System.Exception e2) {
                        throw new System.ArgumentException ("Could not cast " + e + " as Expression", e1);
                    }
                }
                try {
                    return (Net.Vpc.Upa.Expressions.Expression) c.Invoke(new object[] { e });
                } catch (System.Exception e1) {
                    throw new System.ArgumentException (e1.ToString());
                }
            }
        }

        public static Net.Vpc.Upa.Expressions.Expression ToLiteral(object @value) {
            return ((Net.Vpc.Upa.Expressions.Expression) (@value == null || !(@value is Net.Vpc.Upa.Expressions.Expression) ? ((Net.Vpc.Upa.Expressions.Expression)(new Net.Vpc.Upa.Expressions.Literal(@value, null))) : (Net.Vpc.Upa.Expressions.Expression) @value));
        }

        public static Net.Vpc.Upa.Expressions.Expression ToVar(object @value) {
            return ((Net.Vpc.Upa.Expressions.Expression) (@value == null || !(@value is Net.Vpc.Upa.Expressions.Expression) ? ((Net.Vpc.Upa.Expressions.Expression)(new Net.Vpc.Upa.Expressions.Var((string) (@value)))) : (Net.Vpc.Upa.Expressions.Expression) @value));
        }
    }
}
