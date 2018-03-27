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
    public sealed class PosInvokeArgument : Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument {

        private string name;

        private System.Type platformType;

        private int pos;

        private bool acceptSubClasses;

        public PosInvokeArgument(string name, System.Type platformType, int pos, bool acceptSubClasses) {
            this.name = name;
            this.platformType = platformType;
            this.pos = pos;
            this.acceptSubClasses = acceptSubClasses;
        }


        public string GetName() {
            return name;
        }


        public System.Type GetPlatformType() {
            return platformType;
        }


        public object GetValue(object[] arguments) {
            return arguments[pos];
        }


        public bool IsAcceptSubClasses() {
            return acceptSubClasses;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument that = (Net.Vpc.Upa.Impl.Config.Callback.PosInvokeArgument) o;
            if (pos != that.pos) return false;
            if (acceptSubClasses != that.acceptSubClasses) return false;
            if (name != null ? !name.Equals(that.name) : that.name != null) return false;
            return !(platformType != null ? !platformType.Equals(that.platformType) : that.platformType != null);
        }


        public override int GetHashCode() {
            int result = name != null ? name.GetHashCode() : 0;
            result = 31 * result + (platformType != null ? platformType.GetHashCode() : 0);
            result = 31 * result + pos;
            result = 31 * result + (acceptSubClasses ? 1 : 0);
            return result;
        }
    }
}
