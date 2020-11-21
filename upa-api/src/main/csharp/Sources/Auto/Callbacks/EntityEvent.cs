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
     *
     * @author taha.bensalah@gmail.com
     */
    public class EntityEvent : Net.TheVpc.Upa.Callbacks.UPAEvent {

        private Net.TheVpc.Upa.Persistence.EntityExecutionContext context;

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private Net.TheVpc.Upa.Entity entity;

        private Net.TheVpc.Upa.Package parent;

        private Net.TheVpc.Upa.Package oldParent;

        private int index;

        private int oldIndex;

        private Net.TheVpc.Upa.EventPhase phase;

        /**
             * actual trigger if this event is fired by a trigger
             */
        private Net.TheVpc.Upa.Callbacks.Trigger trigger;

        public EntityEvent(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.Package parent, int index, Net.TheVpc.Upa.Package oldParent, int oldIndex, Net.TheVpc.Upa.EventPhase phase) {
            this.persistenceUnit = persistenceUnit;
            this.entity = entity;
            this.parent = parent;
            this.index = index;
            this.oldParent = oldParent;
            this.oldIndex = oldIndex;
            this.phase = phase;
        }

        public EntityEvent(Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.EventPhase phase) {
            this.context = context;
            this.entity = context.GetEntity();
            this.parent = entity.GetParent();
            this.persistenceUnit = context.GetPersistenceUnit();
            this.index = -1;
            this.oldIndex = -1;
            this.phase = phase;
        }

        public virtual Net.TheVpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual Net.TheVpc.Upa.Callbacks.Trigger GetTrigger() {
            return trigger;
        }

        public virtual void SetTrigger(Net.TheVpc.Upa.Callbacks.Trigger trigger) {
            this.trigger = trigger;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceUnit.GetPersistenceGroup();
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityExecutionContext GetContext() {
            return context;
        }

        public virtual Net.TheVpc.Upa.Package GetParent() {
            return parent;
        }

        public virtual Net.TheVpc.Upa.Package GetOldParent() {
            return oldParent;
        }

        public virtual int GetIndex() {
            return index;
        }

        public virtual int GetOldIndex() {
            return oldIndex;
        }
    }
}
