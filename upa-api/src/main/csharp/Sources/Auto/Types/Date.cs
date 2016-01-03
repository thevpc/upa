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

    public partial class Date : Net.Vpc.Upa.Types.Temporal {







        public Date(long date)  : base(ValidateTime(date)){

        }

        public virtual Net.Vpc.Upa.Types.Date NextDay() {
            return GetRelativeDay(1);
        }

        public virtual Net.Vpc.Upa.Types.Date PreviousDay() {
            return GetRelativeDay(-1);
        }






        public override string ToString() {
            Net.Vpc.Upa.Types.Calendar c = Net.Vpc.Upa.Types.Calendar.GetInstance();
            c.SetTime(this);
            int year = c.Get(Net.Vpc.Upa.Types.Calendar.YEAR);
            int month = c.Get(Net.Vpc.Upa.Types.Calendar.MONTH) + 1;
            int day = c.Get(Net.Vpc.Upa.Types.Calendar.DAY_OF_MONTH);
            char[] buf = "2000-00-00".ToCharArray();
            buf[0] = (char) ('0' + (year / 1000));
            buf[1] = (char) ('0' + ((year / 100) % 10));
            buf[2] = (char) ('0' + ((year / 10) % 10));
            buf[3] = (char) ('0' + (year % 10));
            buf[5] = (char) ('0' + (month / 10));
            buf[6] = (char) ('0' + (month % 10));
            buf[8] = (char) ('0' + (day / 10));
            buf[9] = (char) ('0' + (day % 10));
            return new string(buf);
        }
    }
}
