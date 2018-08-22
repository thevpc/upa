package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.Package;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.ext.PersistenceUnitExt;
import net.vpc.upa.persistence.*;

import java.util.*;
import java.util.logging.Level;
import java.util.logging.Logger;
import net.vpc.upa.impl.ext.persistence.PersistenceStoreExt;
import net.vpc.upa.impl.persistence.commit.EntityImplicitViewStructureCommitAction;
import net.vpc.upa.impl.persistence.commit.EntityPKStructureCommitAction;
import net.vpc.upa.impl.persistence.commit.EntityStructureCommitAction;
import net.vpc.upa.impl.persistence.commit.IndexStructureCommitAction;
import net.vpc.upa.impl.persistence.commit.PrimitiveFieldStructureCommitAction;
import net.vpc.upa.impl.persistence.commit.RelationshipStructureCommitAction;
import net.vpc.upa.impl.persistence.commit.ViewStructureCommitAction;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/21/12 6:20 PM
 */
public class DefaultPersistenceUnitCommitManager {

    protected static Logger log = Logger.getLogger(DefaultPersistenceUnitCommitManager.class.getName());
    private static final StructureCommitComparator STRUCTURE_COMMIT_COMPARATOR = new StructureCommitComparator();
    private Set<StructureCommitAction> storage = new HashSet<StructureCommitAction>();
    private PersistenceStoreExt persistenceStore;
    private Map<UPAObject, UPAPersistenceInfo> persistenceInfoMap = new HashMap<UPAObject, UPAPersistenceInfo>();

    public void init(PersistenceStoreExt persistenceStore) {
        this.persistenceStore = persistenceStore;
    }

    private UPAPersistenceInfo getUPAObjectInfo(UPAObject object, boolean create) {
        UPAPersistenceInfo info = persistenceInfoMap.get(object);
        if (info == null && create) {
            info = new UPAPersistenceInfo(object);
            persistenceInfoMap.put(object, info);
        }
        return info;
    }

    public PersistentObjectInfo getPersistentObjectInfo(UPAObject object, String type) {
        Map<String, PersistentObjectInfo> persistentObjects = getUPAObjectInfo(object, true).persistentObjects;
        PersistentObjectInfo persistentObjectInfo = persistentObjects.get(type);
        if (persistentObjectInfo == null) {
            persistentObjectInfo = new PersistentObjectInfo(object, type);
            persistentObjects.put(type, persistentObjectInfo);
        }
        return persistentObjectInfo;
    }

    private UConnection getConnection(EntityExecutionContext executionContext) {
        return executionContext.getConnection();
    }

    public void alterPersistenceUnitAddObject(UPAObject object) throws UPAException {
        if (object instanceof PrimitiveField) {
            PrimitiveField p = (PrimitiveField) object;
            Entity e = p.getEntity();
            if (persistenceStore.isView(e)) {
                storage.add(new ViewStructureCommitAction(e, this));
            } else {
                if (e.hasAssociatedView() && p.getModifiers().contains(FieldModifier.SELECT_COMPILED)) {
                    storage.add(new EntityImplicitViewStructureCommitAction(e, this));
                } else {
                    storage.add(new PrimitiveFieldStructureCommitAction(p, this));
                }
            }
            return;
        }
        if (object instanceof CompoundField) {
            //nothing to do
            //storage.add(new DummyCommit(object,ColumnPersistentObject.class));
            return;
        }
        if (object instanceof Section) {
            //nothing to do
            //storage.add(new DummyCommit(object,ColumnPersistentObject.class));
            return;
        }
        if (object instanceof Package) {
            //nothing to do
            //storage.add(new DummyCommit(object,ColumnPersistentObject.class));
            return;
        }
        if (object instanceof Entity) {
            Entity e = (Entity) object;
            if (persistenceStore.isView(e)) {
                storage.add(new ViewStructureCommitAction(e, this));
            } else {
                storage.add(new EntityStructureCommitAction(e, this));
                storage.add(new EntityPKStructureCommitAction(e, this));
                if (e.hasAssociatedView()) {
                    storage.add(new EntityImplicitViewStructureCommitAction(e, this));
                }
            }
            return;
        }

        if (object instanceof Relationship) {
            storage.add(new RelationshipStructureCommitAction((Relationship) object, this));
            return;
        }
        if (object instanceof Index) {
            storage.add(new IndexStructureCommitAction((Index) object, this));
        }
    }

    public boolean commitStructure(PersistenceUnit persistenceUnit) throws UPAException {
        EntityExecutionContext context = ((PersistenceUnitExt) persistenceUnit).createContext(ContextOperation.CREATE_PERSISTENCE_NAME, null);
        StructureCommitAction[] storageArray = storage.toArray(new StructureCommitAction[storage.size()]);
        Arrays.sort(storageArray, STRUCTURE_COMMIT_COMPARATOR);
        if (log.isLoggable(Level.FINEST)) {
            for (int i = 0; i < storageArray.length; i++) {
                StructureCommitAction structureCommit = storageArray[i];
                log.log(Level.FINEST, STRUCTURE_COMMIT_COMPARATOR.get(structureCommit.persistenceNameType) + " :: " + structureCommit);
            }
        }
        boolean someCommit = false;
        for (StructureCommitAction next : storageArray) {
            if (next.commit(context)) {
                someCommit = true;
            }
        }
        storage.clear();
        return someCommit;
    }

    public PersistenceStoreExt getPersistenceStore() {
        return persistenceStore;
    }
}
