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
    * @creationdate 12/20/12 2:49 AM*/
    public class SerializablePlatformObjectMarshaller : Net.Vpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        public SerializablePlatformObjectMarshaller() {
        }

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            byte[] b = resultSet.GetBytes(index);
            if (b == null) {
                return null;
            }
            try {
                return Net.Vpc.Upa.Impl.Util.IOUtils.GetObjectFromSerializedForm(b);
            } catch (System.Exception e) {
                //Log.bug(e);
                return null;
            }
        }

        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return base.ToSQLLiteral(@object);
            }
            Net.Vpc.Upa.Impl.Persistence.TypeMarshaller wrapper = GetMarshallManager().GetTypeMarshaller(@object.GetType());
            if (wrapper != null && wrapper.GetType() != GetType()) {
                return wrapper.ToSQLLiteral(@object);
            }
            throw new System.Exception("literal not supported for Objects (" + @object + " as " + @object.GetType() + ")");
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            if (@object == null) {
                //            	preparedStatement.setNull(i, Types.VARCHAR);
                preparedStatement.SetBytes(i, null);
            } else {
                //            	byte[] d=Utils.getSerializedFormOf(object);
                //InputStream dis=new ByteArrayInputStream(d);
                //preparedStatement.setBinaryStream(i, dis,d.length);
                preparedStatement.SetBytes(i, Net.Vpc.Upa.Impl.Util.IOUtils.GetSerializedFormOf(@object));
            }
        }


        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
        }

        public override bool IsLiteralSupported() {
            return false;
        }
    }
}
