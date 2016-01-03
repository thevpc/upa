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



namespace Net.Vpc.Upa.Exceptions
{


    public class InsertRecordDuplicateUniqueFieldsException : Net.Vpc.Upa.Exceptions.EntityException {

        private System.Collections.Generic.IList<string> fieldNames;

        private string indexName;

        private string entityName;

        private readonly object @value;

        public InsertRecordDuplicateUniqueFieldsException(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Index index, object @value)  : base(entity, "insert.DuplicateUniqueFields", FieldTitles(index == null ? null : new System.Collections.Generic.List<Net.Vpc.Upa.Field>(index.GetFields())), @value){

            this.@value = @value;
            if (index != null) {
                this.indexName = index.GetName();
                this.entityName = index.GetEntity().GetName();
                this.fieldNames = new System.Collections.Generic.List<string>();
                foreach (Net.Vpc.Upa.Field field in index.GetFields()) {
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

        private static string FieldTitles(System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields) {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (fields != null) {
                sb.Append(fields[0].GetI18NString());
                for (int i = 1; i < (fields).Count; i++) {
                    sb.Append(", ");
                    sb.Append(fields[i].GetI18NString());
                }
            }
            return sb.ToString();
        }
    }
}
