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



namespace Net.TheVpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 12:39 AM
     */
    public abstract class AbstractEntityExtension : Net.TheVpc.Upa.Persistence.EntityExtension {

        private Net.TheVpc.Upa.Extensions.EntityExtensionDefinition spec;

        private Net.TheVpc.Upa.Entity entity;

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;


        public virtual Net.TheVpc.Upa.Extensions.EntityExtensionDefinition GetDefinition() {
            return spec;
        }


        public virtual void Install(Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityOperationManager entityOperationManager, Net.TheVpc.Upa.Extensions.EntityExtensionDefinition spec) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            this.spec = spec;
            this.entity = entity;
            this.persistenceUnit = entity.GetPersistenceUnit();
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }


        public virtual void CommitModelChanges() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }
    }
}
