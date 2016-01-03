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



namespace Net.Vpc.Upa.Bulk
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public abstract class TextFixedWidthParser : Net.Vpc.Upa.Bulk.AbstractDataParser {

        private bool containsHeader;

        private int skipRows = 0;

        private bool trimValues = true;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.TextFixedWidthColumn> columns = new System.Collections.Generic.List<Net.Vpc.Upa.Bulk.TextFixedWidthColumn>();

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.TextFixedWidthColumn> GetColumns() {
            return columns;
        }

        public virtual bool IsContainsHeader() {
            return containsHeader;
        }

        public virtual void SetContainsHeader(bool containsHeader) {
            this.containsHeader = containsHeader;
        }

        public virtual bool IsTrimValues() {
            return trimValues;
        }

        public virtual void SetTrimValues(bool trimValues) {
            this.trimValues = trimValues;
        }

        public virtual int GetSkipRows() {
            return skipRows;
        }

        public virtual void SetSkipRows(int skipRows) {
            this.skipRows = skipRows;
        }
    }
}
