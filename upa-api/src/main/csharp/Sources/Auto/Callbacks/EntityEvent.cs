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



namespace Net.Vpc.Upa.Callbacks
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class EntityEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private Net.Vpc.Upa.Persistence.EntityExecutionContext context;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.Entity entity;

        private Net.Vpc.Upa.Package parent;

        private Net.Vpc.Upa.Package oldParent;

        private int index;

        private int oldIndex;

        private Net.Vpc.Upa.EventPhase phase;

        /**
             * actual trigger if this event is fired by a trigger
             */
        private Net.Vpc.Upa.Callbacks.Trigger trigger;

        public EntityEvent(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Package parent, int index, Net.Vpc.Upa.Package oldParent, int oldIndex, Net.Vpc.Upa.EventPhase phase) {
            this.persistenceUnit = persistenceUnit;
            this.entity = entity;
            this.parent = parent;
            this.index = index;
            this.oldParent = oldParent;
            this.oldIndex = oldIndex;
            this.phase = phase;
        }

        public EntityEvent(Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.EventPhase phase) {
            this.context = context;
            this.entity = context.GetEntity();
            this.parent = entity.GetParent();
            this.persistenceUnit = context.GetPersistenceUnit();
            this.index = -1;
            this.oldIndex = -1;
            this.phase = phase;
        }

        public virtual Net.Vpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual Net.Vpc.Upa.Callbacks.Trigger GetTrigger() {
            return trigger;
        }

        public virtual void SetTrigger(Net.Vpc.Upa.Callbacks.Trigger trigger) {
            this.trigger = trigger;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceUnit.GetPersistenceGroup();
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual Net.Vpc.Upa.Persistence.EntityExecutionContext GetContext() {
            return context;
        }

        public virtual Net.Vpc.Upa.Package GetParent() {
            return parent;
        }

        public virtual Net.Vpc.Upa.Package GetOldParent() {
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
