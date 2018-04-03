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
    public class TextFixedWidthColumn : Net.Vpc.Upa.Bulk.DataColumn {

        private int skippedColumns;

        private string skippedColumnsChars;

        private int columnWidth;

        private Net.Vpc.Upa.Bulk.TextAlignment textAlignment;

        private string defaultPaddingChars;

        private string leftPaddingChars;

        private string rightPaddingChars;

        public TextFixedWidthColumn() {
        }

        public TextFixedWidthColumn(int columnWidth) {
            this.columnWidth = columnWidth;
        }

        public virtual int GetSkippedColumns() {
            return skippedColumns;
        }

        public virtual void SetSkippedColumns(int skippedColumns) {
            this.skippedColumns = skippedColumns;
        }

        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthColumn UpdateSkippedColumns(int skippedColumns) {
            SetSkippedColumns(skippedColumns);
            return this;
        }

        public virtual int GetColumnWidth() {
            return columnWidth;
        }

        public virtual void SetColumnWidth(int columnWidth) {
            this.columnWidth = columnWidth;
        }

        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthColumn UpdateColumnWidth(int columnWidth) {
            SetColumnWidth(columnWidth);
            return this;
        }

        public virtual Net.Vpc.Upa.Bulk.TextAlignment GetTextAlignment() {
            return textAlignment;
        }

        public virtual void SetTextAlignment(Net.Vpc.Upa.Bulk.TextAlignment textAlignment) {
            this.textAlignment = textAlignment;
        }

        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthColumn UpdateTextAlignment(Net.Vpc.Upa.Bulk.TextAlignment textAlignment) {
            SetTextAlignment(textAlignment);
            return this;
        }

        public virtual string GetDefaultPaddingChars() {
            return defaultPaddingChars;
        }

        public virtual void SetDefaultPaddingChars(string defaultPaddingChars) {
            this.defaultPaddingChars = defaultPaddingChars;
        }

        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthColumn UpdateDefaultPaddingChars(string defaultPaddingChars) {
            SetDefaultPaddingChars(defaultPaddingChars);
            return this;
        }

        public virtual string GetLeftPaddingChars() {
            return leftPaddingChars;
        }

        public virtual void SetLeftPaddingChars(string leftPaddingChars) {
            this.leftPaddingChars = leftPaddingChars;
        }

        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthColumn UpdateLeftPaddingChars(string leftPaddingChars) {
            SetLeftPaddingChars(leftPaddingChars);
            return this;
        }

        public virtual string GetRightPaddingChars() {
            return rightPaddingChars;
        }

        public virtual void SetRightPaddingChars(string rightPaddingChars) {
            this.rightPaddingChars = rightPaddingChars;
        }

        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthColumn UpdateRightPaddingChars(string rightPaddingChars) {
            SetRightPaddingChars(rightPaddingChars);
            return this;
        }

        public virtual string GetSkippedColumnsChars() {
            return skippedColumnsChars;
        }

        public virtual void SetSkippedColumnsChars(string skippedColumnsChars) {
            this.skippedColumnsChars = skippedColumnsChars;
        }

        public virtual Net.Vpc.Upa.Bulk.TextFixedWidthColumn UpdateSkippedColumnsChars(string skippedColumnsChars) {
            SetSkippedColumnsChars(skippedColumnsChars);
            return this;
        }














    }
}
