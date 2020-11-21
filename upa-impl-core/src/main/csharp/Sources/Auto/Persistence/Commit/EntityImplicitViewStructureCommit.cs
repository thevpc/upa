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
    public class EntityImplicitViewStructureCommit : Net.TheVpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.Commit.EntityImplicitViewStructureCommit)).FullName);

        public EntityImplicitViewStructureCommit(Net.TheVpc.Upa.Entity @object, Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.TheVpc.Upa.Entity), Net.TheVpc.Upa.Persistence.PersistenceNameType.IMPLICIT_VIEW){

        }


        public override void Persist(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, Net.TheVpc.Upa.PersistenceState status) /* throws System.Exception, Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = (Net.TheVpc.Upa.Entity) @object;
            Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceUnitManager = (Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            if (persistenceUnitManager.IsViewSupported() && entity.NeedsView()) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
                Net.TheVpc.Upa.Persistence.UConnection b = executionContext.GetConnection();
                b.ExecuteNonQuery(persistenceUnitManager.GetCreateImplicitViewStatement(entity, executionContext), null, null);
            }
        }
    }
}
