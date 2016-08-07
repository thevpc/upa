using Net.Vpc.Upa.Impl.Util;

namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN Salah
    * @creationdate 1/8/13 3:02 AM*/
    internal class SingleEntityQueryResultParseMethodInterceptor<R> {

//        private readonly R ret;
//
//        private readonly Net.Vpc.Upa.Persistence.QueryResult result;
//
//        private Net.Vpc.Upa.Impl.Persistence.SingleEntityQueryResult<R> singleEntityQueryResult;
//
//        public SingleEntityQueryResultParseMethodInterceptor(Net.Vpc.Upa.Impl.Persistence.SingleEntityQueryResult<R> singleEntityQueryResult, R ret, Net.Vpc.Upa.Persistence.QueryResult result) {
//            this.singleEntityQueryResult = singleEntityQueryResult;
//            this.ret = ret;
//            this.result = result;
//        }
//
//
//        public virtual R MakeAware() /* throws Net.Vpc.Upa.Exceptions.UPAException */
//        {
//            return ret.Proxy<R>(MyInterceptorMethod);
//        }
//
//        public object MyInterceptorMethod<T>(T@object, string methodName, object[] args, EmitProxyExecute<T> execute)
//        {
//            string name = methodName;
//            Net.Vpc.Upa.Impl.Persistence.FieldTracking prop = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Persistence.FieldTracking>(singleEntityQueryResult.setterToProp,name);
//            if (prop == null) {
//                return execute(@object, args);
//            } else {
//                result.Write<object>(prop.GetIndex(), args[0]);
//                return execute(@object, args);
//            }
//        }
    }
}
