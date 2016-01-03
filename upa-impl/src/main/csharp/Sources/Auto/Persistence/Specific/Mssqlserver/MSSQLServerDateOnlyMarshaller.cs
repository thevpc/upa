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



namespace Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 11/22/12 10:00 PM*/
    internal class MSSQLServerDateOnlyMarshaller : Net.Vpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            Net.Vpc.Upa.Types.Date t = System.Convert.ToDateTime(resultSet[index]);
            return t == null ? null : new Net.Vpc.Upa.Types.Date(t);
        }


        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return base.ToSQLLiteral(@object);
            }
            //TODO : pkoa Utils.UNIVERSAL_DATE_TIME_FORMAT?
            //2005-11-05 j'ai change en date seulement
            //            return "'" + Utils.UNIVERSAL_DATE_TIME_FORMAT.format(toTimestamp(object)) + "'";
            return "'" + Net.Vpc.Upa.Impl.Util.DateUtils.FormatUniversalDate(Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerPersistenceStore.ToTimestamp(@object)) + "'";
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            if (@object == null) {
                preparedStatement.SetNull(i, Java.Sql.Types.DATE);
            } else {
                ( System.Data.IDbDataParameter)(preparedStatement).Parameters[i].Value=Net.Vpc.Upa.Impl.Persistence.Specific.Mssqlserver.MSSQLServerPersistenceStore.ToTimestamp(@object);
            }
        }

        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
        }

        public MSSQLServerDateOnlyMarshaller() {
        }
    }
}
