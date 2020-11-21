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
     * @creationdate 9/9/12 4:33 PM
     */
    public class DefaultTrigger : Net.TheVpc.Upa.Impl.AbstractUPAObject, Net.TheVpc.Upa.Callbacks.Trigger {

        private Net.TheVpc.Upa.Entity entity;

        private Net.TheVpc.Upa.Callbacks.EntityInterceptor interceptor;

        private Net.TheVpc.Upa.Callbacks.EntityListener listener;

        public DefaultTrigger() {
        }

        public virtual Net.TheVpc.Upa.Entity GetEntity() {
            return entity;
        }

        public virtual void SetEntity(Net.TheVpc.Upa.Entity entity) {
            this.entity = entity;
        }

        public virtual Net.TheVpc.Upa.Callbacks.EntityInterceptor GetInterceptor() {
            return interceptor;
        }

        public virtual void SetInterceptor(Net.TheVpc.Upa.Callbacks.EntityInterceptor interceptor) {
            this.interceptor = interceptor;
        }

        public virtual Net.TheVpc.Upa.Callbacks.EntityListener GetListener() {
            return listener;
        }

        public virtual void SetListener(Net.TheVpc.Upa.Callbacks.EntityListener listener) {
            this.listener = listener;
        }


        public override string GetAbsoluteName() {
            return GetEntity().GetAbsoluteName() + "." + GetName();
        }

        public override void Close() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
        }
    }
}
