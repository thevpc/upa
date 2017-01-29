package net.vpc.upa.impl.util.stringvalueparser;

/**
 * Created by vpc on 1/29/17.
 */
public class StringValueParserInt implements StringValueParser{
    @Override
    public Object parse(String value, String format) {
        return Integer.parseInt(value);
    }
}
