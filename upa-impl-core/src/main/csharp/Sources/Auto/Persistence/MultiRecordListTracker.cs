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
    * @creationdate 1/8/13 1:55 AM*/
    internal class MultiRecordListTracker {

        internal string recordName;

        internal Net.TheVpc.Upa.Record record;

        internal Net.TheVpc.Upa.PropertyChangeListener changeListener;

        internal MultiRecordListTracker(string recordName, Net.TheVpc.Upa.Record record, Net.TheVpc.Upa.PropertyChangeListener changeListener) {
            this.recordName = recordName;
            this.record = record;
            this.changeListener = changeListener;
        }
    }
}
