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
     * @author taha.bensalah@gmail.com
     */
    public class MethodCallback {

        private object instance;

        private System.Reflection.MethodInfo method;

        private Net.TheVpc.Upa.ObjectType objectType;

        private Net.TheVpc.Upa.CallbackType callbackType;

        private Net.TheVpc.Upa.EventPhase phase;

        private System.Collections.Generic.IDictionary<string , object> configuration;

        public MethodCallback() {
        }

        public MethodCallback(object instance, System.Reflection.MethodInfo method, Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.EventPhase phase) {
            this.instance = instance;
            this.method = method;
            this.phase = phase;
            this.callbackType = callbackType;
        }

        public MethodCallback(object instance, System.Reflection.MethodInfo method, Net.TheVpc.Upa.ObjectType objectType, Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.EventPhase phase, System.Collections.Generic.IDictionary<string , object> configuration) {
            this.instance = instance;
            this.objectType = objectType;
            this.method = method;
            this.callbackType = callbackType;
            this.phase = phase;
            this.configuration = configuration;
        }

        public virtual Net.TheVpc.Upa.ObjectType GetObjectType() {
            return objectType;
        }

        public virtual Net.TheVpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual object GetInstance() {
            return instance;
        }

        public virtual Net.TheVpc.Upa.MethodCallback SetInstance(object instance) {
            this.instance = instance;
            return this;
        }

        public virtual System.Reflection.MethodInfo GetMethod() {
            return method;
        }

        public virtual Net.TheVpc.Upa.MethodCallback SetMethod(System.Reflection.MethodInfo method) {
            this.method = method;
            return this;
        }

        public virtual Net.TheVpc.Upa.CallbackType GetCallbackType() {
            return callbackType;
        }

        public virtual Net.TheVpc.Upa.MethodCallback SetCallbackType(Net.TheVpc.Upa.CallbackType callbackType) {
            this.callbackType = callbackType;
            return this;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetConfiguration() {
            return configuration;
        }

        public virtual Net.TheVpc.Upa.MethodCallback SetConfiguration(System.Collections.Generic.IDictionary<string , object> configuration) {
            this.configuration = configuration;
            return this;
        }

        public virtual Net.TheVpc.Upa.MethodCallback PutConfig(string name, object @value) {
            if (configuration == null) {
                configuration = new System.Collections.Generic.Dictionary<string , object>();
            }
            configuration[name]=@value;
            return this;
        }
    }
}
