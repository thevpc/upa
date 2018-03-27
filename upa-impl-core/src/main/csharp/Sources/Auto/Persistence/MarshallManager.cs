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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/5/12 12:40 AM
     */
    public interface MarshallManager {

         void SetNullMarshaller(Net.Vpc.Upa.Impl.Persistence.TypeMarshaller wrapper);

         Net.Vpc.Upa.Impl.Persistence.TypeMarshaller GetNullMarshaller();

         void SetTypeMarshaller(System.Type platformType, Net.Vpc.Upa.Impl.Persistence.TypeMarshaller wrapper);

         void SetTypeMarshallerFactory(System.Type platformType, Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory wrapperFactory);

         Net.Vpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(Net.Vpc.Upa.Types.DataTypeTransform someClass);

         Net.Vpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(System.Type someClass);

         Net.Vpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(Net.Vpc.Upa.Types.DataType p);

         Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory GetTypeMarshallerFactory(System.Type someClass);

         string FormatSqlValue(object @value);
    }
}
