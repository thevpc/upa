/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
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
    public class MonthEnd : Net.Vpc.Upa.Expressions.FunctionExpression {



        private System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.Expression> expressions = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(2);

        public MonthEnd() {
        }

        public MonthEnd(Net.Vpc.Upa.Expressions.Expression[] expressions) {
            if (expressions.Length != 0 && expressions.Length != 1 && expressions.Length != 2) {
                CheckArgCount(GetName(), expressions, 1);
            }
            Net.Vpc.Upa.FwkConvertUtils.ListAddRange(this.expressions, new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.Expression>(expressions));
        }

        public MonthEnd(Net.Vpc.Upa.Expressions.Expression date, Net.Vpc.Upa.Expressions.Expression count) {
            expressions.Add(date);
            expressions.Add(count);
        }

        public MonthEnd(Net.Vpc.Upa.Expressions.Expression count) {
            expressions.Add(count);
        }


        public override void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e) {
            expressions[index]=e;
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
