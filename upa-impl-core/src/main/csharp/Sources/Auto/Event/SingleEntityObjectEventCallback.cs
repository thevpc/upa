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



namespace Net.TheVpc.Upa.Impl.Event
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public abstract class SingleEntityObjectEventCallback : Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback, Net.TheVpc.Upa.PreparedCallback {

        public SingleEntityObjectEventCallback(object o, System.Reflection.MethodInfo m, Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.EventPhase phase, Net.TheVpc.Upa.ObjectType objectType, Net.TheVpc.Upa.Impl.Config.Callback.MethodArgumentsConverter converter, System.Collections.Generic.IDictionary<string , object> configuration)  : base(o, m, callbackType, phase, objectType, converter, configuration){

        }

        protected internal virtual void InvokeSingle(Net.TheVpc.Upa.Callbacks.EntityEvent singleEvent) {
            try {
                method.Invoke(instance, converter.Convert(new object[] { singleEvent }));
            } catch (System.Exception ex) {
                throw Net.TheVpc.Upa.Impl.Util.PlatformUtils.CreateRuntimeException(ex);
            }
        }

        public static System.Collections.Generic.IList<object> ResolveIdListUtility(Net.TheVpc.Upa.Callbacks.EntityEvent @event, Net.TheVpc.Upa.Expressions.Expression whereExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            if (whereExpression is Net.TheVpc.Upa.Expressions.IdExpression) {
                object id = ((Net.TheVpc.Upa.Expressions.IdExpression) whereExpression).GetId();
                return id == null ? new System.Collections.Generic.List<object>() : new System.Collections.Generic.List<object>(new[]{id});
            } else {
                if (!executionContext.IsSet("ALL_IDS")) {
                    if (@event.GetPhase() == Net.TheVpc.Upa.EventPhase.AFTER) {
                        throw new Net.TheVpc.Upa.Exceptions.UPAException("SingleEntityEventCalledInPostProcessButNeverInPreProcess");
                    }
                    System.Collections.Generic.IList<object> idList = @event.GetEntity().CreateQueryBuilder().ByExpression(whereExpression).GetIdList<K>();
                    executionContext.SetObject("ALL_IDS", idList);
                }
                return (System.Collections.Generic.IList<object>) executionContext.GetObject<T>("ALL_IDS");
            }
        }

        protected internal virtual System.Collections.Generic.IList<object> ResolveIdList(Net.TheVpc.Upa.Callbacks.EntityEvent @event, Net.TheVpc.Upa.Expressions.Expression whereExpression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            return ResolveIdListUtility(@event, whereExpression);
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Prepare(Net.TheVpc.Upa.Callbacks.UPAEvent arg1);
    }
}
