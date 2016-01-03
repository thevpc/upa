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
    public class PrimitiveFieldStructureCommit : Net.Vpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.Commit.PrimitiveFieldStructureCommit)).FullName);

        public PrimitiveFieldStructureCommit(Net.Vpc.Upa.PrimitiveField @object, Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.Vpc.Upa.PrimitiveField), null){

        }

        protected internal override Net.Vpc.Upa.PersistenceState GetObjectStatus() {
            return GetPersistenceUnitCommitManager().GetPersistenceUnitManager().GetPersistenceState(@object, typedObject.GetSpec());
        }


        public override void Persist(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext, Net.Vpc.Upa.PersistenceState status) /* throws System.Exception, Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.PrimitiveField field = (Net.Vpc.Upa.PrimitiveField) @object;
            Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceUnitManager = (Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
            string q = persistenceUnitManager.GetAlterTableAddColumnStatement(field);
            Net.Vpc.Upa.Persistence.UConnection b = persistenceUnitManager.GetConnection();
            b.ExecuteNonQuery(q, null, null);
        }
    }
}
