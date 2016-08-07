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



namespace Net.Vpc.Upa.Impl.Util
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class ExprTypeInfo {

        private Net.Vpc.Upa.Types.DataTypeTransform transform;

        private object oldReferrer;

        private object referrer;

        public ExprTypeInfo() {
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return transform;
        }

        public virtual void SetTransform(Net.Vpc.Upa.Types.DataTypeTransform transform) {
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
