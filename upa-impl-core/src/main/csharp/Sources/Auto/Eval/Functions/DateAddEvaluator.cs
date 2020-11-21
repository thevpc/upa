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



namespace Net.TheVpc.Upa.Impl.Eval.Functions
{


    /**
     * Created by vpc on 7/3/16.
     */
    public class DateAddEvaluator : Net.TheVpc.Upa.Function {

        public static readonly Net.TheVpc.Upa.Function INSTANCE = new Net.TheVpc.Upa.Impl.Eval.Functions.DateAddEvaluator();


        public virtual object Eval(Net.TheVpc.Upa.EvalContext evalContext) {
            object[] arg = evalContext.GetArguments();
            Net.TheVpc.Upa.Expressions.DatePartType type = (Net.TheVpc.Upa.Expressions.DatePartType) arg[0];
            object count = (object) arg[1];
            Net.TheVpc.Upa.Types.Date date = (Net.TheVpc.Upa.Types.Date) arg[2];
            Net.TheVpc.Upa.Types.Calendar instance = Net.TheVpc.Upa.Types.Calendar.GetInstance();
            instance.SetTime(date);
            int f = -1;
            switch(type) {
                case Net.TheVpc.Upa.Expressions.DatePartType.DATE:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.DATE;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.DAY:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.DATE;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.DAYOFMONTH:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.DAY_OF_MONTH;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.DAYOFWEEK:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.DAY_OF_WEEK;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.DAYOFYEAR:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.DAY_OF_YEAR;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.HOUR:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.HOUR;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.MILLISECOND:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.MILLISECOND;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.MINUTE:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.MINUTE;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.SECOND:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.SECOND;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.MONTH:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.MONTH;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.WEEK:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.WEEK_OF_MONTH;
                        break;
                    }
                case Net.TheVpc.Upa.Expressions.DatePartType.YEAR:
                    {
                        f = Net.TheVpc.Upa.Types.Calendar.YEAR;
                        break;
                    }
                default:
                    {
                        throw new System.Exception("Unsupported");
                    }
            }
            instance.Add(f, System.Convert.ToInt32(count));
            return instance.GetTime();
        }
    }
}
