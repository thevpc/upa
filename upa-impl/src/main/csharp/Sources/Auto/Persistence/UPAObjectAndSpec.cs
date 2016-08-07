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
    * @creationdate 1/8/13 1:54 AM*/
    public class UPAObjectAndSpec {

        private object @object;

        private Net.Vpc.Upa.Persistence.PersistenceNameType spec;

        internal UPAObjectAndSpec(object @object, Net.Vpc.Upa.Persistence.PersistenceNameType spec) {
            this.@object = @object;
            this.spec = spec;
        }

        public virtual object GetObject() {
            return @object;
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
            Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec that = (Net.Vpc.Upa.Impl.Persistence.UPAObjectAndSpec) o;
            if (@object != null ? !@object.Equals(that.@object) : that.@object != null) {
                return false;
            }
            if (spec != null ? !spec.Equals(that.spec) : that.spec != null) {
                return false;
            }
            return true;
        }


        public override int GetHashCode() {
            int result = @object != null ? @object.GetHashCode() : 0;
            result = 31 * result + (spec != null ? spec.GetHashCode() : 0);
            return result;
        }
    }
}
