using Net.Vpc.Upa.Impl.Util;

namespace Net.Vpc.Upa.Impl.Config
{


    /**
    * @author Taha BEN Salah
    * @creationdate 1/7/13 2:32 PM*/
    internal class MakeSessionAwareMethodInterceptor2<T> {

        private readonly Net.Vpc.Upa.MethodFilter methodFilter;

        public MakeSessionAwareMethodInterceptor2(Net.Vpc.Upa.MethodFilter methodFilter) {
            this.methodFilter = methodFilter;
        }

        public virtual T MakeSessionAware() /* throws Net.Vpc.Upa.Exceptions.UPAException */
        {
            T t = (T)System.Activator.CreateInstance(typeof (T));
            return t.Proxy<T>(MyInterceptorMethod);
        }

        public object MyInterceptorMethod<T>(T@object, string methodName, object[] args, EmitProxyExecute<T> execute){
            if (methodFilter == null /*|| methodFilter.Accept(method)*/) {
                Net.Vpc.Upa.PersistenceGroup persistenceGroup = Net.Vpc.Upa.UPA.GetPersistenceGroup();
                Net.Vpc.Upa.Session s = null;
                try {
                    s = persistenceGroup.GetCurrentSession();
                } catch (Net.Vpc.Upa.Exceptions.CurrentSessionNotFoundException ignore) {
                }
                //ignore
                bool sessionCreated = false;
                if (s == null) {
                    s = persistenceGroup.OpenSession();
                    sessionCreated = true;
                }
                bool transactionCreated = false;
                persistenceGroup.GetPersistenceUnit().BeginTransaction(Net.Vpc.Upa.TransactionType.REQUIRED);
                transactionCreated = true;
                object ret = null;
                try {
                    ret = execute(@object, args);
                    persistenceGroup.GetPersistenceUnit().CommitTransaction();
                } catch (System.Exception e) {
                    if (transactionCreated) {
                        persistenceGroup.GetPersistenceUnit().RollbackTransaction();
                    }
                    throw e;
                } finally {
                    if (sessionCreated) {
                        s.Close();
                    }
                }
                return ret;
            } else {
                return execute(@object, args);
            }
        }
    }
}
