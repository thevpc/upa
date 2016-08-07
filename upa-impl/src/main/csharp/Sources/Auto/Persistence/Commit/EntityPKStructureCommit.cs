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
    public class EntityPKStructureCommit : Net.Vpc.Upa.Impl.Persistence.StructureCommit {

        protected internal static System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Persistence.Commit.EntityPKStructureCommit)).FullName);

        public EntityPKStructureCommit(Net.Vpc.Upa.Entity @object, Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceUnitCommitManager persistenceUnitCommitManager)  : base(persistenceUnitCommitManager, @object, typeof(Net.Vpc.Upa.Entity), Net.Vpc.Upa.Persistence.PersistenceNameType.PK_CONSTRAINT){

        }


        public override void Persist(Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext, Net.Vpc.Upa.PersistenceState status) /* throws System.Exception, Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Entity entity = (Net.Vpc.Upa.Entity) @object;
            Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore store = (Net.Vpc.Upa.Impl.Persistence.DefaultPersistenceStore) executionContext.GetPersistenceStore();
            if ((entity.GetPrimaryFields()).Count > 0) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit {0} / {1} : found {2}, persist",null,new object[] { @object, typedObject, status }));
                Net.Vpc.Upa.Persistence.UConnection b = executionContext.GetConnection();
                foreach (Net.Vpc.Upa.PrimitiveField primaryField in entity.GetPrimitiveFields(Net.Vpc.Upa.Filters.Fields.Id())) {
                    Net.Vpc.Upa.Impl.Persistence.ColumnDesc cd = store.LoadColumnDesc(primaryField, b.GetMetadataAccessibleConnection());
                    if (cd.IsNullable() != null && (cd.IsNullable()).Value) {
                        b.ExecuteNonQuery(store.GetAlterTableAlterColumnNullStatement(primaryField, false), null, null);
                    }
                }
                b.ExecuteNonQuery(store.GetCreateTablePKConstraintStatement(entity), null, null);
            }
        }


        protected internal override Net.Vpc.Upa.PersistenceState GetObjectStatus(Net.Vpc.Upa.Persistence.EntityExecutionContext entityExecutionContext) {
            return GetPersistenceUnitCommitManager().GetPersistenceUnitManager().GetPersistenceState(GetObject(), GetTypedObject().GetSpec(), entityExecutionContext);
        }
    }
}
