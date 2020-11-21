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
    public class PersistObjectEvent : Net.TheVpc.Upa.Callbacks.EntityEvent {

        private object objectId;

        private Net.TheVpc.Upa.Document objectDocument;

        private object objectValue;

        public PersistObjectEvent(object objectId, Net.TheVpc.Upa.Document objectDocument, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.TheVpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.objectId = objectId;
            this.objectDocument = objectDocument;
        }

        public virtual object GetObjectId() {
            return objectId;
        }

        public virtual Net.TheVpc.Upa.Document GetObjectDocument() {
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
