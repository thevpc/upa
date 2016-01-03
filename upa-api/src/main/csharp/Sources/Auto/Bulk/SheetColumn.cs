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
    public class SheetColumn : Net.Vpc.Upa.Bulk.DataColumn {

        private int skippedColumns;

        public SheetColumn() {
        }

        public virtual int GetSkippedColumns() {
            return skippedColumns;
        }

        public virtual void SetSkippedColumns(int skippedColumns) {
            this.skippedColumns = skippedColumns;
        }

        public virtual Net.Vpc.Upa.Bulk.SheetColumn UpdateSkippedColumns(int skippedColumns) {
            SetSkippedColumns(skippedColumns);
            return this;
        }














    }
}
