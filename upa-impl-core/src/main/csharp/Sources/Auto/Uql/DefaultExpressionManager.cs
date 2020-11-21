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



namespace Net.TheVpc.Upa.Impl.Uql
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultExpressionManager : Net.TheVpc.Upa.ExpressionManager {

        private static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Uql.DefaultExpressionManager)).FullName);

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager translationManager;

        private Net.TheVpc.Upa.Impl.Uql.ExpressionValidationManager validationManager;

        private Net.TheVpc.Upa.Impl.Uql.ExpressionMetadataBuilder expressionMetadataBuilder;

        private System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.FunctionDefinition> qlFunctionMap = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.FunctionDefinition>();

        private Net.TheVpc.Upa.QLExpressionParser parser;

        public DefaultExpressionManager(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
            translationManager = new Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager(this, persistenceUnit);
            validationManager = new Net.TheVpc.Upa.Impl.Uql.ExpressionValidationManager(persistenceUnit);
            expressionMetadataBuilder = new Net.TheVpc.Upa.Impl.Uql.ExpressionMetadataBuilder(this, persistenceUnit);
            parser = persistenceUnit.GetFactory().CreateObject<Net.TheVpc.Upa.QLExpressionParser>(typeof(Net.TheVpc.Upa.QLExpressionParser));
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.ExpressionTranslationManager GetTranslationManager() {
            return translationManager;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.ExpressionValidationManager GetValidationManager() {
            return validationManager;
        }

        public virtual Net.TheVpc.Upa.Persistence.ResultMetaData CreateMetaData(Net.TheVpc.Upa.Expressions.Expression baseExpression, Net.TheVpc.Upa.Filters.FieldFilter fieldFilter) {
            return expressionMetadataBuilder.CreateResultMetaData(baseExpression, fieldFilter);
        }


        public virtual Net.TheVpc.Upa.Expressions.FunctionExpression CreateFunctionExpression(string name, Net.TheVpc.Upa.Expressions.Expression[] args) {
            return Net.TheVpc.Upa.Impl.Uql.Parser.Syntax.FunctionFactory.CreateFunction(name, new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(args));
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression ParseExpression(Net.TheVpc.Upa.Expressions.Expression expression) {
            if (expression is Net.TheVpc.Upa.Expressions.UserExpression) {
                Net.TheVpc.Upa.Expressions.UserExpression ucce = (Net.TheVpc.Upa.Expressions.UserExpression) expression;
                Net.TheVpc.Upa.Expressions.Expression expr = ParseExpression(ucce.GetExpression());
                expr.Visit(new Net.TheVpc.Upa.Impl.Uql.Util.UserExpressionParametersMatcherVisitor(ucce));
                return expr;
            } else {
                Net.TheVpc.Upa.Impl.Uql.Util.UserExpressionParserVisitor v = new Net.TheVpc.Upa.Impl.Uql.Util.UserExpressionParserVisitor(this);
                expression.Visit(v);
                return expression;
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression ParseExpression(string expression) {
            try {
                return parser.Parse(new System.IO.StringReader(expression));
            } catch (Net.TheVpc.Upa.Impl.Uql.Parser.Syntax.ParseException e) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to parse Expression : " + expression,e));
                throw e;
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.CompiledExpression CompileExpression(Net.TheVpc.Upa.Expressions.Expression expression, Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig config) {
            if (config == null) {
                config = new Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig();
            }
            Net.TheVpc.Upa.Expressions.CompiledExpression qe = translationManager.CompileExpression(expression, config);
            qe = CompileExpression(qe, config);
            return qe;
        }

        public virtual Net.TheVpc.Upa.Expressions.CompiledExpression CompileExpression(Net.TheVpc.Upa.Expressions.CompiledExpression expression, Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig config) {
            if (config == null) {
                config = new Net.TheVpc.Upa.Persistence.ExpressionCompilerConfig();
            }
            if (config.IsValidate() || config.IsExpandFields()) {
                expression = validationManager.ValidateExpression(expression, config);
            }
            return expression;
        }


        public virtual Net.TheVpc.Upa.FunctionDefinition AddFunction(string name, Net.TheVpc.Upa.Types.DataType type, Net.TheVpc.Upa.Function function) {
            if (name == null || function == null) {
                throw new System.NullReferenceException();
            }
            if (ContainsFunction(name)) {
                throw new System.ArgumentException ("Function already exists " + name);
            }
            Net.TheVpc.Upa.FunctionDefinition q = new Net.TheVpc.Upa.Impl.Uql.DefaultFunction(name, type, function);
            AddFunction(q);
            return q;
        }

        public virtual void AddFunction(Net.TheVpc.Upa.FunctionDefinition function) {
            string name = persistenceUnit.GetNamingStrategy().GetUniformValue(function.GetName());
            qlFunctionMap[name]=function;
        }

        public virtual void RemoveFunction(string name) {
            name = persistenceUnit.GetNamingStrategy().GetUniformValue(name);
            if (!qlFunctionMap.ContainsKey(name)) {
                throw new System.ArgumentException ("No Such Function " + name);
            }
            qlFunctionMap.Remove(name);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.FunctionDefinition> GetFunctions() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.FunctionDefinition>((qlFunctionMap).Values);
        }

        public virtual System.Collections.Generic.ISet<string> GetFunctionNames() {
            System.Collections.Generic.HashSet<string> keys = new System.Collections.Generic.HashSet<string>();
            foreach (Net.TheVpc.Upa.FunctionDefinition f in (qlFunctionMap).Values) {
                keys.Add(f.GetName());
            }
            return keys;
        }

        public virtual bool ContainsFunction(string name) {
            name = persistenceUnit.GetNamingStrategy().GetUniformValue(name);
            return qlFunctionMap.ContainsKey(name);
        }

        public virtual Net.TheVpc.Upa.FunctionDefinition GetFunction(string name) {
            name = persistenceUnit.GetNamingStrategy().GetUniformValue(name);
            Net.TheVpc.Upa.FunctionDefinition qlFunction = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.FunctionDefinition>(qlFunctionMap,name);
            if (qlFunction == null) {
                throw new System.ArgumentException ("No Such QLFunction " + name);
            }
            return qlFunction;
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression SimplifyExpression(Net.TheVpc.Upa.Expressions.Expression expression, System.Collections.Generic.IDictionary<string , object> vars) {
            Net.TheVpc.Upa.Expressions.Expression e = ParseExpression(expression);
            Net.TheVpc.Upa.Expressions.ExpressionTransformerResult e2 = e.Transform(new Net.TheVpc.Upa.Impl.Uql.Util.SimplifyVarsExpressionTransformer(GetPersistenceUnit(), vars));
            return CreateEvaluator().EvalObject(e2.GetExpression(), null);
        }


        public virtual Net.TheVpc.Upa.Expressions.Expression SimplifyExpression(string expression, System.Collections.Generic.IDictionary<string , object> vars) {
            return SimplifyExpression(ParseExpression(expression), vars);
        }


        public virtual Net.TheVpc.Upa.QLEvaluator CreateEvaluator() {
            return GetPersistenceUnit().GetFactory().CreateObject<Net.TheVpc.Upa.QLEvaluator>(typeof(Net.TheVpc.Upa.QLEvaluator));
        }
    }
}
