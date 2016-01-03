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



namespace Net.Vpc.Upa.Impl.Util
{


    /**
     * Created by vpc on 7/25/15.
     */
    public sealed class CallbackInvokerKey {

        private Net.Vpc.Upa.CallbackType callbackType;

        private Net.Vpc.Upa.ObjectType objectType;

        private bool system;

        private string name;

        public CallbackInvokerKey(Net.Vpc.Upa.CallbackType callbackType, Net.Vpc.Upa.ObjectType objectType, string name, bool system) {
            this.callbackType = callbackType;
            this.objectType = objectType;
            this.system = system;
            this.name = name;
        }

        public Net.Vpc.Upa.CallbackType GetCallbackType() {
            return callbackType;
        }

        public Net.Vpc.Upa.ObjectType GetObjectType() {
            return objectType;
        }

        public bool IsSystem() {
            return system;
        }

        public string GetName() {
            return name;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.Vpc.Upa.Impl.Util.CallbackInvokerKey that = (Net.Vpc.Upa.Impl.Util.CallbackInvokerKey) o;
            if (system != that.system) return false;
            if (callbackType != that.callbackType) return false;
            if (objectType != that.objectType) return false;
            return !(name != null ? !name.Equals(that.name) : that.name != null);
        }


        public override int GetHashCode() {
            int result = callbackType != null ? callbackType.GetHashCode() : 0;
            result = 31 * result + (objectType != null ? objectType.GetHashCode() : 0);
            result = 31 * result + (system ? 1 : 0);
            result = 31 * result + (name != null ? name.GetHashCode() : 0);
            return result;
        }
    }
}
