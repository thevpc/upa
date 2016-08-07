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



namespace Net.Vpc.Upa.Impl.Persistence.Result
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     * @creationdate 1/8/13 2:20 AM
     */
    internal class QueryResultUpdaterPropertyChangeListener : Net.Vpc.Upa.PropertyChangeListener {

        private readonly Net.Vpc.Upa.Persistence.QueryResult result;

        private readonly Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo typeInfo;

        public QueryResultUpdaterPropertyChangeListener(Net.Vpc.Upa.Impl.Persistence.Result.TypeInfo typeInfo, Net.Vpc.Upa.Persistence.QueryResult result) {
            this.result = result;
            this.typeInfo = typeInfo;
        }

        public virtual void PropertyChange(Net.Vpc.Upa.PropertyChangeEvent evt) {
            int index = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,Net.Vpc.Upa.Impl.Persistence.Result.FieldInfo>(typeInfo.fields,evt.GetPropertyName()).dbIndex;
            result.Write<object>(index, evt.GetNewValue());
        }
    }
}
