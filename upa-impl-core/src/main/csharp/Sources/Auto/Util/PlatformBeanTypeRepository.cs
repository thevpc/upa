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
     * Created by vpc on 6/11/16.
     */
    public class PlatformBeanTypeRepository {

        private static Net.Vpc.Upa.Impl.Util.PlatformBeanTypeRepository instance = new Net.Vpc.Upa.Impl.Util.PlatformBeanTypeRepository();

        private readonly System.Collections.Generic.IDictionary<System.Type , Net.Vpc.Upa.BeanType> classBeanTypeReflectorMap = new System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.BeanType>();

        public static Net.Vpc.Upa.Impl.Util.PlatformBeanTypeRepository GetInstance() {
            return instance;
        }

        public virtual Net.Vpc.Upa.BeanType GetBeanType(System.Type cls) {
            Net.Vpc.Upa.BeanType beanType = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.BeanType>(classBeanTypeReflectorMap,cls);
            if (beanType == null) {
                lock (classBeanTypeReflectorMap) {
                    beanType = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.BeanType>(classBeanTypeReflectorMap,cls);
                    if (beanType == null) {
                        beanType = new Net.Vpc.Upa.Impl.Util.DefaultBeanType(cls);
                        classBeanTypeReflectorMap[cls]=beanType;
                    }
                }
            }
            return beanType;
        }
    }
}
