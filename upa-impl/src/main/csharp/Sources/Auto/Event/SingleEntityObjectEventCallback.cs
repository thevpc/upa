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



namespace Net.Vpc.Upa.Impl.Event
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public abstract class SingleEntityObjectEventCallback : Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback, Net.Vpc.Upa.PreparedCallback {

        public SingleEntityObjectEventCallback(object o, System.Reflection.MethodInfo m, Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.EventPhase phase, Net.Vpc.Upa.ObjectType objectType, Net.Vpc.Upa.Impl.Config.Callback.MethodArgumentsConverter converter, System.Collections.Generic.IDictionary<string , object> configuration)  : base(o, m, callbackType, phase, objectType, converter, configuration){

        }

        protected internal virtual void InvokeSingle(Net.Vpc.Upa.Callbacks.EntityEvent singleEvent) {
            try {
                method.Invoke(instance, converter.Convert(new object[] { singleEvent }));
            } catch (System.Exception ex) {
                throw Net.Vpc.Upa.Impl.Util.PlatformUtils.CreateRuntimeException(ex);
            }
        }

        public static System.Collections.Generic.IList<object> ResolveIdListUtility(Net.Vpc.Upa.Callbacks.EntityEvent @event, Net.Vpc.Upa.Expressions.Expression whereExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            if (whereExpression is Net.Vpc.Upa.Expressions.IdExpression) {
                object id = ((Net.Vpc.Upa.Expressions.IdExpression) whereExpression).GetId();
                return id == null ? new System.Collections.Generic.List<object>() : new System.Collections.Generic.List<object>(new[]{id});
            } else {
                if (!executionContext.IsSet("ALL_IDS")) {
                    if (@event.GetPhase() == Net.Vpc.Upa.EventPhase.AFTER) {
                        throw new Net.Vpc.Upa.Exceptions.UPAException("SingleEntityEventCalledInPostProcessButNeverInPreProcess");
                    }
                    System.Collections.Generic.IList<object> idList = @event.GetEntity().CreateQueryBuilder().ByExpression(whereExpression).GetIdList<K>();
                    executionContext.SetObject("ALL_IDS", idList);
                }
                return (System.Collections.Generic.IList<object>) executionContext.GetObject<T>("ALL_IDS");
            }
        }

        protected internal virtual System.Collections.Generic.IList<object> ResolveIdList(Net.Vpc.Upa.Callbacks.EntityEvent @event, Net.Vpc.Upa.Expressions.Expression whereExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return ResolveIdListUtility(@event, whereExpression);
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Prepare(Net.Vpc.Upa.Callbacks.UPAEvent arg1);
    }
}
