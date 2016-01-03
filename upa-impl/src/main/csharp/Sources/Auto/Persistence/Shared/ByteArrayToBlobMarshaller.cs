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
     * @creationdate 12/20/12 2:48 AM
     */
    public class ByteArrayToBlobMarshaller : Net.Vpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            Java.Sql.Blob t = resultSet.GetBlob(index);
            if (t == null) {
                return null;
            }
            try {
                return Net.Vpc.Upa.Impl.Util.IOUtils.ToByteArray(t.GetBinaryStream());
            } catch (System.Exception e) {
                //                    Log.bug(e);
                return null;
            }
        }


        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
        }


        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return base.ToSQLLiteral(@object);
            }
            throw new System.ArgumentException ("Unsupported");
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            if (@object == null) {
                preparedStatement.SetNull(i, Java.Sql.Types.BLOB);
            } else {
                preparedStatement.SetBlob(i, new Java.Io.ByteArrayInputStream((byte[]) @object));
            }
        }

        public ByteArrayToBlobMarshaller() {
        }
    }
}
