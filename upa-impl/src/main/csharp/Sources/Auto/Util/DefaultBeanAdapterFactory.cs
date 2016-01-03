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



namespace Net.Vpc.Upa.Impl.Util
{


    /**
     *
     * @author vpc
     */
    public class DefaultBeanAdapterFactory : Net.Vpc.Upa.BeanAdapterFactory {

        public virtual Net.Vpc.Upa.BeanAdapter CreateBeanAdapter(object instance) {
            return new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(instance);
        }

        public virtual Net.Vpc.Upa.BeanAdapter CreateBeanAdapter(System.Type type) {
            return new Net.Vpc.Upa.Impl.Util.DefaultBeanAdapter(type);
        }
    }
}
