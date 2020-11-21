/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:52 PM
     */
    public class TriggerEvent : Net.TheVpc.Upa.Callbacks.UPAEvent {

        private Net.TheVpc.Upa.Entity entity;

        private Net.TheVpc.Upa.Callbacks.Trigger trigger;

        private Net.TheVpc.Upa.EventPhase phase;

        public TriggerEvent(Net.TheVpc.Upa.Callbacks.Trigger trigger, Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.EventPhase phase) {
            this.entity = entity;
            this.trigger = trigger;
            this.phase = phase;
        }

        public virtual Net.TheVpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual Net.TheVpc.Upa.Callbacks.Trigger GetTrigger() {
            return trigger;
        }
    }
}
