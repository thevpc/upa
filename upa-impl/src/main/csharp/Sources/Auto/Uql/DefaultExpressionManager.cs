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

        private System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.FunctionDefinition> qlFunctionMap = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.FunctionDefinition>();

        public DefaultExpressionManager(Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
            translationManager = new Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager(this, persistenceUnit);
            validationManager = new Net.Vpc.Upa.Impl.Uql.ExpressionValidationManager(persistenceUnit);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.ExpressionTranslationManager GetTranslationManager() {
            return translationManager;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.ExpressionValidationManager GetValidationManager() {
            return validationManager;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression ParseExpression(string expression) {
            Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParser p = new Net.Vpc.Upa.Impl.Uql.Parser.Syntax.UQLParser(new System.IO.StringReader(expression));
            try {
                return p.Any();
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
                validationManager.ValidateExpression(expression, config);
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
                throw new System.ArgumentException ("No Such QLFunction " + name);
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
    }
}
