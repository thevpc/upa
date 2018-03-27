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
     * @creationdate 9/9/12 4:33 PM
     */
    public class DefaultTrigger : Net.Vpc.Upa.Impl.AbstractUPAObject, Net.Vpc.Upa.Callbacks.Trigger {

        private Net.Vpc.Upa.Entity entity;

        private Net.Vpc.Upa.Callbacks.EntityInterceptor interceptor;

        private Net.Vpc.Upa.Callbacks.EntityListener listener;

        public DefaultTrigger() {
        }

        public virtual Net.Vpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual void SetEntity(Net.Vpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public virtual Net.Vpc.Upa.Callbacks.EntityInterceptor GetInterceptor() {
            return interceptor;
        }

        public virtual void SetInterceptor(Net.Vpc.Upa.Callbacks.EntityInterceptor interceptor) {
            this.interceptor = interceptor;
        }

        public virtual Net.Vpc.Upa.Callbacks.EntityListener GetListener() {
            return listener;
        }

        public virtual void SetListener(Net.Vpc.Upa.Callbacks.EntityListener listener) {
            this.listener = listener;
        }


        public override string GetAbsoluteName() {
            return GetEntity().GetAbsoluteName() + "." + GetName();
        }

        public override void Close() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
        }
    }
}
