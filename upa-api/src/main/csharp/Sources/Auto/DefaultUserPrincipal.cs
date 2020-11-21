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
     *
     * @author taha.bensalah@gmail.com
     */
    public class DefaultUserPrincipal : Net.TheVpc.Upa.UserPrincipal {

        private string name;

        private object @object;

        public DefaultUserPrincipal(string name, object @object) {
            this.name = name;
            this.@object = @object;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual object GetObject() {
            return @object;
        }


        public override int GetHashCode() {
            int hash = 3;
            hash = 97 * hash + (this.name != null ? this.name.GetHashCode() : 0);
            hash = 97 * hash + (this.@object != null ? this.@object.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.TheVpc.Upa.DefaultUserPrincipal other = (Net.TheVpc.Upa.DefaultUserPrincipal) obj;
            if ((this.name == null) ? (other.name != null) : !this.name.Equals(other.name)) {
                return false;
            }
            if (this.@object != other.@object && (this.@object == null || !this.@object.Equals(other.@object))) {
                return false;
            }
            return true;
        }


        public override string ToString() {
            return System.Convert.ToString(name);
        }
    }
}
