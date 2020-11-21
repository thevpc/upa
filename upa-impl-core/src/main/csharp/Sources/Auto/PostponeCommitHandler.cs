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



namespace Net.TheVpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 1:45 AM
     */
    internal class PostponeCommitHandler : Net.TheVpc.Upa.Callbacks.DefinitionListenerAdapter, Net.TheVpc.Upa.Callbacks.EntityDefinitionListener, Net.TheVpc.Upa.Callbacks.FieldDefinitionListener, Net.TheVpc.Upa.Callbacks.SectionDefinitionListener, Net.TheVpc.Upa.Callbacks.TriggerDefinitionListener, Net.TheVpc.Upa.Callbacks.RelationshipDefinitionListener, Net.TheVpc.Upa.Callbacks.IndexDefinitionListener {

        internal PostponeCommitHandler() {
        }


        public override void OnPreCreateField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (!@event.GetPersistenceUnit().IsValidStructureModificationContext()) {
                throw new Net.TheVpc.Upa.Exceptions.InvalidStructureModificationContextException();
            }
        }


        public override void OnCreateField(Net.TheVpc.Upa.Callbacks.FieldEvent @event) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Impl.DefaultPersistenceUnit defaultPersistenceUnit = (Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) @event.GetPersistenceUnit();
            defaultPersistenceUnit.PostponeCommit(new Net.TheVpc.Upa.Impl.Persistence.DefaultOnHoldCommitAction(@event.GetField(), Net.TheVpc.Upa.Impl.OnHoldCommitActionType.CREATE, Net.TheVpc.Upa.Impl.DefaultPersistenceUnit.COMMIT_ORDER_FIELD));
        }


        public override void OnPreCreateSection(Net.TheVpc.Upa.Callbacks.SectionEvent @event) {
            if (!@event.GetPersistenceUnit().IsValidStructureModificationContext()) {
                throw new Net.TheVpc.Upa.Exceptions.InvalidStructureModificationContextException();
            }
        }


        public override void OnPreCreateTrigger(Net.TheVpc.Upa.Callbacks.TriggerEvent @event) {
        }


        public override void OnCreateTrigger(Net.TheVpc.Upa.Callbacks.TriggerEvent @event) {
            Net.TheVpc.Upa.Impl.DefaultPersistenceUnit defaultPersistenceUnit = (Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) @event.GetEntity().GetPersistenceUnit();
            defaultPersistenceUnit.PostponeCommit(new Net.TheVpc.Upa.Impl.Persistence.DefaultOnHoldCommitAction(@event.GetTrigger(), Net.TheVpc.Upa.Impl.OnHoldCommitActionType.CREATE, Net.TheVpc.Upa.Impl.DefaultPersistenceUnit.COMMIT_ORDER_TRIGGER));
        }


        public override void OnPreCreateIndex(Net.TheVpc.Upa.Callbacks.IndexEvent @event) {
            if (!@event.GetPersistenceUnit().IsValidStructureModificationContext()) {
                throw new Net.TheVpc.Upa.Exceptions.InvalidStructureModificationContextException();
            }
        }


        public override void OnCreateIndex(Net.TheVpc.Upa.Callbacks.IndexEvent @event) {
            Net.TheVpc.Upa.Impl.DefaultPersistenceUnit defaultPersistenceUnit = (Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) @event.GetPersistenceUnit();
            defaultPersistenceUnit.PostponeCommit(new Net.TheVpc.Upa.Impl.Persistence.DefaultOnHoldCommitAction(@event.GetIndex(), Net.TheVpc.Upa.Impl.OnHoldCommitActionType.CREATE, Net.TheVpc.Upa.Impl.DefaultPersistenceUnit.COMMIT_ORDER_INDEX));
        }


        public override void OnPreCreateRelationship(Net.TheVpc.Upa.Callbacks.RelationshipEvent @event) {
            if (!@event.GetPersistenceUnit().IsValidStructureModificationContext()) {
                throw new Net.TheVpc.Upa.Exceptions.InvalidStructureModificationContextException();
            }
        }


        public override void OnCreateRelationship(Net.TheVpc.Upa.Callbacks.RelationshipEvent @event) {
            Net.TheVpc.Upa.Impl.DefaultPersistenceUnit defaultPersistenceUnit = (Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) @event.GetPersistenceUnit();
            defaultPersistenceUnit.PostponeCommit(new Net.TheVpc.Upa.Impl.Persistence.DefaultOnHoldCommitAction(@event.GetRelationship(), Net.TheVpc.Upa.Impl.OnHoldCommitActionType.CREATE, Net.TheVpc.Upa.Impl.DefaultPersistenceUnit.COMMIT_ORDER_RELATION));
        }


        public override void OnPreCreateEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
            if (!@event.GetPersistenceUnit().IsValidStructureModificationContext()) {
                throw new Net.TheVpc.Upa.Exceptions.InvalidStructureModificationContextException();
            }
        }


        public override void OnCreateEntity(Net.TheVpc.Upa.Callbacks.EntityEvent @event) {
            Net.TheVpc.Upa.Impl.DefaultPersistenceUnit defaultPersistenceUnit = (Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) @event.GetPersistenceUnit();
            defaultPersistenceUnit.PostponeCommit(new Net.TheVpc.Upa.Impl.Persistence.DefaultOnHoldCommitAction(@event.GetEntity(), Net.TheVpc.Upa.Impl.OnHoldCommitActionType.CREATE, Net.TheVpc.Upa.Impl.DefaultPersistenceUnit.COMMIT_ORDER_ENTITY));
        }
    }
}
