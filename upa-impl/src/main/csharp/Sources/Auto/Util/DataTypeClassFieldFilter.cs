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
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DataTypeClassFieldFilter : Net.Vpc.Upa.Filters.AbstractFieldFilter {

        private System.Type type;

        public DataTypeClassFieldFilter(System.Type type) {
            this.type = type;
        }


        public override bool AcceptDynamic() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return true;
        }


        public override bool Accept(Net.Vpc.Upa.Field f) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            return type.IsAssignableFrom(f.GetDataType().GetType());
        }


        public override int GetHashCode() {
            int hash = 7;
            hash = 97 * hash + (this.type != null ? this.type.GetHashCode() : 0);
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Impl.Util.DataTypeClassFieldFilter other = (Net.Vpc.Upa.Impl.Util.DataTypeClassFieldFilter) obj;
            if (this.type != other.type && (this.type == null || !this.type.Equals(other.type))) {
                return false;
            }
            return true;
        }
    }
}
