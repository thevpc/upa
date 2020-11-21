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



namespace Net.TheVpc.Upa.Impl.Config.Callback
{


    /**
     * Created by vpc on 7/25/15.
     */
    public class DefaultCallback : Net.TheVpc.Upa.Callback {

        protected internal Net.TheVpc.Upa.Impl.Config.Callback.MethodArgumentsConverter converter;

        protected internal object instance;

        protected internal System.Reflection.MethodInfo method;

        private Net.TheVpc.Upa.CallbackType callbackType;

        private Net.TheVpc.Upa.ObjectType objectType;

        private System.Collections.Generic.IDictionary<string , object> configuration;

        private Net.TheVpc.Upa.EventPhase phase;

        public DefaultCallback(object o, System.Reflection.MethodInfo m, Net.TheVpc.Upa.CallbackType callbackType, Net.TheVpc.Upa.EventPhase phase, Net.TheVpc.Upa.ObjectType objectType, Net.TheVpc.Upa.Impl.Config.Callback.MethodArgumentsConverter converter, System.Collections.Generic.IDictionary<string , object> configuration) {
            this.converter = converter;
            this.instance = o;
            this.method = m;
            this.objectType = objectType;
            this.callbackType = callbackType;
            this.configuration = configuration;
            this.phase = phase;
        }

        public virtual Net.TheVpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetConfiguration() {
            return configuration;
        }

        public virtual Net.TheVpc.Upa.CallbackType GetCallbackType() {
            return callbackType;
        }

        public virtual Net.TheVpc.Upa.ObjectType GetObjectType() {
            return objectType;
        }


        public virtual object Invoke(params object [] arguments) {
            try {
                return method.Invoke(instance, converter.Convert(arguments));
            } catch (System.Exception e) {
                throw Net.TheVpc.Upa.Impl.Util.PlatformUtils.CreateRuntimeException(e);
            }
        }


        public override bool Equals(object o1) {
            if (this == o1) {
                return true;
            }
            if (o1 == null || GetType() != o1.GetType()) {
                return false;
            }
            Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback that = (Net.TheVpc.Upa.Impl.Config.Callback.DefaultCallback) o1;
            if (converter != null ? !converter.Equals(that.converter) : that.converter != null) {
                return false;
            }
            if (instance != null ? !instance.Equals(that.instance) : that.instance != null) {
                return false;
            }
            return !(method != null ? !method.Equals(that.method) : that.method != null);
        }


        public override int GetHashCode() {
            int result = converter != null ? converter.GetHashCode() : 0;
            result = 31 * result + (instance != null ? instance.GetHashCode() : 0);
            result = 31 * result + (method != null ? method.GetHashCode() : 0);
            return result;
        }
    }
}
