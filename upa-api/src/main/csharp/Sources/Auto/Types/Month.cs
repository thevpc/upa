/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
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
    public class Month : Net.Vpc.Upa.Types.Temporal {



        public Month()  : this(System.DateTime.Now.Ticks){

        }

        public Month(int year, int month)  : this(ValidateTime(year, month)){

        }

        public Month(Net.Vpc.Upa.Types.Temporal date)  : this(date.GetTime()){

        }

        public Month(long date)  : base(ValidateTime(date)){

        }

        public static long ValidateTime(int year, int month) {
            Net.Vpc.Upa.Types.Calendar calendar = Net.Vpc.Upa.Types.Calendar.GetInstance();
            calendar.Set(Net.Vpc.Upa.Types.Calendar.YEAR, year);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.MONTH, month - 1);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.DAY_OF_MONTH, 1);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.HOUR_OF_DAY, 0);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.MINUTE, 0);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.SECOND, 0);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.MILLISECOND, 0);
            //        if (!startPeriod) {
            //            calendar.add(Calendar.MONTH, 1);
            //            calendar.add(Calendar.MILLISECOND, -1);
            //        }
            return calendar.GetTime().GetTime();
        }

        private static long ValidateTime(long time) {
            Net.Vpc.Upa.Types.Calendar calendar = Net.Vpc.Upa.Types.Calendar.GetInstance();
            calendar.SetTimeInMillis(time);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.DAY_OF_MONTH, 1);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.HOUR_OF_DAY, 0);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.MINUTE, 0);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.SECOND, 0);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.MILLISECOND, 0);
            //        if (!startPeriod) {
            //            calendar.add(Calendar.MONTH, +1);
            //            calendar.add(Calendar.MILLISECOND, -1);
            //        }
            return calendar.GetTime().GetTime();
        }

        public virtual Net.Vpc.Upa.Types.Month GetRelativeMonthYear(int relative) {
            Net.Vpc.Upa.Types.Calendar calendar = Net.Vpc.Upa.Types.Calendar.GetInstance();
            calendar.SetTimeInMillis(GetTime());
            calendar.Add(Net.Vpc.Upa.Types.Calendar.MARCH, relative);
            return new Net.Vpc.Upa.Types.Month(calendar.GetTime());
        }


        public override string ToString() {
            Net.Vpc.Upa.Types.Calendar calendar = Net.Vpc.Upa.Types.Calendar.GetInstance();
            calendar.SetTimeInMillis(GetTime());
            int year = calendar.Get(Net.Vpc.Upa.Types.Calendar.YEAR) + 1900;
            int month = calendar.Get(Net.Vpc.Upa.Types.Calendar.MONTH) + 1;
            char[] buf = "2000-00".ToCharArray();
            buf[0] = (char) ('0' + (year / 1000));
            buf[1] = (char) ('0' + ((year / 100) % 10));
            buf[2] = (char) ('0' + ((year / 10) % 10));
            buf[3] = (char) ('0' + (year % 10));
            buf[5] = (char) ('0' + (month / 10));
            buf[6] = (char) ('0' + (month % 10));
            return new string(buf);
        }
    }
}
