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



namespace Net.TheVpc.Upa.Expressions
{

    /**
     * @author taha.bensalah@gmail.com
     */
    public class DefaultTag : Net.TheVpc.Upa.Expressions.ExpressionTag {

        private string name;

        public DefaultTag(string name) {
            this.name = name;
        }

        public virtual string GetName() {
            return name;
        }


        public override int GetHashCode() {
            int hash = 5;
            hash = 97 * hash + (this.name != null ? this.name.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (this == obj) {
                return true;
            }
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.TheVpc.Upa.Expressions.DefaultTag other = (Net.TheVpc.Upa.Expressions.DefaultTag) obj;
            if ((this.name == null) ? (other.name != null) : !this.name.Equals(other.name)) {
                return false;
            }
            return true;
        }
    }
}
