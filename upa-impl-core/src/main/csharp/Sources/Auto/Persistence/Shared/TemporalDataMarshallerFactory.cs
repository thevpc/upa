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
    * @creationdate 12/20/12 2:50 AM*/
    public class TemporalDataMarshallerFactory : Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory {

        public TemporalDataMarshallerFactory() {
        }

        private Net.TheVpc.Upa.Impl.Persistence.MarshallManager pm;


        public virtual void SetMarshallManager(Net.TheVpc.Upa.Impl.Persistence.MarshallManager pm) {
            this.pm = pm;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller CreateTypeMarshaller(Net.TheVpc.Upa.Types.DataType type) {
            Net.TheVpc.Upa.Types.TemporalType n = (Net.TheVpc.Upa.Types.TemporalType) type;
            System.Type primitiveType = type.GetPlatformType();
            return pm.GetTypeMarshaller(primitiveType);
        }
    }
}
