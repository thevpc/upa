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



namespace Net.Vpc.Upa.Impl.Persistence.Shared
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/15/12 Time: 11:46 PM To change
     * this template use File | Settings | File Templates.
     */
    public class PlusExpressionSQLProvider : Net.Vpc.Upa.Impl.Persistence.Shared.AbstractSQLProvider {

        public PlusExpressionSQLProvider()  : base(typeof(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledPlus)){

        }


        public override string GetSQL(object oo, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledPlus o = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledPlus) oo;
            System.Type t1 = o.GetLeft().GetTypeTransform().GetTargetType().GetPlatformType();
            System.Type t2 = o.GetRight().GetTypeTransform().GetTargetType().GetPlatformType();
            bool s0 = o.GetTypeTransform().GetTargetType().GetPlatformType().Equals(typeof(string));
            bool s1 = t1.Equals(typeof(string));
            bool s2 = t2.Equals(typeof(string));
            if (s0 || s1 || s2) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression c1 = o.GetLeft().Copy();
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression c2 = o.GetRight().Copy();
                c1.SetParentExpression(null);
                c2.SetParentExpression(null);
                if (!s1) {
                    if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsAnyInteger(t1)) {
                        c1 = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(c1.Copy());
                    } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsAnyFloat(t1)) {
                        c1 = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(c1.Copy());
                    } else {
                        throw new System.ArgumentException ("Unsupported");
                    }
                }
                if (!s2) {
                    if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsAnyInteger(t2)) {
                        c2 = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(c2.Copy());
                    } else if (Net.Vpc.Upa.Impl.Util.PlatformUtils.IsAnyFloat(t2)) {
                        c2 = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledI2V(c2.Copy());
                    } else {
                        throw new System.ArgumentException ("Unsupported");
                    }
                }
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat cc = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledConcat(c1, c2);
                return sqlManager.GetSQL(cc, qlContext, declarations);
            }
            string leftValue = o.GetLeft() != null ? sqlManager.GetSQL(o.GetLeft(), qlContext, declarations) : "NULL";
            string rightValue = o.GetRight() != null ? sqlManager.GetSQL(o.GetRight(), qlContext, declarations) : "NULL";
            string s = null;
            s = leftValue + " + " + rightValue;
            return "(" + s + ")";
        }
    }
}
