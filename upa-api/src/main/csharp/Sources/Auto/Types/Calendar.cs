using System;
using System.Collections.Generic;
namespace Net.TheVpc.Upa.Types{
//SPECIFIC

/**
 * User: taha
 * Date: 5 sept. 2003
 * Time: 12:57:26
 */
    public class Calendar {
        private System.DateTime time;

            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * era, e.g., AD or BC in the Julian calendar. This is a calendar-specific
             * value; see subclass documentation.
             *
             * @see GregorianCalendar#AD
             * @see GregorianCalendar#BC
             */
            public const int ERA = 0;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * year. This is a calendar-specific value; see subclass documentation.
             */
            public const int YEAR = 1;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * month. This is a calendar-specific value. The first month of
             * the year in the Gregorian and Julian calendars is
             * <code>JANUARY</code> which is 0; the last depends on the number
             * of months in a year.
             *
             * @see #JANUARY
             * @see #FEBRUARY
             * @see #MARCH
             * @see #APRIL
             * @see #MAY
             * @see #JUNE
             * @see #JULY
             * @see #AUGUST
             * @see #SEPTEMBER
             * @see #OCTOBER
             * @see #NOVEMBER
             * @see #DECEMBER
             * @see #UNDECIMBER
             */
            public const int MONTH = 2;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * week number within the current year.  The first week of the year, as
             * defined by <code>getFirstDayOfWeek()</code> and
             * <code>getMinimalDaysInFirstWeek()</code>, has value 1.  Subclasses define
             * the value of <code>WEEK_OF_YEAR</code> for days before the first week of
             * the year.
             *
             * @see #getFirstDayOfWeek
             * @see #getMinimalDaysInFirstWeek
             */
            public const int WEEK_OF_YEAR = 3;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * week number within the current month.  The first week of the month, as
             * defined by <code>getFirstDayOfWeek()</code> and
             * <code>getMinimalDaysInFirstWeek()</code>, has value 1.  Subclasses define
             * the value of <code>WEEK_OF_MONTH</code> for days before the first week of
             * the month.
             *
             * @see #getFirstDayOfWeek
             * @see #getMinimalDaysInFirstWeek
             */
            public const int WEEK_OF_MONTH = 4;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * day of the month. This is a synonym for <code>DAY_OF_MONTH</code>.
             * The first day of the month has value 1.
             *
             * @see #DAY_OF_MONTH
             */
            public const int DATE = 5;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * day of the month. This is a synonym for <code>DATE</code>.
             * The first day of the month has value 1.
             *
             * @see #DATE
             */
            public const int DAY_OF_MONTH = 5;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the day
             * number within the current year.  The first day of the year has value 1.
             */
            public const int DAY_OF_YEAR = 6;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the day
             * of the week.  This field takes values <code>SUNDAY</code>,
             * <code>MONDAY</code>, <code>TUESDAY</code>, <code>WEDNESDAY</code>,
             * <code>THURSDAY</code>, <code>FRIDAY</code>, and <code>SATURDAY</code>.
             *
             * @see #SUNDAY
             * @see #MONDAY
             * @see #TUESDAY
             * @see #WEDNESDAY
             * @see #THURSDAY
             * @see #FRIDAY
             * @see #SATURDAY
             */
            public const int DAY_OF_WEEK = 7;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * ordinal number of the day of the week within the current month. Together
             * with the <code>DAY_OF_WEEK</code> field, this uniquely specifies a day
             * within a month.  Unlike <code>WEEK_OF_MONTH</code> and
             * <code>WEEK_OF_YEAR</code>, this field's value does <em>not</em> depend on
             * <code>getFirstDayOfWeek()</code> or
             * <code>getMinimalDaysInFirstWeek()</code>.  <code>DAY_OF_MONTH 1</code>
             * through <code>7</code> always correspond to <code>DAY_OF_WEEK_IN_MONTH
             * 1</code>; <code>8</code> through <code>14</code> correspond to
             * <code>DAY_OF_WEEK_IN_MONTH 2</code>, and so on.
             * <code>DAY_OF_WEEK_IN_MONTH 0</code> indicates the week before
             * <code>DAY_OF_WEEK_IN_MONTH 1</code>.  Negative values count back from the
             * end of the month, so the last Sunday of a month is specified as
             * <code>DAY_OF_WEEK = SUNDAY, DAY_OF_WEEK_IN_MONTH = -1</code>.  Because
             * negative values count backward they will usually be aligned differently
             * within the month than positive values.  For example, if a month has 31
             * days, <code>DAY_OF_WEEK_IN_MONTH -1</code> will overlap
             * <code>DAY_OF_WEEK_IN_MONTH 5</code> and the end of <code>4</code>.
             *
             * @see #DAY_OF_WEEK
             * @see #WEEK_OF_MONTH
             */
            public const int DAY_OF_WEEK_IN_MONTH = 8;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * hour of the morning or afternoon. <code>HOUR</code> is used for the
             * 12-hour clock (0 - 11). Noon and midnight are represented by 0, not by 12.
             * E.g., at 10:04:15.250 PM the <code>HOUR</code> is 10.
             *
             * @see #AM_PM
             * @see #HOUR_OF_DAY
             */
            public const int HOUR = 10;

