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
    public abstract class TextCSVFormatter : Net.Vpc.Upa.Bulk.AbstractDataFormatter {

        private bool containsHeader;

        private bool trimValues = true;

        private string separators = ";";

        private bool supportsDoubleQuote = true;

        private bool supportsSimpleQuote = true;

        private bool supportsBackSlash = true;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.TextCSVColumn> columns = new System.Collections.Generic.List<Net.Vpc.Upa.Bulk.TextCSVColumn>();

        private string newLine;

        private int skipRows;

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.TextCSVColumn> GetColumns() {
            return columns;
        }

        public virtual bool IsContainsHeader() {
            return containsHeader;
        }

        public virtual Net.Vpc.Upa.Bulk.TextCSVFormatter SetContainsHeader(bool containsHeader) {
            this.containsHeader = containsHeader;
            return this;
        }

        public virtual string GetSeparators() {
            return separators;
        }

        public virtual Net.Vpc.Upa.Bulk.TextCSVFormatter SetSeparators(string separators) {
            this.separators = separators;
            return this;
        }

        public virtual bool IsSupportsDoubleQuote() {
            return supportsDoubleQuote;
        }

        public virtual Net.Vpc.Upa.Bulk.TextCSVFormatter SetSupportsDoubleQuote(bool supportsDoubleQuote) {
            this.supportsDoubleQuote = supportsDoubleQuote;
            return this;
        }

        public virtual bool IsSupportsSimpleQuote() {
            return supportsSimpleQuote;
        }

        public virtual Net.Vpc.Upa.Bulk.TextCSVFormatter SetSupportsSimpleQuote(bool supportsSimpleQuote) {
            this.supportsSimpleQuote = supportsSimpleQuote;
            return this;
        }

        public virtual bool IsSupportsBackSlash() {
            return supportsBackSlash;
        }

        public virtual Net.Vpc.Upa.Bulk.TextCSVFormatter SetSupportsBackSlash(bool supportsBackSlash) {
            this.supportsBackSlash = supportsBackSlash;
            return this;
        }

        public virtual bool IsTrimValues() {
            return trimValues;
        }

        public virtual Net.Vpc.Upa.Bulk.TextCSVFormatter SetTrimValues(bool trimValues) {
            this.trimValues = trimValues;
            return this;
        }

        public virtual string GetNewLine() {
            return newLine;
        }

        public virtual Net.Vpc.Upa.Bulk.TextCSVFormatter SetNewLine(string newLine) {
            this.newLine = newLine;
            return this;
        }

        public virtual int GetSkipRows() {
            return skipRows;
        }

        public virtual Net.Vpc.Upa.Bulk.TextCSVFormatter SetSkipRows(int skipRows) {
            this.skipRows = skipRows;
            return this;
        }
    }
}
