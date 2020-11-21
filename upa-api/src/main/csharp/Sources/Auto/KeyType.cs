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



namespace Net.TheVpc.Upa
{


    public class KeyType : Net.TheVpc.Upa.Types.StructType {

        private Net.TheVpc.Upa.Expressions.Expression filter;

        private Net.TheVpc.Upa.Entity entity;

        public KeyType(Net.TheVpc.Upa.Entity entity)  : this(entity, (Net.TheVpc.Upa.Expressions.Expression) null, true){

        }

        public KeyType(Net.TheVpc.Upa.Entity entity, string filter, bool nullable)  : this(entity, filter == null ? null : new Net.TheVpc.Upa.Expressions.UserExpression(filter), nullable){

        }

        public KeyType(Net.TheVpc.Upa.Entity entity, bool nullable)  : this(entity, (Net.TheVpc.Upa.Expressions.Expression) null, nullable){

        }

        public KeyType(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Expressions.Expression filter, bool nullable)  : base(entity.GetName(), typeof(Net.TheVpc.Upa.Key), ConstructorFieldNames(entity), ConstructorFieldTypes(entity), nullable){

            this.entity = entity;
            this.filter = filter;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetFilter() {
            return filter;
        }

        public virtual void SetFilter(Net.TheVpc.Upa.Expressions.Expression filter) {
            this.filter = filter;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        private static string[] ConstructorFieldNames(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = entity.GetIdFields();
            string[] fs = new string[(primaryFields).Count];
            for (int i = 0; i < fs.Length; i++) {
                fs[i] = primaryFields[i].GetName();
            }
            return fs;
        }

        private static Net.TheVpc.Upa.Types.DataType[] ConstructorFieldTypes(Net.TheVpc.Upa.Entity entity) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = entity.GetIdFields();
            Net.TheVpc.Upa.Types.DataType[] dt = new Net.TheVpc.Upa.Types.DataType[(primaryFields).Count];
            for (int i = 0; i < dt.Length; i++) {
                dt[i] = primaryFields[i].GetDataType();
            }
            return dt;
        }


        public override object GetItemValueAt(int index, object @value) {
            return @value == null ? null : ((Net.TheVpc.Upa.Key) @value).GetValue()[index];
        }


        public override object GetObjectForArray(object[] @value) {
            return entity.CreateId(@value);
        }


        public override object[] GetArrayForObject(object @value) {
            return @value == null ? null : ((Net.TheVpc.Upa.Key) @value).GetValue();
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.TheVpc.Upa.KeyType keyType = (Net.TheVpc.Upa.KeyType) o;
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
