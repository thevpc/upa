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


    public class BigIntType : Net.Vpc.Upa.Types.NumberType {

        public static readonly Net.Vpc.Upa.Types.BigIntType DEFAULT = new Net.Vpc.Upa.Types.BigIntType(null, null, true);

        protected internal System.Numerics.BigInteger? min;

        protected internal System.Numerics.BigInteger? max;

        public BigIntType(System.Numerics.BigInteger? min, System.Numerics.BigInteger? max, bool nullable)  : this("BIGINT", min, max, nullable){

        }

        /**
             * @param min minimum value (compared to value * multiplier). if null, no
             * constraints
             * @param max maximum value (compared to value * multiplier). if null, no
             * constraints
             * @param nullable null accept if true
             */
        public BigIntType(string name, System.Numerics.BigInteger? min, System.Numerics.BigInteger? max, bool nullable)  : base(name, typeof(System.Numerics.BigInteger?), (System.Math.Max((min == null ? System.Int32.MaxValue : (System.Convert.ToString(min)).Length), (max == null ? System.Int32.MaxValue : (System.Convert.ToString(max)).Length))), 0, nullable){

            this.min = min;
            this.max = max;
            SetDefaultNonNullValue(System.Numerics.BigInteger.Zero);
        }

        public virtual System.Numerics.BigInteger? GetMin() {
            return min;
        }

        public virtual void SetMin(System.Numerics.BigInteger? min) {
            this.min = min;
        }

        public virtual System.Numerics.BigInteger? GetMax() {
            return max;
        }

        public virtual void SetMax(System.Numerics.BigInteger? max) {
            this.max = max;
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (GetMin() != null && ((System.Numerics.BigInteger?) @value).Value.CompareTo(GetMin()) < 0) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooLow", name, description, @value, GetMin());
            }
            if (GetMax() != null && ((System.Numerics.BigInteger?) @value).Value.CompareTo(GetMax()) > 0) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooHigh", name, description, @value, GetMax());
            }
        }


        public override object Clone() {
            return base.MemberwiseClone();
        }


        public override string ToString() {
            return "BigIntType{" + "min=" + min + ", max=" + max + '}';
        }


        public override object Parse(string @value) {
            if (@value == null || @value.Trim().Length==0) {
                return null;
            }
            return Net.Vpc.Upa.FwkConvertUtils.CreateBigInteger(@value);
        }
    }
}
