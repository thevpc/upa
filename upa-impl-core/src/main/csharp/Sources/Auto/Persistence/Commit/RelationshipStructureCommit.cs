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
    public class RelationshipStructureCommit : Net.TheVpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.Commit.RelationshipStructureCommit)).FullName);

        public RelationshipStructureCommit(Net.TheVpc.Upa.Relationship @object, Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.TheVpc.Upa.Relationship), null){

        }


        public override void Persist(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, Net.TheVpc.Upa.PersistenceState status) /* throws System.Exception, Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Relationship relation = (Net.TheVpc.Upa.Relationship) @object;
            Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceUnitManager = (Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
            if (!relation.IsTransient() && persistenceUnitManager.IsReferencingSupported()) {
                Net.TheVpc.Upa.Persistence.UConnection b = executionContext.GetConnection();
                b.ExecuteNonQuery(persistenceUnitManager.GetCreateRelationshipStatement(relation), null, null);
            }
        }
    }
}
