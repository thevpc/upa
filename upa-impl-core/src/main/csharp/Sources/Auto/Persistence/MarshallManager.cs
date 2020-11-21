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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/5/12 12:40 AM
     */
    public interface MarshallManager {

         void SetNullMarshaller(Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller wrapper);

         Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller GetNullMarshaller();

         void SetTypeMarshaller(System.Type platformType, Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller wrapper);

         void SetTypeMarshallerFactory(System.Type platformType, Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory wrapperFactory);

         Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(Net.TheVpc.Upa.Types.DataTypeTransform someClass);

         Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(System.Type someClass);

         Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller GetTypeMarshaller(Net.TheVpc.Upa.Types.DataType p);

         Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory GetTypeMarshallerFactory(System.Type someClass);

         string FormatSqlValue(object @value);
    }
}
