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
     * Created by vpc on 6/11/16.
     */
    public class MethodSignature {

        private string name;

        private System.Type[] parameterTypes;

        public MethodSignature(string name, System.Type[] parameterTypes) {
            this.name = name;
            this.parameterTypes = parameterTypes;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (!(o is Net.Vpc.Upa.Impl.Util.MethodSignature)) return false;
            Net.Vpc.Upa.Impl.Util.MethodSignature that = (Net.Vpc.Upa.Impl.Util.MethodSignature) o;
            if (name != null ? !name.Equals(that.name) : that.name != null) return false;
            // Probably incorrect - comparing Object[] arrays with Arrays.equals
            return Net.Vpc.Upa.Impl.FwkConvertUtils.ArraysEquals<System.Type>(parameterTypes,that.parameterTypes);
        }


        public override int GetHashCode() {
            int result = name != null ? name.GetHashCode() : 0;
            result = 31 * result + (parameterTypes != null ? Net.Vpc.Upa.Impl.FwkConvertUtils.ArraysGetHashCode<Java.Util.Arrays>(parameterTypes) : 0);
            return result;
        }
    }
}
