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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 2:20 AM*/
    internal class QueryResultUpdaterPropertyChangeListener : Net.Vpc.Upa.PropertyChangeListener {

        private readonly Net.Vpc.Upa.Persistence.QueryResult result;

        private Net.Vpc.Upa.Impl.Persistence.MergedRecordList records;

        public QueryResultUpdaterPropertyChangeListener(Net.Vpc.Upa.Impl.Persistence.MergedRecordList records, Net.Vpc.Upa.Persistence.QueryResult result) {
            this.records = records;
            this.result = result;
        }

        public virtual void PropertyChange(Net.Vpc.Upa.PropertyChangeEvent evt) {
            int? i = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,int?>(records.nameToIndex,evt.GetPropertyName());
            if (i != null) {
                result.Write<object>((i).Value, evt.GetNewValue());
            }
        }
    }
}
