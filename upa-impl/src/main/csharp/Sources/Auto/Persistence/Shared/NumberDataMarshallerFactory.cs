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
     * @creationdate 12/20/12 2:49 AM
     */
    public class NumberDataMarshallerFactory : Net.Vpc.Upa.Impl.Persistence.TypeMarshallerFactory {

        public NumberDataMarshallerFactory() {
        }

        private Net.Vpc.Upa.Impl.Persistence.MarshallManager pm;


        public virtual void SetMarshallManager(Net.Vpc.Upa.Impl.Persistence.MarshallManager pm) {
            this.pm = pm;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.TypeMarshaller CreateTypeMarshaller(Net.Vpc.Upa.Types.DataType type) {
            Net.Vpc.Upa.Types.NumberType n = (Net.Vpc.Upa.Types.NumberType) type;
            System.Type c = n.GetPlatformType();
            Net.Vpc.Upa.Impl.Persistence.TypeMarshaller m = pm.GetTypeMarshaller(c);
            if (m == null) {
                m = pm.GetTypeMarshaller(typeof(object));
            }
            return m;
        }
    }
}
