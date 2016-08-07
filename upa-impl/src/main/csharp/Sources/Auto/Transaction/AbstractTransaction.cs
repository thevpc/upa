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
     * @creationdate 9/16/12 5:02 PM
     */
    public abstract class AbstractTransaction : Net.Vpc.Upa.Transaction {

        private Net.Vpc.Upa.TransactionStatus status = Net.Vpc.Upa.TransactionStatus.NOT_ACTIVE;

        protected internal System.Collections.Generic.IList<Net.Vpc.Upa.TransactionListener> listeners = new System.Collections.Generic.List<Net.Vpc.Upa.TransactionListener>();

        public virtual Net.Vpc.Upa.TransactionStatus GetStatus() {
            return status;
        }

        public virtual void SetStatus(Net.Vpc.Upa.TransactionStatus status) {
            this.status = status;
        }


        public virtual void Begin() /* throws Net.Vpc.Upa.Exceptions.TransactionException */  {
            try {
                BeginImpl();
                SetStatus(Net.Vpc.Upa.TransactionStatus.ACTIVE);
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.TransactionException(e, new Net.Vpc.Upa.Types.I18NString("TransactionCommitFailed"));
            }
        }


        public virtual void Commit() /* throws Net.Vpc.Upa.Exceptions.TransactionException */  {
            try {
                CommitImpl();
                SetStatus(Net.Vpc.Upa.TransactionStatus.COMMITTED);
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.TransactionException(e, new Net.Vpc.Upa.Types.I18NString("TransactionCommitFailed"));
            }
        }


        public virtual void Rollback() /* throws Net.Vpc.Upa.Exceptions.TransactionException */  {
            try {
                RollbackImpl();
                SetStatus(Net.Vpc.Upa.TransactionStatus.ROLLED_BACK);
            } catch (System.Exception e) {
                throw new Net.Vpc.Upa.Exceptions.TransactionException(e, new Net.Vpc.Upa.Types.I18NString("TransactionCommitFailed"));
            }
        }


        public virtual void Close() {
            SetStatus(Net.Vpc.Upa.TransactionStatus.CLOSED);
        }


        public virtual void AddTransactionListener(Net.Vpc.Upa.TransactionListener transactionListener) {
            listeners.Add(transactionListener);
        }


        public virtual void RemoveTransactionListener(Net.Vpc.Upa.TransactionListener transactionListener) {
            listeners.Remove(transactionListener);
        }

        protected internal abstract void BeginImpl() /* throws System.Exception */ ;

        public abstract void CommitImpl() /* throws System.Exception */ ;

        public abstract void RollbackImpl() /* throws System.Exception */ ;
    }
}
