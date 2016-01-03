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

        public virtual void SetWriteHeader(bool writeHeader) {
            this.writeHeader = writeHeader;
        }

        public virtual bool IsTrimValues() {
            return trimValues;
        }

        public virtual void SetTrimValues(bool trimValues) {
            this.trimValues = trimValues;
        }

        public virtual int GetSheetIndex() {
            return sheetIndex;
        }

        public virtual void SetSheetIndex(int sheetIndex) {
            this.sheetIndex = sheetIndex;
        }

        public virtual string GetSheetName() {
            return sheetName;
        }

        public virtual void SetSheetName(string sheetName) {
            this.sheetName = sheetName;
        }

        public virtual int GetSkipRows() {
            return skipRows;
        }

        public virtual void SetSkipRows(int skipRows) {
            this.skipRows = skipRows;
        }

        public virtual Net.Vpc.Upa.Bulk.SheetContentType GetContentType() {
            return contentType;
        }

        public virtual void SetContentType(Net.Vpc.Upa.Bulk.SheetContentType contentType) {
            this.contentType = contentType;
        }

        public abstract bool IsSupported(Net.Vpc.Upa.Bulk.SheetContentType contentType);

        public abstract Net.Vpc.Upa.Bulk.SheetContentType GetDefaultContentType();
    }
}
