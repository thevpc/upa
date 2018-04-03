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
    public abstract class SheetParser : Net.Vpc.Upa.Bulk.AbstractDataParser {

        private bool containsHeader;

        private bool trimValues = true;

        private int sheetIndex = 0;

        private int skipRows = 0;

        private int minColumns = 0;

        private bool skipEmptyRows = false;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.SheetColumn> columns = new System.Collections.Generic.List<Net.Vpc.Upa.Bulk.SheetColumn>();

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.SheetColumn> GetColumns() {
            return columns;
        }

        public virtual System.Collections.Generic.IList<string> GetColumnNames() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.SheetColumn> columns = GetColumns();
            System.Collections.Generic.IList<string> names = new System.Collections.Generic.List<string>((columns).Count);
            foreach (Net.Vpc.Upa.Bulk.SheetColumn column in columns) {
                names.Add(column.GetName());
            }
            return names;
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

        public virtual int GetSheetIndex() {
            return sheetIndex;
        }

        public virtual void SetSheetIndex(int sheetIndex) {
            this.sheetIndex = sheetIndex;
        }

        public virtual int GetSkipRows() {
            return skipRows;
        }

        public virtual void SetSkipRows(int skipRows) {
            this.skipRows = skipRows;
        }

        public virtual int GetMinColumns() {
            return minColumns;
        }

        public virtual void SetMinColumns(int minColumns) {
            this.minColumns = minColumns;
        }

        public virtual bool IsSkipEmptyRows() {
            return skipEmptyRows;
        }

        public virtual void SetSkipEmptyRows(bool skipEmptyRows) {
            this.skipEmptyRows = skipEmptyRows;
        }

        public abstract string[] GetSheetNames() /* throws System.IO.IOException */ ;
    }
}
