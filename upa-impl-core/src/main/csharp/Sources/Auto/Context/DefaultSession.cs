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



namespace Net.TheVpc.Upa.Impl.Context
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 9/12/12 1:21 AM
     */
    public class DefaultSession : Net.TheVpc.Upa.Session {

        protected internal static readonly System.Diagnostics.TraceSource log = new System.Diagnostics.TraceSource((typeof(Net.TheVpc.Upa.Impl.Context.DefaultSession)).FullName);

        private System.Collections.Generic.IList<Net.TheVpc.Upa.SessionContext> stack = new System.Collections.Generic.List<Net.TheVpc.Upa.SessionContext>();

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Callbacks.SessionListener> sessionListeners = new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.SessionListener>();

        public DefaultSession() {
            PushContext();
        }

        public virtual Net.TheVpc.Upa.SessionContext GetCurrentContext() {
            return stack[(stack).Count - 1];
        }


        public virtual void PushContext() {
            stack.Add(new Net.TheVpc.Upa.Impl.Context.DefaultSessionContext());
            if ((sessionListeners).Count > 0) {
                foreach (Net.TheVpc.Upa.Callbacks.SessionListener sessionListener in new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.SessionListener>(sessionListeners)) {
                    sessionListener.PushContext(this);
                }
            }
        }


        public virtual void PopContext() {
            if ((sessionListeners).Count > 0) {
                foreach (Net.TheVpc.Upa.Callbacks.SessionListener sessionListener in new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.SessionListener>(sessionListeners)) {
                    sessionListener.PopContext(this);
                }
            }
            stack.RemoveAt((stack).Count - 1);
        }


        public virtual void SetParam(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, string name, object @value) {
            GetCurrentContext().SetParam(persistenceUnit, name, @value);
        }

        public virtual  T GetImmediateParam<T>(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.SessionContext> v = stack;
            Net.TheVpc.Upa.SessionContext m = v[(v).Count - 1];
            if (m.ContainsParam(persistenceUnit, name)) {
                return m.GetParam<T>(persistenceUnit, type, name, defaultValue);
            }
            return defaultValue;
        }


        public virtual  T GetParam<T>(Net.TheVpc.Upa.PersistenceUnit persistenceUnit, System.Type type, string name, T defaultValue) {
            System.Collections.Generic.IList<Net.TheVpc.Upa.SessionContext> v = stack;
            for (int i = (v).Count - 1; i >= 0; i--) {
                Net.TheVpc.Upa.SessionContext m = v[i];
                if (m.ContainsParam(persistenceUnit, name)) {
                    return m.GetParam<T>(persistenceUnit, type, name, defaultValue);
                }
            }
            return defaultValue;
        }


        public virtual void Close() {
            while ((stack).Count > 0) {
                PopContext();
            }
            if ((sessionListeners).Count > 0) {
                foreach (Net.TheVpc.Upa.Callbacks.SessionListener sessionListener in new System.Collections.Generic.List<Net.TheVpc.Upa.Callbacks.SessionListener>(sessionListeners)) {
                    sessionListener.CloseSession(this);
                }
            }
            log.TraceEvent(System.Diagnostics.TraceEventType.Verbose,60,Net.TheVpc.Upa.Impl.FwkConvertUtils.LogMessageExceptionFormatter("Session '{'{0}'}' : Closed",null,this));
        }


        public virtual void Init(Net.TheVpc.Upa.PersistenceGroup manager) {
        }


        public virtual void AddSessionListener(Net.TheVpc.Upa.Callbacks.SessionListener sessionListener) {
            sessionListeners.Add(sessionListener);
        }


        public virtual void RemoveSessionListener(Net.TheVpc.Upa.Callbacks.SessionListener sessionListener) {
            sessionListeners.Remove(sessionListener);
        }


        public override string ToString() {
            return "Session" + ((int)(System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(this))).ToString("X").ToUpper();
        }
    }
}
