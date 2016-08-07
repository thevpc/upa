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



namespace Net.Vpc.Upa.Impl.Uql.Compiler
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class InsertExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileInsert((Net.Vpc.Upa.Expressions.Insert) o, manager, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert CompileInsert(Net.Vpc.Upa.Expressions.Insert v, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert();
            s.Into(v.GetEntity().GetName());
            for (int i = 0; i < v.CountFields(); i++) {
                Net.Vpc.Upa.Expressions.Var fvar = v.GetField(i);
                Net.Vpc.Upa.Expressions.Expression fvalue = v.GetFieldValue(i);
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression vv = manager.TranslateAny(fvalue, declarations);
                s.Set(fvar.GetName(), vv);
            }
            return s;
        }
    }
}
