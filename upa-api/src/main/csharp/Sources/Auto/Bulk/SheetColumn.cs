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
    public class SheetColumn : Net.TheVpc.Upa.Bulk.DataColumn {

        private int skippedColumns;

        public SheetColumn() {
        }

        public virtual int GetSkippedColumns() {
            return skippedColumns;
        }

        public virtual void SetSkippedColumns(int skippedColumns) {
            this.skippedColumns = skippedColumns;
        }

        public virtual Net.TheVpc.Upa.Bulk.DataColumn UpdateSkippedColumns(int skippedColumns) {
            SetSkippedColumns(skippedColumns);
            return this;
        }














    }
}
