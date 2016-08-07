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
     * Created by vpc on 8/7/15.
     */
    public class SequencePatternEvaluator : Net.Vpc.Upa.Impl.Util.Converter<string , string> {

        private Net.Vpc.Upa.Field field;

        private object replacement;

        private Net.Vpc.Upa.Record record;

        public SequencePatternEvaluator(Net.Vpc.Upa.Field field, object replacement, Net.Vpc.Upa.Record record) {
            this.field = field;
            this.replacement = replacement;
            this.record = record;
        }


        public virtual string Convert(string v) {
            if (v.Equals("#")) {
                return System.Convert.ToString(replacement);
            }
            if (record != null && record.IsSet(v)) {
                return System.Convert.ToString(record.GetObject<T>(v));
            }
            Net.Vpc.Upa.Expressions.Select s = new Net.Vpc.Upa.Expressions.Select();
            s.Field(new Net.Vpc.Upa.Expressions.UserExpression(v), "customValue");
            return System.Convert.ToString(field.GetEntity().GetPersistenceUnit().CreateQuery(s).GetSingleValue());
        }
    }
}
