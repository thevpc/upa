package net.thevpc.upa.impl.util.stringvalueparser;

import net.thevpc.upa.types.DateTime;

import java.util.Date;

/**
 * Created by vpc on 1/29/17.
 */
public class StringValueParserVpcDateTime extends StringValueParserUtilDate{
    @Override
    public Object parse(String value, String format) {
        Date d=(Date) super.parse(value,format);
        if(d==null){
            return null;
        }
        return new DateTime(d);
    }
}
