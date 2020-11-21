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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    public class DefaultQueryExecutor : Net.TheVpc.Upa.Impl.Persistence.QueryExecutor {

        internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.DefaultQueryExecutor)).FullName);

        private System.Collections.Generic.IDictionary<string , object> hints;

        private string query;

        private Net.TheVpc.Upa.Persistence.UConnection connection;

        private Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore;

        private Net.TheVpc.Upa.Impl.Persistence.NativeStatementType type;

        private System.Collections.Generic.Dictionary<string , string> parameters;

        private object returnValue;

        private int currentStatementIndex;

        private bool updatable;

        private string errorTrace;

        private Net.TheVpc.Upa.Impl.Persistence.NativeField[] fields;

        private Net.TheVpc.Upa.Persistence.ResultMetaData metaData;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.Parameter> queryParameters;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.Parameter> generatedKeys;

        public DefaultQueryExecutor(Net.TheVpc.Upa.Impl.Persistence.NativeStatementType type, System.Collections.Generic.IDictionary<string , object> hints, string query, System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.Parameter> queryParameters, System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.Parameter> generatedKeys, Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore, Net.TheVpc.Upa.Persistence.UConnection connection, Net.TheVpc.Upa.Impl.Persistence.NativeField[] nativeFields, bool updatable, Net.TheVpc.Upa.Persistence.ResultMetaData metaData) {
            this.type = type;
            this.updatable = updatable;
            this.metaData = metaData;
            this.query = query;
            this.fields = nativeFields;
            this.queryParameters = queryParameters;
            this.generatedKeys = generatedKeys;
            this.persistenceStore = persistenceStore;
            this.connection = connection;
            parameters = new System.Collections.Generic.Dictionary<string , string>();
            this.hints = hints;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.NativeStatementType GetStatementType() {
            return type;
        }


        public override string ToString() {
            return "BEGIN NATIVE_SQL" + "\n" + query + "\n" + "parameters=" + parameters + "\n" + "END NATIVE_SQL";
        }

        public virtual void Dispose() {
        }

        public virtual string GetErrorTrace() {
            return errorTrace;
        }

        public virtual int GetCurrentStatementIndex() {
            return currentStatementIndex;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.QueryExecutor Execute() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            string logString = null;
            try {
                errorTrace = null;
                this.currentStatementIndex = 0;
                //        log.log(Level.FINE,"NATIVE QUERY : " + query);
                //        Log.log(PersistenceUnitManager.DB_QUERY_LOG, "RETURN :=" + query);
                switch(GetStatementType()) {
                    case Net.TheVpc.Upa.Impl.Persistence.NativeStatementType.SELECT:
                        {
                            Net.TheVpc.Upa.Types.DataTypeTransform[] types = new Net.TheVpc.Upa.Types.DataTypeTransform[fields.Length];
                            for (int i = 0; i < types.Length; i++) {
                                types[i] = fields[i].GetTypeTransform();
                            }
                            SetQueryResult(connection.ExecuteQuery(query, types, queryParameters, updatable));
                            break;
                        }
                    case Net.TheVpc.Upa.Impl.Persistence.NativeStatementType.UPDATE:
                        {
                            if (generatedKeys != null && (generatedKeys).Count > 0) {
                                int updates = connection.ExecuteNonQuery(query, queryParameters, generatedKeys);
                                SetResultCount(updates);
                            } else {
                                SetResultCount(connection.ExecuteNonQuery(query, queryParameters, null));
                            }
                            break;
                        }
                    default:
                        throw new System.Exception("Unexpected QueryExecutor type " + GetStatementType());
                }
            } catch (System.Exception e) {
                errorTrace = "--ERROR-EXEC--" + "\n" + "        full query =" + query + "\n" + "   statement index =" + GetCurrentStatementIndex() + "\n" + " execution-context =" + this + "\n" + "         exception =" + e + "\n" + "        stacktrace =" + "\n";
                //            Log.log(PersistenceUnitManager.DB_ERROR_LOG,errorTrace);
                throw new Net.TheVpc.Upa.Exceptions.UPAException(e, new Net.TheVpc.Upa.Types.I18NString("NativeException"), errorTrace);
            } finally {
                //            if (errorTrace == null){
                //                switch (createExecutor.getDataType()) {
                //                    case 2: // '\002'
                //                        Log.log(DatabaseAdapter.DB_UPDATE_LOG,"[COUNT=?] " + getResultCount());
                //                        break;
                //                }
                //            }
                Dispose();
            }
            return this;
        }

        public virtual void SetQueryResult(Net.TheVpc.Upa.Persistence.QueryResult r) {
            returnValue = r;
        }

        public virtual void SetResultCount(int r) {
            returnValue = r;
        }

        public virtual Net.TheVpc.Upa.Persistence.QueryResult GetQueryResult() {
            return (Net.TheVpc.Upa.Persistence.QueryResult) returnValue;
        }

        public virtual int GetResultCount() {
            return ((int?) returnValue).Value;
        }

        public virtual void SetParameter(string paramName, string @value) {
            parameters[paramName]=@value;
        }

        public virtual System.Collections.Generic.IDictionary<string , string> GetParameters() {
            return parameters;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetHints() {
            return hints;
        }

        public virtual Net.TheVpc.Upa.Persistence.ResultMetaData GetMetaData() {
            return metaData;
        }


        public virtual Net.TheVpc.Upa.Impl.Persistence.NativeField[] GetFields() {
            return fields;
        }


        public virtual Net.TheVpc.Upa.Persistence.UConnection GetConnection() {
            return connection;
        }
    }
}
