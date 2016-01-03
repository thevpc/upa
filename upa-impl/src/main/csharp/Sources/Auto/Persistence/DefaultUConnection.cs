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

        private System.Data.IDbConnection connection;

        private Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager;

        private Net.Vpc.Upa.Impl.Persistence.Connection.CloseListenerSupport support;

        private bool closed = false;

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.DefaultUConnection)).FullName);

        public DefaultUConnection(System.Data.IDbConnection connection, Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager) {
            this.connection = connection;
            this.marshallManager = marshallManager;
            this.support = new Net.Vpc.Upa.Impl.Persistence.Connection.CloseListenerSupport();
        }

        public virtual Net.Vpc.Upa.Persistence.QueryResult ExecuteQuery(string query, Net.Vpc.Upa.Types.DataTypeTransform[] types, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> queryParameters, bool updatable) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (closed) {
                throw new System.ArgumentException ("Connection closed");
            }
            try {
                try {
                    //                long startTime = System.currentTimeMillis();
                    if (/*IsLoggable=*/true) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("executeQuery {0} :: parameters = {1}",null,new object[] { query, queryParameters }));
                    }
                    System.Data.IDbCommand s = null;
                    s = connection.CreateCommand();
                    s.CommandText=query;
                    s.CommandType=System.Data.CommandType.Text;
                    int index = 1;
                    Net.Vpc.Upa.Impl.Persistence.TypeMarshaller[] marshallers = new Net.Vpc.Upa.Impl.Persistence.TypeMarshaller[types.Length];
                    for (int i = 0; i < marshallers.Length; i++) {
                        marshallers[i] = marshallManager.GetTypeMarshaller(types[i]);
                    }
                    int mi = 0;
                    if (queryParameters != null) {
                        foreach (Net.Vpc.Upa.Persistence.Parameter @value in queryParameters) {
                            Net.Vpc.Upa.Types.DataTypeTransform transform = @value.GetTypeTransform();
                            Net.Vpc.Upa.Impl.Persistence.TypeMarshaller marshaller = marshallManager.GetTypeMarshaller(transform);
                            marshaller.Write(@value.GetValue(), index, s);
                            index += marshaller.GetSize();
                            mi++;
                        }
                    }
                    //        Log.log(PersistenceUnitManager.DB_PRE_NATIVE_QUERY_LOG,"[BEFORE] "+currentQueryInfo+" :=" + currentQuery);
                    return new Net.Vpc.Upa.Impl.Persistence.DefaultQueryResult(s.ExecuteQuery(), s, marshallers, types);
                } catch (System.Exception ee) {
                    log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("[Error] executeQuery " + query + " :: parameters = " + queryParameters,ee));
                    throw ee;
                } finally {
                }
            } catch (System.Exception ex) {
                throw CreateUPAException(ex, "ExecuteQueryFailedException", query);
            }
        }

        public virtual int ExecuteNonQuery(string query, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> queryParameters, System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.Parameter> generatedKeys) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (closed) {
                throw new System.ArgumentException ("Connection closed");
            }
            int count = -1;
            bool gen = generatedKeys != null && (generatedKeys).Count > 0;
            //        Log.log(PersistenceUnitManager.DB_NATIVE_UPDATE_LOG,"[BEFORE] "+currentQueryInfo+" :=" + currentQuery);
            if (/*IsLoggable=*/true) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("executeNonQuery {0}" + ((queryParameters != null && !(queryParameters.Count==0)) ? "\n\tqueryParameters={1}" : ""),null,new object[] { query, queryParameters }));
            }
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
                if (gen) {
                    System.Data.IDataReader rs = s.GetGeneratedKeys();
                    if (rs.Next()) {
                        index = 1;
                        foreach (Net.Vpc.Upa.Persistence.Parameter entry in generatedKeys) {
                            Net.Vpc.Upa.Types.DataTypeTransform chain = entry.GetTypeTransform();
                            Net.Vpc.Upa.Impl.Persistence.TypeMarshaller marshaller = marshallManager.GetTypeMarshaller(chain);
                            entry.SetValue(marshaller.Read(index, rs));
                            index += marshaller.GetSize();
                        }
                    }
                }
            } catch (System.Exception ee) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("[Error] executeNonQuery " + query + " :: parameters = " + queryParameters,ee));
                //            Log.log(PersistenceUnitManager.DB_ERROR_LOG,"[Error] "+currentQueryInfo+" :=" + currentQuery);
                throw CreateUPAException(ee, "ExecuteUpdateFailedException", query);
            } finally {
                long endTime = System.DateTime.Now.Ticks;
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
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("[Error] executeNonQuery @" + i + " : " + script.GetStatement(i),sqle));
                        //                    log.log(Level.SEVERE,"Error @" + i + " : " + script.getStatement(i));
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Error @{0} : {1}",null,new object[] { i, script.GetStatement(i) }));
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
                connection.Commit();
            } catch (System.Exception e) {
                throw CreateUPAException(e, "CloseFailed", connection);
            }
            try {
                connection.Close();
            } catch (System.Exception e) {
                throw CreateUPAException(e, "CloseFailed", connection);
            }
            closed = true;
            support.AfterClose(this);
        }


        public virtual System.Data.IDbConnection GetMetadataAccessibleConnection() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Data.IDbConnection retConn = connection;
            while (true) {
                if ((retConn.GetType()).FullName.Equals("org.apache.tomcat.dbcp.dbcp.PoolingDataSource$PoolGuardConnectionWrapper")) {
                    System.Reflection.FieldInfo f;
                    try {
                        f = (retConn.GetType()).BaseType.GetField("_conn", System.Reflection.BindingFlags.Default|System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.Instance);
                        //f.SetAccessible(true);
                        retConn = (System.Data.IDbConnection) f.GetValue(retConn);
                    } catch (System.Exception ex) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to rerive MetadataAccessibleConnection from dbcp PoolGuardConnectionWrapper",ex));
                        retConn = connection;
                        break;
                    }
                } else if ((retConn.GetType()).FullName.Equals("org.apache.tomcat.dbcp.dbcp.PoolableConnection")) {
                    System.Reflection.FieldInfo f;
                    try {
                        f = (retConn.GetType()).BaseType.GetField("_conn", System.Reflection.BindingFlags.Default|System.Reflection.BindingFlags.Public|System.Reflection.BindingFlags.NonPublic|System.Reflection.BindingFlags.Static|System.Reflection.BindingFlags.Instance);
                        //f.SetAccessible(true);
                        retConn = (System.Data.IDbConnection) f.GetValue(retConn);
                    } catch (System.Exception ex) {
                        log.TraceEvent(System.Diagnostics.TraceEventType.Error,100,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Unable to rerive MetadataAccessibleConnection from dbcp PoolableConnection",ex));
                        retConn = connection;
                        break;
                    }
                } else {
                    break;
                }
            }
            return retConn;
        }


        public override string ToString() {
            return "UConnection{" + connection + '}';
        }
    }
}
