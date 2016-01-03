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
    public class Year : Net.Vpc.Upa.Types.Temporal {



        public Year()  : this(System.DateTime.Now.Ticks){

        }

        public Year(int gregorianYear)  : this(ValidateTime(gregorianYear)){

        }

        public Year(Net.Vpc.Upa.Types.Temporal date)  : this(date.GetTime()){

        }

        public Year(long date)  : base(ValidateTime(date)){

        }

        public virtual int GetGregorianYear() {
            Net.Vpc.Upa.Types.Calendar calendar = Net.Vpc.Upa.Types.Calendar.GetInstance();
            calendar.SetTimeInMillis(GetTime());
            return calendar.Get(Net.Vpc.Upa.Types.Calendar.YEAR);
        }

        public static long ValidateTime(int year) {
            Net.Vpc.Upa.Types.Calendar calendar = Net.Vpc.Upa.Types.Calendar.GetInstance();
            calendar.Set(Net.Vpc.Upa.Types.Calendar.YEAR, year);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.MONTH, 0);
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
            calendar.Set(Net.Vpc.Upa.Types.Calendar.MONTH, 0);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.DAY_OF_MONTH, 1);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.HOUR_OF_DAY, 0);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.MINUTE, 0);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.SECOND, 0);
            calendar.Set(Net.Vpc.Upa.Types.Calendar.MILLISECOND, 0);
            //        if (!startPeriod) {
            //            calendar.add(Calendar.YEAR, +1);
            //            calendar.add(Calendar.MILLISECOND, -1);
            //        }
            return calendar.GetTime().GetTime();
        }

        public virtual Net.Vpc.Upa.Types.Year NextYear() {
            return GetRelativeYear(1);
        }

        public virtual Net.Vpc.Upa.Types.Year GetRelativeYear(int relative) {
            Net.Vpc.Upa.Types.Calendar calendar = Net.Vpc.Upa.Types.Calendar.GetInstance();
            calendar.SetTimeInMillis(GetTime());
            calendar.Add(Net.Vpc.Upa.Types.Calendar.YEAR, relative);
            return new Net.Vpc.Upa.Types.Year(calendar.GetTime());
        }

        public virtual Net.Vpc.Upa.Types.Year PreviousYear() {
            return GetRelativeYear(-1);
        }


        public override string ToString() {
            Net.Vpc.Upa.Types.Calendar c = Net.Vpc.Upa.Types.Calendar.GetInstance();
            c.SetTime(this);
            int year = c.Get(Net.Vpc.Upa.Types.Calendar.YEAR) + 1900;
            char[] buf = "2000".ToCharArray();
            buf[0] = (char) ('0' + (year / 1000));
            buf[1] = (char) (((year / 100) % 10));
            buf[2] = (char) (((year / 10) % 10));
            buf[3] = (char) ((year % 10));
            return new string(buf);
        }
    }
}