             /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * hour of the day. <code>HOUR_OF_DAY</code> is used for the 24-hour clock.
             * E.g., at 10:04:15.250 PM the <code>HOUR_OF_DAY</code> is 22.
             *
             * @see #HOUR
             */
            public const int HOUR_OF_DAY = 11;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * minute within the hour.
             * E.g., at 10:04:15.250 PM the <code>MINUTE</code> is 4.
             */
            public const int MINUTE = 12;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * second within the minute.
             * E.g., at 10:04:15.250 PM the <code>SECOND</code> is 15.
             */
            public const int SECOND = 13;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * millisecond within the second.
             * E.g., at 10:04:15.250 PM the <code>MILLISECOND</code> is 250.
             */
            public const int MILLISECOND = 14;
        
            /**
             * Field number for <code>get</code> and <code>set</code>
             * indicating the raw offset from GMT in milliseconds.
             * <p>
             * This field reflects the correct GMT offset value of the time
             * zone of this <code>Calendar</code> if the
             * <code>TimeZone</code> implementation subclass supports
             * historical GMT offset changes.
             */
            public const int ZONE_OFFSET = 15;
        
            /**
             * Field number for <code>get</code> and <code>set</code> indicating the
             * daylight saving offset in milliseconds.
             * <p>
             * This field reflects the correct daylight saving offset value of
             * the time zone of this <code>Calendar</code> if the
             * <code>TimeZone</code> implementation subclass supports
             * historical Daylight Saving Time schedule changes.
             */
            public const int DST_OFFSET = 16;
        
            /**
             * The number of distinct fields recognized by <code>get</code> and <code>set</code>.
             * Field numbers range from <code>0..FIELD_COUNT-1</code>.
             */
            public const int FIELD_COUNT = 17;
        
            /**
             * Value of the {@link #DAY_OF_WEEK} field indicating
             * Sunday.
             */
            public const int SUNDAY = 1;
        
            /**
             * Value of the {@link #DAY_OF_WEEK} field indicating
             * Monday.
             */
            public const int MONDAY = 2;
        
            /**
             * Value of the {@link #DAY_OF_WEEK} field indicating
             * Tuesday.
             */
            public const int TUESDAY = 3;
        
            /**
             * Value of the {@link #DAY_OF_WEEK} field indicating
             * Wednesday.
             */
            public const int WEDNESDAY = 4;
        
            /**
             * Value of the {@link #DAY_OF_WEEK} field indicating
             * Thursday.
             */
            public const int THURSDAY = 5;
        
            /**
             * Value of the {@link #DAY_OF_WEEK} field indicating
             * Friday.
             */
            public const int FRIDAY = 6;
        
