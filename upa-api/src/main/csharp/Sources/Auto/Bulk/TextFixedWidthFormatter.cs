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
    public abstract class TextFixedWidthFormatter : Net.Vpc.Upa.Bulk.AbstractDataFormatter {

        private bool writeHeader;

        private string newLine;

        private int skipRows;

        private System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.TextFixedWidthColumn> columns = new System.Collections.Generic.List<Net.Vpc.Upa.Bulk.TextFixedWidthColumn>();

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Bulk.TextFixedWidthColumn> GetColumns() {
            return columns;
        }

        public virtual bool IsWriteHeader() {
            return writeHeader;
        }

        public virtual void SetWriteHeader(bool writeHeader) {
            this.writeHeader = writeHeader;
        }

        public virtual int GetSkipRows() {
            return skipRows;
        }

        public virtual void SetSkipRows(int skipRows) {
            this.skipRows = skipRows;
        }

        public virtual string GetNewLine() {
            return newLine;
        }

        public virtual void SetNewLine(string newLine) {
            this.newLine = newLine;
        }

        public abstract Net.Vpc.Upa.Bulk.DataWriter Format(System.IO.TextWriter writer) /* throws System.IO.IOException */ ;
    }
}
