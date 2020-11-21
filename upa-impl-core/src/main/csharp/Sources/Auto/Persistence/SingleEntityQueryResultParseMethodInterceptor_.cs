using Net.TheVpc.Upa.Impl.Util;

namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN Salah
    * @creationdate 1/8/13 3:02 AM*/
    internal class SingleEntityQueryResultParseMethodInterceptor<R> {

//        private readonly R ret;
//
//        private readonly Net.TheVpc.Upa.Persistence.QueryResult result;
//
//        private Net.TheVpc.Upa.Impl.Persistence.SingleEntityQueryResult<R> singleEntityQueryResult;
//
//        public SingleEntityQueryResultParseMethodInterceptor(Net.TheVpc.Upa.Impl.Persistence.SingleEntityQueryResult<R> singleEntityQueryResult, R ret, Net.TheVpc.Upa.Persistence.QueryResult result) {
//            this.singleEntityQueryResult = singleEntityQueryResult;
//            this.ret = ret;
//            this.result = result;
//        }
//
//
//        public virtual R MakeAware() /* throws Net.TheVpc.Upa.Exceptions.UPAException */
//        {
//            return ret.Proxy<R>(MyInterceptorMethod);
//        }
//
//        public object MyInterceptorMethod<T>(T@object, string methodName, object[] args, EmitProxyExecute<T> execute)
//        {
//            string name = methodName;
//            Net.TheVpc.Upa.Impl.Persistence.FieldTracking prop = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Persistence.FieldTracking>(singleEntityQueryResult.setterToProp,name);
//            if (prop == null) {
//                return execute(@object, args);
//            } else {
//                result.Write<object>(prop.GetIndex(), args[0]);
//                return execute(@object, args);
//            }
//        }
    }
}
