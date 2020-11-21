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


    public class DateType : Net.TheVpc.Upa.Types.TemporalType {

        public static readonly Net.TheVpc.Upa.Types.DateType DEFAULT = new Net.TheVpc.Upa.Types.DateType("DATE", typeof(Net.TheVpc.Upa.Types.Date), null, null, true);





        protected internal Net.TheVpc.Upa.Types.Date min = null;

        protected internal Net.TheVpc.Upa.Types.Date max = null;

        public DateType(string name, System.Type type, bool nullable)  : this(name, type, null, null, nullable){

        }

        public DateType(string name, System.Type type, Net.TheVpc.Upa.Types.Date min, Net.TheVpc.Upa.Types.Date max, bool nullable)  : base(name, type == null ? typeof(Net.TheVpc.Upa.Types.Date) : type, 0, 0, nullable){

            if (type != null && !type.Equals(typeof(Net.TheVpc.Upa.Types.Date)) && !type.Equals(typeof(Net.TheVpc.Upa.Types.Temporal)) && !type.Equals(typeof(Net.TheVpc.Upa.Types.Date))) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Invalid Temporal Type " + type);
            }
            this.min = min;
            this.max = max;
        }


        public override Net.TheVpc.Upa.Types.TemporalOption GetTemporalOption() {
            return Net.TheVpc.Upa.Types.TemporalOption.DATE;
        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            if (!defaultValueUserDefined && !IsNullable()) {
                defaultValue = (Convert(new Net.TheVpc.Upa.Types.DateTime(0)));
            }
        }

        public virtual Net.TheVpc.Upa.Types.Date GetMin() {
            return min;
        }

        public virtual void SetMin(Net.TheVpc.Upa.Types.Date newMin) {
            min = newMin;
        }

        public virtual Net.TheVpc.Upa.Types.Date GetMax() {
            return max;
        }

        public virtual void SetMax(Net.TheVpc.Upa.Types.Date newMax) {
            max = newMax;
        }


        public override void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (!(@value is Net.TheVpc.Upa.Types.Date)) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
            if (GetMin() != null && GetMin().CompareTo((Net.TheVpc.Upa.Types.Temporal) @value) > 0) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("DateTooEarly", name, description, @value, min);
            }
            if (GetMax() != null && GetMax().CompareTo((Net.TheVpc.Upa.Types.Temporal) @value) < 0) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("DateTooLate", name, description, @value, max);
            }
        }


        public override object Convert(object @value) {
            if (@value == null) {
                return null;
            }
            if (@value is Net.TheVpc.Upa.Types.Temporal) {
                return ValidateDate((Net.TheVpc.Upa.Types.Temporal) @value);
            }
            return base.Convert(@value);
        }

        public override Net.TheVpc.Upa.Types.Temporal ValidateDate(Net.TheVpc.Upa.Types.Temporal date) {
            if (date == null) {
                return null;
            }
            System.Type type = GetPlatformType();
            if (date.GetType().Equals(type)) {
                return date;
            }
            Net.TheVpc.Upa.Types.Calendar c = Net.TheVpc.Upa.Types.Calendar.GetInstance();
            c.SetTime(date);
            long time = date.GetTime();
            if (typeof(Net.TheVpc.Upa.Types.Date).IsAssignableFrom(type)) {
                return new Net.TheVpc.Upa.Types.Date(time);
            } else if (typeof(Net.TheVpc.Upa.Types.Temporal).IsAssignableFrom(type)) {
                return new Net.TheVpc.Upa.Types.DateTime(time);
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException();
            }
        }

        public virtual bool IsYearOnly() {
            System.Type type = GetPlatformType();
            return typeof(Net.TheVpc.Upa.Types.Year).IsAssignableFrom(type);
        }

        public virtual bool IsMonthOnly() {
            System.Type type = GetPlatformType();
            return typeof(Net.TheVpc.Upa.Types.Month).IsAssignableFrom(type);
        }

        public virtual bool IsDateTime() {
            System.Type type = GetPlatformType();
            return typeof(Net.TheVpc.Upa.Types.DateTime).IsAssignableFrom(type) || typeof(Net.TheVpc.Upa.Types.Temporal).Equals(type);
        }

        public virtual bool IsDateOnly() {
            System.Type type = GetPlatformType();
            return typeof(Net.TheVpc.Upa.Types.Date).IsAssignableFrom(type) || typeof(Net.TheVpc.Upa.Types.Date).IsAssignableFrom(type);
        }

        public virtual bool IsTimeOnly() {
            System.Type type = GetPlatformType();
            return typeof(Net.TheVpc.Upa.Types.Time).IsAssignableFrom(type) || typeof(Net.TheVpc.Upa.Types.Time).IsAssignableFrom(type);
        }

        public virtual bool IsTimestamp() {
            System.Type type = GetPlatformType();
            return typeof(Net.TheVpc.Upa.Types.Timestamp).IsAssignableFrom(type) || typeof(Net.TheVpc.Upa.Types.Timestamp).IsAssignableFrom(type);
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.TheVpc.Upa.Types.DateType dateType = (Net.TheVpc.Upa.Types.DateType) o;
            if (min != null ? !min.Equals(dateType.min) : dateType.min != null) return false;
            return max != null ? max.Equals(dateType.max) : dateType.max == null;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (min != null ? min.GetHashCode() : 0);
            result = 31 * result + (max != null ? max.GetHashCode() : 0);
            return result;
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("DateType[" + (GetPlatformType()).FullName + "]");
            System.Collections.Generic.IDictionary<string , object> v = new System.Collections.Generic.Dictionary<string , object>();
            if (min != null) {
                v["min"]=min;
            }
            if (min != null) {
                v["max"]=max;
            }
            if ((v).Count > 0) {
                sb.Append(v);
            }
            return sb.ToString();
        }


        public override Net.TheVpc.Upa.DataTypeInfo GetInfo() {
            Net.TheVpc.Upa.DataTypeInfo d = base.GetInfo();
            if (min != null) {
                d.GetProperties()["min"]=System.Convert.ToString(Net.TheVpc.Upa.Types.PlatformUtils.FormatUniversalDate(min));
            }
            if (max != null) {
                d.GetProperties()["max"]=System.Convert.ToString(Net.TheVpc.Upa.Types.PlatformUtils.FormatUniversalDate(max));
            }
            return d;
        }


        public override Net.TheVpc.Upa.Types.Temporal Parse(string @value) {
            if (@value == null || (@value.Trim().Length==0)) {
                return null;
            }
            return ValidateDate(Net.TheVpc.Upa.Types.PlatformUtils.ParseUniversalDate(@value));
        }
    }
}
