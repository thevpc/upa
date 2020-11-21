/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.TheVpc.Upa.Exceptions
{


    public class InsertDocumentDuplicateUniqueFieldsException : Net.TheVpc.Upa.Exceptions.EntityException {

        private System.Collections.Generic.IList<string> fieldNames;

        private string indexName;

        private string entityName;

        private readonly object @value;

        public InsertDocumentDuplicateUniqueFieldsException(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Index index, object @value)  : base(entity, "insert.DuplicateUniqueFields", FieldTitles(index == null ? null : new System.Collections.Generic.List<Net.TheVpc.Upa.Field>(index.GetFields())), @value){

            this.@value = @value;
            if (index != null) {
                this.indexName = index.GetName();
                this.entityName = index.GetEntity().GetName();
                Net.TheVpc.Upa.Field[] fields = index.GetFields();
                this.fieldNames = new System.Collections.Generic.List<string>(fields.Length);
                foreach (Net.TheVpc.Upa.Field field in fields) {
                    this.fieldNames.Add(field.GetName());
                }
            }
        }

        public virtual object GetValue() {
            return @value;
        }

        public virtual System.Collections.Generic.IList<string> GetFieldNames() {
            return fieldNames;
        }

        public virtual string GetIndexName() {
            return indexName;
        }

        public virtual string GetEntityName() {
            return entityName;
        }

        private static string FieldTitles(System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (fields != null) {
                sb.Append(fields[0].GetI18NTitle());
                for (int i = 1; i < (fields).Count; i++) {
                    sb.Append(", ");
                    sb.Append(fields[i].GetI18NTitle());
                }
            }
            return sb.ToString();
        }
    }
}
