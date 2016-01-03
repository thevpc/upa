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



namespace Net.Vpc.Upa.Impl.Bulk
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public abstract class AbstractDataWriter : Net.Vpc.Upa.Bulk.DataWriter {

        protected internal Net.Vpc.Upa.Bulk.DataColumn[] parserColumns;

        protected internal Net.Vpc.Upa.Bulk.DataColumn columnPrototype;

        protected internal bool headerSupported;

        protected internal long rowIndex;

        protected internal bool started;

        protected internal Net.Vpc.Upa.Bulk.DataSerializer dataSerializer;

        public AbstractDataWriter(Net.Vpc.Upa.Bulk.DataColumn columnPrototype, bool headerSupported, Net.Vpc.Upa.Bulk.DataColumn[] parserColumns) {
            this.parserColumns = parserColumns;
            this.columnPrototype = columnPrototype;
            this.headerSupported = headerSupported;
        }

        public virtual Net.Vpc.Upa.Bulk.DataSerializer GetDataSerializer() {
            return dataSerializer;
        }

        public virtual void SetDataSerializer(Net.Vpc.Upa.Bulk.DataSerializer dataSerializer) {
            this.dataSerializer = dataSerializer;
        }

        public virtual void WriteObject(object row) {
            Net.Vpc.Upa.Bulk.DataSerializer os = GetDataSerializer();
            if (os == null) {
                throw new System.ArgumentException ("Missing ObjectSerializer");
            }
            Net.Vpc.Upa.Bulk.DataRow r = os.ObjecttoRow(row, parserColumns);
            WriteRow(r.GetValues());
        }

        public virtual void StartDocument() {
            if (headerSupported) {
                object[] r = new object[parserColumns.Length];
                for (int i = 0; i < r.Length; i++) {
                    Net.Vpc.Upa.Bulk.DataColumn c = parserColumns[i];
                    string t = null;
                    if (c != null) {
                        t = c.GetTitle();
                        if (t == null) {
                            t = c.GetName();
                        }
                    }
                    if (t == null) {
                        t = "#" + (i + 1);
                    }
                    r[i] = t;
                }
                WriteRow(r);
            }
        }

        public virtual void WriteRow(object[] values) {
            if (!started) {
                started = true;
                StartDocument();
            }
            Net.Vpc.Upa.Bulk.DataRow row = new Net.Vpc.Upa.Impl.Bulk.DefaultDataRow(parserColumns, values);
            StartRow(row);
            for (int i = 0; i < values.Length; i++) {
                object v = values[i];
                WriteCell(rowIndex, row, i, v);
            }
            EndRow(row);
            rowIndex++;
        }

        public virtual long GetRowIndex() {
            return rowIndex;
        }

        protected internal virtual void SetRowIndex(long rowIndex) {
            this.rowIndex = rowIndex;
        }

        protected internal abstract void StartRow(Net.Vpc.Upa.Bulk.DataRow row);

        protected internal abstract void WriteCell(long rowIndex, Net.Vpc.Upa.Bulk.DataRow row, int cellIndex, object cell);

        protected internal abstract void EndRow(Net.Vpc.Upa.Bulk.DataRow row);
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract void Close();
    }
}
