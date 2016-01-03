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
    public class ConstantDataMarshallerFactory : Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory {

        private Net.Vpc.Upa.Impl.Persistence.TypeMarshaller w;

        public ConstantDataMarshallerFactory(Net.Vpc.Upa.Impl.Persistence.TypeMarshaller w) {
            this.w = w;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.TypeMarshaller CreateTypeMarshaller(Net.Vpc.Upa.Types.DataType type) {
            return w;
        }


        public virtual void SetMarshallManager(Net.Vpc.Upa.Impl.Persistence.MarshallManager pm) {
        }
    }
}
