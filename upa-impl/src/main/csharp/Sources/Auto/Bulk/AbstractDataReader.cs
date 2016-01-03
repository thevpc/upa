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
    public abstract class AbstractDataReader : Net.Vpc.Upa.Bulk.DataReader {

        protected internal Net.Vpc.Upa.Bulk.DataColumn[] parserColumns;

        protected internal Net.Vpc.Upa.Bulk.DataColumn[] header;

        protected internal Net.Vpc.Upa.Bulk.DataColumn columnPrototype;

        protected internal bool containsHeader;

        protected internal int skipRows;

        protected internal Net.Vpc.Upa.Bulk.DataDeserializer objectDeserializer;

        public AbstractDataReader(Net.Vpc.Upa.Bulk.DataColumn columnPrototype, Net.Vpc.Upa.Bulk.DataColumn[] parserColumns, bool containsHeader, int skipRows) {
            this.parserColumns = parserColumns;
            this.columnPrototype = columnPrototype;
            this.containsHeader = containsHeader;
            this.skipRows = skipRows;
        }

        public virtual Net.Vpc.Upa.Bulk.DataDeserializer GetObjectDeserializer() {
            return objectDeserializer;
        }

        public virtual void SetObjectDeserializer(Net.Vpc.Upa.Bulk.DataDeserializer objectDeserializer) {
            this.objectDeserializer = objectDeserializer;
        }

        protected internal virtual void PrepareHeader() {
            if (skipRows > 0) {
                int s = skipRows;
                while (s > 0) {
                    if (HasNext()) {
                        NextHeader();
                    }
                    s--;
                }
            }
            if (containsHeader) {
                if (HasNext()) {
                    header = NextHeader();
                } else {
                    header = new Net.Vpc.Upa.Bulk.DataColumn[parserColumns.Length];
                    for (int i = 0; i < header.Length; i++) {
                        header[i] = (Net.Vpc.Upa.Bulk.DataColumn) parserColumns[i].Clone();
                        header[i].SetIndex(i);
                    }
                }
            } else {
                header = new Net.Vpc.Upa.Bulk.DataColumn[parserColumns.Length];
                for (int i = 0; i < header.Length; i++) {
                    header[i] = (Net.Vpc.Upa.Bulk.DataColumn) parserColumns[i].Clone();
                    header[i].SetIndex(i);
                }
            }
        }

        public virtual Net.Vpc.Upa.Bulk.DataColumn[] GetColumns() {
            return header;
        }

        public virtual object ReadObject() {
            Net.Vpc.Upa.Bulk.DataDeserializer od = GetObjectDeserializer();
            if (od == null) {
                throw new System.ArgumentException ("Missing Object deserializer");
            }
            return od.RowToObject(ReadRow());
        }

        public virtual Net.Vpc.Upa.Bulk.DataRow ReadRow() {
            object[] rawValues = NextRowArray();
            Net.Vpc.Upa.Bulk.DataColumn[] columns1 = GetColumns();
            object[] values = new object[rawValues.Length > header.Length ? rawValues.Length : header.Length];
            for (int i = 0; i < values.Length; i++) {
                Net.Vpc.Upa.Bulk.DataColumn columnInfo = i < columns1.Length ? (Net.Vpc.Upa.Bulk.DataColumn) columns1[i] : null;
                object rawValue = i < rawValues.Length ? rawValues[i] : null;
                object @value = rawValue;
                if (columnInfo != null) {
                    if (columnInfo.IsTrimValue()) {
                        rawValue = rawValue == null ? null : ((rawValue is string) ? ((object)(((string) rawValue).Trim())) : rawValue);
                    }
                    Net.Vpc.Upa.Bulk.ValueConverter r = columnInfo.GetRawValueConverter();
                    if (r == null) {
                        if (columnInfo.GetDataType() != null) {
                            @value = Net.Vpc.Upa.Impl.Bulk.ValueParser.Parse(rawValue, columnInfo.GetDataType());
                        }
                    } else {
                        @value = r.Convert(rawValue);
                    }
                    r = columnInfo.GetValueConverter();
                    if (r != null) {
                        @value = r.Convert(@value);
                    }
                    Net.Vpc.Upa.Bulk.ValueValidator valueValidator = columnInfo.GetValueValidator();
                    if (valueValidator != null) {
                        valueValidator.ValidateValue(@value);
                    }
                } else {
                    @value = Net.Vpc.Upa.Impl.Bulk.ValueParser.Parse(rawValue, Net.Vpc.Upa.Types.StringType.UNLIMITED);
                }
                values[i] = @value;
            }
            return new Net.Vpc.Upa.Impl.Bulk.DefaultDataRow(header, values);
        }

        protected internal abstract object[] NextRowArray();

        protected internal virtual Net.Vpc.Upa.Bulk.DataColumn CreateColumn(int col) {
            return (Net.Vpc.Upa.Bulk.DataColumn) columnPrototype.Clone();
        }

        private Net.Vpc.Upa.Bulk.DataColumn[] NextHeader() {
            object[] all = NextRowArray();
            Net.Vpc.Upa.Bulk.DataColumn[] columns = new Net.Vpc.Upa.Bulk.DataColumn[all.Length];
            for (int i = 0; i < columns.Length; i++) {
                if (i < parserColumns.Length && !Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(parserColumns[i].GetName())) {
                    columns[i] = (Net.Vpc.Upa.Bulk.DataColumn) parserColumns[i].Clone();
                } else {
                    columns[i] = CreateColumn(i);
                    columns[i].SetName(System.Convert.ToString(all[i]));
                }
                columns[i].SetTitle(System.Convert.ToString(all[i]));
                columns[i].SetIndex(i);
            }
            return columns;
        }

        public virtual void Remove() {
            throw new System.Exception("Not supported.");
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public abstract bool HasNext();
    }
}
