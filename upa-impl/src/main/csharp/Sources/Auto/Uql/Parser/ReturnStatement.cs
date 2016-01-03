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
     * User: taha Date: 25 juin 2003 Time: 17:30:36
     */
    public class ReturnStatement : Net.Vpc.Upa.Impl.Persistence.NativeStatement {

        private string query;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> queryParameters;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> generatedKeys;

        public ReturnStatement(string query, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> queryParameters, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> generatedKeys) {
            this.query = query;
            this.queryParameters = queryParameters;
            this.generatedKeys = generatedKeys;
        }

        public virtual void Execute(Net.Vpc.Upa.Impl.Persistence.NativeSQL nativeSQL) /* throws System.Exception, Net.Vpc.Upa.Exceptions.UPAException */  {
            nativeSQL.SetCurrentQueryInfo("RETURN");
            nativeSQL.SetCurrentQuery(query);
            Net.Vpc.Upa.Persistence.UConnection connection = nativeSQL.GetConnection();
            //        log.log(Level.FINE,"NATIVE QUERY : " + query);
            //        Log.log(PersistenceUnitManager.DB_QUERY_LOG, "RETURN :=" + query);
            switch(nativeSQL.GetStatementType()) {
                case Net.Vpc.Upa.Impl.Persistence.NativeStatementType.SELECT:
                    {
                        Net.Vpc.Upa.Impl.Persistence.NativeField[] fields = nativeSQL.GetFields();
                        Net.Vpc.Upa.Types.DataTypeTransform[] types = new Net.Vpc.Upa.Types.DataTypeTransform[fields.Length];
                        for (int i = 0; i < types.Length; i++) {
                            types[i] = fields[i].GetTypeTransform();
                        }
                        nativeSQL.SetQueryResult(connection.ExecuteQuery(nativeSQL.GetQuery(), types, queryParameters, nativeSQL.IsUpdatable()));
                        break;
                    }
                case Net.Vpc.Upa.Impl.Persistence.NativeStatementType.UPDATE:
                    {
                        if (generatedKeys != null && (generatedKeys).Count > 0) {
                            int updates = connection.ExecuteNonQuery(nativeSQL.GetQuery(), queryParameters, generatedKeys);
                            nativeSQL.SetResultCount(updates);
                        } else {
                            nativeSQL.SetResultCount(connection.ExecuteNonQuery(nativeSQL.GetQuery(), queryParameters, null));
                        }
                        break;
                    }
                default:
                    throw new System.Exception("Unexpected NativeSQL type " + nativeSQL.GetStatementType());
            }
        }

        public virtual void Dispose() /* throws System.Exception */  {
        }


        public override string ToString() {
            return "return " + query;
        }
    }
}
