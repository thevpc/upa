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
    * @creationdate 11/22/12 10:01 PM*/
    internal class MSSQLServerTimeMarshaller : Net.Vpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            Net.Vpc.Upa.Types.Time t = resultSet.GetTime(index);
            return t == null ? null : new Net.Vpc.Upa.Types.Time(t);
        }


        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return base.ToSQLLiteral(@object);
            }
            return "'" + Net.Vpc.Upa.Impl.Util.DateUtils.FormatUniversalTime((Net.Vpc.Upa.Types.Temporal) @object) + "'";
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            if (@object == null) {
                preparedStatement.SetNull(i, Java.Sql.Types.TIME);
            } else {
                ( System.Data.IDbDataParameter)(preparedStatement).Parameters[i].Value=(@object is Net.Vpc.Upa.Types.Time) ? ((Net.Vpc.Upa.Types.Time) @object) : (new Net.Vpc.Upa.Types.Time(((Net.Vpc.Upa.Types.Temporal) @object).GetTime()));
            }
        }

        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
        }

        public MSSQLServerTimeMarshaller() {
        }
    }
}
