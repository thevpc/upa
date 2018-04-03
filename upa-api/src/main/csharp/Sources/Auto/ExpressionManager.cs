/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
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

         Net.Vpc.Upa.Persistence.ResultMetaData CreateMetaData(Net.Vpc.Upa.Expressions.Expression baseExpression, Net.Vpc.Upa.Filters.FieldFilter fieldFilter);

         Net.Vpc.Upa.Expressions.FunctionExpression CreateFunctionExpression(string name, Net.Vpc.Upa.Expressions.Expression[] args);

         Net.Vpc.Upa.QLEvaluator CreateEvaluator();

         Net.Vpc.Upa.Expressions.Expression ParseExpression(string expression);

        /**
             * simplifies expression by evaluating all map vars in the expression.
             * simplifyExpression("a.id",{"a":{id:4,name:'example'}}) = Literal(4)
             * the expression it self may be modified while evaluation process.
             * Do copy ( expression.copy() ) the expression if one wants readonly acept
             * @param expression expression to simplify
             * @param vars map of available vars
             * @return simplified expression
             */
         Net.Vpc.Upa.Expressions.Expression SimplifyExpression(Net.Vpc.Upa.Expressions.Expression expression, System.Collections.Generic.IDictionary<string , object> vars);

         Net.Vpc.Upa.Expressions.Expression SimplifyExpression(string expression, System.Collections.Generic.IDictionary<string , object> vars);

        /**
             * parse all UserExpressions withing this expression
             * @param expression any expression
             * @return expression where all UserExpressions are parsed
             */
         Net.Vpc.Upa.Expressions.Expression ParseExpression(Net.Vpc.Upa.Expressions.Expression expression);

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
