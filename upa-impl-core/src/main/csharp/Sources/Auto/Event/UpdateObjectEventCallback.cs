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
    public class UpdateObjectEventCallback : Net.TheVpc.Upa.Impl.Event.SingleEntityObjectEventCallback {

        public UpdateObjectEventCallback(object o, System.Reflection.MethodInfo m, Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.EventPhase phase, Net.TheVpc.Upa.ObjectType objectType, Net.TheVpc.Upa.Impl.Config.Callback.MethodArgumentsConverter converter, System.Collections.Generic.IDictionary<string , object> configuration)  : base(o, m, callbackType, phase, objectType, converter, configuration){

        }


        public override void Prepare(Net.TheVpc.Upa.Callbacks.UPAEvent @event) {
            Net.TheVpc.Upa.Callbacks.UpdateEvent ev = (Net.TheVpc.Upa.Callbacks.UpdateEvent) @event;
            ResolveIdList(ev, ev.GetFilterExpression());
        }


        public override object Invoke(params object [] arguments) {
            Net.TheVpc.Upa.Callbacks.UpdateEvent ev = (Net.TheVpc.Upa.Callbacks.UpdateEvent) arguments[0];
            foreach (object id in ResolveIdList(ev, ev.GetFilterExpression())) {
                Net.TheVpc.Upa.Record updatesRecord = ev.GetUpdatesRecord().Copy();
                ev.GetEntity().GetBuilder().SetObjectId(updatesRecord, id);
                Net.TheVpc.Upa.Callbacks.UpdateObjectEvent oe = new Net.TheVpc.Upa.Callbacks.UpdateObjectEvent(id, updatesRecord, ev.GetFilterExpression(), ev.GetContext(), GetPhase());
                InvokeSingle(oe);
            }
            return null;
        }
    }
}
