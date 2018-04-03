/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE HAS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



namespace Net.Vpc.Upa.Types
{


    /**
     * User: taha
     * Date: 5 sept. 2003
     * Time: 13:02:55
     */
    public class Timestamp : Net.Vpc.Upa.Types.Temporal {



        private int nanos;

        public Timestamp()  : this(System.DateTime.Now.Ticks){

        }

        public Timestamp(Net.Vpc.Upa.Types.Temporal date)  : this(date.GetTime()){

        }

        public Timestamp(long time)  : base((time / 1000) * 1000){

            nanos = (int) ((time % 1000) * 1000000);
            if (nanos < 0) {
                nanos = 1000000000 + nanos;
                base.time=new System.DateTime(((time / 1000) - 1) * 1000);
            }
        }

        public override long GetTime() {
            long time = base.GetTime();
            return (time + (nanos / 1000000));
        }


        public override string ToString() {
            Net.Vpc.Upa.Types.Calendar c = Net.Vpc.Upa.Types.Calendar.GetInstance();
            c.SetTimeInMillis(GetTime());
            int year = c.Get(Net.Vpc.Upa.Types.Calendar.YEAR);
            int month = c.Get(Net.Vpc.Upa.Types.Calendar.MONTH) + 1;
            int day = c.Get(Net.Vpc.Upa.Types.Calendar.DAY_OF_MONTH);
            int hour = c.Get(Net.Vpc.Upa.Types.Calendar.HOUR_OF_DAY);
            int minute = c.Get(Net.Vpc.Upa.Types.Calendar.MINUTE);
            int second = c.Get(Net.Vpc.Upa.Types.Calendar.SECOND);
            //        int year = super.getYear() + 1900;
            //        int month = super.getMonth() + 1;
            //        int day = super.getDate();
            //        int hour = super.getHours();
            //        int minute = super.getMinutes();
            //        int second = super.getSeconds();
            string yearString;
            string monthString;
            string dayString;
            string hourString;
            string minuteString;
            string secondString;
            string nanosString;
            string zeros = "000000000";
            string yearZeros = "0000";
            System.Text.StringBuilder timestampBuf;
            if (year < 1000) {
                // Add leading zeros
                yearString = "" + year;
                yearString = yearZeros.Substring(0, (4 - (yearString).Length)) + yearString;
            } else {
                yearString = "" + year;
            }
            if (month < 10) {
                monthString = "0" + month;
            } else {
                monthString = System.Convert.ToString(month);
            }
            if (day < 10) {
                dayString = "0" + day;
            } else {
                dayString = System.Convert.ToString(day);
            }
            if (hour < 10) {
                hourString = "0" + hour;
            } else {
                hourString = System.Convert.ToString(hour);
            }
            if (minute < 10) {
                minuteString = "0" + minute;
            } else {
                minuteString = System.Convert.ToString(minute);
            }
            if (second < 10) {
                secondString = "0" + second;
            } else {
                secondString = System.Convert.ToString(second);
            }
            if (nanos == 0) {
                nanosString = "0";
            } else {
                nanosString = System.Convert.ToString(nanos);
                // Add leading zeros
                nanosString = zeros.Substring(0, (9 - (nanosString).Length)) + nanosString;
                // Truncate trailing zeros
                char[] nanosChar = new char[(nanosString).Length];
                nanosString.CopyTo(0,nanosChar,0,((nanosString).Length)-(0));
                int truncIndex = 8;
                while (nanosChar[truncIndex] == '0') {
                    truncIndex--;
                }
                nanosString = new string(nanosChar, 0, truncIndex + 1);
            }
            // do a string buffer here instead.
            timestampBuf = new System.Text.StringBuilder(20 + (nanosString).Length);
            timestampBuf.Append(yearString);
            timestampBuf.Append("-");
            timestampBuf.Append(monthString);
            timestampBuf.Append("-");
            timestampBuf.Append(dayString);
            timestampBuf.Append(" ");
            timestampBuf.Append(hourString);
            timestampBuf.Append(":");
            timestampBuf.Append(minuteString);
            timestampBuf.Append(":");
            timestampBuf.Append(secondString);
            timestampBuf.Append(".");
            timestampBuf.Append(nanosString);
            return (timestampBuf.ToString());
        }
    }
}
