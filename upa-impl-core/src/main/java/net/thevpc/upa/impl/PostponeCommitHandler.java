package net.thevpc.upa.impl;

import net.thevpc.upa.impl.ext.PersistenceUnitExt;
import net.thevpc.upa.impl.persistence.DefaultOnHoldCommitAction;
import net.thevpc.upa.impl.persistence.DefaultOnHoldCommitActionEntity;
import net.thevpc.upa.impl.persistence.DefaultOnHoldCommitActionRelationship;
import net.thevpc.upa.events.SectionDefinitionListener;
import net.thevpc.upa.events.TriggerEvent;
import net.thevpc.upa.events.FieldDefinitionListener;
import net.thevpc.upa.events.FieldEvent;
import net.thevpc.upa.events.RelationshipEvent;
import net.thevpc.upa.events.IndexEvent;
import net.thevpc.upa.events.IndexDefinitionListener;
import net.thevpc.upa.events.EntityEvent;
import net.thevpc.upa.events.EntityDefinitionListener;
import net.thevpc.upa.events.TriggerDefinitionListener;
import net.thevpc.upa.events.SectionEvent;
import net.thevpc.upa.events.RelationshipDefinitionListener;
import net.thevpc.upa.events.DefinitionListenerAdapter;
import net.thevpc.upa.exceptions.InvalidStructureModificationContextException;
import net.thevpc.upa.exceptions.UPAException;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/8/13 1:45 AM
 */
class PostponeCommitHandler extends DefinitionListenerAdapter implements
        EntityDefinitionListener,
        FieldDefinitionListener,
        SectionDefinitionListener,
        TriggerDefinitionListener,
        RelationshipDefinitionListener,
        IndexDefinitionListener {

    PostponeCommitHandler() {
    }

    @Override
    public void onPreCreateField(FieldEvent event) throws UPAException {
        if (!event.getPersistenceUnit().isValidStructureModificationContext()) {
            throw new InvalidStructureModificationContextException();
        }
    }

    @Override
    public void onCreateField(FieldEvent event) throws UPAException {
        PersistenceUnitExt defaultPersistenceUnit = (PersistenceUnitExt) event.getPersistenceUnit();
        defaultPersistenceUnit.postponeCommit(new DefaultOnHoldCommitAction(event.getField(), OnHoldCommitActionType.CREATE, DefaultPersistenceUnit.COMMIT_ORDER_FIELD));
    }


    @Override
    public void onPreCreateSection(SectionEvent event) {
        if (!event.getPersistenceUnit().isValidStructureModificationContext()) {
            throw new InvalidStructureModificationContextException();
        }
    }


    @Override
    public void onPreCreateTrigger(TriggerEvent event) {
        //check if event.getTrigger is persistentTrigger!
//        if (!event.getEntity().getPersistenceUnit().isValidStructureModificationContext()) {
//            throw new InvalidStructureModificationContextException();
//        }
    }

    @Override
    public void onCreateTrigger(TriggerEvent event) {
        PersistenceUnitExt defaultPersistenceUnit = (PersistenceUnitExt) event.getEntity().getPersistenceUnit();
        defaultPersistenceUnit.postponeCommit(new DefaultOnHoldCommitAction(event.getTrigger(), OnHoldCommitActionType.CREATE, DefaultPersistenceUnit.COMMIT_ORDER_TRIGGER));
    }


    @Override
    public void onPreCreateIndex(IndexEvent event) {
        if (!event.getPersistenceUnit().isValidStructureModificationContext()) {
            throw new InvalidStructureModificationContextException();
        }
    }

    @Override
    public void onCreateIndex(IndexEvent event) {
        PersistenceUnitExt defaultPersistenceUnit = (PersistenceUnitExt) event.getPersistenceUnit();
        defaultPersistenceUnit.postponeCommit(new DefaultOnHoldCommitAction(event.getIndex(), OnHoldCommitActionType.CREATE, DefaultPersistenceUnit.COMMIT_ORDER_INDEX));
    }


    @Override
    public void onPreCreateRelationship(RelationshipEvent event) {
        if (!event.getPersistenceUnit().isValidStructureModificationContext()) {
            throw new InvalidStructureModificationContextException();
        }
    }

    @Override
    public void onCreateRelationship(RelationshipEvent event) {
        PersistenceUnitExt defaultPersistenceUnit = (PersistenceUnitExt) event.getPersistenceUnit();
        defaultPersistenceUnit.postponeCommit(new DefaultOnHoldCommitActionRelationship(event.getRelationship(), OnHoldCommitActionType.CREATE));
    }

    @Override
    public void onPreCreateEntity(EntityEvent event) {
        if (!event.getPersistenceUnit().isValidStructureModificationContext()) {
            throw new InvalidStructureModificationContextException();
        }
    }

    @Override
    public void onCreateEntity(EntityEvent event) {
        PersistenceUnitExt defaultPersistenceUnit = (PersistenceUnitExt) event.getPersistenceUnit();
        defaultPersistenceUnit.postponeCommit(new DefaultOnHoldCommitActionEntity(event.getEntity(), OnHoldCommitActionType.CREATE));
    }


}
