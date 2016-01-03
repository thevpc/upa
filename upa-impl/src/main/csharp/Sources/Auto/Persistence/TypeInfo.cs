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
     * Created by vpc on 1/4/14.
     */
    internal class TypeInfo {

        internal string parentBinding;

        internal string bindingName;

        internal string binding;

        internal System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Persistence.FieldInfo> infos = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Persistence.FieldInfo>();

        internal Net.Vpc.Upa.Impl.Persistence.FieldInfo[] infosArray;

        internal Net.Vpc.Upa.Impl.Persistence.FieldInfo leadPrimaryField;

        internal Net.Vpc.Upa.Impl.Persistence.FieldInfo leadField;

        internal object entityObject;

        internal object entityUpdatable;

        internal Net.Vpc.Upa.Record entityRecord;

        internal Net.Vpc.Upa.Entity entity;

        internal System.Type entityType;

        internal Net.Vpc.Upa.EntityBuilder entityFactory;

        internal Net.Vpc.Upa.EntityBuilder entityConverter;

        internal System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.Impl.Persistence.FieldInfo> setterToProp = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.Impl.Persistence.FieldInfo>();

        public TypeInfo(string binding, Net.Vpc.Upa.Entity entity) {
            this.binding = binding;
            int dotPos = binding == null ? -1 : binding.LastIndexOf('.');
            if (dotPos > 0) {
                this.parentBinding = binding.Substring(0, dotPos);
                this.bindingName = binding.Substring(dotPos + 1);
            }
            this.entity = entity;
            entityFactory = entity.GetBuilder();
            entityConverter = entity.GetBuilder();
            entityType = entity.GetEntityType();
        }
    }
}
