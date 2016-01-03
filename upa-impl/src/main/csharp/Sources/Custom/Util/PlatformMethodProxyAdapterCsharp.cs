using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Vpc.Upa.Impl.Util
{
    public class PlatformMethodProxyAdapterCsharp<T>
    {
        private Type type;
        private PlatformMethodProxy<T> methodProxy;
        public PlatformMethodProxyAdapterCsharp (Type type, PlatformMethodProxy<T> methodProxy){
          this.type=type;
          this.methodProxy=methodProxy;
        }
        public object Create() {
            return obj.Proxy<T>(MyInterceptorMethod);
        }

        public object MyInterceptorMethod<T>(T@object, string methodName, System.Reflection.MethodInfo method,object[] args, EmitProxyExecute<T> execute)
        {
            methodProxy.Intercept(new PlatformMethodProxyEventCsharp<T>(@object, methodName, method,args, execute));
        }
    }
}
