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
    public class EntityPKStructureCommit : Net.TheVpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Persistence.Commit.EntityPKStructureCommit)).FullName);

        public EntityPKStructureCommit(Net.TheVpc.Upa.Entity @object, Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.TheVpc.Upa.Entity), Net.TheVpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT){

        }


        public override void Persist(Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext, Net.TheVpc.Upa.PersistenceState status) /* throws System.Exception, Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = (Net.TheVpc.Upa.Entity) @object;
            Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore store = (Net.TheVpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            if ((entity.GetPrimaryFields()).Count > 0) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
                Net.TheVpc.Upa.Persistence.UConnection b = executionContext.GetConnection();
                foreach (Net.TheVpc.Upa.PrimitiveField primaryField in entity.GetPrimitiveFields(Net.TheVpc.Upa.Filters.Fields.Id())) {
                    Net.TheVpc.Upa.Impl.Persistence.ColumnDesc cd = store.LoadColumnDesc(primaryField, b.GetMetadataAccessibleConnection());
                    if (cd.IsNullable() != null && (cd.IsNullable()).Value) {
                        b.ExecuteNonQuery(store.GetAlterTableAlterColumnNullStatement(primaryField, false), null, null);
                    }
                }
                b.ExecuteNonQuery(store.GetCreateTablePKConstraintStatement(entity), null, null);
            }
        }


        protected internal override Net.TheVpc.Upa.PersistenceState GetObjectStatus(Net.TheVpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
            return GetPersistenceUnitCommitManager().GetPersistenceUnitManager().GetPersistenceState(GetObject(), GetTypedObject().GetSpec(), entityExecutionContext);
        }
    }
}
