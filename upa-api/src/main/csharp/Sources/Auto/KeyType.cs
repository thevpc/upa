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



namespace Net.Vpc.Upa
{


    public class KeyType : Net.Vpc.Upa.Types.StructType {

        private Net.Vpc.Upa.Expressions.Expression filter;

        private Net.Vpc.Upa.Entity entity;

        public KeyType(Net.Vpc.Upa.Entity entity)  : this(entity, (Net.Vpc.Upa.Expressions.Expression) null, true){

        }

        public KeyType(Net.Vpc.Upa.Entity entity, string filter, bool nullable)  : this(entity, filter == null ? null : new Net.Vpc.Upa.Expressions.UserExpression(filter), nullable){

        }

        public KeyType(Net.Vpc.Upa.Entity entity, bool nullable)  : this(entity, (Net.Vpc.Upa.Expressions.Expression) null, nullable){

        }

        public KeyType(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Expressions.Expression filter, bool nullable)  : base(entity.GetName(), typeof(Net.Vpc.Upa.Key), ConstructorFieldNames(entity), ConstructorFieldTypes(entity), nullable){

            this.entity = entity;
            this.filter = filter;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetFilter() {
            return filter;
        }

        public virtual void SetFilter(Net.Vpc.Upa.Expressions.Expression filter) {
            this.filter = filter;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        private static string[] ConstructorFieldNames(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = entity.GetIdFields();
            string[] fs = new string[(primaryFields).Count];
            for (int i = 0; i < fs.Length; i++) {
                fs[i] = primaryFields[i].GetName();
            }
            return fs;
        }

        private static Net.Vpc.Upa.Types.DataType[] ConstructorFieldTypes(Net.Vpc.Upa.Entity entity) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.Vpc.Upa.Field> primaryFields = entity.GetIdFields();
            Net.Vpc.Upa.Types.DataType[] dt = new Net.Vpc.Upa.Types.DataType[(primaryFields).Count];
            for (int i = 0; i < dt.Length; i++) {
                dt[i] = primaryFields[i].GetDataType();
            }
            return dt;
        }


        public override object GetItemValueAt(int index, object @value) {
            return @value == null ? null : ((Net.Vpc.Upa.Key) @value).GetValue()[index];
        }


        public override object GetObjectForArray(object[] @value) {
            return entity.CreateId(@value);
        }


        public override object[] GetArrayForObject(object @value) {
            return @value == null ? null : ((Net.Vpc.Upa.Key) @value).GetValue();
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.Vpc.Upa.KeyType keyType = (Net.Vpc.Upa.KeyType) o;
            if (filter != null ? !filter.Equals(keyType.filter) : keyType.filter != null) return false;
            return entity != null ? entity.Equals(keyType.entity) : keyType.entity == null;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (filter != null ? filter.GetHashCode() : 0);
            result = 31 * result + (entity != null ? entity.GetHashCode() : 0);
            return result;
        }
    }
}
