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
    public class FieldEvent : Net.Vpc.Upa.Callbacks.UPAEvent {

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private int index;

        private int oldIndex;

        private Net.Vpc.Upa.Field field;

        private Net.Vpc.Upa.Entity entity;

        private Net.Vpc.Upa.EntityPart parent;

        private Net.Vpc.Upa.EntityPart oldParent;

        private Net.Vpc.Upa.EventPhase phase;

        public FieldEvent(Net.Vpc.Upa.Field field, Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.EntityPart parent, int index, Net.Vpc.Upa.EntityPart oldParent, int oldIndex, Net.Vpc.Upa.EventPhase phase) {
            this.persistenceUnit = persistenceUnit;
            this.field = field;
            this.parent = parent;
            this.index = index;
            this.oldParent = oldParent;
            this.oldIndex = oldIndex;
            this.entity = entity;
            this.phase = phase;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual int GetIndex() {
            return index;
        }

        public virtual int GetOldIndex() {
            return oldIndex;
        }

        public virtual Net.Vpc.Upa.Field GetField() {
            return field;
        }

        public virtual Net.Vpc.Upa.EntityPart GetParent() {
            return parent;
        }

        public virtual Net.Vpc.Upa.EntityPart GetOldParent() {
            return oldParent;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual Net.Vpc.Upa.EventPhase GetPhase() {
            return phase;
        }
    }
}
