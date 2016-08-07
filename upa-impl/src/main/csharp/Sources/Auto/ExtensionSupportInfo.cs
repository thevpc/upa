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



namespace Net.Vpc.Upa.Impl
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/5/13 9:47 PM*/
    internal class ExtensionSupportInfo {

        private System.Type entityExtensionDefinitionType;

        private Net.Vpc.Upa.Extensions.EntityExtensionDefinition extension;

        private Net.Vpc.Upa.Persistence.EntityExtension support;

        internal ExtensionSupportInfo(System.Type entityExtensionDefinitionType, Net.Vpc.Upa.Extensions.EntityExtensionDefinition extension, Net.Vpc.Upa.Persistence.EntityExtension support) {
            this.SetEntityExtensionDefinitionType(entityExtensionDefinitionType);
            this.SetExtension(extension);
            this.SetSupport(support);
        }

        public virtual System.Type GetEntityExtensionDefinitionType() {
            return entityExtensionDefinitionType;
        }

        public virtual void SetEntityExtensionDefinitionType(System.Type entityExtensionDefinitionType) {
            this.entityExtensionDefinitionType = entityExtensionDefinitionType;
        }

        public virtual Net.Vpc.Upa.Extensions.EntityExtensionDefinition GetExtension() {
            return extension;
        }

        public virtual void SetExtension(Net.Vpc.Upa.Extensions.EntityExtensionDefinition extension) {
            this.extension = extension;
        }

        public virtual Net.Vpc.Upa.Persistence.EntityExtension GetSupport() {
            return support;
        }

        public virtual void SetSupport(Net.Vpc.Upa.Persistence.EntityExtension support) {
            this.support = support;
        }
    }
}
