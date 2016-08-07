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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 1:53 AM
     */
    public class ObjectAndType {

        private System.Type cls;

        private Net.Vpc.Upa.Persistence.PersistenceNameType spec;

        internal ObjectAndType(System.Type cls, Net.Vpc.Upa.Persistence.PersistenceNameType type) {
            this.cls = cls;
            this.spec = type;
        }

        public virtual System.Type GetCls() {
            return cls;
        }

        public virtual Net.Vpc.Upa.Persistence.PersistenceNameType GetSpec() {
            return spec;
        }


        public override bool Equals(object o) {
            if (this == o) {
                return true;
            }
            if (o == null || GetType() != o.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Impl.Persistence.ObjectAndType that = (Net.Vpc.Upa.Impl.Persistence.ObjectAndType) o;
            if (cls != null ? !cls.Equals(that.cls) : that.cls != null) {
                return false;
            }
            if (spec != null ? !spec.Equals(that.spec) : that.spec != null) {
                return false;
            }
            return true;
        }


        public override int GetHashCode() {
            int result = cls != null ? cls.GetHashCode() : 0;
            result = 31 * result + (spec != null ? spec.GetHashCode() : 0);
            return result;
        }


        public override string ToString() {
            return "ObjectAndType{" + "cls=" + cls + ", type='" + spec + '\'' + '}';
        }
    }
}
