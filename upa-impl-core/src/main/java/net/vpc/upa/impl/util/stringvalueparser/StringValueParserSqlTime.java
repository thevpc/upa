package net.vpc.upa.impl.util.stringvalueparser;

import java.util.Date;

/**
 * Created by vpc on 1/29/17.
 */
public class StringValueParserSqlTime extends StringValueParserUtilDate{
    @Override
    public Object parse(String value, String format) {
        Date d=(Date) super.parse(value,format);
        if(d==null){
            return null;
        }
        return new java.sql.Time(d.getTime());
    }
}
