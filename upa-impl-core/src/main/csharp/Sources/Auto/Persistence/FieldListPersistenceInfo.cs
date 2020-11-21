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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 12/16/12 11:21 PM
     */
    public class FieldListPersistenceInfo {

        public Net.TheVpc.Upa.Entity entity;

        public Net.TheVpc.Upa.Persistence.PersistenceStore persistenceStore;

        public System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo> fields = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo>();

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo> persistSequenceGeneratorFields = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo>();

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo> updateSequenceGeneratorFields = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo>();

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo> insertExpressions = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo>();

        public System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo> updateExpressions = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo>();

        public virtual void Update() {
            System.Collections.Generic.ISet<string> visited = new System.Collections.Generic.HashSet<string>();
            persistSequenceGeneratorFields.Clear();
            updateSequenceGeneratorFields.Clear();
            insertExpressions.Clear();
            updateExpressions.Clear();
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields1 = entity.GetFields();
            foreach (Net.TheVpc.Upa.Field field in fields1) {
                visited.Remove(field.GetName());
                Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo fieldPersistenceInfo = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo>(fields,field.GetName());
                if (fieldPersistenceInfo == null) {
                    fieldPersistenceInfo = new Net.TheVpc.Upa.Impl.Persistence.FieldPersistenceInfo();
                    fields[field.GetName()]=fieldPersistenceInfo;
                }
                fieldPersistenceInfo.field = field;
                fieldPersistenceInfo.persistenceStore = persistenceStore;
                fieldPersistenceInfo.Synchronize();
                if (fieldPersistenceInfo.persistFieldPersister != null) {
                    persistSequenceGeneratorFields.Add(fieldPersistenceInfo);
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
                if (field.GetDataType() is Net.TheVpc.Upa.Types.ManyToOneType) {
                    ((Net.TheVpc.Upa.Impl.AbstractField) field).SetFieldPersister(new Net.TheVpc.Upa.Impl.EntityTypeFieldPersister());
                } else if (Net.TheVpc.Upa.Impl.Util.UPAUtils.IsPasswordTransform(Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity(field))) {
                    ((Net.TheVpc.Upa.Impl.AbstractField) field).SetFieldPersister(new Net.TheVpc.Upa.Impl.Transform.PasswordTypeFieldPersister());
                } else {
                    ((Net.TheVpc.Upa.Impl.AbstractField) field).SetFieldPersister(new Net.TheVpc.Upa.Impl.SimpleFieldPersister());
                }
            }
            foreach (string r in visited) {
                fields.Remove(r);
            }
        }
    }
}
