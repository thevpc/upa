/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Expressions
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/17/12
     * Time: 2:56 AM
     * To change this template use File | Settings | File Templates.
     */
    public class ExpressionFactory {

        public static Net.TheVpc.Upa.Expressions.Expression ToExpression(object e, System.Type defaultInstance) {
            if (e == null) {
                return new Net.TheVpc.Upa.Expressions.Literal(null, null);
            } else if (e is Net.TheVpc.Upa.Expressions.Expression) {
                return (Net.TheVpc.Upa.Expressions.Expression) e;
            } else if ((e.GetType()).IsArray) {
                int l = ((System.Array)(e)).Length;
                Net.TheVpc.Upa.Expressions.Expression[] eitems = new Net.TheVpc.Upa.Expressions.Expression[l];
                for (int i = 0; i < eitems.Length; i++) {
                    eitems[i] = ToExpression(((System.Array)(e)).GetValue(i), defaultInstance);
                }
                return eitems.Length == 1 ? ((Net.TheVpc.Upa.Expressions.Expression)(eitems[0])) : new Net.TheVpc.Upa.Expressions.Uplet(eitems);
            } else {
                System.Reflection.ConstructorInfo c = null;
                try {
                    c = defaultInstance.GetConstructor(new System.Type[] { e.GetType() });
                } catch (System.Exception e1) {
                    try {
                        c = defaultInstance.GetConstructor(new System.Type[] { typeof(object) });
                    } catch (System.Exception e2) {
                        throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Could not cast " + e + " as Expression", e1);
                    }
                }
                try {
                    return (Net.TheVpc.Upa.Expressions.Expression) c.Invoke(new object[] { e });
                } catch (System.Exception e1) {
                    throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException(e1.ToString());
                }
            }
        }

        public static Net.TheVpc.Upa.Expressions.Expression ToLiteral(object @value) {
            return ((Net.TheVpc.Upa.Expressions.Expression) (@value == null || !(@value is Net.TheVpc.Upa.Expressions.Expression) ? ((Net.TheVpc.Upa.Expressions.Expression)(new Net.TheVpc.Upa.Expressions.Literal(@value, null))) : (Net.TheVpc.Upa.Expressions.Expression) @value));
        }

        public static Net.TheVpc.Upa.Expressions.Expression ToVar(object @value) {
            return ((Net.TheVpc.Upa.Expressions.Expression) (@value == null || !(@value is Net.TheVpc.Upa.Expressions.Expression) ? ((Net.TheVpc.Upa.Expressions.Expression)(new Net.TheVpc.Upa.Expressions.Var((string) (@value)))) : (Net.TheVpc.Upa.Expressions.Expression) @value));
        }
    }
}
