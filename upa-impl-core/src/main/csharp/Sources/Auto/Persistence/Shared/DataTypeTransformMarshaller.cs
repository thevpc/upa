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
     * @creationdate 12/20/12 2:46 AM
     */
    public class DataTypeTransformMarshaller : Net.TheVpc.Upa.Impl.Persistence.SimpleTypeMarshaller {

        private Net.TheVpc.Upa.Types.DataTypeTransform dataTypeTransform;

        private Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller targetMarshaller;

        public DataTypeTransformMarshaller(Net.TheVpc.Upa.Types.DataTypeTransform dataTypeTransform, Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller targetMarshaller) {
            this.dataTypeTransform = dataTypeTransform;
            this.targetMarshaller = targetMarshaller;
        }

        public override object Read(int index, System.Data.IDataReader resultSet) /* throws System.Exception */  {
            return dataTypeTransform.ReverseTransformValue(targetMarshaller.Read(index, resultSet));
        }

        public override void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */  {
            targetMarshaller.Write(dataTypeTransform.TransformValue(@object), i, updatableResultSet);
        }


        public override string ToSQLLiteral(object @object) {
            return targetMarshaller.ToSQLLiteral(dataTypeTransform.TransformValue(@object));
        }

        public override void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */  {
            targetMarshaller.Write(dataTypeTransform.TransformValue(@object), i, preparedStatement);
        }


        public override Net.TheVpc.Upa.Types.DataType GetPersistentDataType(Net.TheVpc.Upa.Types.DataType datatype) {
            return dataTypeTransform.GetTargetType();
        }
    }
}
