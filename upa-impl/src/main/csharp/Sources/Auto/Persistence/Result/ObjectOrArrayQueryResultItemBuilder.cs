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
    public class ObjectOrArrayQueryResultItemBuilder : Net.Vpc.Upa.Impl.Persistence.Result.QueryResultItemBuilder {

        private static string CACHE_KEY = "ObjectOrArrayQueryResultItemBuilder.binding";


        public virtual object CreateResult(Net.Vpc.Upa.Impl.Persistence.Result.ResultColumn[] row, Net.Vpc.Upa.Persistence.ResultMetaData metadata) {
            System.Collections.Generic.IList<Net.Vpc.Upa.Persistence.ResultField> fields = metadata.GetFields();
            Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData d = (Net.Vpc.Upa.Impl.Persistence.DefaultResultMetaData) metadata;
            string[] bindings = (string[]) Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<string,object>(d.GetProperties(),CACHE_KEY);
            if (bindings == null) {
                bindings = new string[(fields).Count];
                for (int i = 0; i < (fields).Count; i++) {
                    Net.Vpc.Upa.Persistence.ResultField field = fields[i];
                    Net.Vpc.Upa.Expressions.Expression ss = field.GetExpression();
                    string binding = ss == null ? "null" : ss.ToString();
                    bindings[i] = binding;
                }
                d.GetProperties()[CACHE_KEY]=bindings;
            }
            if ((fields).Count == 1) {
                string binding = bindings[0];
                return row[0].GetValue();
            } else {
                object[] allRet = new object[(fields).Count];
                for (int i = 0; i < allRet.Length; i++) {
                    allRet[i] = row[i].GetValue();
                }
                return allRet;
            }
        }
    }
}
