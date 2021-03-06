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



namespace Net.TheVpc.Upa.Bulk
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public abstract class TextCSVFormatter : Net.TheVpc.Upa.Bulk.AbstractDataFormatter {

        private bool writeHeader;

        private bool trimValues = true;

        private string separators = ";";

        private bool supportsDoubleQuote = true;

        private bool supportsSimpleQuote = true;

        private bool supportsBackSlash = true;

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Bulk.TextCSVColumn> columns = new System.Collections.Generic.List<Net.TheVpc.Upa.Bulk.TextCSVColumn>();

        private string newLine;

        private int skipRows;

        public virtual Net.TheVpc.Upa.Bulk.TextCSVColumn AddColumn(string name) {
            Net.TheVpc.Upa.Bulk.TextCSVColumn column = new Net.TheVpc.Upa.Bulk.TextCSVColumn();
            GetColumns().Add((Net.TheVpc.Upa.Bulk.TextCSVColumn) column.UpdateName(name));
            return column;
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Bulk.TextCSVColumn> GetColumns() {
            return columns;
        }

        public virtual bool IsWriteHeader() {
            return writeHeader;
        }

        public virtual Net.TheVpc.Upa.Bulk.TextCSVFormatter SetWriteHeader(bool writeHeader) {
            this.writeHeader = writeHeader;
            return this;
        }

        public virtual string GetSeparators() {
            return separators;
        }

        public virtual Net.TheVpc.Upa.Bulk.TextCSVFormatter SetSeparators(string separators) {
            this.separators = separators;
            return this;
        }

        public virtual bool IsSupportsDoubleQuote() {
            return supportsDoubleQuote;
        }

        public virtual Net.TheVpc.Upa.Bulk.TextCSVFormatter SetSupportsDoubleQuote(bool supportsDoubleQuote) {
            this.supportsDoubleQuote = supportsDoubleQuote;
            return this;
        }

        public virtual bool IsSupportsSimpleQuote() {
            return supportsSimpleQuote;
        }

        public virtual Net.TheVpc.Upa.Bulk.TextCSVFormatter SetSupportsSimpleQuote(bool supportsSimpleQuote) {
            this.supportsSimpleQuote = supportsSimpleQuote;
            return this;
        }

        public virtual bool IsSupportsBackSlash() {
            return supportsBackSlash;
        }

        public virtual Net.TheVpc.Upa.Bulk.TextCSVFormatter SetSupportsBackSlash(bool supportsBackSlash) {
            this.supportsBackSlash = supportsBackSlash;
            return this;
        }

        public virtual bool IsTrimValues() {
            return trimValues;
        }

        public virtual Net.TheVpc.Upa.Bulk.TextCSVFormatter SetTrimValues(bool trimValues) {
            this.trimValues = trimValues;
            return this;
        }

        public virtual string GetNewLine() {
            return newLine;
        }

        public virtual Net.TheVpc.Upa.Bulk.TextCSVFormatter SetNewLine(string newLine) {
            this.newLine = newLine;
            return this;
        }

        public virtual int GetSkipRows() {
            return skipRows;
        }

        public virtual Net.TheVpc.Upa.Bulk.TextCSVFormatter SetSkipRows(int skipRows) {
            this.skipRows = skipRows;
            return this;
        }
    }
}
