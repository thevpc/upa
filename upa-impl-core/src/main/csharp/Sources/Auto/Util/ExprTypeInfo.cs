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



namespace Net.TheVpc.Upa.Impl.Util
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ExprTypeInfo {

        private Net.TheVpc.Upa.Types.DataTypeTransform transform;

        private object oldReferrer;

        private object referrer;

        public ExprTypeInfo() {
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return transform;
        }

        public virtual void SetTransform(Net.TheVpc.Upa.Types.DataTypeTransform transform) {
            this.transform = transform;
        }

        public virtual object GetOldReferrer() {
            return oldReferrer;
        }

        public virtual void SetOldReferrer(object oldReferrer) {
            this.oldReferrer = oldReferrer;
        }

        public virtual object GetReferrer() {
            return referrer;
        }

        public virtual void SetReferrer(object referrer) {
            this.referrer = referrer;
        }
    }
}
