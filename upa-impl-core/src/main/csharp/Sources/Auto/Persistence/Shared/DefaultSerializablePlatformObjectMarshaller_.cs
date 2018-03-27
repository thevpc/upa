
namespace Net.Vpc.Upa.Impl.Persistence.Shared
{
    public partial class DefaultSerializablePlatformObjectMarshaller:TypeMarshaller
    {
         public void SetMarshallManager(Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager)
        {
                 }
         public object Read(int i, System.Data.IDataReader resultset) /* throws System.Exception */
    {
         return null;
             }
         public void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */
    {
             }
         public void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */
         {
                  }

         public string ToSQLLiteral(object @object){
         return null;
                                                            }

         public bool IsLiteralSupported(){
                                                           return false;
}

         public int GetSize(){
         return 0;
                                      }

         public string GetName(string name, int i){
         return null;
                                                           }

         public Net.Vpc.Upa.Types.DataType GetPersistentDataType(Net.Vpc.Upa.Types.DataType datatype){
         return null;
         }
    }
}
