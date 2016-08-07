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
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 29 avr. 2003
     * Time: 09:16:24
     * To change this template use Options | File Templates.
     */

    public partial class DatePeriod {

        private int count;

        private Net.Vpc.Upa.Types.PeriodOption periodType;

        public DatePeriod(int count, Net.Vpc.Upa.Types.PeriodOption type) {
            this.count = count;
            this.periodType = type;
        }

        public virtual int GetCount() {
            return count;
        }

        public virtual Net.Vpc.Upa.Types.PeriodOption GetPeriodType() {
            return periodType;
        }


        public override string ToString() {
            return count + " " + periodType.ToString();
        }


        public override int GetHashCode() {
            return count + 31 * periodType.GetHashCode();
        }


        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            Net.Vpc.Upa.Types.DatePeriod datePeriod = (Net.Vpc.Upa.Types.DatePeriod) obj;
            return (count == datePeriod.count) && (periodType == datePeriod.periodType);
        }




    }
}
