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
    public abstract class TextCSVParser : Net.Vpc.Upa.Bulk.AbstractDataParser {

        private bool containsHeader;

        private bool trimValues = true;

        private int skipRows = 0;

        private string separators = ";";

        private bool supportsDoubleQuote = true;

        private bool supportsSimpleQuote = true;

        private bool supportsBackSlash = true;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.TextCSVColumn> columns = new System.Collections.Generic.List<Net.Vpc.Upa.Bulk.TextCSVColumn>();

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.TextCSVColumn> GetColumns() {
            return columns;
        }

        public virtual bool IsContainsHeader() {
            return containsHeader;
        }

        public virtual void SetContainsHeader(bool containsHeader) {
            this.containsHeader = containsHeader;
        }

        public virtual string GetSeparators() {
            return separators;
        }

        public virtual void SetSeparators(string separators) {
            this.separators = separators;
        }

        public virtual bool IsSupportsDoubleQuote() {
            return supportsDoubleQuote;
        }

        public virtual void SetSupportsDoubleQuote(bool supportsDoubleQuote) {
            this.supportsDoubleQuote = supportsDoubleQuote;
        }

        public virtual bool IsSupportsSimpleQuote() {
            return supportsSimpleQuote;
        }

        public virtual void SetSupportsSimpleQuote(bool supportsSimpleQuote) {
            this.supportsSimpleQuote = supportsSimpleQuote;
        }

        public virtual bool IsSupportsBackSlash() {
            return supportsBackSlash;
        }

        public virtual void SetSupportsBackSlash(bool supportsBackSlash) {
            this.supportsBackSlash = supportsBackSlash;
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
