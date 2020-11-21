package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.Function;
import net.thevpc.upa.expressions.DatePartType;
import net.thevpc.upa.types.Date;

import java.util.Calendar;

/**
 * Created by vpc on 7/3/16.
 */
public class DatePartEvaluator implements Function {
    public static final Function INSTANCE=new DatePartEvaluator();
    @Override
    public Object eval(FunctionEvalContext evalContext) {
        Object[] arg = evalContext.getArguments();
        DatePartType type=(DatePartType) arg[0];
        Number count=(Number)arg[1];
        Date date=(Date)arg[2];
        Calendar instance = Calendar.getInstance();
        instance.setTime(date);
        int f=-1;
        switch (type){
            case DATE:{
                f=Calendar.DATE;
                break;
            }
            case DAY:{
                f=Calendar.DATE;
                break;
            }
            case DAYOFMONTH:{
                f=Calendar.DAY_OF_MONTH;
                break;
            }
            case DAYOFWEEK:{
                f=Calendar.DAY_OF_WEEK;
                break;
            }
            case DAYOFYEAR:{
                f=Calendar.DAY_OF_YEAR;
                break;
            }
            case HOUR:{
                f=Calendar.HOUR;
                break;
            }
            case MILLISECOND:{
                f=Calendar.MILLISECOND;
                break;
            }
            case MINUTE:{
                f=Calendar.MINUTE;
                break;
            }
            case SECOND:{
                f=Calendar.SECOND;
                break;
            }
            case MONTH:{
                f=Calendar.MONTH;
                break;
            }
            case WEEK:{
                f=Calendar.WEEK_OF_MONTH;
                break;
            }
            case YEAR:{
                f=Calendar.YEAR;
                break;
            }
            case DAYOFWEEKNAME:{
                switch (instance.get(Calendar.DAY_OF_WEEK)){
                    case 1:{
                        return "Sunday";
                    }
                    case 2:{
                        return "Monday";
                    }
                    case 3:{
                        return "Tuesday";
                    }
                    case 4:{
                        return "Wednesday";
                    }
                    case 5:{
                        return "Thursday";
                    }
                    case 6:{
                        return "Friday";
                    }
                    case 7:{
                        return "Saturday";
                    }
                    default:{
                        return "";
                    }
                }
            }
            case MONTHNAME:{
                switch (instance.get(Calendar.MONTH)){
                    case 1:{
                        return "January";
                    }
                    case 2:{
                        return "February";
                    }
                    case 3:{
                        return "March";
                    }
                    case 4:{
                        return "April";
                    }
                    case 5:{
                        return "May";
                    }
                    case 6:{
                        return "June";
                    }
                    case 7:{
                        return "July";
                    }
                    case 8:{
                        return "August";
                    }
                    case 9:{
                        return "September";
                    }
                    case 10:{
                        return "October";
                    }
                    case 11:{
                        return "November";
                    }
                    case 12:{
                        return "December";
                    }
                    default:{
                        return "";
                    }
                }
            }
            default:{
                throw new RuntimeException("Unsupported");
            }
        }
        return instance.get(f);
    }
}
