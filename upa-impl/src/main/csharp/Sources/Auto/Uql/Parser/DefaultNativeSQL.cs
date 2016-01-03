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


    public class DefaultNativeSQL : Net.Vpc.Upa.Impl.Persistence.NativeSQL {

        internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Uql.Parser.DefaultNativeSQL)).FullName);

        private System.Collections.Generic.List<Net.Vpc.Upa.Impl.Persistence.NativeStatement> statements;

        private string query;

        private Net.Vpc.Upa.Persistence.UConnection connection;

        private Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager;

        private Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore;

        private Net.Vpc.Upa.Impl.Persistence.NativeStatementType type;

        private string currentQuery;

        private string currentQueryInfo;

        private System.Collections.Generic.Dictionary<string , object> execVars;

        private System.Collections.Generic.Dictionary<string , string> parameters;

        private object returnValue;

        private int currentStatementIndex;

        private string errorTrace;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Param> queryParameters;

        private Net.Vpc.Upa.Impl.Persistence.NativeField[] fields;

        private bool updatable;


        public virtual string GetQuery() {
            return query;
        }


        public virtual void SetQuery(string query) {
            this.query = query;
        }

        public DefaultNativeSQL(Net.Vpc.Upa.Impl.Persistence.NativeStatementType type) {
            statements = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Persistence.NativeStatement>();
            this.type = type;
            execVars = new System.Collections.Generic.Dictionary<string , object>();
            parameters = new System.Collections.Generic.Dictionary<string , string>();
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.NativeStatementType GetStatementType() {
            return type;
        }


        public virtual void SetStatementType(Net.Vpc.Upa.Impl.Persistence.NativeStatementType type) {
            this.type = type;
        }


        public virtual int Size() {
            return (statements).Count;
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.NativeStatement GetStatement(int i) {
            return statements[i];
        }


        public virtual void AddNativeStatement(Net.Vpc.Upa.Impl.Persistence.NativeStatement s) {
            statements.Add(s);
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("BEGIN NATIVE_SQL");
            sb.Append("\n");
            sb.Append("# ").Append((statements).Count).Append(" statement(s).");
            sb.Append("\n");
            for (int i = 0; i < (statements).Count; i++) {
                if (i > 0) {
                    sb.Append("\n");
                }
                sb.Append(" ");
                sb.Append(statements[i].ToString());
                sb.Append(';');
            }
            sb.Append("\n");
            sb.Append("parameters=").Append(parameters);
            sb.Append("\n");
            sb.Append("END NATIVE_SQL");
            return sb.ToString();
        }

        public virtual void Dispose() {
            try {
                for (int i = (statements).Count - 1; i >= 0; i--) {
                    (statements[i]).Dispose();
                }
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("NativeException"));
            }
        }


        public virtual string GetErrorTrace() {
            return errorTrace;
        }


        public virtual int GetCurrentStatementIndex() {
            return currentStatementIndex;
        }


        public virtual int ExecuteUpdate() /* throws System.Exception */  {
            Execute();
            return GetResultCount();
        }


        public virtual Net.Vpc.Upa.Persistence.QueryResult ExecuteQuery() /* throws System.Exception */  {
            Execute();
            return GetQueryResult();
        }

        public virtual void Execute() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        if (isCheckSecurity()) {
            //            getShield().checkLoad();
            //        }
            string logString = null;
            try {
                errorTrace = null;
                this.currentStatementIndex = 0;
                int sqlsize = Size();
                switch(GetStatementType()) {
                    case Net.Vpc.Upa.Impl.Persistence.NativeStatementType.SELECT:
                        {
                            if (sqlsize > 1) {
                                logString = "[size=" + sqlsize + "] " + GetQuery();
                            } else {
                                logString = GetQuery();
                            }
                            break;
                        }
                    case Net.Vpc.Upa.Impl.Persistence.NativeStatementType.UPDATE:
                        {
                            if (sqlsize > 1) {
                                logString = "[size=" + sqlsize + "] " + GetQuery();
                            } else {
                                logString = GetQuery();
                            }
                            break;
                        }
                    default:
                        {
                            throw new System.Exception("WouldNeverBeThrownException");
                        }
                }
                //                    if(sqlsize>1){
                //                        logString = "[size=" + sqlsize + "] " + nativeSQL.getQuery();
                //                    }else{
                //                        logString = nativeSQL.getQuery();
                //                    }
                //
                //                    Log.log(DatabaseAdapter.DB_EXEC_LOG, logString);
                //                    break;
                int currentStatementIndex = 0;
                for (currentStatementIndex = 0; currentStatementIndex < sqlsize; currentStatementIndex++) {
                    Net.Vpc.Upa.Impl.Persistence.NativeStatement stm = GetStatement(currentStatementIndex);
                    stm.Execute(this);
                }
            } catch (System.Exception e) {
                errorTrace = "--ERROR-EXEC--" + "\n" + "        full query =" + GetQuery() + "\n" + "   statement index =" + GetCurrentStatementIndex() + "\n" + "         statement =" + GetCurrentStatement() + "\n" + "             query =" + GetCurrentQuery() + "\n" + " execution-context =" + this + "\n" + "         exception =" + e + "\n" + "        stacktrace =" + "\n";
                //            Log.log(PersistenceUnitManager.DB_ERROR_LOG,errorTrace);
                throw new Net.Vpc.Upa.Exceptions.UPAException(e, new Net.Vpc.Upa.Types.I18NString("NativeException"), errorTrace);
            } finally {
                //            if (errorTrace == null){
                //                switch (nativeSQL.getDataType()) {
                //                    case 2: // '\002'
                //                        Log.log(DatabaseAdapter.DB_UPDATE_LOG,"[COUNT=?] " + getResultCount());
                //                        break;
                //                }
                //            }
                Dispose();
            }
        }


        public virtual string GetCurrentQuery() {
            return currentQuery;
        }


        public virtual void SetCurrentQuery(string currentQuery) {
            this.currentQuery = currentQuery;
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.NativeStatement GetCurrentStatement() {
            return GetStatement(GetCurrentStatementIndex());
        }


        public virtual void SetQueryResult(Net.Vpc.Upa.Persistence.QueryResult r) {
            returnValue = r;
        }


        public virtual void SetResultCount(int r) {
            returnValue = r;
        }

        public virtual Net.Vpc.Upa.Persistence.QueryResult GetQueryResult() {
            return (Net.Vpc.Upa.Persistence.QueryResult) returnValue;
        }

        public virtual int GetResultCount() {
            return ((int?) returnValue).Value;
        }


        public virtual Net.Vpc.Upa.Persistence.PersistenceStore GetPersistenceManager() {
            return persistenceStore;
        }


        public virtual object GetVar(string varName) {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(execVars,varName);
        }


        public virtual void SetVar(string varName, object @value) {
            execVars[varName]=@value;
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetVars() {
            return execVars;
        }


        public virtual string GetParameter(string paramName) {
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,string>(parameters,paramName);
        }


        public virtual void SetParameter(string paramName, string @value) {
            parameters[paramName]=@value;
        }


        public virtual System.Collections.Generic.IDictionary<string , string> GetParameters() {
            return parameters;
        }


        public virtual void SetPersistenceStore(Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore) {
            this.persistenceStore = persistenceStore;
        }


        public virtual string GetCurrentQueryInfo() {
            return currentQueryInfo;
        }


        public virtual void SetCurrentQueryInfo(string currentQueryInfo) {
            this.currentQueryInfo = currentQueryInfo;
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Param> GetQueryParameters() {
            return queryParameters;
        }


        public virtual void SetQueryParameters(System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Param> queryParameters) {
            this.queryParameters = queryParameters;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.NativeField[] GetFields() {
            return fields;
        }

        public virtual void SetFields(Net.Vpc.Upa.Impl.Persistence.NativeField[] fields) {
            this.fields = fields;
        }


        public virtual Net.Vpc.Upa.Persistence.UConnection GetConnection() {
            return connection;
        }


        public virtual void SetConnection(Net.Vpc.Upa.Persistence.UConnection connection) {
            this.connection = connection;
        }


        public virtual Net.Vpc.Upa.Impl.Persistence.MarshallManager GetMarshallManager() {
            return marshallManager;
        }


        public virtual void SetMarshallManager(Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager) {
            this.marshallManager = marshallManager;
        }

        public virtual bool IsUpdatable() {
            return updatable;
        }

        public virtual void SetUpdatable(bool updatable) {
            this.updatable = updatable;
        }
    }
}
