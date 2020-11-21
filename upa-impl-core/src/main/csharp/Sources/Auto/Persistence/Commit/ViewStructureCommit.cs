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
    public class ViewStructureCommit : Net.TheVpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.Commit.ViewStructureCommit)).FullName);

        public ViewStructureCommit(Net.TheVpc.Upa.Entity @object, Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.TheVpc.Upa.Entity), null){

        }


        public override void Persist(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, Net.TheVpc.Upa.PersistenceState status) /* throws System.Exception, Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entityManager = (Net.TheVpc.Upa.Entity) @object;
            Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore persistenceUnitManager = (Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
            Net.TheVpc.Upa.Persistence.UConnection b = executionContext.GetConnection();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.ViewEntityExtension> specSupport = entityManager.GetExtensions<Net.TheVpc.Upa.Persistence.ViewEntityExtension>(typeof(Net.TheVpc.Upa.Persistence.ViewEntityExtension));
            foreach (Net.TheVpc.Upa.Persistence.ViewEntityExtension ss in specSupport) {
                b.ExecuteNonQuery(persistenceUnitManager.GetCreateViewStatement(entityManager, ss.GetQuery(), executionContext), null, null);
            }
            System.Collections.Generic.IList<Net.TheVpc.Upa.Persistence.UnionEntityExtension> uspecSupport = entityManager.GetExtensions<Net.TheVpc.Upa.Persistence.UnionEntityExtension>(typeof(Net.TheVpc.Upa.Persistence.UnionEntityExtension));
            foreach (Net.TheVpc.Upa.Persistence.UnionEntityExtension ss in uspecSupport) {
                b.ExecuteNonQuery(persistenceUnitManager.GetCreateViewStatement(entityManager, ss.GetQuery(), executionContext), null, null);
            }
            System.Collections.Generic.IList<Net.TheVpc.Upa.Extensions.FilterEntityExtensionDefinition> fspecSupport = entityManager.GetExtensionDefinitions<Net.TheVpc.Upa.Extensions.FilterEntityExtensionDefinition>(typeof(Net.TheVpc.Upa.Extensions.FilterEntityExtensionDefinition));
            foreach (Net.TheVpc.Upa.Extensions.FilterEntityExtensionDefinition ss in fspecSupport) {
                b.ExecuteNonQuery(persistenceUnitManager.GetCreateViewStatement(entityManager, ss.GetQuery(), executionContext), null, null);
            }
        }
    }
}
