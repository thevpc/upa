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
    public class InsertSelectionExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileInsertSelection((Net.Vpc.Upa.Expressions.InsertSelection) o, manager, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection CompileInsertSelection(Net.Vpc.Upa.Expressions.InsertSelection v, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection();
            s.Into(v.GetEntity().GetName());
            for (int i = 0; i < v.CountFields(); i++) {
                Net.Vpc.Upa.Expressions.Var fvar = v.GetField(i);
                s.Field(fvar.GetName());
            }
            s.From((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) manager.TranslateAny(v.GetSelection(), declarations));
            return s;
        }
    }
}
