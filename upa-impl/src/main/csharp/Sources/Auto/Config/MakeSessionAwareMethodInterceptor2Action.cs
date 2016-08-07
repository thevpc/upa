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
     * @author taha.bensalah@gmail.com
     */
    internal class MakeSessionAwareMethodInterceptor2Action<T> : Net.Vpc.Upa.Action<object> {

        private readonly Net.Vpc.Upa.Impl.Util.PlatformMethodProxyEvent<T> methodProxy;

        public MakeSessionAwareMethodInterceptor2Action(Net.Vpc.Upa.Impl.Util.PlatformMethodProxyEvent<T> methodProxy) {
            this.methodProxy = methodProxy;
        }

        public virtual object Run() {
            try {
                return methodProxy.InvokeBase(methodProxy.GetObject(), methodProxy.GetArguments());
            } catch (System.Exception ex) {
                throw new Net.Vpc.Upa.Exceptions.UPAException(ex, new Net.Vpc.Upa.Types.I18NString("InvokeError"));
            }
        }
    }
}
