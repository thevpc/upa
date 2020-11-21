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
    public class DateDiffExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileDateDiff((Net.TheVpc.Upa.Expressions.DateDiff) o, manager, declarations);
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDateDiff CompileDateDiff(Net.TheVpc.Upa.Expressions.DateDiff v, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDateDiff s = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDateDiff(v.GetDatePartType(), manager.TranslateAny(v.GetStart(), declarations), manager.TranslateAny(v.GetEnd(), declarations));
            //        s.setDeclarationList(declarations);
            return s;
        }
    }
}
