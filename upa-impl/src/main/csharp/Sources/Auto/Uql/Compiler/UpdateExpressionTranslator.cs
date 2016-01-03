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
    public class UpdateExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        private readonly Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer;

        public UpdateExpressionTranslator(Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager outer) {
            this.outer = outer;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager expressionTranslationManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileUpdate((Net.Vpc.Upa.Expressions.Update) o, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate CompileUpdate(Net.Vpc.Upa.Expressions.Update v, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate();
            s.Entity(v.GetEntity().GetName());
            Net.Vpc.Upa.Entity entity = outer.GetPersistenceUnit().GetEntity(v.GetEntity().GetName());
            for (int i = 0; i < v.CountFields(); i++) {
                Net.Vpc.Upa.Expressions.Var fvar = v.GetField(i);
                Net.Vpc.Upa.Expressions.Expression fvalue = v.GetFieldValue(i);
                s.Set(entity.GetField(fvar.GetName()), outer.CompileAny(fvalue, declarations));
            }
            s.Where(outer.CompileAny(v.GetCondition(), declarations));
            return s;
        }
    }
}
