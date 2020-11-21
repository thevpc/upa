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



namespace Net.TheVpc.Upa.Expressions
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
    public class MonthEnd : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.Expression> expressions = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(2);

        public MonthEnd() {
        }

        public MonthEnd(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            if (expressions.Length != 0 && expressions.Length != 1 && expressions.Length != 2) {
                CheckArgCount(GetName(), expressions, 1);
            }
            Net.TheVpc.Upa.FwkConvertUtils.ListAddRange(this.expressions, new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.Expression>(expressions));
        }

        public MonthEnd(Net.TheVpc.Upa.Expressions.Expression date, Net.TheVpc.Upa.Expressions.Expression count) {
            expressions.Add(date);
            expressions.Add(count);
        }

        public MonthEnd(Net.TheVpc.Upa.Expressions.Expression count) {
            expressions.Add(count);
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            expressions[index]=e;
        }


        public override string GetName() {
            return "MonthEnd";
        }


        public override int GetArgumentsCount() {
            return (expressions).Count;
        }


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            return expressions[index];
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.MonthEnd o = new Net.TheVpc.Upa.Expressions.MonthEnd();
            foreach (Net.TheVpc.Upa.Expressions.Expression expression in expressions) {
                o.expressions.Add(expression.Copy());
            }
            return o;
        }
    }
}
