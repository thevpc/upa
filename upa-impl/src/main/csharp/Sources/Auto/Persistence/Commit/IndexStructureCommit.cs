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



namespace Net.Vpc.Upa.Impl.Persistence.Commit
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class IndexStructureCommit : Net.Vpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.Commit.IndexStructureCommit)).FullName);

        public IndexStructureCommit(Net.Vpc.Upa.Index @object, Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.Vpc.Upa.Index), null){

        }


        public override void Persist(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext, Net.Vpc.Upa.PersistenceState status) /* throws System.Exception, Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Index index = (Net.Vpc.Upa.Index) @object;
            Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceUnitManager = (Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            if (!persistenceUnitManager.IsView(index.GetEntity())) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
                Net.Vpc.Upa.Persistence.UConnection b = persistenceUnitManager.GetConnection();
                if (status == Net.Vpc.Upa.PersistenceState.DIRTY) {
                    b.ExecuteNonQuery(persistenceUnitManager.GetDropIndexStatement(index), null, null);
                }
                b.ExecuteNonQuery(persistenceUnitManager.GetCreateIndexStatement(index), null, null);
            }
        }
    }
}
