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



namespace Net.Vpc.Upa
{


    /**
     * Created by vpc on 7/20/15.
     */
    public class DefaultEntityDescriptor : Net.Vpc.Upa.EntityDescriptor {

        private string name;

        private string shortName;

        private System.Type idType;

        private System.Type entityType;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers;

        private Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> excludeModifiers;

        private string packagePath;

        private string listOrder;

        private string archivingOrder;

        private int position;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.EntityExtensionDefinition> entityExtensions;

        private object source;

        public System.Collections.Generic.IList<Net.Vpc.Upa.FieldDescriptor> fieldDescriptors;

        public System.Collections.Generic.IList<Net.Vpc.Upa.IndexDescriptor> indexDescriptors;

        public System.Collections.Generic.IList<Net.Vpc.Upa.RelationshipDescriptor> relationshipDescriptors;

        public System.Collections.Generic.IDictionary<string , object> properties;

        public virtual string GetName() {
            return name;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetName(string name) {
            this.name = name;
            return this;
        }

        public virtual string GetShortName() {
            return shortName;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetShortName(string shortName) {
            this.shortName = shortName;
            return this;
        }

        public virtual System.Type GetIdType() {
            return idType;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetIdType(System.Type idType) {
            this.idType = idType;
            return this;
        }

        public virtual System.Type GetEntityType() {
            return entityType;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetEntityType(System.Type entityType) {
            this.entityType = entityType;
            return this;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetModifiers() {
            return modifiers;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> modifiers) {
            this.modifiers = modifiers;
            return this;
        }

        public virtual Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> GetExcludeModifiers() {
            return excludeModifiers;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetExcludeModifiers(Net.Vpc.Upa.FlagSet<Net.Vpc.Upa.EntityModifier> excludeModifiers) {
            this.excludeModifiers = excludeModifiers;
            return this;
        }

        public virtual string GetPackagePath() {
            return packagePath;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetPackagePath(string packagePath) {
            this.packagePath = packagePath;
            return this;
        }

        public virtual int GetPosition() {
            return position;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetPosition(int position) {
            this.position = position;
            return this;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.EntityExtensionDefinition> GetEntityExtensions() {
            return entityExtensions;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetEntityExtensions(System.Collections.Generic.IList<Net.Vpc.Upa.Extensions.EntityExtensionDefinition> entityExtensions) {
            this.entityExtensions = entityExtensions;
            return this;
        }

        public virtual object GetSource() {
            return source;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetSource(object source) {
            this.source = source;
            return this;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.FieldDescriptor> GetFieldDescriptors() {
            return fieldDescriptors;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetFieldDescriptors(System.Collections.Generic.IList<Net.Vpc.Upa.FieldDescriptor> fieldDescriptors) {
            this.fieldDescriptors = fieldDescriptors;
            return this;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.IndexDescriptor> GetIndexDescriptors() {
            return indexDescriptors;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetIndexDescriptors(System.Collections.Generic.IList<Net.Vpc.Upa.IndexDescriptor> indexDescriptors) {
            this.indexDescriptors = indexDescriptors;
            return this;
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.RelationshipDescriptor> GetRelationshipDescriptors() {
            return relationshipDescriptors;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetRelationshipDescriptors(System.Collections.Generic.IList<Net.Vpc.Upa.RelationshipDescriptor> relationshipDescriptors) {
            this.relationshipDescriptors = relationshipDescriptors;
            return this;
        }


        public virtual string GetListOrder() {
            return listOrder;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetListOrder(string listOrder) {
            this.listOrder = listOrder;
            return this;
        }

        public virtual string GetArchivingOrder() {
            return archivingOrder;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetArchivingOrder(string archivingOrder) {
            this.archivingOrder = archivingOrder;
            return this;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetProperties() {
            return properties;
        }

        public virtual Net.Vpc.Upa.DefaultEntityDescriptor SetProperties(System.Collections.Generic.IDictionary<string , object> properties) {
            this.properties = properties;
            return this;
        }


        public override string ToString() {
            return "DefaultEntityDescriptor{" + "name='" + name + '\'' + ", idType=" + idType + ", entityType=" + entityType + ", source=" + source + ", packagePath='" + packagePath + '\'' + ", modifiers=" + modifiers + '}';
        }
    }
}
