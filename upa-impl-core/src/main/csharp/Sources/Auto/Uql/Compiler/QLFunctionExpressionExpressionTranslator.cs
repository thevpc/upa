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
    public class QLFunctionExpressionExpressionTranslator : Net.Vpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileQLFunctionExpression((Net.Vpc.Upa.Impl.Uql.QLFunctionExpression) o, manager, declarations);
        }

        protected internal virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression CompileQLFunctionExpression(Net.Vpc.Upa.Impl.Uql.QLFunctionExpression v, Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.Vpc.Upa.FunctionDefinition h = manager.GetPersistenceUnit().GetExpressionManager().GetFunction(v.GetName());
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression s = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression(v.GetName(), manager.TranslateArray(v.GetArguments(), declarations), new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(h.GetDataType()), h.GetFunction());
            //        s.setDeclarationList(declarations);
            return s;
        }
    }
}
