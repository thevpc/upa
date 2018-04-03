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
    public class PersistEvent : Net.Vpc.Upa.Callbacks.EntityEvent {

        private object persistedId;

        private Net.Vpc.Upa.Document persistedDocument;

        private object persistedObject;

        public PersistEvent(object persistedId, Net.Vpc.Upa.Document persistedDocument, Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.Vpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.persistedId = persistedId;
            this.persistedDocument = persistedDocument;
        }

        public virtual object GetPersistedId() {
            return persistedId;
        }

        public virtual Net.Vpc.Upa.Document GetPersistedDocument() {
            return persistedDocument;
        }

        public virtual object GetPersistedObject() {
            if (persistedObject == null && persistedDocument != null) {
                persistedObject = GetContext().GetEntity().GetBuilder().DocumentToObject<>(persistedDocument);
            }
            return persistedObject;
        }
    }
}
