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



namespace Net.TheVpc.Upa
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class InvokeContext : System.ICloneable {

        private string login;

        private string credentials;

        private bool privileged;

        private Net.TheVpc.Upa.TransactionType transactionType = Net.TheVpc.Upa.TransactionType.REQUIRED;

        private Net.TheVpc.Upa.PersistenceGroup persistenceGroup;

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

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

        public virtual Net.TheVpc.Upa.TransactionType GetTransactionType() {
            return transactionType;
        }

        public virtual void SetTransactionType(Net.TheVpc.Upa.TransactionType transactionType) {
            this.transactionType = transactionType;
        }

        public virtual Net.TheVpc.Upa.PersistenceGroup GetPersistenceGroup() {
            return persistenceGroup;
        }

        public virtual void SetPersistenceGroup(Net.TheVpc.Upa.PersistenceGroup persistenceGroup) {
            this.persistenceGroup = persistenceGroup;
        }

        public virtual Net.TheVpc.Upa.PersistenceUnit GetPersistenceUnit() {
            return persistenceUnit;
        }

        public virtual void SetPersistenceUnit(Net.TheVpc.Upa.PersistenceUnit persistenceUnit) {
            this.persistenceUnit = persistenceUnit;
        }

        public virtual Net.TheVpc.Upa.InvokeContext Copy() {
            try {
                return (Net.TheVpc.Upa.InvokeContext) base.MemberwiseClone();
            } catch (System.Exception ex) {
                throw new Net.TheVpc.Upa.Exceptions.UnexpectedException(ex);
            }
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        virtual public object Clone() { return base.MemberwiseClone();}
    }
}
