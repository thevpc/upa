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



namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class DefaultBeanAdapterFactory : Net.TheVpc.Upa.BeanAdapterFactory {

        public virtual Net.TheVpc.Upa.BeanAdapter CreateBeanAdapter(object instance) {
            return new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(instance);
        }

        public virtual Net.TheVpc.Upa.BeanAdapter CreateBeanAdapter(System.Type type) {
            return new Net.TheVpc.Upa.Impl.Util.DefaultBeanAdapter(type);
        }
    }
}
