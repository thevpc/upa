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
            SetDefaultNonNullValue(0L);
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
            return s.ToString();
        }


        public override object Parse(string @value) {
            if (@value == null || @value.Trim().Length==0) {
                return null;
            }
            return System.Convert.ToInt64(@value);
        }
    }
}
