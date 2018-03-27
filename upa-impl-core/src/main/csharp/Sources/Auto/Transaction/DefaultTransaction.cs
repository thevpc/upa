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



namespace Net.Vpc.Upa.Impl.Transaction
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/16/12 4:59 PM
     */
    public class DefaultTransaction : Net.Vpc.Upa.Impl.Transaction.AbstractTransaction {

        protected internal System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.Vpc.Upa.Impl.Transaction.DefaultTransaction)).FullName);

        private Net.Vpc.Upa.Persistence.UConnection connection;

        public DefaultTransaction() {
        }

        public virtual void Init(Net.Vpc.Upa.Persistence.UConnection connection) {
            this.connection = connection;
        }


        public override void CommitImpl() /* throws System.Exception */  {
            if (/*IsLoggable=*/true) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Commit Transaction {0}",null,((int)(System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(this))).ToString("X").ToUpper()));
            }
            
        }


        protected internal override void BeginImpl() /* throws System.Exception */  {
            if (/*IsLoggable=*/true) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Begin  Transaction {0}",null,((int)(System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(this))).ToString("X").ToUpper()));
            }
        }


        public override void RollbackImpl() /* throws System.Exception */  {
            if (/*IsLoggable=*/true) {
                log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.Vpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Rollback Transaction {0}",null,((int)(System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(this))).ToString("X").ToUpper()));
            }
            
        }
    }
}
