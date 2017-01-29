package net.vpc.upa.impl.util.stringvalueparser;

import net.vpc.upa.impl.util.DateUtils;

import java.text.ParseException;
import java.util.Date;

/**
 * Created by vpc on 1/29/17.
 */
public class StringValueParserVpcDate extends StringValueParserUtilDate{
    @Override
    public Object parse(String value, String format) {
        java.util.Date d=(java.util.Date) super.parse(value,format);
        if(d==null){
            return null;
        }
        return new net.vpc.upa.types.Date(d);
    }
}
