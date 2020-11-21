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
    public class InsertSelectionExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileInsertSelection((Net.TheVpc.Upa.Expressions.InsertSelection) o, manager, declarations);
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection CompileInsertSelection(Net.TheVpc.Upa.Expressions.InsertSelection v, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection s = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsertSelection();
            s.Into(v.GetEntity().GetName());
            for (int i = 0; i < v.CountFields(); i++) {
                Net.TheVpc.Upa.Expressions.Var fvar = v.GetField(i);
                s.Field(fvar.GetName());
            }
            s.From((Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQueryStatement) manager.TranslateAny(v.GetSelection(), declarations));
            return s;
        }
    }
}
