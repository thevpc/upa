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

    public class IntType : Net.Vpc.Upa.Types.NumberType {

        public static readonly Net.Vpc.Upa.Types.IntType DEFAULT = new Net.Vpc.Upa.Types.IntType(null, null, null, true, false);

        protected internal int? min;

        protected internal int? max;

        public IntType(int? min, int? max, bool nullable, bool primitiveType)  : this(null, min, max, nullable, primitiveType){

        }

        /**
             * @param min minimum value (compared to value * multiplier). if null, no
             * constraints
             * @param max maximum value (compared to value * multiplier). if null, no
             * constraints
             * @param nullable null accept if true
             */
        public IntType(string name, int? min, int? max, bool nullable, bool primitiveType)  : base(name == null ? "INT" : name, primitiveType ? typeof(int) : typeof(int?), (System.Math.Max((min == null ? System.Int32.MaxValue : (System.Convert.ToString(min)).Length), (max == null ? System.Int32.MaxValue : (System.Convert.ToString(max)).Length))), 0, nullable){

            this.min = min;
            this.max = max;
            SetDefaultNonNullValue(0);
        }

        public virtual int? GetMin() {
            return min;
        }

        public virtual int? GetMax() {
            return max;
        }

        public virtual void SetMin(int? min) {
            this.min = min;
        }

        public virtual void SetMax(int? max) {
            this.max = max;
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (GetMin() != null && ((int?) @value) < GetMin()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooLow", name, description, @value, GetMin());
            }
            if (GetMax() != null && ((int?) @value) > GetMax()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooHigh", name, description, @value, GetMax());
            }
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder("Int");
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
            return System.Convert.ToInt32(@value);
        }
    }
}
