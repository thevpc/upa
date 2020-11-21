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


    public class DoubleType : Net.TheVpc.Upa.Types.NumberType {

        public static readonly Net.TheVpc.Upa.Types.DoubleType DEFAULT = new Net.TheVpc.Upa.Types.DoubleType(null, null, System.Int32.MaxValue, System.Int32.MaxValue, true, false);

        protected internal double? min;

        protected internal double? max;

        private bool fixedDigits;

        private string userFormatName;

        public DoubleType(double? min, double? max, int before, int after, bool nullable, bool primitiveType)  : this("DOUBLE", min, max, before, after, nullable, primitiveType){

        }

        /**
             * @param min minimum value (compared to value * multiplier). if null, no
             * constraints
             * @param max maximum value (compared to value * multiplier). if null, no
             * constraints
             * @param before number of digits before dot
             * @param after number of digits after dot
             * @param nullable null accept if true
             */
        public DoubleType(string name, double? min, double? max, int before, int after, bool nullable, bool primitiveType)  : base(name, primitiveType ? typeof(double) : typeof(double?), before + after, after, nullable){

            this.min = min;
            this.max = max;
        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            if (!defaultValueUserDefined && !IsNullable()) {
                defaultValue = (0.0);
            }
        }

        public virtual double? GetMin() {
            return min;
        }

        public virtual void SetMin(double? min) {
            this.min = min;
        }

        public virtual double? GetMax() {
            return max;
        }

        public virtual void SetMax(double? max) {
            this.max = max;
        }

        public virtual int GetMaximumIntegerDigits() {
            if (GetScale() <= 0 || GetPrecision() <= 0) {
                return -1;
            }
            return GetScale() - GetPrecision();
        }

        public virtual int GetMaximumFractionDigits() {
            return GetPrecision();
        }


        public override void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (!(@value is double?)) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
            if (GetMin() != null && (double?) @value < GetMin()) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("NumberTooLow", name, description, @value, GetMin());
            }
            if (GetMax() != null && (double?) @value > GetMax()) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("NumberTooHigh", name, description, @value, GetMax());
            }
        }

        public virtual bool IsFixedDigits() {
            return fixedDigits;
        }

        public virtual void SetFixedDigits(bool fixedDigits) {
            this.fixedDigits = fixedDigits;
        }

        public virtual string GetUserFormatName() {
            return userFormatName;
        }

        public virtual void SetUserFormatName(string userFormatName) {
            this.userFormatName = userFormatName;
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder("DoubleType");
            if (min != null || max != null) {
                s.Append("[");
                if (min != null) {
                    s.Append(min);
                }
                s.Append("...");
                if (max != null) {
                    s.Append(max);
                }
                s.Append("]");
            }
            if (IsNullable()) {
                s.Append("?");
            }
            return s.ToString();
        }


        public override object Parse(string @value) {
            if (@value == null || (@value.Trim().Length==0)) {
                return null;
            }
            return System.Convert.ToDouble(@value);
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.TheVpc.Upa.Types.DoubleType that = (Net.TheVpc.Upa.Types.DoubleType) o;
            if (fixedDigits != that.fixedDigits) return false;
            if (min != null ? !min.Equals(that.min) : that.min != null) return false;
            if (max != null ? !max.Equals(that.max) : that.max != null) return false;
            return userFormatName != null ? userFormatName.Equals(that.userFormatName) : that.userFormatName == null;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (min != null ? min.GetHashCode() : 0);
            result = 31 * result + (max != null ? max.GetHashCode() : 0);
            result = 31 * result + (fixedDigits ? 1 : 0);
            result = 31 * result + (userFormatName != null ? userFormatName.GetHashCode() : 0);
            return result;
        }


        public override Net.TheVpc.Upa.DataTypeInfo GetInfo() {
            Net.TheVpc.Upa.DataTypeInfo d = base.GetInfo();
            d.GetProperties()["userFormatName"]=System.Convert.ToString(userFormatName);
            d.GetProperties()["fixedDigits"]=System.Convert.ToString(fixedDigits);
            if (min != null) {
                d.GetProperties()["min"]=System.Convert.ToString(min);
            }
            if (max != null) {
                d.GetProperties()["max"]=System.Convert.ToString(max);
            }
            return d;
        }
    }
}
