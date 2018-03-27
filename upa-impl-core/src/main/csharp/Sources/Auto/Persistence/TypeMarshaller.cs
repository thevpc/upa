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


    public interface TypeMarshaller {

         void SetMarshallManager(Net.Vpc.Upa.Impl.Persistence.MarshallManager marshallManager);

         object Read(int i, System.Data.IDataReader resultset) /* throws System.Exception */ ;

         void Write(object @object, int i, System.Data.IDataReader updatableResultSet) /* throws System.Exception */ ;

         void Write(object @object, int i, System.Data.IDbCommand preparedStatement) /* throws System.Exception */ ;

         string ToSQLLiteral(object @object);

         bool IsLiteralSupported();

         int GetSize();

         string GetName(string name, int i);

         Net.Vpc.Upa.Types.DataType GetPersistentDataType(Net.Vpc.Upa.Types.DataType datatype);
    }
}
