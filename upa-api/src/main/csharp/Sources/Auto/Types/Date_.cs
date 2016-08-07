using System;
namespace Net.Vpc.Upa.Types{
//SPECIFIC

/**
 * User: taha
 * Date: 5 sept. 2003
 * Time: 12:57:26
 */
    public partial class Date{

        public Date()  : this(System.DateTime.Now.Ticks){

        }

        public Date(System.DateTime date)  : this(date.Ticks){

        }

        public Date GetRelativeDay(int relative) {
            Calendar calendar = Calendar.GetInstance();
            calendar.SetTime(GetTime());
            calendar.Add(Calendar.DAY_OF_YEAR, relative);
            return new Date(Value);
        }

        private static long ValidateTime(long time) {
            Calendar calendar = Calendar.GetInstance();
            calendar.SetTime(time);
            System.DateTime t=new System.DateTime(time);
            return new System.DateTime(t.Year,t.Month,t.Day).Ticks;
            //return new System.DateTime(t.Year,t.Month,t.Day,23,59,59,999).Ticks;
        }
    }
}
