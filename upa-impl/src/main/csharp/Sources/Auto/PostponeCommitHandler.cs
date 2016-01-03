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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 1:45 AM
     */
    internal class PostponeCommitHandler : Net.Vpc.Upa.Callbacks.DefinitionListenerAdapter {

        internal PostponeCommitHandler() {
        }


        public override void OnPreCreateField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (!@event.GetPersistenceUnit().IsValidStructureModificationContext()) {
                throw new Net.Vpc.Upa.Exceptions.InvalidStructureModificationContextException();
            }
        }


        public override void OnCreateField(Net.Vpc.Upa.Callbacks.FieldEvent @event) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Impl.DefaultPersistenceUnit defaultPersistenceUnit = (Net.Vpc.Upa.Impl.DefaultPersistenceUnit) @event.GetPersistenceUnit();
            defaultPersistenceUnit.PostponeCommit(new Net.Vpc.Upa.Impl.Persistence.DefaultOnHoldCommitAction(@event.GetField(), Net.Vpc.Upa.Impl.OnHoldCommitActionType.CREATE, Net.Vpc.Upa.Impl.DefaultPersistenceUnit.COMMIT_ORDER_FIELD));
        }


        public override void OnPreCreateSection(Net.Vpc.Upa.Callbacks.SectionEvent @event) {
            if (!@event.GetPersistenceUnit().IsValidStructureModificationContext()) {
                throw new Net.Vpc.Upa.Exceptions.InvalidStructureModificationContextException();
            }
        }


        public override void OnPreCreateTrigger(Net.Vpc.Upa.Callbacks.TriggerEvent @event) {
        }


        public override void OnCreateTrigger(Net.Vpc.Upa.Callbacks.TriggerEvent @event) {
            Net.Vpc.Upa.Impl.DefaultPersistenceUnit defaultPersistenceUnit = (Net.Vpc.Upa.Impl.DefaultPersistenceUnit) @event.GetEntity().GetPersistenceUnit();
            defaultPersistenceUnit.PostponeCommit(new Net.Vpc.Upa.Impl.Persistence.DefaultOnHoldCommitAction(@event.GetTrigger(), Net.Vpc.Upa.Impl.OnHoldCommitActionType.CREATE, Net.Vpc.Upa.Impl.DefaultPersistenceUnit.COMMIT_ORDER_TRIGGER));
        }


        public override void OnPreCreateIndex(Net.Vpc.Upa.Callbacks.IndexEvent @event) {
            if (!@event.GetPersistenceUnit().IsValidStructureModificationContext()) {
                throw new Net.Vpc.Upa.Exceptions.InvalidStructureModificationContextException();
            }
        }


        public override void OnCreateIndex(Net.Vpc.Upa.Callbacks.IndexEvent @event) {
            Net.Vpc.Upa.Impl.DefaultPersistenceUnit defaultPersistenceUnit = (Net.Vpc.Upa.Impl.DefaultPersistenceUnit) @event.GetPersistenceUnit();
            defaultPersistenceUnit.PostponeCommit(new Net.Vpc.Upa.Impl.Persistence.DefaultOnHoldCommitAction(@event.GetIndex(), Net.Vpc.Upa.Impl.OnHoldCommitActionType.CREATE, Net.Vpc.Upa.Impl.DefaultPersistenceUnit.COMMIT_ORDER_INDEX));
        }


        public override void OnPreCreateRelationship(Net.Vpc.Upa.Callbacks.RelationshipEvent @event) {
            if (!@event.GetPersistenceUnit().IsValidStructureModificationContext()) {
                throw new Net.Vpc.Upa.Exceptions.InvalidStructureModificationContextException();
            }
        }


        public override void OnCreateRelationship(Net.Vpc.Upa.Callbacks.RelationshipEvent @event) {
            Net.Vpc.Upa.Impl.DefaultPersistenceUnit defaultPersistenceUnit = (Net.Vpc.Upa.Impl.DefaultPersistenceUnit) @event.GetPersistenceUnit();
            defaultPersistenceUnit.PostponeCommit(new Net.Vpc.Upa.Impl.Persistence.DefaultOnHoldCommitAction(@event.GetRelationship(), Net.Vpc.Upa.Impl.OnHoldCommitActionType.CREATE, Net.Vpc.Upa.Impl.DefaultPersistenceUnit.COMMIT_ORDER_RELATION));
        }


        public override void OnPreCreateEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
            if (!@event.GetPersistenceUnit().IsValidStructureModificationContext()) {
                throw new Net.Vpc.Upa.Exceptions.InvalidStructureModificationContextException();
            }
        }


        public override void OnCreateEntity(Net.Vpc.Upa.Callbacks.EntityEvent @event) {
            Net.Vpc.Upa.Impl.DefaultPersistenceUnit defaultPersistenceUnit = (Net.Vpc.Upa.Impl.DefaultPersistenceUnit) @event.GetPersistenceUnit();
            defaultPersistenceUnit.PostponeCommit(new Net.Vpc.Upa.Impl.Persistence.DefaultOnHoldCommitAction(@event.GetEntity(), Net.Vpc.Upa.Impl.OnHoldCommitActionType.CREATE, Net.Vpc.Upa.Impl.DefaultPersistenceUnit.COMMIT_ORDER_ENTITY));
        }
    }
}
