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



namespace Net.Vpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface ExpressionManager {

         Net.Vpc.Upa.Expressions.Expression ParseExpression(string expression);

         Net.Vpc.Upa.Expressions.CompiledExpression CompileExpression(Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config);

         Net.Vpc.Upa.Expressions.CompiledExpression CompileExpression(Net.Vpc.Upa.Expressions.CompiledExpression expression, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config);

         Net.Vpc.Upa.FunctionDefinition AddFunction(string name, Net.Vpc.Upa.Types.DataType type, Net.Vpc.Upa.Function function);

         void RemoveFunction(string name);

         System.Collections.Generic.IList<Net.Vpc.Upa.FunctionDefinition> GetFunctions();

         System.Collections.Generic.ISet<string> GetFunctionNames();

         bool ContainsFunction(string name);

         Net.Vpc.Upa.FunctionDefinition GetFunction(string name);
    }
}
