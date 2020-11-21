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
    public class InsertExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileInsert((Net.TheVpc.Upa.Expressions.Insert) o, manager, declarations);
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert CompileInsert(Net.TheVpc.Upa.Expressions.Insert v, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert s = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledInsert();
            s.Into(v.GetEntity().GetName());
            for (int i = 0; i < v.CountFields(); i++) {
                Net.TheVpc.Upa.Expressions.Var fvar = v.GetField(i);
                Net.TheVpc.Upa.Expressions.Expression fvalue = v.GetFieldValue(i);
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression vv = manager.TranslateAny(fvalue, declarations);
                s.Set(fvar.GetName(), vv);
            }
            return s;
        }
    }
}
