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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
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
    public class CompiledMonthStart : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledMonthStart()  : base("MonthStart"){

        }

        public CompiledMonthStart(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression date, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression count)  : this(){

            ProtectedAddArgument(date);
            ProtectedAddArgument(count);
        }

        public CompiledMonthStart(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression count)  : this(){

            ProtectedAddArgument(count);
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledMonthStart o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledMonthStart();
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in GetArguments()) {
                o.ProtectedAddArgument(expression.Copy());
            }
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
