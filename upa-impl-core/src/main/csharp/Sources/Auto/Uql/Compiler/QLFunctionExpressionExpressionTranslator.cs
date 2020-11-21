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
    public class QLFunctionExpressionExpressionTranslator : Net.TheVpc.Upa.Impl.Uql.ExpressionTranslator {

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression TranslateExpression(object o, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            return CompileQLFunctionExpression((Net.TheVpc.Upa.Impl.Uql.QLFunctionExpression) o, manager, declarations);
        }

        protected internal virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression CompileQLFunctionExpression(Net.TheVpc.Upa.Impl.Uql.QLFunctionExpression v, Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager manager, Net.TheVpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) {
            if (v == null) {
                return null;
            }
            Net.TheVpc.Upa.FunctionDefinition h = manager.GetPersistenceUnit().GetExpressionManager().GetFunction(v.GetName());
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression s = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledQLFunctionExpression(v.GetName(), manager.TranslateArray(v.GetArguments(), declarations), new Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform(h.GetDataType()), h.GetFunction());
            //        s.setDeclarationList(declarations);
            return s;
        }
    }
}
