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


    public class FloatType : Net.Vpc.Upa.Types.NumberType {

        public static readonly Net.Vpc.Upa.Types.FloatType DEFAULT = new Net.Vpc.Upa.Types.FloatType(null, null, System.Int32.MaxValue, System.Int32.MaxValue, true, false);

        protected internal float? min;

        protected internal float? max;

        private bool fixedDigits;

        private string userFormatName;

        public FloatType(float? min, float? max, int before, int after, bool nullable, bool primitiveType)  : this("FLOAT", min, max, before, after, nullable, primitiveType){

        }

        /**
             * @param min      minimum value (compared to value * multiplier). if null, no
             *                 constraints
             * @param max      maximum value (compared to value * multiplier). if null, no
             *                 constraints
             * @param before   number of digits before dot
             * @param after    number of digits after dot
             * @param nullable null accept if true
             */
        public FloatType(string name, float? min, float? max, int before, int after, bool nullable, bool primitiveType)  : base(name, primitiveType ? typeof(float) : typeof(float?), before + after, after, nullable){

            this.min = min;
            this.max = max;
        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            if (!defaultValueUserDefined && !IsNullable()) {
                defaultValue = (0f);
            }
        }

        public virtual float? GetMin() {
            return min;
        }

        public virtual void SetMin(float? min) {
            this.min = min;
        }

        public virtual float? GetMax() {
            return max;
        }

        public virtual void SetMax(float? max) {
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


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (!(@value is float?)) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
            if (GetMin() != null && (float?) @value < GetMin()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooLow", name, description, @value, GetMin());
            }
            if (GetMax() != null && (float?) @value > GetMax()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooHigh", name, description, @value, GetMax());
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
            System.Text.StringBuilder s = new System.Text.StringBuilder("FloatType");
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
            return System.Convert.ToSingle(@value);
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.Vpc.Upa.Types.FloatType floatType = (Net.Vpc.Upa.Types.FloatType) o;
            if (fixedDigits != floatType.fixedDigits) return false;
            if (min != null ? !min.Equals(floatType.min) : floatType.min != null) return false;
            if (max != null ? !max.Equals(floatType.max) : floatType.max != null) return false;
            return userFormatName != null ? userFormatName.Equals(floatType.userFormatName) : floatType.userFormatName == null;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (min != null ? min.GetHashCode() : 0);
            result = 31 * result + (max != null ? max.GetHashCode() : 0);
            result = 31 * result + (fixedDigits ? 1 : 0);
            result = 31 * result + (userFormatName != null ? userFormatName.GetHashCode() : 0);
            return result;
        }


        public override Net.Vpc.Upa.DataTypeInfo GetInfo() {
            Net.Vpc.Upa.DataTypeInfo d = base.GetInfo();
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
