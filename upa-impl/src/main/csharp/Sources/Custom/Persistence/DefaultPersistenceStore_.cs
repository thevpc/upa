
namespace Net.Vpc.Upa.Impl.Persistence
{
    public partial class DefaultPersistenceStore
    {
        protected internal virtual bool TableExists(string persistenceName)
        {
            try
            {
                System.Data.IDbConnection connection = GetConnection().GetPlatformConnection();
                if (connection is System.Data.Common.DbConnection)
                {
                    System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                    System.Data.DataTable found = dconnection.GetSchema("Tables", new string[] { null, null, persistenceName, "BASE TYPE" });
                    return (found.Rows.Count != 0);
                }
            }
            catch (System.Exception ex)
            {
                throw CreateUPAException(ex, "UnableToGetEntityStorageStatus", "Table " + persistenceName);
            }
            return false;
        }

        protected internal virtual bool ViewExists(string persistenceName)
        {
            try
            {
                System.Data.IDbConnection connection = GetConnection().GetPlatformConnection();
                if (connection is System.Data.Common.DbConnection)
                {
                    System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                    System.Data.DataTable found = dconnection.GetSchema("Tables", new string[] { null, null, persistenceName, "VIEW" });
                    return (found.Rows.Count != 0);
                }
            }
            catch (System.Exception ex)
            {
                throw CreateUPAException(ex, "UnableToGetEntityStorageStatus", "Table " + persistenceName);
            }
            return false;
        }

        protected internal virtual bool PkConstraintsExists(string tableName, string constraintsName)
        {
            try
            {
                System.Data.IDbConnection connection = GetConnection().GetPlatformConnection();
                if (connection is System.Data.Common.DbConnection)
                {
                    System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                    System.Data.DataTable found = dconnection.GetSchema("IndexColumns", new string[] { connection.Database, null, tableName, constraintsName, null });
                    return (found.Rows.Count != 0);
                }
            }
            catch (System.Exception ex)
            {
                throw CreateUPAException(ex, "UnableToGetEntityStorageStatus", "Table " + tableName);
            }
            return false;
        }

        protected internal virtual bool IndexExists(string tableName, string indexName,bool unique)
        {
            try
            {
                System.Data.IDbConnection connection = GetConnection().GetPlatformConnection();
                if (connection is System.Data.Common.DbConnection)
                {
                    System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                    System.Data.DataTable found = dconnection.GetSchema("Indexes", new string[] { connection.Database, null, tableName, indexName});
                    return (found.Rows.Count != 0);
                }
            }
            catch (System.Exception ex)
            {
                throw CreateUPAException(ex, "UnableToGetEntityStorageStatus", "Table " + tableName);
            }
            return false;
        }

        protected internal virtual bool ColumnExists(string tableName, string columnName)
        {
            try
            {
                System.Data.IDbConnection connection = GetConnection().GetPlatformConnection();
                if (connection is System.Data.Common.DbConnection)
                {
                    System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                    System.Data.DataTable found = dconnection.GetSchema("Indexes", new string[] { connection.Database, null, tableName, columnName });
                    return (found.Rows.Count != 0);
                }
            }
            catch (System.Exception ex)
            {
                throw CreateUPAException(ex, "UnableToGetEntityStorageStatus", "Table " + tableName);
            }
            return false;
        }
        protected internal virtual bool ForeignKeyExists(string tableName, string constraintName)
        {
            try
            {
                System.Data.IDbConnection connection = GetConnection().GetPlatformConnection();
                if (connection is System.Data.Common.DbConnection)
                {
                    System.Data.Common.DbConnection dconnection = (System.Data.Common.DbConnection)connection;
                    System.Data.DataTable found = dconnection.GetSchema("ForeignKeys", new string[] { connection.Database, null, tableName, constraintName });
                    return (found.Rows.Count != 0);
                }
            }
            catch (System.Exception ex)
            {
                throw CreateUPAException(ex, "UnableToGetEntityStorageStatus", "Table " + tableName);
            }
            return false;
        }
    }
}
