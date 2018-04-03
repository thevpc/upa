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


    public class LongType : Net.Vpc.Upa.Types.NumberType {

        public static readonly Net.Vpc.Upa.Types.LongType DEFAULT = new Net.Vpc.Upa.Types.LongType(null, null, true, false);

        protected internal long? min;

        protected internal long? max;

        public LongType(long? min, long? max, bool nullable, bool primitiveType)  : this("LONG", min, max, nullable, primitiveType){

        }

        /**
             * @param min minimum value (compared to value * multiplier). if null, no
             * constraints
             * @param max maximum value (compared to value * multiplier). if null, no
             * constraints
             * @param nullable null accept if true
             */
        public LongType(string name, long? min, long? max, bool nullable, bool primitiveType)  : base(name, primitiveType ? typeof(long) : typeof(long?), (System.Math.Max((min == null ? System.Int32.MaxValue : (System.Convert.ToString(min)).Length), (max == null ? System.Int32.MaxValue : (System.Convert.ToString(max)).Length))), 0, nullable){

            this.min = min;
            this.max = max;
        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            if (!defaultValueUserDefined && !IsNullable()) {
                defaultValue = (0L);
            }
        }

        public virtual long? GetMin() {
            return min;
        }

        public virtual long? GetMax() {
            return max;
        }

        public virtual void SetMin(long? min) {
            this.min = min;
        }

        public virtual void SetMax(long? max) {
            this.max = max;
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (!(@value is long?)) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
            if (GetMin() != null && ((long?) @value) < GetMin()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooLow", name, description, @value, GetMin());
            }
            if (GetMax() != null && ((long?) @value) > GetMax()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooHigh", name, description, @value, GetMax());
            }
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder("Long");
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
            return System.Convert.ToInt64(@value);
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.Vpc.Upa.Types.LongType longType = (Net.Vpc.Upa.Types.LongType) o;
            if (min != null ? !min.Equals(longType.min) : longType.min != null) return false;
            return max != null ? max.Equals(longType.max) : longType.max == null;
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
                d.GetProperties()["min"]=System.Convert.ToString(min);
            }
            if (max != null) {
                d.GetProperties()["max"]=System.Convert.ToString(max);
            }
            return d;
        }
    }
}
