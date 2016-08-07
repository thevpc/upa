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

    public class ShortType : Net.Vpc.Upa.Types.NumberType {

        public static readonly Net.Vpc.Upa.Types.ShortType DEFAULT = new Net.Vpc.Upa.Types.ShortType("DEFAULT", null, null, true, false);

        protected internal short? min;

        protected internal short? max;

        public virtual short? GetMin() {
            return min;
        }

        public virtual short? GetMax() {
            return max;
        }

        public virtual void SetMin(short? min) {
            this.min = min;
        }

        public virtual void SetMax(short? max) {
            this.max = max;
        }

        /**
             * @param min minimum value (compared to value * multiplier). if null, no
             * constraints
             * @param max maximum value (compared to value * multiplier). if null, no
             * constraints
             * @param nullable null accept if true
             */
        public ShortType(string name, short? min, short? max, bool nullable, bool primitiveType)  : base(name, primitiveType ? typeof(short) : typeof(short?), (System.Math.Max((min == null ? System.Int32.MaxValue : (System.Convert.ToString(min)).Length), (max == null ? System.Int32.MaxValue : (System.Convert.ToString(max)).Length))), 0, nullable){

            this.min = min;
            this.max = max;
            SetDefaultNonNullValue((short) ((short)0));
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (!(@value is short?)) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
            if (GetMin() != null && ((short?) @value) < GetMin()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooLow", name, description, @value, GetMin());
            }
            if (GetMax() != null && ((short?) @value) > GetMax()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooHigh", name, description, @value, GetMax());
            }
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder("Short");
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
            return System.Convert.ToInt16(@value);
        }
    }
}
