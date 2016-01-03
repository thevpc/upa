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


    public class TimeType : Net.Vpc.Upa.Types.TemporalType {

        public static readonly Net.Vpc.Upa.Types.TimeType DEFAULT = new Net.Vpc.Upa.Types.TimeType("DATE", typeof(Net.Vpc.Upa.Types.Time), null, null, true);





        protected internal Net.Vpc.Upa.Types.Time min = null;

        protected internal Net.Vpc.Upa.Types.Time max = null;

        public TimeType(bool nullable)  : this("TIME", typeof(Net.Vpc.Upa.Types.Time), null, null, nullable){

        }

        public TimeType(Net.Vpc.Upa.Types.Time min, Net.Vpc.Upa.Types.Time max, bool nullable)  : this("TIME", typeof(Net.Vpc.Upa.Types.Time), min, max, nullable){

        }

        public TimeType(System.Type type, bool nullable)  : this("TIME", type, null, null, nullable){

        }

        public TimeType(System.Type type, Net.Vpc.Upa.Types.Time min, Net.Vpc.Upa.Types.Time max, bool nullable)  : this("TIME", type, min, max, nullable){

        }

        public TimeType(string name, System.Type type, bool nullable)  : this(name, type, null, null, nullable){

        }

        public TimeType(string name, System.Type type, Net.Vpc.Upa.Types.Time min, Net.Vpc.Upa.Types.Time max, bool nullable)  : base(name, type == null ? typeof(Net.Vpc.Upa.Types.Time) : type, 0, 0, nullable){

            if (type != null && !typeof(Net.Vpc.Upa.Types.Time).Equals(type) && !typeof(Net.Vpc.Upa.Types.Time).Equals(type) && !typeof(Net.Vpc.Upa.Types.Temporal).Equals(type)) {
                throw new System.ArgumentException ("Invalid Temporal Type " + type);
            }
            this.min = min;
            this.max = max;
            SetDefaultNonNullValue(Convert(new Net.Vpc.Upa.Types.DateTime(0)));
        }

        public virtual Net.Vpc.Upa.Types.Time GetMin() {
            return min;
        }

        public virtual Net.Vpc.Upa.Types.Time GetMax() {
            return max;
        }

        public virtual void SetMin(Net.Vpc.Upa.Types.Time newMin) {
            min = newMin;
        }

        public virtual void SetMax(Net.Vpc.Upa.Types.Time newMax) {
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
            if (typeof(Net.Vpc.Upa.Types.Time).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.Time(time);
            } else if (typeof(Net.Vpc.Upa.Types.Time).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.Time(time);
            } else if (typeof(Net.Vpc.Upa.Types.Temporal).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.DateTime(time);
            } else {
                throw new System.ArgumentException ();
            }
        }
    }
}
