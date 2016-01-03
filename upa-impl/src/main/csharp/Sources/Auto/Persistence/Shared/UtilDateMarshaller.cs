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



namespace Net.Vpc.Upa.Impl.Persistence.Shared
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 12/20/12 2:48 AM*/
    public class UtilDateMarshaller : Net.Vpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            Net.Vpc.Upa.Types.Timestamp ts = resultSet.GetTimestamp(index);
            return ts == null ? null : new Net.Vpc.Upa.Types.Date(ts.GetTime());
        }


        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
        }

        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return base.ToSQLLiteral(@object);
            }
            return "{ts '" + Net.Vpc.Upa.Impl.Util.DateUtils.FormatUniversalDateTime((Net.Vpc.Upa.Types.Temporal) @object) + "'}";
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            if (@object == null) {
                preparedStatement.SetNull(i, Java.Sql.Types.TIMESTAMP);
            } else {
                ( System.Data.IDbDataParameter)(preparedStatement).Parameters[i].Value=(@object is Net.Vpc.Upa.Types.Timestamp) ? ((Net.Vpc.Upa.Types.Timestamp) @object) : (new Net.Vpc.Upa.Types.Timestamp(((Net.Vpc.Upa.Types.Temporal) @object).GetTime()));
            }
        }

        public UtilDateMarshaller() {
        }
    }
}
