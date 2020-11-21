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
    public class PersistEvent : Net.TheVpc.Upa.Callbacks.EntityEvent {

        private object persistedId;

        private Net.TheVpc.Upa.Document persistedDocument;

        private object persistedObject;

        public PersistEvent(object persistedId, Net.TheVpc.Upa.Document persistedDocument, Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext, Net.TheVpc.Upa.EventPhase phase)  : base(entityExecutionContext, phase){

            this.persistedId = persistedId;
            this.persistedDocument = persistedDocument;
        }

        public virtual object GetPersistedId() {
            return persistedId;
        }

        public virtual Net.TheVpc.Upa.Document GetPersistedDocument() {
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
