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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/3/13 10:11 AM*/
    public class ValidationPass : System.IComparable<object> {

        private System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> fields = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field>();

        private int pass;

        private Net.TheVpc.Upa.Impl.Persistence.ValidationPassType type;

        public ValidationPass(int pass, Net.TheVpc.Upa.Impl.Persistence.ValidationPassType type) {
            this.type = type;
            this.pass = pass;
        }

        public virtual int CompareTo(object o) {
            if (o == null) {
                return 1;
            }
            if (o == this) {
                return 0;
            }
            Net.TheVpc.Upa.Impl.Persistence.ValidationPass oth = (Net.TheVpc.Upa.Impl.Persistence.ValidationPass) o;
            if (pass > oth.pass) {
                return 1;
            } else if (pass < oth.pass) {
                return -1;
            } else {
                return (type == oth.type) ? 0 : ((int)type) > ((int)oth.type) ? 1 : -1;
            }
        }

        public virtual System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> GetFields() {
            return fields;
        }

        public virtual int GetPass() {
            return pass;
        }

        public virtual Net.TheVpc.Upa.Impl.Persistence.ValidationPassType GetType() {
            return type;
        }
    }
}
