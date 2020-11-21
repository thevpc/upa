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
    public class DateTruncExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileDateTrunc((Net.TheVpc.Upa.Expressions.DateTrunc) o, manager, declarations);
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDateTrunc CompileDateTrunc(Net.TheVpc.Upa.Expressions.DateTrunc v, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDateTrunc s = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledDateTrunc(v.GetDatePartType(), manager.TranslateAny(v.GetValue(), declarations));
            //        s.setDeclarationList(declarations);
            return s;
        }
    }
}
