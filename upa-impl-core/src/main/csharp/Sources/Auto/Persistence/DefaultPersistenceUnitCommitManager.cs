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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/21/12 6:20 PM
     */
    public class DefaultPersistenceUnitCommitManager {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager)).FullName);

        internal System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Persistence.StructureCommit> storage = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Persistence.StructureCommit>();

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        internal Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceStore;

        internal static Net.TheVpc.Upa.Impl.Persistence.StructureCommitComparator structureCommitComparator = new Net.TheVpc.Upa.Impl.Persistence.StructureCommitComparator();

        private System.Collections.Generic.IDictionary<Net.TheVpc.Upa.UPAObject , Net.TheVpc.Upa.Impl.Persistence.UPAPersistenceInfo> persistenceInfoMap = new System.Collections.Generic.Dictionary<Net.TheVpc.Upa.UPAObject , Net.TheVpc.Upa.Impl.Persistence.UPAPersistenceInfo>();

        public virtual void Init(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceStore) {
            this.persistenceUnit = persistenceUnit;
            this.persistenceStore = persistenceStore;
        }

        private Net.TheVpc.Upa.Impl.Persistence.UPAPersistenceInfo GetUPAObjectInfo(Net.TheVpc.Upa.UPAObject @object, bool create) {
            Net.TheVpc.Upa.Impl.Persistence.UPAPersistenceInfo info = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<Net.TheVpc.Upa.UPAObject,Net.TheVpc.Upa.Impl.Persistence.UPAPersistenceInfo>(persistenceInfoMap,@object);
            if (info == null && create) {
                info = new Net.TheVpc.Upa.Impl.Persistence.UPAPersistenceInfo(@object);
                persistenceInfoMap[@object]=info;
            }
            return info;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.PersistentObjectInfo GetPersistentObjectInfo(Net.TheVpc.Upa.UPAObject @object, string type) {
            System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Persistence.PersistentObjectInfo> persistentObjects = GetUPAObjectInfo(@object, true).persistentObjects;
            Net.TheVpc.Upa.Impl.Persistence.PersistentObjectInfo persistentObjectInfo = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Persistence.PersistentObjectInfo>(persistentObjects,type);
            if (persistentObjectInfo == null) {
                persistentObjectInfo = new Net.TheVpc.Upa.Impl.Persistence.PersistentObjectInfo(@object, type);
                persistentObjects[type]=persistentObjectInfo;
            }
            return persistentObjectInfo;
        }

        private Net.TheVpc.Upa.Persistence.UConnection GetConnection(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) {
            return executionContext.GetConnection();
        }

        public virtual void AlterPersistenceUnitAddObject(Net.TheVpc.Upa.UPAObject @object) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (@object is Net.TheVpc.Upa.PrimitiveField) {
                storage.Add(new Net.TheVpc.Upa.Impl.Persistence.Commit.PrimitiveFieldStructureCommit((Net.TheVpc.Upa.PrimitiveField) @object, this));
                return;
            }
            if (@object is Net.TheVpc.Upa.CompoundField) {
                //nothing to do
                //storage.add(new DummyCommit(object,ColumnPersistentObject.class));
                return;
            }
            if (@object is Net.TheVpc.Upa.Section) {
                //nothing to do
                //storage.add(new DummyCommit(object,ColumnPersistentObject.class));
                return;
            }
            if (@object is Net.TheVpc.Upa.Package) {
                //nothing to do
                //storage.add(new DummyCommit(object,ColumnPersistentObject.class));
                return;
            }
            if (@object is Net.TheVpc.Upa.Entity) {
                if (persistenceStore.IsView((Net.TheVpc.Upa.Entity) @object)) {
                    storage.Add(new Net.TheVpc.Upa.Impl.Persistence.Commit.ViewStructureCommit((Net.TheVpc.Upa.Entity) @object, this));
                } else {
                    storage.Add(new Net.TheVpc.Upa.Impl.Persistence.Commit.EntityStructureCommit((Net.TheVpc.Upa.Entity) @object, this));
                    storage.Add(new Net.TheVpc.Upa.Impl.Persistence.Commit.EntityPKStructureCommit((Net.TheVpc.Upa.Entity) @object, this));
                    storage.Add(new Net.TheVpc.Upa.Impl.Persistence.Commit.EntityImplicitViewStructureCommit((Net.TheVpc.Upa.Entity) @object, this));
                }
                return;
            }
            if (@object is Net.TheVpc.Upa.Relationship) {
                storage.Add(new Net.TheVpc.Upa.Impl.Persistence.Commit.RelationshipStructureCommit((Net.TheVpc.Upa.Relationship) @object, this));
                return;
            }
            if (@object is Net.TheVpc.Upa.Index) {
                storage.Add(new Net.TheVpc.Upa.Impl.Persistence.Commit.IndexStructureCommit((Net.TheVpc.Upa.Index) @object, this));
            }
        }

        public virtual bool CommitStructure() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Persistence.EntityExecutionContext context = ((Net.TheVpc.Upa.Impl.DefaultPersistenceUnit) persistenceUnit).CreateContext(Net.TheVpc.Upa.Persistence.ContextOperation.CREATE_PERSISTENCE_NAME, null);
            Net.TheVpc.Upa.Impl.FwkConvertUtils.ListSort(storage, structureCommitComparator);
            bool someCommit = false;
            foreach (Net.TheVpc.Upa.Impl.Persistence.StructureCommit next in storage) {
                if (next.Commit(context)) {
                    someCommit = true;
                }
            }
            storage.Clear();
            return someCommit;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore GetPersistenceUnitManager() {
            return persistenceStore;
        }
    }
}
