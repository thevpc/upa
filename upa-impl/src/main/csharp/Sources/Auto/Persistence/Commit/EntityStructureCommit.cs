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
    public class EntityStructureCommit : Net.Vpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.Commit.EntityStructureCommit)).FullName);

        public EntityStructureCommit(Net.Vpc.Upa.Entity @object, Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.Vpc.Upa.Entity), null){

        }


        public override void Persist(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext, Net.Vpc.Upa.PersistenceState status) /* throws System.Exception, Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = (Net.Vpc.Upa.Entity) @object;
            Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceUnitManager = (Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
            Net.Vpc.Upa.Persistence.UConnection b = persistenceUnitManager.GetConnection();
            b.ExecuteNonQuery(persistenceUnitManager.GetCreateTableStatement(entity), null, null);
        }
    }
}
