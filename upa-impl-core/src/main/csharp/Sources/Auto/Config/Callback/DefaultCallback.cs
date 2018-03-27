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



namespace Net.Vpc.Upa.Impl.Config.Callback
{


    /**
     * Created by vpc on 7/25/15.
     */
    public class DefaultCallback : Net.Vpc.Upa.Callback {

        protected internal Net.Vpc.Upa.Impl.Config.Callback.MethodArgumentsConverter converter;

        protected internal object instance;

        protected internal System.Reflection.MethodInfo method;

        private Net.Vpc.Upa.CallbackType callbackType;

        private Net.Vpc.Upa.ObjectType objectType;

        private System.Collections.Generic.IDictionary<string , object> configuration;

        private Net.Vpc.Upa.EventPhase phase;

        public DefaultCallback(object o, System.Reflection.MethodInfo m, Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.EventPhase phase, Net.Vpc.Upa.ObjectType objectType, Net.Vpc.Upa.Impl.Config.Callback.MethodArgumentsConverter converter, System.Collections.Generic.IDictionary<string , object> configuration) {
            this.converter = converter;
            this.instance = o;
            this.method = m;
            this.objectType = objectType;
            this.callbackType = callbackType;
            this.configuration = configuration;
            this.phase = phase;
        }

        public virtual Net.Vpc.Upa.EventPhase GetPhase() {
            return phase;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetConfiguration() {
            return configuration;
        }

        public virtual Net.Vpc.Upa.CallbackType GetCallbackType() {
            return callbackType;
        }

        public virtual Net.Vpc.Upa.ObjectType GetObjectType() {
            return objectType;
        }


        public virtual object Invoke(params object [] arguments) {
            try {
                return method.Invoke(instance, converter.Convert(arguments));
            } catch (System.Exception e) {
                throw Net.Vpc.Upa.Impl.Util.PlatformUtils.CreateRuntimeException(e);
            }
        }


        public override bool Equals(object o1) {
            if (this == o1) {
                return true;
            }
            if (o1 == null || GetType() != o1.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback that = (Net.Vpc.Upa.Impl.Config.Callback.DefaultCallback) o1;
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
