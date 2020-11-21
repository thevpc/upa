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



namespace Net.TheVpc.Upa.Impl.Persistence.Result
{


    /**
     * Created by vpc on 1/4/14.
     */
    internal class TypeInfo {

        internal bool record;

        internal string parentBinding;

        internal string bindingName;

        internal string binding;

        internal bool update;

        internal System.Collections.Generic.IList<int?> indexesToUpdate = new System.Collections.Generic.List<int?>();

        internal System.Collections.Generic.IList<Net.TheVpc.Upa.Impl.Persistence.Result.FieldInfo> allFields = new System.Collections.Generic.List<Net.TheVpc.Upa.Impl.Persistence.Result.FieldInfo>();

        internal System.Collections.Generic.ISet<Net.TheVpc.Upa.Relationship> manyToOneRelations = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Relationship>();

        internal Net.TheVpc.Upa.Impl.Persistence.Result.FieldInfo[] infosArray;

        internal Net.TheVpc.Upa.Impl.Persistence.Result.FieldInfo leadPrimaryField;

        internal Net.TheVpc.Upa.Impl.Persistence.Result.FieldInfo leadField;

        internal object entityObject;

        internal object entityResult;

        internal object entityUpdatable;

        internal Net.TheVpc.Upa.Record entityRecord;

        internal Net.TheVpc.Upa.Entity entity;

        internal System.Type entityType;

        internal Net.TheVpc.Upa.EntityBuilder entityFactory;

        internal Net.TheVpc.Upa.EntityBuilder entityConverter;

        internal System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Persistence.Result.FieldInfo> fields = new System.Collections.Generic.Dictionary<string , Net.TheVpc.Upa.Impl.Persistence.Result.FieldInfo>();

        public TypeInfo(string binding, Net.TheVpc.Upa.Entity entity) {
            this.binding = binding;
            int dotPos = binding == null ? -1 : binding.LastIndexOf('.');
            if (dotPos > 0) {
                this.parentBinding = binding.Substring(0, dotPos);
                this.bindingName = binding.Substring(dotPos + 1);
            }
            this.entity = entity;
            if (entity != null) {
                entityFactory = entity.GetBuilder();
                entityConverter = entity.GetBuilder();
                entityType = entity.GetEntityType();
            }
        }


        public override string ToString() {
            return "TypeInfo{" + "binding='" + binding + '\'' + ", entity=" + entity + '}';
        }
    }
}
