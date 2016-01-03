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



namespace Net.Vpc.Upa.Impl.Context
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/10/12 12:27 AM
     */
    public class DefaultEntityTriggerContext : Net.Vpc.Upa.Callbacks.EntityTriggerContext {

        private Net.Vpc.Upa.Entity entityManager;

        private Net.Vpc.Upa.Callbacks.Trigger triggerObject;

        private Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext;

        public DefaultEntityTriggerContext(Net.Vpc.Upa.Entity entityManager, Net.Vpc.Upa.Callbacks.Trigger triggerObject, Net.Vpc.Upa.Persistence.EntityExecutionContext executionContext) {
            this.entityManager = entityManager;
            this.triggerObject = triggerObject;
            this.executionContext = executionContext;
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entityManager;
        }

        public virtual Net.Vpc.Upa.Callbacks.Trigger GetTrigger() {
            return triggerObject;
        }

        public virtual Net.Vpc.Upa.Persistence.EntityExecutionContext GetEntityExecutionContext() {
            return executionContext;
        }
    }
}
