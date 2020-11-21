package net.thevpc.upa.impl.util.stringvalueparser;

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
        return new net.thevpc.upa.types.Date(d);
    }
}
