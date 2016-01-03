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
    * @creationdate 12/20/12 2:46 AM*/
    public class StringMarshaller : Net.Vpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            return System.Convert.ToString(resultSet[index]);
        }

        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
        }


        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return base.ToSQLLiteral(@object);
            }
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            s.Append('\'');
            foreach (char c in @object.ToString().ToCharArray()) {
                switch(c) {
                    case '\'':
                        {
                            s.Append("''");
                            break;
                        }
                    default:
                        {
                            s.Append(c);
                            break;
                        }
                }
            }
            s.Append('\'');
            return s.ToString();
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            preparedStatement.SetString(i, (string) @object);
        }

        public StringMarshaller() {
        }
    }
}
