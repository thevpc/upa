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
    public class PrimitiveFieldStructureCommit : Net.TheVpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.Commit.PrimitiveFieldStructureCommit)).FullName);

        public PrimitiveFieldStructureCommit(Net.TheVpc.Upa.PrimitiveField @object, Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.TheVpc.Upa.PrimitiveField), null){

        }

        protected internal override Net.TheVpc.Upa.PersistenceState GetObjectStatus(Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
            return GetPersistenceUnitCommitManager().GetPersistenceUnitManager().GetPersistenceState(@object, typedObject.GetSpec(), entityExecutionContext);
        }


        public override void Persist(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, Net.TheVpc.Upa.PersistenceState status) /* throws System.Exception, Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.PrimitiveField field = (Net.TheVpc.Upa.PrimitiveField) @object;
            Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceUnitManager = (Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
            string q = persistenceUnitManager.GetAlterTableAddColumnStatement(field, executionContext);
            Net.TheVpc.Upa.Persistence.UConnection b = executionContext.GetConnection();
            b.ExecuteNonQuery(q, null, null);
        }
    }
}
