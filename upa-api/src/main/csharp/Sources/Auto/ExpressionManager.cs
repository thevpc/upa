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



namespace Net.TheVpc.Upa
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public interface ExpressionManager {

         Net.TheVpc.Upa.Persistence.ResultMetaData CreateMetaData(Net.TheVpc.Upa.Expressions.Expression baseExpression, Net.TheVpc.Upa.Filters.FieldFilter fieldFilter);

         Net.TheVpc.Upa.Expressions.FunctionExpression CreateFunctionExpression(string name, Net.TheVpc.Upa.Expressions.Expression[] args);

         Net.TheVpc.Upa.QLEvaluator CreateEvaluator();

         Net.TheVpc.Upa.Expressions.Expression ParseExpression(string expression);

        /**
             * simplifies expression by evaluating all map vars in the expression.
             * simplifyExpression("a.id",{"a":{id:4,name:'example'}}) = Literal(4)
             * the expression it self may be modified while evaluation process.
             * Do copy ( expression.copy() ) the expression if one wants readonly acept
             * @param expression expression to simplify
             * @param vars map of available vars
             * @return simplified expression
             */
         Net.TheVpc.Upa.Expressions.Expression SimplifyExpression(Net.TheVpc.Upa.Expressions.Expression expression, System.Collections.Generic.IDictionary<string , object> vars);

         Net.TheVpc.Upa.Expressions.Expression SimplifyExpression(string expression, System.Collections.Generic.IDictionary<string , object> vars);

        /**
             * parse all UserExpressions withing this expression
             * @param expression any expression
             * @return expression where all UserExpressions are parsed
             */
         Net.TheVpc.Upa.Expressions.Expression ParseExpression(Net.TheVpc.Upa.Expressions.Expression expression);

         Net.TheVpc.Upa.Expressions.CompiledExpression CompileExpression(Net.TheVpc.Upa.Expressions.Expression expression, Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig config);

         Net.TheVpc.Upa.Expressions.CompiledExpression CompileExpression(Net.TheVpc.Upa.Expressions.CompiledExpression expression, Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig config);

         Net.TheVpc.Upa.FunctionDefinition AddFunction(string name, Net.TheVpc.Upa.Types.DataType type, Net.TheVpc.Upa.Function function);

         void RemoveFunction(string name);

         System.Collections.Generic.IList<Net.TheVpc.Upa.FunctionDefinition> GetFunctions();

         System.Collections.Generic.ISet<string> GetFunctionNames();

         bool ContainsFunction(string name);

         Net.TheVpc.Upa.FunctionDefinition GetFunction(string name);
    }
}
