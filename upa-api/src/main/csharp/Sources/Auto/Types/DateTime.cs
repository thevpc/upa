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
     * Time: 13:01:29
     */
    public class DateTime : Net.TheVpc.Upa.Types.Temporal {



        public DateTime() {
        }

        public DateTime(long date)  : base(date){

        }

        public DateTime(Net.TheVpc.Upa.Types.Temporal date)  : base(date.GetTime()){

        }


        public override string ToString() {
            return base.ToString();
        }

        public static Net.TheVpc.Upa.Types.DateTime ForDetails(int year, int month, int day) {
            return ForDetails(year, month, day, 0, 0, 0, 0);
        }

        public static Net.TheVpc.Upa.Types.DateTime ForDetails(int year, int month, int day, int hour, int minute, int seconds) {
            return ForDetails(year, month, day, hour, minute, seconds, 0);
        }

        public static Net.TheVpc.Upa.Types.DateTime ForDetails(int year, int month, int day, int hour, int minute, int seconds, int millis) {
            Net.TheVpc.Upa.Types.Calendar c = Net.TheVpc.Upa.Types.Calendar.GetInstance();
            c.Set(Net.TheVpc.Upa.Types.Calendar.YEAR, year);
            c.Set(Net.TheVpc.Upa.Types.Calendar.MONTH, month);
            c.Set(Net.TheVpc.Upa.Types.Calendar.DAY_OF_MONTH, day);
            c.Set(Net.TheVpc.Upa.Types.Calendar.HOUR_OF_DAY, hour);
            c.Set(Net.TheVpc.Upa.Types.Calendar.MINUTE, minute);
            c.Set(Net.TheVpc.Upa.Types.Calendar.SECOND, seconds);
            c.Set(Net.TheVpc.Upa.Types.Calendar.MILLISECOND, millis);
            return new Net.TheVpc.Upa.Types.DateTime(c.GetTime());
        }
    }
}
