

using System;

namespace Net.TheVpc.Upa.Types{
    public partial class DatePeriod {
        public int Compare(DatePeriod other, Temporal startDate) {
            System.DateTime t = startDate.Value;

            switch(periodType) {
                case PeriodOption.DAY:
                {
                    t=t.AddDays(count);
                    break;
                }
                case PeriodOption.MONTH:
                {
                    t=t.AddMonths(count);
                    break;
                }
                case PeriodOption.YEAR:
                {
                    t=t.AddYears(count);
                    break;
                }
            }
            System.DateTime t2 = startDate.Value;
            switch(other.periodType) {
                case PeriodOption.DAY:
                {
                    t2=t2.AddDays(other.count);
                    break;
                }
                case PeriodOption.MONTH:
                {
                    t2=t2.AddMonths(other.count);
                    break;
                }
                case PeriodOption.YEAR:
                {
                    t2=t2.AddYears(other.count);
                    break;
                }
            }
            long d2 = t2.Ticks-t.Ticks;
            return d2==0 ? 0 : d2 > 0 ? 1 : -1;
        }

        public Temporal Next(Temporal startDate) {
            System.DateTime t = startDate.Value;

            switch(periodType) {
                case PeriodOption.DAY:
                {
                    t=t.AddDays(count);
                    break;
                }
                case PeriodOption.MONTH:
                {
                    t=t.AddMonths(count);
                    break;
                }
                case PeriodOption.YEAR:
                {
                    t=t.AddYears(count);
                    break;
                }
            }
            if(startDate is DateTime){
                return new DateTime(t.Ticks);
            }
            if(startDate is Date){
                return new Date(t.Ticks);
            }
            if(startDate is Timestamp){
                return new Timestamp(t.Ticks);
            }
            if(startDate is Time){
                return new Time(t.Ticks);
            }
            throw new Exception("Unexpected");
        }
    }
}