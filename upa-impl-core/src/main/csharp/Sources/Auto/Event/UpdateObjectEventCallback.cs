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
    public class UpdateObjectEventCallback : Net.Vpc.Upa.Impl.Event.SingleEntityObjectEventCallback {

        public UpdateObjectEventCallback(object o, System.Reflection.MethodInfo m, Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.EventPhase phase, Net.Vpc.Upa.ObjectType objectType, Net.Vpc.Upa.Impl.Config.Callback.MethodArgumentsConverter converter, System.Collections.Generic.IDictionary<string , object> configuration)  : base(o, m, callbackType, phase, objectType, converter, configuration){

        }


        public override void Prepare(Net.Vpc.Upa.Callbacks.UPAEvent @event) {
            Net.Vpc.Upa.Callbacks.UpdateEvent ev = (Net.Vpc.Upa.Callbacks.UpdateEvent) @event;
            ResolveIdList(ev, ev.GetFilterExpression());
        }


        public override object Invoke(params object [] arguments) {
            Net.Vpc.Upa.Callbacks.UpdateEvent ev = (Net.Vpc.Upa.Callbacks.UpdateEvent) arguments[0];
            foreach (object id in ResolveIdList(ev, ev.GetFilterExpression())) {
                Net.Vpc.Upa.Record updatesRecord = ev.GetUpdatesRecord().Copy();
                ev.GetEntity().GetBuilder().SetObjectId(updatesRecord, id);
                Net.Vpc.Upa.Callbacks.UpdateObjectEvent oe = new Net.Vpc.Upa.Callbacks.UpdateObjectEvent(id, updatesRecord, ev.GetFilterExpression(), ev.GetContext(), GetPhase());
                InvokeSingle(oe);
            }
            return null;
        }
    }
}
