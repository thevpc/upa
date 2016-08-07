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
    public class CurrentTimestampExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileCurrentTimestamp((Net.Vpc.Upa.Expressions.CurrentTimestamp) o, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCurrentTimestamp CompileCurrentTimestamp(Net.Vpc.Upa.Expressions.CurrentTimestamp v, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCurrentTimestamp s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledCurrentTimestamp();
            //        s.setDeclarationList(declarations);
            return s;
        }
    }
}
