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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
    * @author Taha BEN SALAH <taha.bensalah@gmail.com>
    * @creationdate 1/8/13 3:05 AM*/
    internal class MultiRecordListTrackPropertyChangeListener : Net.TheVpc.Upa.PropertyChangeListener {

        private readonly string r;

        private readonly Net.TheVpc.Upa.Persistence.QueryResult result;

        private Net.TheVpc.Upa.Impl.Persistence.MultiRecordList multiRecords;

        public MultiRecordListTrackPropertyChangeListener(Net.TheVpc.Upa.Impl.Persistence.MultiRecordList multiRecords, string r, Net.TheVpc.Upa.Persistence.QueryResult result) {
            this.multiRecords = multiRecords;
            this.r = r;
            this.result = result;
        }


        public virtual void PropertyChange(Net.TheVpc.Upa.PropertyChangeEvent evt) {
            System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Persistence.FieldTracking> stringFieldTrackingMap = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,System.Collections.Generic.IDictionary<string , Net.TheVpc.Upa.Impl.Persistence.FieldTracking>>(multiRecords.setterToProp,r);
            Net.TheVpc.Upa.Impl.Persistence.FieldTracking t = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Persistence.FieldTracking>(stringFieldTrackingMap,evt.GetPropertyName());
            if (t != null) {
                result.Write<object>(t.GetIndex(), evt.GetNewValue());
            }
        }
    }
}
