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
    * @creationdate 12/20/12 2:50 AM*/
    public class TemporalDataMarshallerFactory : Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory {

        public TemporalDataMarshallerFactory() {
        }

        private Net.Vpc.Upa.Impl.Persistence.MarshallManager pm;


        public virtual void SetMarshallManager(Net.Vpc.Upa.Impl.Persistence.MarshallManager pm) {
            this.pm = pm;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.TypeMarshaller CreateTypeMarshaller(Net.Vpc.Upa.Types.DataType type) {
            Net.Vpc.Upa.Types.TemporalType n = (Net.Vpc.Upa.Types.TemporalType) type;
            System.Type primitiveType = type.GetPlatformType();
            return pm.GetTypeMarshaller(primitiveType);
        }
    }
}
