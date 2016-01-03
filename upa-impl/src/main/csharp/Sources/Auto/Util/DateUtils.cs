using System;
using System.Globalization;

namespace Net.Vpc.Upa.Impl.Util
{


    /**
     * @author Taha BEN Salah
     * @creationdate 1/12/13 3:44 AM
     */
    public class DateUtils {

    private const string UNIVERSAL_DATE_TIME_FORMAT = "yyyy-MM-dd HH:mm:ss.fff";
    private const string UNIVERSAL_DATE_FORMAT = "yyyy-MM-dd";
    private const string UNIVERSAL_TIME_FORMAT = "HH:mm:ss";






        public static Net.Vpc.Upa.Types.Temporal ParseUniversalDateTime(System.String date)
        {
            return ParseDateTime(date, UNIVERSAL_DATE_TIME_FORMAT);
        }

        public static System.String FormatUniversalDateTime(Net.Vpc.Upa.Types.Temporal date) {
            return date.Value.ToString(UNIVERSAL_DATE_TIME_FORMAT);
        }

        public static Net.Vpc.Upa.Types.Date ParseUniversalDate(System.String date) {
            return new Net.Vpc.Upa.Types.Date(ParseDateTime(date, UNIVERSAL_DATE_FORMAT).GetTime());
        }

        public static System.String FormatUniversalDate(Net.Vpc.Upa.Types.Temporal date) {
            return date.Value.ToString(UNIVERSAL_DATE_FORMAT);
        }

        public static Net.Vpc.Upa.Types.Time ParseUniversalTime(System.String date) {
            return new Net.Vpc.Upa.Types.Time(ParseDateTime(date, UNIVERSAL_TIME_FORMAT).GetTime());
        }

        public static Net.Vpc.Upa.Types.Year ParseUniversalYear(System.String date) {
            return new Net.Vpc.Upa.Types.Year(ParseDateTime(date, UNIVERSAL_TIME_FORMAT).GetTime());
        }

        public static Net.Vpc.Upa.Types.Year ParseUniversalMonth(System.String date) {
            return new Net.Vpc.Upa.Types.Month(ParseDateTime(date, UNIVERSAL_TIME_FORMAT).GetTime());
        }

        public static Net.Vpc.Upa.Types.Year ParseUniversalTimestamp(System.String date) {
            return new Net.Vpc.Upa.Types.Timestamp(ParseDateTime(date, UNIVERSAL_TIME_FORMAT).GetTime());
        }

        public static System.String FormatUniversalTime(Net.Vpc.Upa.Types.Temporal date) {
            return date.Value.ToString(UNIVERSAL_TIME_FORMAT);
        }

        public static Net.Vpc.Upa.Types.Temporal ParseDateTime(System.String date, System.String format) /* throws Java.Text.ParseException */
        {
            System.DateTime d = System.DateTime.MinValue;
            bool success=System.DateTime.TryParseExact(date, format, new CultureInfo("en-US"),System.Globalization.DateTimeStyles.None, out d);
            if(success)
            {
                return new Net.Vpc.Upa.Types.DateTime(d.Ticks);
            }
            throw new Exception("Invalid Format");
        }
    }
}
