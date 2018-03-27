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



namespace Net.Vpc.Upa.Impl.Extension
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 8/30/12 12:39 AM
     */
    public abstract class AbstractEntityExtension : Net.Vpc.Upa.Persistence.EntityExtension {

        private Net.Vpc.Upa.Extensions.EntityExtensionDefinition spec;

        private Net.Vpc.Upa.Entity entity;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;


        public virtual Net.Vpc.Upa.Extensions.EntityExtensionDefinition GetDefinition() {
            return spec;
        }


        public virtual void Install(Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager, Net.Vpc.Upa.Extensions.EntityExtensionDefinition spec) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            this.spec = spec;
            this.entity = entity;
            this.persistenceUnit = entity.GetPersistenceUnit();
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }


        public virtual void CommitModelChanges() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }
    }
}
