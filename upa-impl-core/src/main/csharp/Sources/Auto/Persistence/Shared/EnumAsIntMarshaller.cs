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
     * @creationdate 12/20/12 2:47 AM
     */
    public class EnumAsIntMarshaller : Net.Vpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        private System.Type type;

        private object[] values;

        public EnumAsIntMarshaller(System.Type type) {
            this.type = type;
            values = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetEnumValues(type);
        }

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            
            return null;
        }


        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
        }


        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return base.ToSQLLiteral(@object);
            }
            return System.Convert.ToString((int)@object);
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            
        }
    }
}
