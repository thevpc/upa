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



namespace Net.Vpc.Upa
{


    /**
     *
     * @author vpc
     */
    public class InvokeContext {

        private string login;

        private string credentials;

        private bool privileged;

        private Net.Vpc.Upa.TransactionType transactionType = Net.Vpc.Upa.TransactionType.REQUIRED;

        public virtual string GetLogin() {
            return login;
        }

        public virtual void SetLogin(string login) {
            this.login = login;
        }

        public virtual string GetCredentials() {
            return credentials;
        }

        public virtual void SetCredentials(string credentials) {
            this.credentials = credentials;
        }

        public virtual bool IsPrivileged() {
            return privileged;
        }

        public virtual void SetPrivileged(bool privileged) {
            this.privileged = privileged;
        }

        public virtual Net.Vpc.Upa.TransactionType GetTransactionType() {
            return transactionType;
        }

        public virtual void SetTransactionType(Net.Vpc.Upa.TransactionType transactionType) {
            this.transactionType = transactionType;
        }
    }
}
