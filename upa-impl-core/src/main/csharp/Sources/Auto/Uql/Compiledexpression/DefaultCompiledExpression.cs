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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    public interface DefaultCompiledExpression : System.ICloneable, Net.TheVpc.Upa.Expressions.CompiledExpression {

         bool IsValid();

         Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions();

         Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetParentExpression();

         void SetParentExpression(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression parent);

         void SetSubExpression(int index, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression);

         Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy();

         string GetDescription();

         Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression SetDescription(string newDesc);

         Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform();

         Net.TheVpc.Upa.Types.DataTypeTransform GetEffectiveDataType();

         void SetTypeTransform(Net.TheVpc.Upa.Types.DataTypeTransform type);

         Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression SetClientProperty(string name, object @value);

         Net.TheVpc.Upa.Properties GetClientParameters();

         object GetClientProperty(string name);

         Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ReplaceExpressions(Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter filter, Net.TheVpc.Upa.Impl.Uql.CompiledExpressionReplacer replacer);

          System.Collections.Generic.IList<T> FindExpressionsList<T>(Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter filter) where  T : Net.TheVpc.Upa.Expressions.CompiledExpression;

          T FindFirstExpression<T>(Net.TheVpc.Upa.Impl.Uql.CompiledExpressionFilter filter) where  T : Net.TheVpc.Upa.Expressions.CompiledExpression;

        /**
             * @param visitor
             * @return true if should continue visiting false otherwise
             */
         bool Visit(Net.TheVpc.Upa.Impl.Uql.CompiledExpressionVisitor visitor);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.ExpressionDeclaration> GetExportedDeclarations();

         void ExportDeclaration(string name, Net.TheVpc.Upa.Impl.Uql.DecObjectType type, object referrerName, object referrerParentId);

         System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Uql.ExpressionDeclaration> GetDeclarations(string alias);

         Net.TheVpc.Upa.Impl.Uql.ExpressionDeclaration GetDeclaration(string name);

         void UnsetParent();

         void Validate();
    }
}
