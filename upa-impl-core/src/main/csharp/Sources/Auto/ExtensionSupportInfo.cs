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



namespace Net.TheVpc.Upa.Impl
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/5/13 9:47 PM*/
    internal class ExtensionSupportInfo {

        private System.Type entityExtensionDefinitionType;

        private Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extension;

        private Net.TheVpc.Upa.Persistence.EntityExtension support;

        internal ExtensionSupportInfo(System.Type entityExtensionDefinitionType, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extension, Net.TheVpc.Upa.Persistence.EntityExtension support) {
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

        public virtual Net.TheVpc.Upa.Extensions.EntityExtensionDefinition GetExtension() {
            return extension;
        }

        public virtual void SetExtension(Net.TheVpc.Upa.Extensions.EntityExtensionDefinition extension) {
            this.extension = extension;
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityExtension GetSupport() {
            return support;
        }

        public virtual void SetSupport(Net.TheVpc.Upa.Persistence.EntityExtension support) {
            this.support = support;
        }
    }
}
