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
     * @author taha.bensalah@gmail.com
     */
    public class CallbackConfig {

        private object instance;

        private System.Reflection.MethodInfo method;

        private Net.Vpc.Upa.CallbackType callbackType;

        private Net.Vpc.Upa.EventPhase phase;

        private System.Collections.Generic.IDictionary<string , object> configuration;

        public CallbackConfig() {
        }

        public CallbackConfig(object instance, System.Reflection.MethodInfo method, Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.EventPhase phase) {
            this.instance = instance;
            this.method = method;
            this.phase = phase;
            this.callbackType = callbackType;
        }

        public CallbackConfig(object instance, System.Reflection.MethodInfo method, Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.EventPhase phase, System.Collections.Generic.IDictionary<string , object> configuration) {
            this.instance = instance;
            this.method = method;
            this.callbackType = callbackType;
            this.phase = phase;
            this.configuration = configuration;
        }

        public virtual Net.Vpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual object GetInstance() {
            return instance;
        }

        public virtual Net.Vpc.Upa.CallbackConfig SetInstance(object instance) {
            this.instance = instance;
            return this;
        }

        public virtual System.Reflection.MethodInfo GetMethod() {
            return method;
        }

        public virtual Net.Vpc.Upa.CallbackConfig SetMethod(System.Reflection.MethodInfo method) {
            this.method = method;
            return this;
        }

        public virtual Net.Vpc.Upa.CallbackType GetCallbackType() {
            return callbackType;
        }

        public virtual Net.Vpc.Upa.CallbackConfig SetCallbackType(Net.Vpc.Upa.CallbackType callbackType) {
            this.callbackType = callbackType;
            return this;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetConfiguration() {
            return configuration;
        }

        public virtual Net.Vpc.Upa.CallbackConfig SetConfiguration(System.Collections.Generic.IDictionary<string , object> configuration) {
            this.configuration = configuration;
            return this;
        }

        public virtual Net.Vpc.Upa.CallbackConfig PutConfig(string name, object @value) {
            if (configuration == null) {
                configuration = new System.Collections.Generic.Dictionary<string , object>();
            }
            configuration[name]=@value;
            return this;
        }
    }
}
