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
    public class PersistObjectEvent : Net.Vpc.Upa.Callbacks.EntityEvent {

        private object objectId;

        private Net.Vpc.Upa.Record objectRecord;

        private object objectValue;

        public PersistObjectEvent(object objectId, Net.Vpc.Upa.Record objectRecord, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.Vpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.objectId = objectId;
            this.objectRecord = objectRecord;
        }

        public virtual object GetObjectId() {
            return objectId;
        }

        public virtual Net.Vpc.Upa.Record GetObjectRecord() {
            return objectRecord;
        }

        public virtual object GetObjectValue() {
            if (objectValue == null && objectRecord != null) {
                objectValue = GetContext().GetEntity().GetBuilder().RecordToObject<object>(objectRecord);
            }
            return objectValue;
        }
    }
}
