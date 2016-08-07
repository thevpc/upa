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



namespace Net.Vpc.Upa.Impl.Uql
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultExpressionManager : Net.Vpc.Upa.ExpressionManager {

        private static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Uql.DefaultExpressionManager)).FullName);

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager translationManager;

        private Net.Vpc.Upa.Impl.Uql.ExpressionValidationManager validationManager;

        private Net.Vpc.Upa.Impl.Uql.ExpressionMetadataBuilder expressionMetadataBuilder;

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.FunctionDefinition> qlFunctionMap = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.FunctionDefinition>();

        private Net.Vpc.Upa.QLExpressionParser parser;

        public DefaultExpressionManager(Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
            translationManager = new Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager(this, persistenceUnit);
            validationManager = new Net.Vpc.Upa.Impl.Uql.ExpressionValidationManager(persistenceUnit);
            expressionMetadataBuilder = new Net.Vpc.Upa.Impl.Uql.ExpressionMetadataBuilder(this, persistenceUnit);
            parser = persistenceUnit.GetFactory().CreateObject<Net.Vpc.Upa.QLExpressionParser>(typeof(Net.Vpc.Upa.QLExpressionParser));
        }

        public virtual Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager GetTranslationManager() {
            return translationManager;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.ExpressionValidationManager GetValidationManager() {
            return validationManager;
        }

        public virtual Net.Vpc.Upa.Persistence.ResultMetaData CreateMetaData(Net.Vpc.Upa.Expressions.Expression baseExpression, Net.Vpc.Upa.Filters.FieldFilter fieldFilter) {
            return expressionMetadataBuilder.CreateResultMetaData(baseExpression, fieldFilter);
        }


        public virtual Net.Vpc.Upa.Expressions.FunctionExpression CreateFunctionExpression(string name, Net.Vpc.Upa.Expressions.Expression[] args) {
            return Net.Vpc.Upa.Impl.Uql.Parser.Syntax.FunctionFactory.CreateFunction(name, new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(args));
        }

        public virtual Net.Vpc.Upa.Expressions.Expression ParseExpression(Net.Vpc.Upa.Expressions.Expression expression) {
            if (expression is Net.Vpc.Upa.Expressions.UserExpression) {
                Net.Vpc.Upa.Expressions.UserExpression ucce = (Net.Vpc.Upa.Expressions.UserExpression) expression;
                Net.Vpc.Upa.Expressions.Expression expr = ParseExpression(ucce.GetExpression());
                expr.Visit(new Net.Vpc.Upa.Impl.Uql.Util.UserExpressionParametersMatcherVisitor(ucce));
                return expr;
            } else {
                Net.Vpc.Upa.Impl.Uql.Util.UserExpressionParserVisitor v = new Net.Vpc.Upa.Impl.Uql.Util.UserExpressionParserVisitor(this);
                expression.Visit(v);
                return expression;
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Expression ParseExpression(string expression) {
            try {
                return parser.Parse(new System.IO.StringReader(expression));
            } catch (Net.Vpc.Upa.Impl.Uql.Parser.Syntax.ParseException e) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to parse Expression : " + expression,e));
                throw e;
            }
        }

        public virtual Net.Vpc.Upa.Expressions.CompiledExpression CompileExpression(Net.Vpc.Upa.Expressions.Expression expression, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            if (config == null) {
                config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
            }
            Net.Vpc.Upa.Expressions.CompiledExpression qe = translationManager.CompileExpression(expression, config);
            qe = CompileExpression(qe, config);
            return qe;
        }

        public virtual Net.Vpc.Upa.Expressions.CompiledExpression CompileExpression(Net.Vpc.Upa.Expressions.CompiledExpression expression, Net.Vpc.Upa.Persistence.ExpressionCompilerConfig config) {
            if (config == null) {
                config = new Net.Vpc.Upa.Persistence.ExpressionCompilerConfig();
            }
            if (config.IsValidate() || config.IsExpandFields()) {
                expression = validationManager.ValidateExpression(expression, config);
            }
            return expression;
        }


        public virtual Net.Vpc.Upa.FunctionDefinition AddFunction(string name, Net.Vpc.Upa.Types.DataType type, Net.Vpc.Upa.Function function) {
            if (name == null || function == null) {
                throw new System.NullReferenceException();
            }
            if (ContainsFunction(name)) {
                throw new System.ArgumentException ("Function already exists " + name);
            }
            Net.Vpc.Upa.FunctionDefinition q = new Net.Vpc.Upa.Impl.Uql.DefaultFunction(name, type, function);
            AddFunction(q);
            return q;
        }

        public virtual void AddFunction(Net.Vpc.Upa.FunctionDefinition function) {
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

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.FunctionDefinition> GetFunctions() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.FunctionDefinition>((qlFunctionMap).Values);
        }

        public virtual System.Collections.Generic.ISet<string> GetFunctionNames() {
            System.Collections.Generic.HashSet<string> keys = new System.Collections.Generic.HashSet<string>();
            foreach (Net.Vpc.Upa.FunctionDefinition f in (qlFunctionMap).Values) {
                keys.Add(f.GetName());
            }
            return keys;
        }

        public virtual bool ContainsFunction(string name) {
            name = persistenceUnit.GetNamingStrategy().GetUniformValue(name);
            return qlFunctionMap.ContainsKey(name);
        }

        public virtual Net.Vpc.Upa.FunctionDefinition GetFunction(string name) {
            name = persistenceUnit.GetNamingStrategy().GetUniformValue(name);
            Net.Vpc.Upa.FunctionDefinition qlFunction = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.FunctionDefinition>(qlFunctionMap,name);
            if (qlFunction == null) {
                throw new System.ArgumentException ("No Such QLFunction " + name);
            }
            return qlFunction;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }


        public virtual Net.Vpc.Upa.Expressions.Expression SimplifyExpression(Net.Vpc.Upa.Expressions.Expression expression, System.Collections.Generic.IDictionary<string , object> vars) {
            Net.Vpc.Upa.Expressions.Expression e = ParseExpression(expression);
            Net.Vpc.Upa.Expressions.ExpressionTransformerResult e2 = e.Transform(new Net.Vpc.Upa.Impl.Uql.Util.SimplifyVarsExpressionTransformer(GetPersistenceUnit(), vars));
            return CreateEvaluator().EvalObject(e2.GetExpression(), null);
        }


        public virtual Net.Vpc.Upa.Expressions.Expression SimplifyExpression(string expression, System.Collections.Generic.IDictionary<string , object> vars) {
            return SimplifyExpression(ParseExpression(expression), vars);
        }


        public virtual Net.Vpc.Upa.QLEvaluator CreateEvaluator() {
            return GetPersistenceUnit().GetFactory().CreateObject<Net.Vpc.Upa.QLEvaluator>(typeof(Net.Vpc.Upa.QLEvaluator));
        }
    }
}
