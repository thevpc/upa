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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
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
    public class CompiledMonthEnd : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction {



        public CompiledMonthEnd()  : base("MonthEnd"){

        }

        public CompiledMonthEnd(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression date, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression count)  : this(){

            ProtectedAddArgument(date);
            ProtectedAddArgument(count);
        }

        public CompiledMonthEnd(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression count)  : this(){

            ProtectedAddArgument(count);
            PrepareChildren(count);
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetTypeTransform() {
            return Net.TheVpc.Upa.Impl.Transform.IdentityDataTypeTransform.STRING;
        }


        public override Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledMonthEnd o = new Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledMonthEnd();
            foreach (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression in GetArguments()) {
                o.ProtectedAddArgument(expression.Copy());
            }
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }
    }
}
