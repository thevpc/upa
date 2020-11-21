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


    public class BigIntType : Net.TheVpc.Upa.Types.NumberType {

        public static readonly Net.TheVpc.Upa.Types.BigIntType DEFAULT = new Net.TheVpc.Upa.Types.BigIntType(null, null, true);

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
        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            if (!defaultValueUserDefined && !IsNullable()) {
                defaultValue = (System.Numerics.BigInteger.Zero);
            }
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


        public override void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (!(@value is System.Numerics.BigInteger?)) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
            if (GetMin() != null && ((System.Numerics.BigInteger?) @value).Value.CompareTo(GetMin()) < 0) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("NumberTooLow", name, description, @value, GetMin());
            }
            if (GetMax() != null && ((System.Numerics.BigInteger?) @value).Value.CompareTo(GetMax()) > 0) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("NumberTooHigh", name, description, @value, GetMax());
            }
        }


        public override string ToString() {
            return "BigIntType{" + "min=" + min + ", max=" + max + '}';
        }


        public override object Parse(string @value) {
            if (@value == null || (@value.Trim().Length==0)) {
                return null;
            }
            return Net.TheVpc.Upa.FwkConvertUtils.CreateBigInteger(@value);
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.TheVpc.Upa.Types.BigIntType that = (Net.TheVpc.Upa.Types.BigIntType) o;
            if (min != null ? !min.Equals(that.min) : that.min != null) return false;
            return max != null ? max.Equals(that.max) : that.max == null;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + (min != null ? min.GetHashCode() : 0);
            result = 31 * result + (max != null ? max.GetHashCode() : 0);
            return result;
        }


        public override Net.TheVpc.Upa.DataTypeInfo GetInfo() {
            Net.TheVpc.Upa.DataTypeInfo d = base.GetInfo();
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
