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



namespace Net.Vpc.Upa.Bulk
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public abstract class XmlFormatter : Net.Vpc.Upa.Bulk.AbstractDataFormatter {

        private bool containsHeader;

        private bool trimValues = true;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.XmlColumn> columns = new System.Collections.Generic.List<Net.Vpc.Upa.Bulk.XmlColumn>();

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.XmlColumn> GetColumns() {
            return columns;
        }

        public virtual bool IsContainsHeader() {
            return containsHeader;
        }

        public virtual Net.Vpc.Upa.Bulk.XmlFormatter SetContainsHeader(bool containsHeader) {
            this.containsHeader = containsHeader;
            return this;
        }

        public virtual bool IsTrimValues() {
            return trimValues;
        }

        public virtual Net.Vpc.Upa.Bulk.XmlFormatter SetTrimValues(bool trimValues) {
            this.trimValues = trimValues;
            return this;
        }
    }
}
