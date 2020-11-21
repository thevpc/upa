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



namespace Net.TheVpc.Upa.Impl.Persistence.Result
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 3:02 AM*/
    internal class UpdatableObjectInterceptor : Net.TheVpc.Upa.Impl.Util.PlatformMethodProxy<object> {

        private readonly object @object;

        private readonly Net.TheVpc.Upa.Persistence.QueryResult result;

        private Net.TheVpc.Upa.Impl.Persistence.Result.TypeInfo singleEntityQueryResult;

        public UpdatableObjectInterceptor(Net.TheVpc.Upa.Impl.Persistence.Result.TypeInfo singleEntityQueryResult, object @object, Net.TheVpc.Upa.Persistence.QueryResult result) {
            this.singleEntityQueryResult = singleEntityQueryResult;
            this.@object = @object;
            this.result = result;
        }


        public virtual object Intercept(Net.TheVpc.Upa.Impl.Util.PlatformMethodProxyEvent<object> @event) /* throws System.Exception */  {
            string name = @event.GetMethodName();
            Net.TheVpc.Upa.Impl.Persistence.Result.FieldInfo prop = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Persistence.Result.FieldInfo>(singleEntityQueryResult.fields,name);
            if (prop == null) {
                return @event.InvokeBase(@object, @event.GetArguments());
            } else {
                result.Write<object>(prop.dbIndex, @event.GetArguments()[0]);
                return @event.InvokeBase(@object, @event.GetArguments());
            }
        }
    }
}
