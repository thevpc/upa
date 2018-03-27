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
    * @creationdate 12/20/12 2:49 AM*/
    public class EnumMarshallerFactory : Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory {

        private Net.Vpc.Upa.Impl.Persistence.MarshallManager pm;

        public EnumMarshallerFactory() {
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.TypeMarshaller CreateTypeMarshaller(Net.Vpc.Upa.Types.DataType type) {
            Net.Vpc.Upa.Types.EnumType n = (Net.Vpc.Upa.Types.EnumType) type;
            //TODO should get more info about marshalling info
            return new Net.Vpc.Upa.Impl.Persistence.Shared.EnumAsIntMarshaller(n.GetPlatformType());
        }


        public virtual void SetMarshallManager(Net.Vpc.Upa.Impl.Persistence.MarshallManager pm) {
            this.pm = pm;
        }
    }
}
