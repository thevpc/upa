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
     * Created by IntelliJ IDEA. User: vpc Date: 18 juin 2006 Time: 22:09:35 To
     * change this template use File | Settings | File Templates.
     */
    public interface TypeMarshallerFactory {

         void SetMarshallManager(Net.TheVpc.Upa.Impl.Persistence.MarshallManager marshallManager);

         Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller CreateTypeMarshaller(Net.TheVpc.Upa.Types.DataType type);
    }
}
