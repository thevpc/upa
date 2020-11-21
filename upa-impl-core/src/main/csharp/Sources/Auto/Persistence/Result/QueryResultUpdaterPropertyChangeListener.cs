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



namespace Net.TheVpc.Upa.Impl.Persistence.Result
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 2:20 AM
     */
    internal class QueryResultUpdaterPropertyChangeListener : Net.TheVpc.Upa.PropertyChangeListener {

        private readonly Net.TheVpc.Upa.Persistence.QueryResult result;

        private readonly Net.TheVpc.Upa.Impl.Persistence.Result.TypeInfo typeInfo;

        public QueryResultUpdaterPropertyChangeListener(Net.TheVpc.Upa.Impl.Persistence.Result.TypeInfo typeInfo, Net.TheVpc.Upa.Persistence.QueryResult result) {
            this.result = result;
            this.typeInfo = typeInfo;
        }

        public virtual void PropertyChange(Net.TheVpc.Upa.PropertyChangeEvent evt) {
            int index = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.TheVpc.Upa.Impl.Persistence.Result.FieldInfo>(typeInfo.fields,evt.GetPropertyName()).dbIndex;
            result.Write<object>(index, evt.GetNewValue());
        }
    }
}
