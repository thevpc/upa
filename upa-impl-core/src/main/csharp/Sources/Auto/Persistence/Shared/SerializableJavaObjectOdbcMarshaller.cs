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



namespace Net.TheVpc.Upa.Impl.Persistence.Shared
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 12/20/12 2:49 AM*/
    public class SerializableJavaObjectOdbcMarshaller : Net.TheVpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        private Net.TheVpc.Upa.Impl.Persistence.MarshallManager pm;


        public override void SetMarshallManager(Net.TheVpc.Upa.Impl.Persistence.MarshallManager marshallManager) {
            this.pm = marshallManager;
        }

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            
            return null;
        }

        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return base.ToSQLLiteral(@object);
            }
            Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller wrapper = pm.GetTypeMarshaller(@object.GetType());
            if (wrapper != null && wrapper.GetType() != GetType()) {
                return wrapper.ToSQLLiteral(@object);
            }
            throw new System.Exception("litteral not supported for Objects (" + @object + " as " + @object.GetType() + ")");
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            
        }


        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
        }

        public override bool IsLiteralSupported() {
            return false;
        }
    }
}
