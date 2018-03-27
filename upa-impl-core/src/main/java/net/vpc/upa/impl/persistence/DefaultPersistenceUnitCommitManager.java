package net.vpc.upa.impl.persistence;

import net.vpc.upa.*;
import net.vpc.upa.Package;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.ext.PersistenceUnitExt;
import net.vpc.upa.persistence.*;

import java.util.*;
import java.util.logging.Logger;
import net.vpc.upa.impl.ext.persistence.PersistenceStoreExt;
import net.vpc.upa.impl.persistence.commit.EntityImplicitViewStructureCommit;
import net.vpc.upa.impl.persistence.commit.EntityPKStructureCommit;
import net.vpc.upa.impl.persistence.commit.EntityStructureCommit;
import net.vpc.upa.impl.persistence.commit.IndexStructureCommit;
import net.vpc.upa.impl.persistence.commit.PrimitiveFieldStructureCommit;
import net.vpc.upa.impl.persistence.commit.RelationshipStructureCommit;
import net.vpc.upa.impl.persistence.commit.ViewStructureCommit;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 9/21/12 6:20 PM
 */
public class DefaultPersistenceUnitCommitManager {

    protected static Logger log = Logger.getLogger(DefaultPersistenceUnitCommitManager.class.getName());
    List<StructureCommit> storage = new ArrayList<StructureCommit>();
    PersistenceStoreExt persistenceStore;
    static StructureCommitComparator structureCommitComparator = new StructureCommitComparator();
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
            storage.add(new PrimitiveFieldStructureCommit((PrimitiveField) object, this));
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
            if (persistenceStore.isView((Entity) object)) {
                storage.add(new ViewStructureCommit((Entity)object, this));
            } else {
                storage.add(new EntityStructureCommit((Entity)object, this));
                storage.add(new EntityPKStructureCommit((Entity)object, this));
                storage.add(new EntityImplicitViewStructureCommit((Entity)object, this));
            }
            return;
        }

        if (object instanceof Relationship) {
            storage.add(new RelationshipStructureCommit((Relationship)object,this));
            return;
        }
        if (object instanceof Index) {
            storage.add(new IndexStructureCommit((Index)object,this) );
        }
    }

    public boolean commitStructure(PersistenceUnit persistenceUnit) throws UPAException {
        EntityExecutionContext context = ((PersistenceUnitExt)persistenceUnit).createContext(ContextOperation.CREATE_PERSISTENCE_NAME,null);
        Collections.sort(storage, structureCommitComparator);
        boolean someCommit = false;
        for (StructureCommit next : storage) {
            if (next.commit(context)) {
                someCommit = true;
            }
        }
        storage.clear();
        return someCommit;
    }

    public PersistenceStoreExt getPersistenceUnitManager() {
        return persistenceStore;
    }
}
