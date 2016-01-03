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


    public class TimestampType : Net.Vpc.Upa.Types.TemporalType {

        public static readonly Net.Vpc.Upa.Types.TimestampType DEFAULT = new Net.Vpc.Upa.Types.TimestampType("TIMESTAMP", typeof(Net.Vpc.Upa.Types.Timestamp), null, null, true);





        protected internal Net.Vpc.Upa.Types.Timestamp min = null;

        protected internal Net.Vpc.Upa.Types.Timestamp max = null;

        public TimestampType(bool nullable)  : this(typeof(Net.Vpc.Upa.Types.Timestamp), nullable){

        }

        public TimestampType(System.Type type, bool nullable)  : this("TIMESTAMP", type, null, null, nullable){

        }

        public TimestampType(System.Type type, Net.Vpc.Upa.Types.Timestamp min, Net.Vpc.Upa.Types.Timestamp max, bool nullable)  : this("TIMESTAMP", type, min, max, nullable){

        }

        public TimestampType(string name, System.Type type, bool nullable)  : this(name, type, null, null, nullable){

        }

        public TimestampType(string name, System.Type type, Net.Vpc.Upa.Types.Timestamp min, Net.Vpc.Upa.Types.Timestamp max, bool nullable)  : base(name, type == null ? typeof(Net.Vpc.Upa.Types.Timestamp) : type, 0, 0, nullable){

            if (type != null && !type.Equals(typeof(Net.Vpc.Upa.Types.Timestamp)) && !type.Equals(typeof(Net.Vpc.Upa.Types.Timestamp)) && !type.Equals(typeof(Net.Vpc.Upa.Types.Temporal))) {
                throw new System.ArgumentException ("Invalid Temporal Type " + type);
            }
            this.min = min;
            this.max = max;
            SetDefaultNonNullValue(Convert(new Net.Vpc.Upa.Types.DateTime(0)));
        }

        public virtual Net.Vpc.Upa.Types.Temporal GetMin() {
            return min;
        }

        public virtual Net.Vpc.Upa.Types.Temporal GetMax() {
            return max;
        }

        public virtual void SetMin(Net.Vpc.Upa.Types.Timestamp newMin) {
            min = newMin;
        }

        public virtual void SetMax(Net.Vpc.Upa.Types.Timestamp newMax) {
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
            if (typeof(Net.Vpc.Upa.Types.Timestamp).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.Timestamp(time);
            } else if (typeof(Net.Vpc.Upa.Types.Temporal).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.DateTime(time);
            } else {
                throw new System.ArgumentException ();
            }
        }
    }
}
