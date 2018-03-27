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



namespace Net.Vpc.Upa.Impl.Eval.Functions
{


    /**
     * Created by vpc on 7/3/16.
     */
    public class DatePartEvaluator : Net.Vpc.Upa.Function {

        public static readonly Net.Vpc.Upa.Function INSTANCE = new Net.Vpc.Upa.Impl.Eval.Functions.DatePartEvaluator();


        public virtual object Eval(Net.Vpc.Upa.EvalContext evalContext) {
            object[] arg = evalContext.GetArguments();
            Net.Vpc.Upa.Expressions.DatePartType type = (Net.Vpc.Upa.Expressions.DatePartType) arg[0];
            object count = (object) arg[1];
            Net.Vpc.Upa.Types.Date date = (Net.Vpc.Upa.Types.Date) arg[2];
            Net.Vpc.Upa.Types.Calendar instance = Net.Vpc.Upa.Types.Calendar.GetInstance();
            instance.SetTime(date);
            int f = -1;
            switch(type) {
                case Net.Vpc.Upa.Expressions.DatePartType.DATE:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.DATE;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.DAY:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.DATE;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.DAYOFMONTH:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.DAY_OF_MONTH;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.DAYOFWEEK:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.DAY_OF_WEEK;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.DAYOFYEAR:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.DAY_OF_YEAR;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.HOUR:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.HOUR;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.MILLISECOND:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.MILLISECOND;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.MINUTE:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.MINUTE;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.SECOND:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.SECOND;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.MONTH:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.MONTH;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.WEEK:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.WEEK_OF_MONTH;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.YEAR:
                    {
                        f = Net.Vpc.Upa.Types.Calendar.YEAR;
                        break;
                    }
                case Net.Vpc.Upa.Expressions.DatePartType.DAYOFWEEKNAME:
                    {
                        switch(instance.Get(Net.Vpc.Upa.Types.Calendar.DAY_OF_WEEK)) {
                            case 1:
                                {
                                    return "Sunday";
                                }
                            case 2:
                                {
                                    return "Monday";
                                }
                            case 3:
                                {
                                    return "Tuesday";
                                }
                            case 4:
                                {
                                    return "Wednesday";
                                }
                            case 5:
                                {
                                    return "Thursday";
                                }
                            case 6:
                                {
                                    return "Friday";
                                }
                            case 7:
                                {
                                    return "Saturday";
                                }
                            default:
                                {
                                    return "";
                                }
                        }
                    }
                    break;
                case Net.Vpc.Upa.Expressions.DatePartType.MONTHNAME:
                    {
                        switch(instance.Get(Net.Vpc.Upa.Types.Calendar.MONTH)) {
                            case 1:
                                {
                                    return "January";
                                }
                            case 2:
                                {
                                    return "February";
                                }
                            case 3:
                                {
                                    return "March";
                                }
                            case 4:
                                {
                                    return "April";
                                }
                            case 5:
                                {
                                    return "May";
                                }
                            case 6:
                                {
                                    return "June";
                                }
                            case 7:
                                {
                                    return "July";
                                }
                            case 8:
                                {
                                    return "August";
                                }
                            case 9:
                                {
                                    return "September";
                                }
                            case 10:
                                {
                                    return "October";
                                }
                            case 11:
                                {
                                    return "November";
                                }
                            case 12:
                                {
                                    return "December";
                                }
                            default:
                                {
                                    return "";
                                }
                        }
                    }
                    break;
                default:
                    {
                        throw new System.Exception("Unsupported");
                    }
            }
            return instance.Get(f);
        }
    }
}
