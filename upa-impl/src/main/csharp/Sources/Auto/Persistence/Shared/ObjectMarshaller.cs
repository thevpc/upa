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
    public class ObjectMarshaller : Net.Vpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            return resultSet.GetObject(index);
        }

        public override string ToSQLLiteral(object @object) {
            Net.Vpc.Upa.Impl.Persistence.TypeMarshaller wrapper = GetMarshallManager().GetTypeMarshaller(@object.GetType());
            if (wrapper != null && wrapper.GetType() != GetType()) {
                return wrapper.ToSQLLiteral(@object);
            }
            throw new System.Exception("literal not supported for Objects");
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            preparedStatement.SetObject(i, @object);
        }


        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
        }

        public override bool IsLiteralSupported() {
            return true;
        }

        public ObjectMarshaller() {
        }
    }
}
