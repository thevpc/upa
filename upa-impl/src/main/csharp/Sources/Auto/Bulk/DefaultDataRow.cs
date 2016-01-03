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



namespace Net.Vpc.Upa.Impl.Bulk
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class DefaultDataRow : Net.Vpc.Upa.Bulk.DataRow {

        private Net.Vpc.Upa.Bulk.DataColumn[] columns;

        private object[] values;

        public DefaultDataRow(Net.Vpc.Upa.Bulk.DataColumn[] columns, object[] values) {
            this.columns = columns;
            this.values = values;
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn[] GetColumns() {
            return columns;
        }

        public virtual object[] GetValues() {
            return values;
        }


        public override string ToString() {
            return "DefaultDataRow{" + "columns=" + Net.Vpc.Upa.Impl.Util.PlatformUtils.ArrayToString(columns) + ", values=" + Net.Vpc.Upa.Impl.Util.PlatformUtils.ArrayToString(values) + '}';
        }


        public override int GetHashCode() {
            int hash = 3;
            hash = 17 * hash;
            foreach (Net.Vpc.Upa.Bulk.DataColumn v1 in this.columns) {
                hash = 31 * hash + v1.GetHashCode();
            }
            foreach (object v1 in this.values) {
                hash = 31 * hash + (v1 == null ? 0 : v1.GetHashCode());
            }
            return hash;
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            if (GetType() != obj.GetType()) {
                return false;
            }
            Net.Vpc.Upa.Impl.Bulk.DefaultDataRow other = (Net.Vpc.Upa.Impl.Bulk.DefaultDataRow) obj;
            if (!Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(this.columns, other.columns)) {
                return false;
            }
            if (!Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(this.values, other.values)) {
                return false;
            }
            return true;
        }
    }
}
