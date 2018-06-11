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
     * @author taha.bensalah@gmail.com
     */
    public class MethodCallback {

        private object instance;

        private System.Reflection.MethodInfo method;

        private Net.Vpc.Upa.ObjectType objectType;

        private Net.Vpc.Upa.CallbackType callbackType;

        private Net.Vpc.Upa.EventPhase phase;

        private System.Collections.Generic.IDictionary<string , object> configuration;

        public MethodCallback() {
        }

        public MethodCallback(object instance, System.Reflection.MethodInfo method, Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.EventPhase phase) {
            this.instance = instance;
            this.method = method;
            this.phase = phase;
            this.callbackType = callbackType;
        }

        public MethodCallback(object instance, System.Reflection.MethodInfo method, Net.Vpc.Upa.ObjectType objectType, Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.EventPhase phase, System.Collections.Generic.IDictionary<string , object> configuration) {
            this.instance = instance;
            this.objectType = objectType;
            this.method = method;
            this.callbackType = callbackType;
            this.phase = phase;
            this.configuration = configuration;
        }

        public virtual Net.Vpc.Upa.ObjectType GetObjectType() {
            return objectType;
        }

        public virtual Net.Vpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual object GetInstance() {
            return instance;
        }

        public virtual Net.Vpc.Upa.MethodCallback SetInstance(object instance) {
            this.instance = instance;
            return this;
        }

        public virtual System.Reflection.MethodInfo GetMethod() {
            return method;
        }

        public virtual Net.Vpc.Upa.MethodCallback SetMethod(System.Reflection.MethodInfo method) {
            this.method = method;
            return this;
        }

        public virtual Net.Vpc.Upa.CallbackType GetCallbackType() {
            return callbackType;
        }

        public virtual Net.Vpc.Upa.MethodCallback SetCallbackType(Net.Vpc.Upa.CallbackType callbackType) {
            this.callbackType = callbackType;
            return this;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetConfiguration() {
            return configuration;
        }

        public virtual Net.Vpc.Upa.MethodCallback SetConfiguration(System.Collections.Generic.IDictionary<string , object> configuration) {
            this.configuration = configuration;
            return this;
        }

        public virtual Net.Vpc.Upa.MethodCallback PutConfig(string name, object @value) {
            if (configuration == null) {
                configuration = new System.Collections.Generic.Dictionary<string , object>();
            }
            configuration[name]=@value;
            return this;
        }
    }
}