            /**
             * Value of the {@link #DAY_OF_WEEK} field indicating
             * Saturday.
             */
            public const int SATURDAY = 7;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * first month of the year in the Gregorian and Julian calendars.
             */
            public const int JANUARY = 0;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * second month of the year in the Gregorian and Julian calendars.
             */
            public const int FEBRUARY = 1;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * third month of the year in the Gregorian and Julian calendars.
             */
            public const int MARCH = 2;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * fourth month of the year in the Gregorian and Julian calendars.
             */
            public const int APRIL = 3;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * fifth month of the year in the Gregorian and Julian calendars.
             */
            public const int MAY = 4;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * sixth month of the year in the Gregorian and Julian calendars.
             */
            public const int JUNE = 5;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * seventh month of the year in the Gregorian and Julian calendars.
             */
            public const int JULY = 6;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * eighth month of the year in the Gregorian and Julian calendars.
             */
            public const int AUGUST = 7;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * ninth month of the year in the Gregorian and Julian calendars.
             */
            public const int SEPTEMBER = 8;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * tenth month of the year in the Gregorian and Julian calendars.
             */
            public const int OCTOBER = 9;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * eleventh month of the year in the Gregorian and Julian calendars.
             */
            public const int NOVEMBER = 10;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * twelfth month of the year in the Gregorian and Julian calendars.
             */
            public const int DECEMBER = 11;
        
            /**
             * Value of the {@link #MONTH} field indicating the
             * thirteenth month of the year. Although <code>GregorianCalendar</code>
             * does not use this value, lunar calendars do.
             */
            public const int UNDECIMBER = 12;
        
            /**
             * A style specifier for {@link #getDisplayName(int, int, Locale)
             * getDisplayName} and {@link #getDisplayNames(int, int, Locale)
             * getDisplayNames} indicating a long name, such as "January".
             *
             * @see #SHORT
             * @since 1.6
             */
            public readonly int LONG = 2;

        public static Calendar GetInstance(){
            return new Calendar(System.DateTime.Now);
        }

        private Calendar(System.DateTime time){
            this.time=time;
        }

        public void SetTime(long l){
            time=new System.DateTime(l);
        }

        public void SetTime(Temporal temporal){
            time=new System.DateTime(temporal.GetTime());
        }

        public void SetTime(System.DateTime time){
            this.time=time;
        }

        public void SetTimeInMillis(long time)
        {
            this.time = new System.DateTime(time);
        }

        public Temporal GetTime(){
            return new DateTime(time.Ticks);
        }

        public int Get(int field)
        {
            switch (field)
            {
                case YEAR:
                    {
                        return time.Year;
                    }
                case MONTH:
                    {
                        return time.Month;
                    }
                case DAY_OF_MONTH:
                    {
                        return time.Day;
                    }
                case HOUR_OF_DAY:
                    {
                        return time.Hour;
                    }
                case MINUTE:
                    {
                        return time.Minute;
                    }
                case SECOND:
                    {
                        return time.Second;
                    }
                case MILLISECOND:
                    {
                        return time.Minute;
                    }
            }
            throw new Exception();
        }

        public void Set(int field, int amount)
        {
            int year = time.Year;
            int month = time.Month;
            int day = time.Day;
            int hour = time.Hour;
            int minute = time.Minute;
            int second = time.Second;
            int millisecond = time.Millisecond;
            switch (field)
            {
                case YEAR:
                    {
                        year = amount;
                        break;
                    }
                case MONTH:
                    {
                        month = amount;
                        break;
                    }
                case DAY_OF_MONTH:
                    {
                        day = amount;
                        break;
                    }
                case HOUR_OF_DAY:
                    {
                        hour = amount;
                        break;
                    }
                case MINUTE:
                    {
                        minute = amount;
                        break;
                    }
                case SECOND:
                    {
                        second = amount;
                        break;
                    }
                case MILLISECOND:
                    {
                        millisecond = amount;
                        break;
                    }
            }
            time = new System.DateTime(year, month, day, hour, minute, second, millisecond);
        }

        public void Add(int field, int amount)
        {
            switch (field)
            {
                case YEAR:
                    {
                        time = time.AddYears(amount);
                        break;
                    }
                case MONTH:
                    {
                        time = time.AddMonths(amount);
                        break;
                    }
                case DAY_OF_MONTH:
                    {
                        time = time.AddDays(amount);
                        break;
                    }
                case HOUR_OF_DAY:
                    {
                        time = time.AddHours(amount);
                        break;
                    }
                case MINUTE:
                    {
                        time = time.AddMinutes(amount);
                        break;
                    }
                case SECOND:
                    {
                        time = time.AddSeconds(amount);
                        break;
                    }
                case MILLISECOND:
                    {
                        time = time.AddMilliseconds(amount);
                        break;
                    }
            }
        }
    }
}
