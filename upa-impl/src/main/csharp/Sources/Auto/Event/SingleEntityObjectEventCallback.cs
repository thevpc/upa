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
     * @author vpc
     */
    public abstract class SingleEntityObjectEventCallback : Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback {

        public SingleEntityObjectEventCallback(object o, System.Reflection.MethodInfo m, Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, Net.Vpc.Upa.Impl.Config.Callback.MethodArgumentsConverter converter, System.Collections.Generic.IDictionary<string , object> configuration)  : base(o, m, callbackType, objectType, converter, configuration){

        }

        protected internal virtual void InvokeSingle(Net.Vpc.Upa.Callbacks.EntityEvent singleEvent) {
            try {
                method.Invoke(instance, converter.Convert(new object[] { singleEvent }));
            } catch (System.Exception e) {
                throw new System.ArgumentException ("IllegalArgumentException", e);
            } catch (System.Exception e) {
                throw new System.ArgumentException ("IllegalArgumentException", e);
            }
        }

        protected internal virtual System.Collections.Generic.IEnumerable<object> ResolveIdList(Net.Vpc.Upa.Callbacks.EntityEvent @event, Net.Vpc.Upa.Expressions.Expression whereExpression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext = @event.GetContext();
            if (whereExpression is Net.Vpc.Upa.Impl.Uql.Expression.KeyExpression) {
                return new System.Collections.Generic.List<object>(new[]{((Net.Vpc.Upa.Impl.Uql.Expression.KeyExpression) whereExpression).GetKey()});
            } else {
                if (!executionContext.IsSet("ALL_KEYS")) {
                    System.Collections.Generic.IList<object> idList = @event.GetEntity().CreateQueryBuilder().SetExpression(whereExpression).GetIdList<object>();
                    executionContext.SetObject("ALL_KEYS", idList);
                }
                return (System.Collections.Generic.IList<object>) executionContext.GetObject<System.Collections.Generic.IList<object>>("ALL_KEYS");
            }
        }
    }
}
