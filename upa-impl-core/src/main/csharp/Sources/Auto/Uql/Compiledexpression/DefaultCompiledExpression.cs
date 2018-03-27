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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{


    public interface DefaultCompiledExpression : System.ICloneable, Net.Vpc.Upa.Expressions.CompiledExpression {

         bool IsValid();

         Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions();

         Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetParentExpression();

         void SetParentExpression(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression parent);

         void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression);

         Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy();

         string GetDescription();

         Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression SetDescription(string newDesc);

         Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform();

         Net.Vpc.Upa.Types.DataTypeTransform GetEffectiveDataType();

         void SetTypeTransform(Net.Vpc.Upa.Types.DataTypeTransform type);

         Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression SetClientProperty(string name, object @value);

         Net.Vpc.Upa.Properties GetClientParameters();

         object GetClientProperty(string name);

         Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ReplaceExpressions(Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter filter, Net.Vpc.Upa.Impl.Uql.CompiledExpressionReplacer replacer);

          System.Collections.Generic.IList<T> FindExpressionsList<T>(Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter filter) where  T : Net.Vpc.Upa.Expressions.CompiledExpression;

          T FindFirstExpression<T>(Net.Vpc.Upa.Impl.Uql.CompiledExpressionFilter filter) where  T : Net.Vpc.Upa.Expressions.CompiledExpression;

        /**
             * @param visitor
             * @return true if should continue visiting false otherwise
             */
         bool Visit(Net.Vpc.Upa.Impl.Uql.CompiledExpressionVisitor visitor);

         System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> GetExportedDeclarations();

         void ExportDeclaration(string name, Net.Vpc.Upa.Impl.Uql.DecObjectType type, object referrerName, object referrerParentId);

         System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration> GetDeclarations(string alias);

         Net.Vpc.Upa.Impl.Uql.ExpressionDeclaration GetDeclaration(string name);

         void UnsetParent();

         void Validate();
    }
}
