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



namespace Net.TheVpc.Upa.Impl.Persistence.Commit
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class IndexStructureCommit : Net.TheVpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.Commit.IndexStructureCommit)).FullName);

        public IndexStructureCommit(Net.TheVpc.Upa.Index @object, Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.TheVpc.Upa.Index), null){

        }


        public override void Persist(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, Net.TheVpc.Upa.PersistenceState status) /* throws System.Exception, Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Index index = (Net.TheVpc.Upa.Index) @object;
            Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceUnitManager = (Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            if (!persistenceUnitManager.IsView(index.GetEntity())) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
                Net.TheVpc.Upa.Persistence.UConnection b = executionContext.GetConnection();
                if (status == Net.TheVpc.Upa.PersistenceState.DIRTY) {
                    b.ExecuteNonQuery(persistenceUnitManager.GetDropIndexStatement(index), null, null);
                }
                b.ExecuteNonQuery(persistenceUnitManager.GetCreateIndexStatement(index), null, null);
            }
        }
    }
}
