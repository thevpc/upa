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


    public class MonthType : Net.Vpc.Upa.Types.TemporalType {

        public static readonly Net.Vpc.Upa.Types.MonthType DEFAULT = new Net.Vpc.Upa.Types.MonthType("MONTH", null, true);

        protected internal Net.Vpc.Upa.Types.Month min = null;

        protected internal Net.Vpc.Upa.Types.Month max = null;

        public MonthType(string name, System.Type type, bool nullable)  : this(name, type, null, null, nullable){

        }

        public MonthType(string name, System.Type type, Net.Vpc.Upa.Types.Month min, Net.Vpc.Upa.Types.Month max, bool nullable)  : base(name, type == null ? typeof(Net.Vpc.Upa.Types.Month) : type, 0, 0, nullable){

            if (type != null && !type.Equals(typeof(Net.Vpc.Upa.Types.Month)) && !type.Equals(typeof(Net.Vpc.Upa.Types.Temporal))) {
                throw new System.ArgumentException ("Invalid Temporal Type " + type);
            }
            this.min = min;
            this.max = max;
            SetDefaultNonNullValue(Convert(new Net.Vpc.Upa.Types.DateTime(0)));
        }

        public virtual Net.Vpc.Upa.Types.Month GetMin() {
            return min;
        }

        public virtual void SetMin(Net.Vpc.Upa.Types.Month newMin) {
            min = newMin;
        }

        public virtual Net.Vpc.Upa.Types.Month GetMax() {
            return max;
        }

        public virtual void SetMax(Net.Vpc.Upa.Types.Month newMax) {
            max = newMax;
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (GetMin() != null && GetMin().CompareTo((Net.Vpc.Upa.Types.Temporal) @value) > 0) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("DateTooEarly", name, description, @value, min);
            }
            if (GetMax() != null && GetMax().CompareTo((Net.Vpc.Upa.Types.Temporal) @value) < 0) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("DateTooLate", name, description, @value, max);
            }
        }


        public override object Convert(object @value) {
            if (@value == null) {
                return null;
            }
            if (@value is Net.Vpc.Upa.Types.Temporal) {
                return ValidateDate((Net.Vpc.Upa.Types.Temporal) @value);
            }
            return base.Convert(@value);
        }

        public override Net.Vpc.Upa.Types.Temporal ValidateDate(Net.Vpc.Upa.Types.Temporal date) {
            if (date == null) {
                return null;
            }
            System.Type type = GetPlatformType();
            Net.Vpc.Upa.Types.Calendar c = Net.Vpc.Upa.Types.Calendar.GetInstance();
            c.SetTime(date);
            long time = date.GetTime();
            if (typeof(Net.Vpc.Upa.Types.Month).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.Month(time);
            } else if (typeof(Net.Vpc.Upa.Types.Temporal).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.Date(time);
            } else {
                throw new System.ArgumentException ();
            }
        }
    }
}
