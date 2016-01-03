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
    public class RemoveObjectEventCallback : Net.Vpc.Upa.Impl.Event.SingleEntityObjectEventCallback {

        public RemoveObjectEventCallback(object o, System.Reflection.MethodInfo m, Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, Net.Vpc.Upa.Impl.Config.Callback.MethodArgumentsConverter converter, System.Collections.Generic.IDictionary<string , object> configuration)  : base(o, m, callbackType, objectType, converter, configuration){

        }


        public override object Invoke(params object [] arguments) {
            Net.Vpc.Upa.Callbacks.RemoveEvent ev = (Net.Vpc.Upa.Callbacks.RemoveEvent) arguments[0];
            foreach (object id in ResolveIdList(ev, ev.GetFilterExpression())) {
                Net.Vpc.Upa.Callbacks.RemoveObjectEvent oe = new Net.Vpc.Upa.Callbacks.RemoveObjectEvent(id, ev.GetFilterExpression(), ev.GetContext());
                InvokeSingle(oe);
            }
            return null;
        }
    }
}
