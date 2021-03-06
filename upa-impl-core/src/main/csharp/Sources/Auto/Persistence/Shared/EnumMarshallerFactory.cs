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
    * @creationdate 12/20/12 2:49 AM*/
    public class EnumMarshallerFactory : Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory {

        private Net.TheVpc.Upa.Impl.Persistence.MarshallManager pm;

        public EnumMarshallerFactory() {
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller CreateTypeMarshaller(Net.TheVpc.Upa.Types.DataType type) {
            Net.TheVpc.Upa.Types.EnumType n = (Net.TheVpc.Upa.Types.EnumType) type;
            //TODO should get more info about marshalling info
            return new Net.TheVpc.Upa.Impl.Persistence.Shared.EnumAsIntMarshaller(n.GetPlatformType());
        }


        public virtual void SetMarshallManager(Net.TheVpc.Upa.Impl.Persistence.MarshallManager pm) {
            this.pm = pm;
        }
    }
}
