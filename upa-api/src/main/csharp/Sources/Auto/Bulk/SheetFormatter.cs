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
    public abstract class SheetFormatter : Net.Vpc.Upa.Bulk.AbstractDataFormatter {

        private bool writeHeader;

        private int skipRows;

        private bool trimValues = true;

        private int sheetIndex = 0;

        private string sheetName;

        private Net.Vpc.Upa.Bulk.SheetContentType contentType;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.SheetColumn> columns = new System.Collections.Generic.List<Net.Vpc.Upa.Bulk.SheetColumn>();

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.SheetColumn> GetColumns() {
            return columns;
        }

        public virtual bool IsWriteHeader() {
            return writeHeader;
        }

        public virtual Net.Vpc.Upa.Bulk.SheetFormatter SetWriteHeader(bool writeHeader) {
            this.writeHeader = writeHeader;
            return this;
        }

        public virtual bool IsTrimValues() {
            return trimValues;
        }

        public virtual Net.Vpc.Upa.Bulk.SheetFormatter SetTrimValues(bool trimValues) {
            this.trimValues = trimValues;
            return this;
        }

        public virtual int GetSheetIndex() {
            return sheetIndex;
        }

        public virtual Net.Vpc.Upa.Bulk.SheetFormatter SetSheetIndex(int sheetIndex) {
            this.sheetIndex = sheetIndex;
            return this;
        }

        public virtual string GetSheetName() {
            return sheetName;
        }

        public virtual Net.Vpc.Upa.Bulk.SheetFormatter SetSheetName(string sheetName) {
            this.sheetName = sheetName;
            return this;
        }

        public virtual int GetSkipRows() {
            return skipRows;
        }

        public virtual Net.Vpc.Upa.Bulk.SheetFormatter SetSkipRows(int skipRows) {
            this.skipRows = skipRows;
            return this;
        }

        public virtual Net.Vpc.Upa.Bulk.SheetContentType GetContentType() {
            return contentType;
        }

        public virtual Net.Vpc.Upa.Bulk.SheetFormatter SetContentType(Net.Vpc.Upa.Bulk.SheetContentType contentType) {
            this.contentType = contentType;
            return this;
        }

        public abstract bool IsSupported(Net.Vpc.Upa.Bulk.SheetContentType contentType);

        public abstract Net.Vpc.Upa.Bulk.SheetContentType GetDefaultContentType();
    }
}
