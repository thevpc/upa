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


    public class DateType : Net.Vpc.Upa.Types.TemporalType {

        public static readonly Net.Vpc.Upa.Types.DateType DEFAULT = new Net.Vpc.Upa.Types.DateType("DATE", typeof(Net.Vpc.Upa.Types.Date), null, null, true);





        protected internal Net.Vpc.Upa.Types.Date min = null;

        protected internal Net.Vpc.Upa.Types.Date max = null;

        public DateType(string name, System.Type type, bool nullable)  : this(name, type, null, null, nullable){

        }

        public DateType(string name, System.Type type, Net.Vpc.Upa.Types.Date min, Net.Vpc.Upa.Types.Date max, bool nullable)  : base(name, type == null ? typeof(Net.Vpc.Upa.Types.Date) : type, 0, 0, nullable){

            if (type != null && !type.Equals(typeof(Net.Vpc.Upa.Types.Date)) && !type.Equals(typeof(Net.Vpc.Upa.Types.Temporal)) && !type.Equals(typeof(Net.Vpc.Upa.Types.Date))) {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException("Invalid Temporal Type " + type);
            }
            this.min = min;
            this.max = max;
            SetDefaultNonNullValue(Convert(new Net.Vpc.Upa.Types.DateTime(0)));
        }

        public virtual Net.Vpc.Upa.Types.Date GetMin() {
            return min;
        }

        public virtual void SetMin(Net.Vpc.Upa.Types.Date newMin) {
            min = newMin;
        }

        public virtual Net.Vpc.Upa.Types.Date GetMax() {
            return max;
        }

        public virtual void SetMax(Net.Vpc.Upa.Types.Date newMax) {
            max = newMax;
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (!(@value is Net.Vpc.Upa.Types.Date)) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
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
            if (typeof(Net.Vpc.Upa.Types.Date).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.Date(time);
            } else if (typeof(Net.Vpc.Upa.Types.Temporal).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.DateTime(time);
            } else {
                throw new Net.Vpc.Upa.Exceptions.IllegalArgumentException();
            }
        }

        public virtual bool IsYearOnly() {
            System.Type type = GetPlatformType();
            return typeof(Net.Vpc.Upa.Types.Year).IsAssignableFrom(type);
        }

        public virtual bool IsMonthOnly() {
            System.Type type = GetPlatformType();
            return typeof(Net.Vpc.Upa.Types.Month).IsAssignableFrom(type);
        }

        public virtual bool IsDateTime() {
            System.Type type = GetPlatformType();
            return typeof(Net.Vpc.Upa.Types.DateTime).IsAssignableFrom(type) || typeof(Net.Vpc.Upa.Types.Temporal).Equals(type);
        }

        public virtual bool IsDateOnly() {
            System.Type type = GetPlatformType();
            return typeof(Net.Vpc.Upa.Types.Date).IsAssignableFrom(type) || typeof(Net.Vpc.Upa.Types.Date).IsAssignableFrom(type);
        }

        public virtual bool IsTimeOnly() {
            System.Type type = GetPlatformType();
            return typeof(Net.Vpc.Upa.Types.Time).IsAssignableFrom(type) || typeof(Net.Vpc.Upa.Types.Time).IsAssignableFrom(type);
        }

        public virtual bool IsTimestamp() {
            System.Type type = GetPlatformType();
            return typeof(Net.Vpc.Upa.Types.Timestamp).IsAssignableFrom(type) || typeof(Net.Vpc.Upa.Types.Timestamp).IsAssignableFrom(type);
        }
    }
}
