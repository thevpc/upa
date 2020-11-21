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



namespace Net.TheVpc.Upa.Impl.Transaction
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/16/12 5:02 PM
     */
    public abstract class AbstractTransaction : Net.TheVpc.Upa.Transaction {

        private Net.TheVpc.Upa.TransactionStatus status = Net.TheVpc.Upa.TransactionStatus.NOT_ACTIVE;

        protected internal System.Collections.Generic.IList<Net.TheVpc.Upa.TransactionListener> listeners = new System.Collections.Generic.List<Net.TheVpc.Upa.TransactionListener>();

        public virtual Net.TheVpc.Upa.TransactionStatus GetStatus() {
            return status;
        }

        public virtual void SetStatus(Net.TheVpc.Upa.TransactionStatus status) {
            this.status = status;
        }


        public virtual void Begin() /* throws Net.TheVpc.Upa.Exceptions.TransactionException */  {
            try {
                BeginImpl();
                SetStatus(Net.TheVpc.Upa.TransactionStatus.ACTIVE);
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.TransactionException(e, new Net.TheVpc.Upa.Types.I18NString("TransactionCommitFailed"));
            }
        }


        public virtual void Commit() /* throws Net.TheVpc.Upa.Exceptions.TransactionException */  {
            try {
                CommitImpl();
                SetStatus(Net.TheVpc.Upa.TransactionStatus.COMMITTED);
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.TransactionException(e, new Net.TheVpc.Upa.Types.I18NString("TransactionCommitFailed"));
            }
        }


        public virtual void Rollback() /* throws Net.TheVpc.Upa.Exceptions.TransactionException */  {
            try {
                RollbackImpl();
                SetStatus(Net.TheVpc.Upa.TransactionStatus.ROLLED_BACK);
            } catch (System.Exception e) {
                throw new Net.TheVpc.Upa.Exceptions.TransactionException(e, new Net.TheVpc.Upa.Types.I18NString("TransactionCommitFailed"));
            }
        }


        public virtual void Close() {
            SetStatus(Net.TheVpc.Upa.TransactionStatus.CLOSED);
        }


        public virtual void AddTransactionListener(Net.TheVpc.Upa.TransactionListener transactionListener) {
            listeners.Add(transactionListener);
        }


        public virtual void RemoveTransactionListener(Net.TheVpc.Upa.TransactionListener transactionListener) {
            listeners.Remove(transactionListener);
        }

        protected internal abstract void BeginImpl() /* throws System.Exception */ ;

        public abstract void CommitImpl() /* throws System.Exception */ ;

        public abstract void RollbackImpl() /* throws System.Exception */ ;
    }
}
