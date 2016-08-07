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
     * Created by vpc on 6/26/16.
     */
    public class RecordQueryResultItemBuilder : Net.Vpc.Upa.Impl.Persistence.Result.QueryResultItemBuilder {

        private const string CACHE_KEY = "RecordQueryResultItemBuilder.preferredNameAndBinding";


        public virtual object CreateResult(Net.Vpc.Upa.Impl.Persistence.Result.ResultColumn[] row, Net.Vpc.Upa.Persistence.ResultMetaData metadata) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ResultField> fields = metadata.GetFields();
            Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData d = (Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData) metadata;
            string[][] preferredNameAndBinding = (string[][]) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(d.GetProperties(),CACHE_KEY);
            if (preferredNameAndBinding == null) {
                preferredNameAndBinding = (string[][])Net.Vpc.Upa.Impl.FwkConvertUtils.CreateMultiArray(typeof(string),(fields).Count,2);
                for (int i = 0; i < (fields).Count; i++) {
                    Net.Vpc.Upa.Persistence.ResultField field = fields[i];
                    Net.Vpc.Upa.Expressions.Expression ss = field.GetExpression();
                    string binding = ss == null ? "null" : ss.ToString();
                    string preferredName = binding;
                    if (preferredName.IndexOf('.') >= 0) {
                        preferredName = preferredName.Substring(preferredName.LastIndexOf('.') + 1);
                    }
                    string alias = field.GetAlias();
                    if (!Net.Vpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(alias)) {
                        preferredName = alias;
                    }
                    preferredNameAndBinding[i][0] = preferredName;
                    preferredNameAndBinding[i][1] = binding;
                }
                d.GetProperties()[CACHE_KEY]=preferredNameAndBinding;
            }
            if ((fields).Count == 1 && row[0].GetValue() is Net.Vpc.Upa.Record) {
                return row[0].GetValue();
            }
            Net.Vpc.Upa.Record r = new Net.Vpc.Upa.Impl.DefaultRecord();
            for (int i = 0; i < (fields).Count; i++) {
                string preferredName = preferredNameAndBinding[i][0];
                r.SetObject(preferredName, row[i].GetValue());
            }
            return r;
        }
    }
}
