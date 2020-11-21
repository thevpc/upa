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
    public class UpdateExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileUpdate((Net.TheVpc.Upa.Expressions.Update) o, manager, declarations);
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate CompileUpdate(Net.TheVpc.Upa.Expressions.Update v, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate s = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledUpdate();
            s.Entity(v.GetEntity().GetName());
            Net.TheVpc.Upa.Entity entity = manager.GetPersistenceUnit().GetEntity(v.GetEntity().GetName());
            for (int i = 0; i < v.CountFields(); i++) {
                Net.TheVpc.Upa.Expressions.Var fvar = v.GetField(i);
                Net.TheVpc.Upa.Expressions.Expression fvalue = v.GetFieldValue(i);
                s.Set(entity.GetField(fvar.GetName()), manager.TranslateAny(fvalue, declarations));
            }
            s.Where(manager.TranslateAny(v.GetCondition(), declarations));
            return s;
        }
    }
}
