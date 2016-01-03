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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/16/12 11:21 PM
     */
    public class FieldListPersistenceInfo {

        public Net.Vpc.Upa.Entity entity;

        public Net.Vpc.Upa.Persistence.PersistenceStore persistenceStore;

        public System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo> fields = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo>();

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo> insertSequenceGeneratorFields = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo>();

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo> updateSequenceGeneratorFields = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo>();

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo> insertExpressions = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo>();

        public System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo> updateExpressions = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo>();

        public virtual void Update() {
            System.Collections.Generic.ISet<string> visited = new System.Collections.Generic.HashSet<string>();
            insertSequenceGeneratorFields.Clear();
            updateSequenceGeneratorFields.Clear();
            insertExpressions.Clear();
            updateExpressions.Clear();
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields1 = entity.GetFields();
            foreach (Net.Vpc.Upa.Field field in fields1) {
                visited.Remove(field.GetName());
                Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo fieldPersistenceInfo = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo>(fields,field.GetName());
                if (fieldPersistenceInfo == null) {
                    fieldPersistenceInfo = new Net.Vpc.Upa.Impl.Persistence.FieldPersistenceInfo();
                    fields[field.GetName()]=fieldPersistenceInfo;
                }
                fieldPersistenceInfo.field = field;
                fieldPersistenceInfo.persistenceStore = persistenceStore;
                fieldPersistenceInfo.Synchronize();
                if (fieldPersistenceInfo.insertFieldPersister != null) {
                    insertSequenceGeneratorFields.Add(fieldPersistenceInfo);
                }
                if (fieldPersistenceInfo.updateFieldPersister != null) {
                    updateSequenceGeneratorFields.Add(fieldPersistenceInfo);
                }
                if (fieldPersistenceInfo.insertExpression != null) {
                    insertExpressions.Add(fieldPersistenceInfo);
                }
                if (fieldPersistenceInfo.updateExpression != null) {
                    updateExpressions.Add(fieldPersistenceInfo);
                }
                if (field.GetDataType() is Net.Vpc.Upa.Types.EntityType) {
                    ((Net.Vpc.Upa.Impl.AbstractField) field).SetFieldPersister(new Net.Vpc.Upa.Impl.EntityTypeFieldPersister());
                } else if (Net.Vpc.Upa.Impl.Util.UPAUtils.IsPasswordTransform(Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(field))) {
                    ((Net.Vpc.Upa.Impl.AbstractField) field).SetFieldPersister(new Net.Vpc.Upa.Impl.Transform.PasswordTypeFieldPersister());
                } else {
                    ((Net.Vpc.Upa.Impl.AbstractField) field).SetFieldPersister(new Net.Vpc.Upa.Impl.SimpleFieldPersister());
                }
            }
            foreach (string r in visited) {
                fields.Remove(r);
            }
        }
    }
}
