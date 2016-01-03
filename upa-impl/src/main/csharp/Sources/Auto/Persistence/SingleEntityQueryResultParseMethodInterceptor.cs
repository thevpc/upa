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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 3:02 AM*/
    internal class SingleEntityQueryResultParseMethodInterceptor : Net.Vpc.Upa.Impl.Util.PlatformMethodProxy<object> {

        private readonly object ret;

        private readonly Net.Vpc.Upa.Persistence.QueryResult result;

        private Net.Vpc.Upa.Impl.Persistence.TypeInfo singleEntityQueryResult;

        public SingleEntityQueryResultParseMethodInterceptor(Net.Vpc.Upa.Impl.Persistence.TypeInfo singleEntityQueryResult, object ret, Net.Vpc.Upa.Persistence.QueryResult result) {
            this.singleEntityQueryResult = singleEntityQueryResult;
            this.ret = ret;
            this.result = result;
        }


        public virtual object Intercept(Net.Vpc.Upa.Impl.Util.PlatformMethodProxyEvent<object> @event) /* throws System.Exception */  {
            string name = @event.GetMethodName();
            Net.Vpc.Upa.Impl.Persistence.FieldInfo prop = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Persistence.FieldInfo>(singleEntityQueryResult.setterToProp,name);
            if (prop == null) {
                return @event.InvokeBase(ret, @event.GetArguments());
            } else {
                result.Write<object>(prop.index, @event.GetArguments()[0]);
                return @event.InvokeBase(ret, @event.GetArguments());
            }
        }
    }
}
