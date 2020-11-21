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



namespace Net.TheVpc.Upa.Impl.Uql.Compiler
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class AvgExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileAvg((Net.TheVpc.Upa.Expressions.Avg) o, manager, declarations);
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg CompileAvg(Net.TheVpc.Upa.Expressions.Avg v, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg s = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledAvg(manager.TranslateAny(v.GetArgument(0), declarations));
            //        s.setDeclarationList(declarations);
            return s;
        }
    }
}
