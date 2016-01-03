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
    public class ViewStructureCommit : Net.Vpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.Commit.ViewStructureCommit)).FullName);

        public ViewStructureCommit(Net.Vpc.Upa.Entity @object, Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.Vpc.Upa.Entity), null){

        }


        public override void Persist(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext, Net.Vpc.Upa.PersistenceState status) /* throws System.Exception, Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entityManager = (Net.Vpc.Upa.Entity) @object;
            Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceUnitManager = (Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
            Net.Vpc.Upa.Persistence.UConnection b = persistenceUnitManager.GetConnection();
            System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ViewEntityExtension> specSupport = entityManager.GetExtensions<Net.Vpc.Upa.Persistence.ViewEntityExtension>(typeof(Net.Vpc.Upa.Persistence.ViewEntityExtension));
            foreach (Net.Vpc.Upa.Persistence.ViewEntityExtension ss in specSupport) {
                b.ExecuteNonQuery(persistenceUnitManager.GetCreateViewStatement(entityManager, ss.GetQuery(), executionContext), null, null);
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.UnionEntityExtension> uspecSupport = entityManager.GetExtensions<Net.Vpc.Upa.Persistence.UnionEntityExtension>(typeof(Net.Vpc.Upa.Persistence.UnionEntityExtension));
            foreach (Net.Vpc.Upa.Persistence.UnionEntityExtension ss in uspecSupport) {
                b.ExecuteNonQuery(persistenceUnitManager.GetCreateViewStatement(entityManager, ss.GetQuery(), executionContext), null, null);
            }
            System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.FilterEntityExtensionDefinition> fspecSupport = entityManager.GetExtensionDefinitions<Net.Vpc.Upa.Extensions.FilterEntityExtensionDefinition>(typeof(Net.Vpc.Upa.Extensions.FilterEntityExtensionDefinition));
            foreach (Net.Vpc.Upa.Extensions.FilterEntityExtensionDefinition ss in fspecSupport) {
                b.ExecuteNonQuery(persistenceUnitManager.GetCreateViewStatement(entityManager, ss.GetQuery(), executionContext), null, null);
            }
        }
    }
}
