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
     * Created by vpc on 8/7/15.
     */
    public class SequencePatternEvaluator : Net.TheVpc.Upa.Impl.Util.Converter<string , string> {

        private Net.TheVpc.Upa.Field field;

        private object replacement;

        private Net.TheVpc.Upa.Record record;

        public SequencePatternEvaluator(Net.TheVpc.Upa.Field field, object replacement, Net.TheVpc.Upa.Record record) {
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
            Net.TheVpc.Upa.Expressions.Select s = new Net.TheVpc.Upa.Expressions.Select();
            s.Field(new Net.TheVpc.Upa.Expressions.UserExpression(v), "customValue");
            return System.Convert.ToString(field.GetEntity().GetPersistenceUnit().CreateQuery(s).GetSingleValue());
        }
    }
}
