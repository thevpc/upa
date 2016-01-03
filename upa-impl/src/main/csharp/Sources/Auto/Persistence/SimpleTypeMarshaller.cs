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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * Created with IntelliJ IDEA.
     * User: vpc
     * Date: 8/17/12
     * Time: 5:40 PM
     * To change this template use File | Settings | File Templates.
     */
    public abstract class SimpleTypeMarshaller : Net.Vpc.Upa.Impl.Persistence.DefaultTypeMarshaller {


        public override string ToSQLLiteral(object @object) {
            if (@object == null) {
                return GetMarshallManager().GetNullMarshaller().ToSQLLiteral(@object);
            }
            return null;
        }


        public override bool IsLiteralSupported() {
            return true;
        }


        public override int GetSize() {
            return 1;
        }


        public override string GetName(string name, int i) {
            return name;
        }

        public override Net.Vpc.Upa.Types.DataType GetPersistentDataType(Net.Vpc.Upa.Types.DataType datatype) {
            return null;
        }
    }
}
