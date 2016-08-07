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



namespace Net.Vpc.Upa.Impl.Uql.Parser
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/26/12 3:13 PM
     */
    public abstract class FunctionSQLProvider : Net.Vpc.Upa.Impl.Persistence.SQLProvider {

        private System.Type expressionType;

        protected internal FunctionSQLProvider(System.Type expressionType) {
            this.expressionType = expressionType;
        }


        public virtual string GetSQL(object o, Net.Vpc.Upa.Persistence.EntityExecutionContext qlContext, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction cc = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction) o;
            return Simplify(qlContext, sqlManager, declarations, cc.GetArguments());
        }

        public virtual string Simplify(Net.Vpc.Upa.Persistence.EntityExecutionContext ctx, Net.Vpc.Upa.Impl.Persistence.SQLManager sqlManager, Net.Vpc.Upa.Impl.Uql.ExpressionDeclarationList declarations, params Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression [] @params) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            string[] p = new string[@params.Length];
            for (int i = 0; i < p.Length; i++) {
                p[i] = sqlManager.GetSQL(@params[i], ctx, declarations);
            }
            return Simplify((GetExpressionType()).Name, p, null);
        }


        public virtual System.Type GetExpressionType() {
            return expressionType;
        }

        public virtual void CheckFunctionSignature(int requiredCount, string[] @params) /* throws System.ArgumentException  */  {
            if (requiredCount != @params.Length) {
                Error("requires " + requiredCount + " params", @params);
            }
        }

        public virtual void CheckFunctionSignature(string[] paramNames, string[] @params) /* throws System.ArgumentException  */  {
            CheckFunctionSignature(paramNames.Length, @params);
        }

        public virtual string Error(string msg, string[] @params) /* throws System.ArgumentException  */  {
            throw new System.ArgumentException ("Error in function '" + (GetExpressionType()).Name + "' params\n" + msg + "\n.Error near " + (GetExpressionType()).Name + "(" + System.Convert.ToString(@params) + ")");
        }

        /**
             * @param functionName
             * @param params       may be null if function was called without parentheses
             * @param context
             * @return
             */
        public virtual string Simplify(string functionName, string[] @params, System.Collections.Generic.IDictionary<string , object> context) {
            throw new System.ArgumentException ("Never");
        }

        private static string Format(object[] @value, string begin, string separator, string end, string nullValue) {
            if (@value == null) {
                return nullValue;
            }
            System.Text.StringBuilder s = new System.Text.StringBuilder(begin);
            for (int i = 0; i < @value.Length; i++) {
                if (i > 0) {
                    s.Append(separator);
                }
                s.Append(System.Convert.ToString(@value[i]));
            }
            s.Append(end);
            return s.ToString();
        }
    }
}
