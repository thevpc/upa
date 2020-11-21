package net.thevpc.upa.impl.eval.functions;

import net.thevpc.upa.FunctionEvalContext;
import net.thevpc.upa.Function;
import net.thevpc.upa.expressions.DatePartType;
import net.thevpc.upa.types.Date;

import java.util.Calendar;

/**
 * Created by vpc on 7/3/16.
 */
public class DateAddEvaluator implements Function {
    public static final Function INSTANCE=new DateAddEvaluator();
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
            default:{
                throw new RuntimeException("Unsupported");
            }
        }
        instance.add(f,count.intValue());
        return instance.getTime();
    }
}
