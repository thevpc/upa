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
     * Created by vpc on 6/11/16.
     */
    public class PlatformBeanTypeRepository {

        private static Net.TheVpc.Upa.Impl.Util.PlatformBeanTypeRepository instance = new Net.TheVpc.Upa.Impl.Util.PlatformBeanTypeRepository();

        private readonly System.Collections.Generic.IDictionary<System.Type , Net.TheVpc.Upa.BeanType> classBeanTypeReflectorMap = new System.Collections.Generic.Dictionary<System.Type , Net.TheVpc.Upa.BeanType>();

        public static Net.TheVpc.Upa.Impl.Util.PlatformBeanTypeRepository GetInstance() {
            return instance;
        }

        public virtual Net.TheVpc.Upa.BeanType GetBeanType(System.Type cls) {
            Net.TheVpc.Upa.BeanType beanType = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.TheVpc.Upa.BeanType>(classBeanTypeReflectorMap,cls);
            if (beanType == null) {
                lock (classBeanTypeReflectorMap) {
                    beanType = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.TheVpc.Upa.BeanType>(classBeanTypeReflectorMap,cls);
                    if (beanType == null) {
                        beanType = new Net.TheVpc.Upa.Impl.Util.DefaultBeanType(cls);
                        classBeanTypeReflectorMap[cls]=beanType;
                    }
                }
            }
            return beanType;
        }
    }
}
