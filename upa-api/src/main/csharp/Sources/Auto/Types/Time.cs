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



namespace Net.TheVpc.Upa.Types
{


    /**
     * User: taha
     * Date: 5 sept. 2003
     * Time: 13:02:55
     */
    public class Time : Net.TheVpc.Upa.Types.Temporal {



        public Time()  : this(System.DateTime.Now.Ticks){

        }

        public Time(Net.TheVpc.Upa.Types.Temporal date)  : this(date.GetTime()){

        }

        public Time(long date)  : base(ValidateTime(date)){

        }

        private static long ValidateTime(long time) {
            Net.TheVpc.Upa.Types.Calendar calendar = Net.TheVpc.Upa.Types.Calendar.GetInstance();
            calendar.SetTimeInMillis(time);
            calendar.Set(Net.TheVpc.Upa.Types.Calendar.DAY_OF_MONTH, 1);
            calendar.Set(Net.TheVpc.Upa.Types.Calendar.MONTH, 0);
            calendar.Set(Net.TheVpc.Upa.Types.Calendar.YEAR, 1900);
            return calendar.GetTime().GetTime();
        }


        public override string ToString() {
            Net.TheVpc.Upa.Types.Calendar c = Net.TheVpc.Upa.Types.Calendar.GetInstance();
            c.SetTimeInMillis(GetTime());
            int hour = c.Get(Net.TheVpc.Upa.Types.Calendar.HOUR_OF_DAY);
            int minute = c.Get(Net.TheVpc.Upa.Types.Calendar.MINUTE);
            int second = c.Get(Net.TheVpc.Upa.Types.Calendar.SECOND);
            string hourString;
            string minuteString;
            string secondString;
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
            return (hourString + ":" + minuteString + ":" + secondString);
        }
    }
}
