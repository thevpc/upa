using Net.Vpc.Upa.Impl.Util;

namespace Net.Vpc.Upa.Impl.Config
{


    /**
    * @author Taha BEN Salah
    * @creationdate 1/7/13 2:32 PM*/
    internal class MakeSessionAwareMethodInterceptor<T> {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource(typeof(Net.Vpc.Upa.Impl.Config.MakeSessionAwareMethodInterceptor).FullName);
        private readonly Net.Vpc.Upa.MethodFilter methodFilter;

        private readonly T instance;

        private Net.Vpc.Upa.Impl.Config.DefaultUPAContext defaultUPAContext;

        public MakeSessionAwareMethodInterceptor(Net.Vpc.Upa.Impl.Config.DefaultUPAContext defaultUPAContext, Net.Vpc.Upa.MethodFilter methodFilter, T instance) {
            this.defaultUPAContext = defaultUPAContext;
            this.methodFilter = methodFilter;
            this.instance = instance;
        }


        public virtual T MakeSessionAware() /* throws Net.Vpc.Upa.Exceptions.UPAException */
        {
            return instance.Proxy<T>(MyInterceptorMethod);
        }

        public object MyInterceptorMethod<T>(T@object, string methodName, object[] args, EmitProxyExecute<T> execute)
        {
            if (methodFilter == null /*|| methodFilter.Accept(method)*/) {
                System.Collections.Generic.IDictionary<string,object> properties = new System.Collections.Generic.Dictionary<string,object>();
                Net.Vpc.Upa.UPAContext context = Net.Vpc.Upa.UPA.GetContext();
                context.BeginInvocation(method, properties);
                object ret = null;
                System.Exception error = null;
                try {
                    ret = execute(@object, args);
                } catch (System.Exception e) {
                    error = e;
                }
                context.EndInvocation(error, properties);
                if(error!=null){
                    throw error;
                }
                return ret;
            } else {
                return execute(@object, args);
            }
        }
    }
}
