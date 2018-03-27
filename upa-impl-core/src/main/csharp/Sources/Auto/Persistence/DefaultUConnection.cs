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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/3/12 11:07 PM
     */
    public class DefaultUConnection : Net.Vpc.Upa.Persistence.UConnection {

        private static System.Collections.Generic.ISet<string> _conn_attr_based_wrappers = new System.Collections.Generic.HashSet<string>(new System.Collections.Generic.List<string>(new[]{"org.apache.tomcat.dbcp.dbcp.PoolableConnection", "org.apache.tomcat.dbcp.dbcp.PoolingDataSource$PoolGuardConnectionWrapper", "org.apache.commons.dbcp.PoolableConnection", "org.apache.commons.dbcp.PoolingDataSource$PoolGuardConnectionWrapper"}));

        private string name;

        private string nameDebugString;

        private System.Data.IDbConnection connection;

        private System.Data.IDbConnection metadataAccessibleConnection;

        private Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager;

        private Net.Vpc.Upa.Impl.Persistence.Connection.CloseListenerSupport support;

        private System.Collections.Generic.IDictionary<string , object> properties;

        private bool closed = false;

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.DefaultUConnection)).FullName);

        public DefaultUConnection(string name, System.Data.IDbConnection connection, Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager) {
            this.name = name;
            this.connection = connection;
            this.marshallManager = marshallManager;
            this.support = new Net.Vpc.Upa.Impl.Persistence.Connection.CloseListenerSupport();
            nameDebugString = Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(name) ? "[]" : ("[" + name + "]");
        }

        public virtual Net.Vpc.Upa.Persistence.QueryResult ExecuteQuery(string query, Net.Vpc.Upa.Types.DataTypeTransform[] types, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> queryParameters, bool updatable) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (closed) {
                throw new System.ArgumentException ("Connection closed");
            }
            long startTime = System.DateTime.Now.Ticks;
            System.Exception error = null;
            try {
                try {
                    System.Data.IDbCommand s = null;
                    s =connection.CreateCommand();
                    s.CommandText=query;
                    s.CommandType=System.Data.CommandType.Text;
                    int mi = 0;
                    int index = 1;
                    if (queryParameters != null) {
                        foreach (Net.Vpc.Upa.Persistence.Parameter @value in queryParameters) {
                            Net.Vpc.Upa.Types.DataTypeTransform transform = @value.GetTypeTransform();
                            Net.Vpc.Upa.Impl.Persistence.TypeMarshaller marshaller = marshallManager.GetTypeMarshaller(transform);
                            marshaller.Write(@value.GetValue(), index, s);
                            index += marshaller.GetSize();
                            mi++;
                        }
                    }
                    System.Data.IDataReader resultSet = s.ExecuteReader();
                    if (types == null) {
                        int columnCount;
                        System.Type[] colTypes;
                        columnCount=resultSet.FieldCount;
                        colTypes = new System.Type[columnCount];
                        for (int i = 0; i < columnCount; i++) {
                        colTypes[i] = resultSet.GetFieldType(i);
                        }
                        types = new Net.Vpc.Upa.Types.DataTypeTransform[columnCount];
                        for (int i = 0; i < types.Length; i++) {
                            types[i] = new Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform(Net.Vpc.Upa.Types.TypesFactory.ForPlatformType(colTypes[i]));
                        }
                    }
                    Net.Vpc.Upa.Impl.Persistence.TypeMarshaller[] marshallers = new Net.Vpc.Upa.Impl.Persistence.TypeMarshaller[types.Length];
                    for (int i = 0; i < marshallers.Length; i++) {
                        marshallers[i] = marshallManager.GetTypeMarshaller(types[i]);
                    }
                    //        Log.log(PersistenceUnitManager.DB_PRE_NATIVE_QUERY_LOG,"[BEFORE] "+currentQueryInfo+" :=" + currentQuery);
                    return new Net.Vpc.Upa.Impl.Persistence.DefaultQueryResult(resultSet, s, marshallers, types);
                } catch (System.Exception ee) {
                    error = ee;
                    throw ee;
                } finally {
                    if (/*IsLoggable=*/true) {
                        if (error != null) {
                            log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(nameDebugString + " [Error] executeQuery " + query + " :: parameters = " + queryParameters,error));
                        } else {
                            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("{0}   executeQuery    {1} ;; parameters = {2} ;; time = {3}",null,new object[] { nameDebugString, query, queryParameters, (System.DateTime.Now.Ticks - startTime) }));
                        }
                    }
                }
            } catch (System.Exception ex) {
                throw CreateUPAException(ex, "ExecuteQueryFailedException", query);
            }
        }

        public virtual int ExecuteNonQuery(string query, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> queryParameters, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> generatedKeys) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (closed) {
                throw new System.ArgumentException ("Connection closed");
            }
            System.Exception error = null;
            int count = -1;
            bool gen = generatedKeys != null && (generatedKeys).Count > 0;
            long startTime = System.DateTime.Now.Ticks;
            try {
                System.Data.IDbCommand s = null;
                s = connection.CreateCommand();
                s.CommandText=query;
                s.CommandType=System.Data.CommandType.Text;
                int index = 1;
                if (queryParameters != null) {
                    foreach (Net.Vpc.Upa.Persistence.Parameter @value in queryParameters) {
                        Net.Vpc.Upa.Types.DataTypeTransform chain = @value.GetTypeTransform();
                        Net.Vpc.Upa.Impl.Persistence.TypeMarshaller typeMarshaller = marshallManager.GetTypeMarshaller(chain);
                        typeMarshaller.Write(@value.GetValue(), index, s);
                        index += typeMarshaller.GetSize();
                    }
                }
                count = s.ExecuteNonQuery();
                
            } catch (System.Exception ee) {
                error = ee;
                //            Log.log(PersistenceUnitManager.DB_ERROR_LOG,"[Error] "+currentQueryInfo+" :=" + currentQuery);
                throw CreateUPAException(ee, "ExecuteUpdateFailedException", query);
            } finally {
                if (/*IsLoggable=*/true) {
                    if (error != null) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(nameDebugString + " [Error] executeNonQuery " + query + " :: parameters = " + queryParameters,error));
                    } else {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("{0} executeNonQuery {1}" + ((queryParameters != null && !(queryParameters.Count==0)) ? "\n\tqueryParameters={2}" : "") + " ;; time = {3}",null,new object[] { nameDebugString, query, queryParameters, (System.DateTime.Now.Ticks - startTime) }));
                    }
                }
            }
            //            Log.log(PersistenceUnitManager.DB_NATIVE_UPDATE_LOG,"[TIME="+Log.DELTA_FORMAT.format(endTime-startTime)+" ; COUNT="+count+"] "+debug+" :=" + currentQuery);
            return count;
        }

        public virtual int ExecuteScript(Net.Vpc.Upa.Expressions.QueryScript script, bool exitOnError) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (closed) {
                throw new System.ArgumentException ("Connection closed");
            }
            //ExecutionContext qlContext = createContext(ContextOperation.CREATE_PERSISTENCE_NAME);
            try {
                int max = script.Size();
                //            int groupPercent = 5;
                int errorsCount = 0;
                //            int group = (int) (((double) max * (double) groupPercent) / 100D);
                for (int i = 0; i < max; i++) {
                    try {
                        ExecuteNonQuery(script.GetStatement(i), null, null);
                    } catch (Net.Vpc.Upa.Exceptions.UPAException sqle) {
                        errorsCount++;
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter(nameDebugString + " [Error] executeNonQuery @" + i + " : " + script.GetStatement(i),sqle));
                        //                    log.log(Level.SEVERE,"Error @" + i + " : " + script.getStatement(i));
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("{0} Error @{1} : {2}",null,new object[] { nameDebugString, i, script.GetStatement(i) }));
                        if (exitOnError) {
                            throw sqle;
                        }
                    }
                }
                //            if (listener != null) {
                //                listener.actionProgress(new ProgressEvent(this, null, null, max, 0L, max, parentEvent));
                //            }
                //            transactionSucceeded = true;
                return errorsCount;
            } finally {
            }
        }

        private Net.Vpc.Upa.Exceptions.UPAException CreateUPAException(System.Exception ex, string mgId, params object [] parameters) {
            return new Net.Vpc.Upa.Exceptions.UPAException(ex, new Net.Vpc.Upa.Types.I18NString(mgId), parameters);
        }

        public virtual System.Data.IDbConnection GetPlatformConnection() {
            return connection;
        }


        public virtual void AddCloseListener(Net.Vpc.Upa.CloseListener closeListener) {
            support.AddCloseListener(closeListener);
        }


        public virtual void RemoveCloseListener(Net.Vpc.Upa.CloseListener closeListener) {
            support.RemoveCloseListener(closeListener);
        }


        public virtual void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            //        try {
            //            connection.rollback();
            //        } catch (SQLException e) {
            //            throw createUPAException(e, "CloseFailed", connection);
            //        }
            support.BeforeClose(this);
            
            try {
                connection.Close();
            } catch (System.Exception e) {
                throw CreateUPAException(e, "CloseFailed", connection);
            }
            closed = true;
            support.AfterClose(this);
        }


        public virtual System.Data.IDbConnection GetMetadataAccessibleConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (metadataAccessibleConnection == null) {
                System.Data.IDbConnection retConn = connection;
                while (true) {
                    string connClassName = (retConn.GetType()).FullName;
                    if (_conn_attr_based_wrappers.Contains(connClassName)) {
                        System.Reflection.FieldInfo f;
                        try {
                            f = (retConn.GetType()).BaseType.GetField("_conn", System.Reflection.BindingFlags.Default|System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.Instance);
                            //f.SetAccessible(true);
                            retConn = (System.Data.IDbConnection) f.GetValue(retConn);
                        } catch (System.Exception ex) {
                            log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to retrieve MetadataAccessibleConnection from Pool Type " + connClassName + "",ex));
                            retConn = connection;
                            break;
                        }
                    } else {
                        break;
                    }
                }
                metadataAccessibleConnection = retConn;
            }
            return metadataAccessibleConnection;
        }


        public virtual object GetProperty(string name) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (properties == null) {
                return null;
            }
            return Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(properties,name);
        }


        public virtual System.Collections.Generic.IDictionary<string , object> GetProperties() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (properties == null) {
                return new System.Collections.Generic.Dictionary<string,object>();
            }
            return new System.Collections.Generic.Dictionary<string,object>(properties);
        }


        public virtual void SetProperty(string name, object @value) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (@value == null) {
                if (properties != null) {
                    properties.Remove(name);
                }
            } else {
                if (properties == null) {
                    properties = new System.Collections.Generic.Dictionary<string , object>();
                }
                properties[name]=@value;
            }
        }


        public override string ToString() {
            return "UConnection{" + connection + '}';
        }
    }
}
