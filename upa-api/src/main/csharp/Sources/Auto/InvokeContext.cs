/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class InvokeContext : System.ICloneable {

        private string login;

        private string credentials;

        private bool privileged;

        private Net.Vpc.Upa.TransactionType transactionType = Net.Vpc.Upa.TransactionType.REQUIRED;

        private Net.Vpc.Upa.PersistenceGroup persistenceGroup;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

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

        public virtual Net.Vpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }

        public virtual void SetPersistenceGroup(Net.Vpc.Upa.PersistenceGroup persistenceGroup) {
            this.persistenceGroup = persistenceGroup;
        }

        public virtual Net.Vpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual void SetPersistenceUnit(Net.Vpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
        }

        public virtual Net.Vpc.Upa.InvokeContext Copy() {
            try {
                return (Net.Vpc.Upa.InvokeContext) base.MemberwiseClone();
            } catch (System.Exception ex) {
                throw new Net.Vpc.Upa.Exceptions.UnexpectedException(ex);
            }
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
