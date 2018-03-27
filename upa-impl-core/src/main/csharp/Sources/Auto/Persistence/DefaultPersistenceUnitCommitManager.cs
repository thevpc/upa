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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/21/12 6:20 PM
     */
    public class DefaultPersistenceUnitCommitManager {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager)).FullName);

        internal System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Persistence.StructureCommit> storage = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Persistence.StructureCommit>();

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        internal Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceStore;

        internal static Net.Vpc.Upa.Impl.Persistence.StructureCommitComparator structureCommitComparator = new Net.Vpc.Upa.Impl.Persistence.StructureCommitComparator();

        private System.Collections.Generic.IDictionary<Net.Vpc.Upa.UPAObject , Net.Vpc.Upa.Impl.Persistence.UPAPersistenceInfo> persistenceInfoMap = new System.Collections.Generic.Dictionary<Net.Vpc.Upa.UPAObject , Net.Vpc.Upa.Impl.Persistence.UPAPersistenceInfo>();

        public virtual void Init(Net.Vpc.Upa.PersistenceUnit persistenceUnit, Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceStore) {
            this.persistenceUnit = persistenceUnit;
            this.persistenceStore = persistenceStore;
        }

        private Net.Vpc.Upa.Impl.Persistence.UPAPersistenceInfo GetUPAObjectInfo(Net.Vpc.Upa.UPAObject @object, bool create) {
            Net.Vpc.Upa.Impl.Persistence.UPAPersistenceInfo info = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.Vpc.Upa.UPAObject,Net.Vpc.Upa.Impl.Persistence.UPAPersistenceInfo>(persistenceInfoMap,@object);
            if (info == null && create) {
                info = new Net.Vpc.Upa.Impl.Persistence.UPAPersistenceInfo(@object);
                persistenceInfoMap[@object]=info;
            }
            return info;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.PersistentObjectInfo GetPersistentObjectInfo(Net.Vpc.Upa.UPAObject @object, string type) {
            System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Impl.Persistence.PersistentObjectInfo> persistentObjects = GetUPAObjectInfo(@object, true).persistentObjects;
            Net.Vpc.Upa.Impl.Persistence.PersistentObjectInfo persistentObjectInfo = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Persistence.PersistentObjectInfo>(persistentObjects,type);
            if (persistentObjectInfo == null) {
                persistentObjectInfo = new Net.Vpc.Upa.Impl.Persistence.PersistentObjectInfo(@object, type);
                persistentObjects[type]=persistentObjectInfo;
            }
            return persistentObjectInfo;
        }

        private Net.Vpc.Upa.Persistence.UConnection GetConnection(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) {
            return executionContext.GetConnection();
        }

        public virtual void AlterPersistenceUnitAddObject(Net.Vpc.Upa.UPAObject @object) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (@object is Net.Vpc.Upa.PrimitiveField) {
                storage.Add(new Net.Vpc.Upa.Impl.Persistence.Commit.PrimitiveFieldStructureCommit((Net.Vpc.Upa.PrimitiveField) @object, this));
                return;
            }
            if (@object is Net.Vpc.Upa.CompoundField) {
                //nothing to do
                //storage.add(new DummyCommit(object,ColumnPersistentObject.class));
                return;
            }
            if (@object is Net.Vpc.Upa.Section) {
                //nothing to do
                //storage.add(new DummyCommit(object,ColumnPersistentObject.class));
                return;
            }
            if (@object is Net.Vpc.Upa.Package) {
                //nothing to do
                //storage.add(new DummyCommit(object,ColumnPersistentObject.class));
                return;
            }
            if (@object is Net.Vpc.Upa.Entity) {
                if (persistenceStore.IsView((Net.Vpc.Upa.Entity) @object)) {
                    storage.Add(new Net.Vpc.Upa.Impl.Persistence.Commit.ViewStructureCommit((Net.Vpc.Upa.Entity) @object, this));
                } else {
                    storage.Add(new Net.Vpc.Upa.Impl.Persistence.Commit.EntityStructureCommit((Net.Vpc.Upa.Entity) @object, this));
                    storage.Add(new Net.Vpc.Upa.Impl.Persistence.Commit.EntityPKStructureCommit((Net.Vpc.Upa.Entity) @object, this));
                    storage.Add(new Net.Vpc.Upa.Impl.Persistence.Commit.EntityImplicitViewStructureCommit((Net.Vpc.Upa.Entity) @object, this));
                }
                return;
            }
            if (@object is Net.Vpc.Upa.Relationship) {
                storage.Add(new Net.Vpc.Upa.Impl.Persistence.Commit.RelationshipStructureCommit((Net.Vpc.Upa.Relationship) @object, this));
                return;
            }
            if (@object is Net.Vpc.Upa.Index) {
                storage.Add(new Net.Vpc.Upa.Impl.Persistence.Commit.IndexStructureCommit((Net.Vpc.Upa.Index) @object, this));
            }
        }

        public virtual bool CommitStructure() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Persistence.EntityExecutionContext context = ((Net.Vpc.Upa.Impl.DefaultPersistenceUnit) persistenceUnit).CreateContext(Net.Vpc.Upa.Persistence.ContextOperation.CREATE_PERSISTENCE_NAME, null);
            Net.Vpc.Upa.Impl.FwkConvertUtils.ListSort(storage, structureCommitComparator);
            bool someCommit = false;
            foreach (Net.Vpc.Upa.Impl.Persistence.StructureCommit next in storage) {
                if (next.Commit(context)) {
                    someCommit = true;
                }
            }
            storage.Clear();
            return someCommit;
        }

        public virtual Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore GetPersistenceUnitManager() {
            return persistenceStore;
        }
    }
}
