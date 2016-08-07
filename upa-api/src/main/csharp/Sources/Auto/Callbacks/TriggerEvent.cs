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



namespace Net.Vpc.Upa.Callbacks
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 11/27/12 9:52 PM
     */
    public class TriggerEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private Net.Vpc.Upa.Entity entity;

        private Net.Vpc.Upa.Callbacks.Trigger trigger;

        private Net.Vpc.Upa.EventPhase phase;

        public TriggerEvent(Net.Vpc.Upa.Callbacks.Trigger trigger, Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.EventPhase phase) {
            this.entity = entity;
            this.trigger = trigger;
            this.phase = phase;
        }

        public virtual Net.Vpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual Net.Vpc.Upa.Callbacks.Trigger GetTrigger() {
            return trigger;
        }
    }
}
