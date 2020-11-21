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
     * @creationdate 12/20/12 2:49 AM
     */
    public class NumberDataMarshallerFactory : Net.TheVpc.Upa.Impl.Persistence.TypeMarshallerFactory {

        public NumberDataMarshallerFactory() {
        }

        private Net.TheVpc.Upa.Impl.Persistence.MarshallManager pm;


        public virtual void SetMarshallManager(Net.TheVpc.Upa.Impl.Persistence.MarshallManager pm) {
            this.pm = pm;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller CreateTypeMarshaller(Net.TheVpc.Upa.Types.DataType type) {
            Net.TheVpc.Upa.Types.NumberType n = (Net.TheVpc.Upa.Types.NumberType) type;
            System.Type c = n.GetPlatformType();
            Net.TheVpc.Upa.Impl.Persistence.TypeMarshaller m = pm.GetTypeMarshaller(c);
            if (m == null) {
                m = pm.GetTypeMarshaller(typeof(object));
            }
            return m;
        }
    }
}
