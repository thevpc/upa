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



namespace Net.Vpc.Upa.Impl
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 2:11 AM
     */
    internal class StackedSession : Net.Vpc.Upa.Session {

        private readonly Net.Vpc.Upa.Session session;

        public StackedSession(Net.Vpc.Upa.Session session) {
            this.session = session;
        }


        public virtual void Init(Net.Vpc.Upa.PersistenceGroup manager) {
            session.Init(manager);
        }


        public virtual void PushContext() {
            session.PushContext();
        }


        public virtual void PopContext() {
            session.PopContext();
        }

        public virtual Net.Vpc.Upa.SessionContext GetCurrentContext() {
            return session.GetCurrentContext();
        }


        public virtual void SetParam(Net.Vpc.Upa.PersistenceUnit persistenceUnit, string name, object @value) {
            session.SetParam(persistenceUnit, name, @value);
        }


        public virtual  T GetParam<T>(Net.Vpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue) {
            return session.GetParam<T>(persistenceUnit, type, name, defaultValue);
        }

        public virtual  T GetImmediateParam<T>(Net.Vpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue) {
            return session.GetImmediateParam<T>(persistenceUnit, type, name, defaultValue);
        }


        public virtual void AddSessionListener(Net.Vpc.Upa.Callbacks.SessionListener sessionListener) {
            session.AddSessionListener(sessionListener);
        }


        public virtual void RemoveSessionListener(Net.Vpc.Upa.Callbacks.SessionListener sessionListener) {
            session.RemoveSessionListener(sessionListener);
        }


        public virtual void Close() {
            session.PopContext();
        }
    }
}
