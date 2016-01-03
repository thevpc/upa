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



namespace Net.Vpc.Upa.Expressions
{


    /**
     * the date at the start of the next "count" month of the given "date"
     * <pre>
     * monthstart()
     *      params
     *          N/A
     *      Synopsis :
     *          the date at the end of the current month
     *          equivalent to : monthstart(CurrentTimestamp(),0) : the date at the end of the month
     *
     * monthstart(count)
     *      params
     *          count : integer expression
     *      Synopsis :
     *          the date at the end of the next "count" month. when count=0, the end of the current month
     *          equivalent to : monthend(CurrentTimestamp(),count)
     * monthstart(date,count)
     *      params
     *          date  : date expression
     *          count : integer expression
     *      Synopsis  :
     *          the date at the end of the next "count" month. when count=0, the end of the current month
     * </pre>
     */
    public class MonthStart : Net.Vpc.Upa.Expressions.Function {



        private System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expressions = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>();

        public MonthStart() {
        }

        public MonthStart(Net.Vpc.Upa.Expressions.Expression date, Net.Vpc.Upa.Expressions.Expression count) {
            expressions.Add(date);
            expressions.Add(count);
        }

        public MonthStart(Net.Vpc.Upa.Expressions.Expression count) {
            expressions.Add(count);
        }


        public override string GetName() {
            return "MonthStart";
        }


        public override int GetArgumentsCount() {
            return (expressions).Count;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            return expressions[index];
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.MonthStart o = new Net.Vpc.Upa.Expressions.MonthStart();
            foreach (Net.Vpc.Upa.Expressions.Expression expression in expressions) {
                o.expressions.Add(expression.Copy());
            }
            return o;
        }
    }
}
