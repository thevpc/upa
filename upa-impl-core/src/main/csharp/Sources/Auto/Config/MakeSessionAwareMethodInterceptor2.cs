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



namespace Net.Vpc.Upa.Impl.Config
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/7/13 2:32 PM
     */
    internal class MakeSessionAwareMethodInterceptor2<T> : Net.Vpc.Upa.Impl.Util.PlatformMethodProxy<T> {

        private readonly Net.Vpc.Upa.MethodFilter methodFilter;

        public MakeSessionAwareMethodInterceptor2(Net.Vpc.Upa.MethodFilter methodFilter) {
            this.methodFilter = methodFilter;
        }


        public virtual object Intercept(Net.Vpc.Upa.Impl.Util.PlatformMethodProxyEvent<T> @event) /* throws System.Exception */  {
            if (methodFilter == null || methodFilter.Accept(@event.GetMethod())) {
                return Net.Vpc.Upa.UPA.GetContext().Invoke<object>(new Net.Vpc.Upa.Impl.Config.MakeSessionAwareMethodInterceptor2Action<T>(@event), null);
            } else {
                return @event.InvokeBase(@event.GetObject(), @event.GetArguments());
            }
        }
    }
}
