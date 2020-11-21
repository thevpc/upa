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



namespace Net.TheVpc.Upa.Impl.Context
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/10/12 12:27 AM
     */
    public class DefaultEntityTriggerContext : Net.TheVpc.Upa.Callbacks.EntityTriggerContext {

        private Net.TheVpc.Upa.Entity entityManager;

        private Net.TheVpc.Upa.Callbacks.Trigger triggerObject;

        private Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext;

        public DefaultEntityTriggerContext(Net.TheVpc.Upa.Entity entityManager, Net.TheVpc.Upa.Callbacks.Trigger triggerObject, Net.TheVpc.Upa.Persistence.EntityExecutionContext executionContext) {
            this.entityManager = entityManager;
            this.triggerObject = triggerObject;
            this.executionContext = executionContext;
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entityManager;
        }

        public virtual Net.TheVpc.Upa.Callbacks.Trigger GetTrigger() {
            return triggerObject;
        }

        public virtual Net.TheVpc.Upa.Persistence.EntityExecutionContext GetEntityExecutionContext() {
            return executionContext;
        }
    }
}
