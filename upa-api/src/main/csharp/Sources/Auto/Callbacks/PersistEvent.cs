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
     *
     * @author taha.bensalah@gmail.com
     */
    public class PersistEvent : Net.Vpc.Upa.Callbacks.EntityEvent {

        private object persistedId;

        private Net.Vpc.Upa.Record persistedRecord;

        private object persistedObject;

        public PersistEvent(object persistedId, Net.Vpc.Upa.Record persistedRecord, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.Vpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.persistedId = persistedId;
            this.persistedRecord = persistedRecord;
        }

        public virtual object GetPersistedId() {
            return persistedId;
        }

        public virtual Net.Vpc.Upa.Record GetPersistedRecord() {
            return persistedRecord;
        }

        public virtual object GetPersistedObject() {
            if (persistedObject == null && persistedRecord != null) {
                persistedObject = GetContext().GetEntity().GetBuilder().RecordToObject<object>(persistedRecord);
            }
            return persistedObject;
        }
    }
}
