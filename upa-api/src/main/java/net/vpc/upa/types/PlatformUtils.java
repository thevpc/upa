package net.vpc.upa.types;

import net.vpc.upa.PortabilityHint;
import net.vpc.upa.exceptions.UPAIllegalArgumentException;

import java.sql.Time;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/12/13 3:44 AM
 */
@PortabilityHint(target = "C#",name = "ignore")
public class PlatformUtils {
    public static final DateFormat UNIVERSAL_TIMESTAMP_FORMAT = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss.SSS");
    public static final DateFormat UNIVERSAL_DATE_TIME_FORMAT = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
    public static final DateFormat UNIVERSAL_DATE_FORMAT = new SimpleDateFormat("yyyy-MM-dd");
    public static final DateFormat UNIVERSAL_TIME_FORMAT = new SimpleDateFormat("HH:mm:ss");
    public static final DateFormat UNIVERSAL_YEAR_FORMAT = new SimpleDateFormat("yyyy");
    public static final DateFormat UNIVERSAL_MONTH_YEAR_FORMAT = new SimpleDateFormat("yyyy-MM");

    public static Date parseUniversalDateTime(String date) {
        try {
            return UNIVERSAL_DATE_TIME_FORMAT.parse(date);
        } catch (ParseException e) {
            throw new UPAIllegalArgumentException(e);
        }
    }

    public static String formatUniversalDateTime(Date date){
        return UNIVERSAL_DATE_TIME_FORMAT.format(date);
    }

    public static Date parseUniversalYear(String date) {
        try {
            return UNIVERSAL_YEAR_FORMAT.parse(date);
        } catch (ParseException e) {
            throw new UPAIllegalArgumentException(e);
        }
    }

    public static String formatUniversalYear(Date date){
        return UNIVERSAL_YEAR_FORMAT.format(date);
    }

    public static Date parseUniversalTimestamp(String date) {
        try {
            return UNIVERSAL_TIMESTAMP_FORMAT.parse(date);
        } catch (ParseException e) {
            throw new UPAIllegalArgumentException(e);
        }
    }

    public static String formatUniversalTimestamp(Date date){
        return UNIVERSAL_TIMESTAMP_FORMAT.format(date);
    }

    public static Date parseUniversalMonthYear(String date) {
        try {
            return UNIVERSAL_MONTH_YEAR_FORMAT.parse(date);
        } catch (ParseException e) {
            throw new UPAIllegalArgumentException(e);
        }
    }

    public static String formatUniversalMonthYear(Date date){
        return UNIVERSAL_MONTH_YEAR_FORMAT.format(date);
    }

    public static java.sql.Date parseUniversalDate(String date) {
        try {
            return new java.sql.Date(UNIVERSAL_DATE_FORMAT.parse(date).getTime());
        } catch (ParseException e) {
            throw new UPAIllegalArgumentException(e);
        }
    }

    public static String formatUniversalDate(Date date){
        return UNIVERSAL_DATE_FORMAT.format(date);
    }

    public static Time parseUniversalTime(String date) {
        try {
            return new Time(UNIVERSAL_TIME_FORMAT.parse(date).getTime());
        } catch (ParseException e) {
            throw new UPAIllegalArgumentException(e);
        }
    }

    public static String formatUniversalTime(Date date){
        return UNIVERSAL_TIME_FORMAT.format(date);
    }

    public static Date parseDateTime(String date, String format) throws ParseException {
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat(format);
        return simpleDateFormat.parse(date);
    }

    public static boolean equals(Object a, Object b) {
        return (a == b) || (a != null && a.equals(b));
    }

}
