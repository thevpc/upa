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
    public class EnumAsNameMarshaller : Net.Vpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        private System.Type type;

        private object[] values;

        private Net.Vpc.Upa.Types.StringType persistentDataType;

        public EnumAsNameMarshaller() {
        }

        public EnumAsNameMarshaller(System.Type type) {
            this.type = type;
            try {
                values = Net.Vpc.Upa.Impl.Util.PlatformUtils.GetEnumValues(type);
                int max = 1;
                foreach (object @object in values) {
                    int x = (System.Convert.ToString(@object)).Length;
                    if (x > max) {
                        max = x;
                    }
                }
                persistentDataType = new Net.Vpc.Upa.Types.StringType((type).FullName, 0, max, true);
            } catch (System.Exception e) {
                throw new System.Exception("RuntimeException", e);
            }
        }

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            string n = System.Convert.ToString(resultSet[index]);
            if (n == null) {
                return null;
            }
            try {
                return System.Enum.Parse(type,n);
            } catch (System.ArgumentException  e) {
                return null;
            }
        }


        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
        }


        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return base.ToSQLLiteral(@object);
            }
            return System.Convert.ToString(((Java.Lang.Enum<E>) @object).ToString());
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            if (@object == null) {
                preparedStatement.SetNull(i, Java.Sql.Types.VARCHAR);
            } else {
                preparedStatement.SetString(i, ((Java.Lang.Enum<E>) @object).ToString());
            }
        }


        public override Net.Vpc.Upa.Types.DataType GetPersistentDataType(Net.Vpc.Upa.Types.DataType datatype) {
            return persistentDataType;
        }
    }
}
