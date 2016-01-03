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



namespace Net.Vpc.Upa.Impl
{


    /**
     *
     * @author vpc
     */
    public class Test {

        public virtual  T MakeSessionAware<T>(T instance, Net.Vpc.Upa.MethodFilter methodFilter) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return (T) Net.Vpc.Upa.Impl.Util.PlatformUtils.CreateObjectInterceptor<T>((System.Type) instance.GetType(), new Net.Vpc.Upa.Impl.Config.MakeSessionAwareMethodInterceptor<T>(null, methodFilter, instance));
        }
    }
}
