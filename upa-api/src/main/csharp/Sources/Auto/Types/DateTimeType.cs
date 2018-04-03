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



namespace Net.Vpc.Upa.Types
{


    public class DateTimeType : Net.Vpc.Upa.Types.TemporalType {

        public static readonly Net.Vpc.Upa.Types.DateTimeType DEFAULT = new Net.Vpc.Upa.Types.DateTimeType("DATE", typeof(Net.Vpc.Upa.Types.DateTime), null, null, true);



        protected internal Net.Vpc.Upa.Types.DateTime min = null;

        protected internal Net.Vpc.Upa.Types.DateTime max = null;

        public DateTimeType(string name, System.Type type, bool nullable)  : this(name, type, null, null, nullable){

        }

        public DateTimeType(string name, System.Type type, Net.Vpc.Upa.Types.DateTime min, Net.Vpc.Upa.Types.DateTime max, bool nullable)  : base(name, type == null ? typeof(Net.Vpc.Upa.Types.DateTime) : type, 0, 0, nullable){

            if (type != null && !type.Equals(typeof(Net.Vpc.Upa.Types.DateTime)) && !type.Equals(typeof(Net.Vpc.Upa.Types.Temporal)) && !type.Equals(typeof(Net.Vpc.Upa.Types.Timestamp))) {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("Invalid Temporal for DateTime : " + type);
            }
            this.min = min;
            this.max = max;
        }


        public override Net.Vpc.Upa.Types.TemporalOption GetTemporalOption() {
            return Net.Vpc.Upa.Types.TemporalOption.DATETIME;
        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            if (!defaultValueUserDefined && !IsNullable()) {
                defaultValue = (Convert(new Net.Vpc.Upa.Types.DateTime(0)));
            }
        }

        public virtual Net.Vpc.Upa.Types.DateTime GetMin() {
            return min;
        }

        public virtual Net.Vpc.Upa.Types.DateTime GetMax() {
            return max;
        }

        public virtual void SetMin(Net.Vpc.Upa.Types.DateTime newMin) {
            min = newMin;
        }

        public virtual void SetMax(Net.Vpc.Upa.Types.DateTime newMax) {
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
            if (date.GetType().Equals(type)) {
                return date;
            }
            Net.Vpc.Upa.Types.Calendar c = Net.Vpc.Upa.Types.Calendar.GetInstance();
            c.SetTime(date);
            long time = date.GetTime();
            if (typeof(Net.Vpc.Upa.Types.DateTime).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.DateTime(time);
            } else if (typeof(Net.Vpc.Upa.Types.Temporal).IsAssignableFrom(type)) {
                return new Net.Vpc.Upa.Types.DateTime(time);
            } else {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException();
            }
        }


        public override string ToString() {
            System.Text.StringBuilder sb = new System.Text.StringBuilder("DateTimeType[" + (GetPlatformType()).FullName + "]");
            System.Collections.Generic.IDictionary<string , object> v = new System.Collections.Generic.Dictionary<string , object>();
            //        if(name!=null){
            //            v.put("name",name);
            //        }
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


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.Vpc.Upa.Types.DateTimeType that = (Net.Vpc.Upa.Types.DateTimeType) o;
            if (min != null ? !min.Equals(that.min) : that.min != null) return false;
            return max != null ? max.Equals(that.max) : that.max == null;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (min != null ? min.GetHashCode() : 0);
            result = 31 * result + (max != null ? max.GetHashCode() : 0);
            return result;
        }


        public override Net.Vpc.Upa.DataTypeInfo GetInfo() {
            Net.Vpc.Upa.DataTypeInfo d = base.GetInfo();
            if (min != null) {
                d.GetProperties()["min"]=System.Convert.ToString(Net.Vpc.Upa.Types.PlatformUtils.FormatUniversalDateTime(min));
            }
            if (max != null) {
                d.GetProperties()["max"]=System.Convert.ToString(Net.Vpc.Upa.Types.PlatformUtils.FormatUniversalDateTime(max));
            }
            return d;
        }


        public override Net.Vpc.Upa.Types.Temporal Parse(string @value) {
            if (@value == null || (@value.Trim().Length==0)) {
                return null;
            }
            return ValidateDate(Net.Vpc.Upa.Types.PlatformUtils.ParseUniversalDateTime(@value));
        }
    }
}
