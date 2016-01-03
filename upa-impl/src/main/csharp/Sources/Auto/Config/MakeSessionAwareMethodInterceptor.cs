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
    public class MakeSessionAwareMethodInterceptor<T> : Net.Vpc.Upa.Impl.Util.PlatformMethodProxy<T> {

        private readonly Net.Vpc.Upa.MethodFilter methodFilter;

        private readonly T instance;

        private Net.Vpc.Upa.Impl.Config.DefaultUPAContext defaultUPAContext;

        private static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(System.Type)).FullName);

        public MakeSessionAwareMethodInterceptor(Net.Vpc.Upa.Impl.Config.DefaultUPAContext defaultUPAContext, Net.Vpc.Upa.MethodFilter methodFilter, T instance) {
            this.defaultUPAContext = defaultUPAContext;
            this.methodFilter = methodFilter;
            this.instance = instance;
        }


        public virtual object Intercept(Net.Vpc.Upa.Impl.Util.PlatformMethodProxyEvent<T> @event) /* throws System.Exception */  {
            if (methodFilter == null || methodFilter.Accept(@event.GetMethod())) {
                System.Collections.Generic.Dictionary<string , object> properties = new System.Collections.Generic.Dictionary<string , object>();
                Net.Vpc.Upa.UPAContext context = Net.Vpc.Upa.UPA.GetContext();
                context.BeginInvocation(@event.GetMethod(), properties);
                object ret = null;
                System.Exception error = null;
                try {
                    ret = @event.InvokeBase(instance, @event.GetArguments());
                } catch (System.Exception e) {
                    error = e;
                }
                context.EndInvocation(error, properties);
                if (error != null) {
                    throw error;
                }
                return ret;
            } else {
                return @event.InvokeBase(instance, @event.GetArguments());
            }
        }
    }
}
