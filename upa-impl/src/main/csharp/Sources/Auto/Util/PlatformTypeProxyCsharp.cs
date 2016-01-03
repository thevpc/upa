using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.Vpc.Upa.Impl.Util
{
    public class PlatformTypeProxyCsharp : Net.Vpc.Upa.Impl.Util.PlatformTypeProxy
    {
        public object Create<T>(Type type, PlatformMethodProxy<T> methodProxy) {
            PlatformMethodProxyAdapterCsharp<T> t=new PlatformMethodProxyAdapterCsharp<T>(type,methodProxy);
            return t.Create();
        }
    }
}
