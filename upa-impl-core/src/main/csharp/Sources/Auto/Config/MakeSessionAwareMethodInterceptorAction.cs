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



namespace Net.TheVpc.Upa.Impl.Config
{


    /**
     * @author taha.bensalah@gmail.com on 7/6/16.
     */
    internal class MakeSessionAwareMethodInterceptorAction<T> : Net.TheVpc.Upa.Action<object> {

        private Net.TheVpc.Upa.Impl.Config.MakeSessionAwareMethodInterceptor<T> makeSessionAwareMethodInterceptor;

        private readonly Net.TheVpc.Upa.Impl.Util.PlatformMethodProxyEvent<T> @event;

        public MakeSessionAwareMethodInterceptorAction(Net.TheVpc.Upa.Impl.Config.MakeSessionAwareMethodInterceptor<T> makeSessionAwareMethodInterceptor, Net.TheVpc.Upa.Impl.Util.PlatformMethodProxyEvent<T> @event) {
            this.makeSessionAwareMethodInterceptor = makeSessionAwareMethodInterceptor;
            this.@event = @event;
        }


        public virtual object Run() {
            try {
                return @event.InvokeBase(makeSessionAwareMethodInterceptor.instance, @event.GetArguments());
            } catch (System.Exception ex) {
                throw new Net.TheVpc.Upa.Exceptions.ExecutionException(ex);
            }
        }
    }
}
