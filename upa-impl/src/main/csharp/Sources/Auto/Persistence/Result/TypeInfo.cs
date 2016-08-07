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



namespace Net.Vpc.Upa.Impl.Persistence.Result
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

        internal System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo> allFields = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo>();

        internal System.Collections.Generic.ISet<Net.Vpc.Upa.Relationship> manyToOneRelations = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Relationship>();

        internal Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo[] infosArray;

        internal Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo leadPrimaryField;

        internal Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo leadField;

        internal object entityObject;

        internal object entityResult;

        internal object entityUpdatable;

        internal Net.Vpc.Upa.Record entityRecord;

        internal Net.Vpc.Upa.Entity entity;

        internal System.Type entityType;

        internal Net.Vpc.Upa.EntityBuilder entityFactory;

        internal Net.Vpc.Upa.EntityBuilder entityConverter;

        internal System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo> fields = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo>();

        public TypeInfo(string binding, Net.Vpc.Upa.Entity entity) {
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
