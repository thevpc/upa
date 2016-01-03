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
     * the date at the end of the next "count" month of the given "date"
     * <pre>
     * monthend()
     *      params
     *          N/A
     *      Synopsis :
     *          the date at the end of the current month
     *          equivalent to : monthend(CurrentTimestamp(),0) : the date at the end of the month
     *
     * monthend(count)
     *      params
     *          count : integer expression
     *      Synopsis :
     *          the date at the end of the next "count" month. when count=0, the end of the current month
     *          equivalent to : monthend(CurrentTimestamp(),count)
     * monthend(date,count)
     *      params
     *          date  : date expression
     *          count : integer expression
     *      Synopsis  :
     *          the date at the end of the next "count" month. when count=0, the end of the current month
     * </pre>
     */
    public class MonthEnd : Net.Vpc.Upa.Expressions.Function {



        private System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expressions = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>();

        public MonthEnd() {
        }

        public MonthEnd(Net.Vpc.Upa.Expressions.Expression date, Net.Vpc.Upa.Expressions.Expression count) {
            expressions.Add(date);
            expressions.Add(count);
        }

        public MonthEnd(Net.Vpc.Upa.Expressions.Expression count) {
            expressions.Add(count);
        }


        public override string GetName() {
            return "MonthEnd";
        }


        public override int GetArgumentsCount() {
            return (expressions).Count;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            return expressions[index];
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.MonthEnd o = new Net.Vpc.Upa.Expressions.MonthEnd();
            foreach (Net.Vpc.Upa.Expressions.Expression expression in expressions) {
                o.expressions.Add(expression.Copy());
            }
            return o;
        }
    }
}
