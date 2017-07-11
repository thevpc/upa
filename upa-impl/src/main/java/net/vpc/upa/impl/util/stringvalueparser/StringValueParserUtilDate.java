package net.vpc.upa.impl.util.stringvalueparser;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.util.DateUtils;

import java.text.ParseException;

/**
 * Created by vpc on 1/29/17.
 */
public class StringValueParserUtilDate implements StringValueParser{
    @Override
    public Object parse(String value, String format) {
        if (value.trim().length() == 0) {
            return null;
        }
        if (format.length() > 0) {
            try {
                return DateUtils.parseDateTime(value, format);
            } catch (ParseException ex) {
                throw new UPAIllegalArgumentException("Unable to parse date " + value);
            }
        }
        return DateUtils.parseUniversalDate(value);
    }
}
