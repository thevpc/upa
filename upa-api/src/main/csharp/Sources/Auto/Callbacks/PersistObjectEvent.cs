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
    public class PersistObjectEvent : Net.Vpc.Upa.Callbacks.EntityEvent {

        private object objectId;

        private Net.Vpc.Upa.Document objectDocument;

        private object objectValue;

        public PersistObjectEvent(object objectId, Net.Vpc.Upa.Document objectDocument, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.Vpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.objectId = objectId;
            this.objectDocument = objectDocument;
        }

        public virtual object GetObjectId() {
            return objectId;
        }

        public virtual Net.Vpc.Upa.Document GetObjectDocument() {
            return objectDocument;
        }

        public virtual object GetObjectValue() {
            if (objectValue == null && objectDocument != null) {
                objectValue = GetContext().GetEntity().GetBuilder().DocumentToObject<>(objectDocument);
            }
            return objectValue;
        }
    }
}
