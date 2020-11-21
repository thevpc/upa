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


    public class ByteType : Net.TheVpc.Upa.Types.NumberType {

        public static readonly Net.TheVpc.Upa.Types.ByteType DEFAULT = new Net.TheVpc.Upa.Types.ByteType(null, null, true, false);

        protected internal byte? min;

        protected internal byte? max;

        public ByteType(byte? min, byte? max, bool nullable, bool primitiveType)  : this("BYTE", min, max, nullable, primitiveType){

        }

        /**
             * @param min      minimum value (compared to value * multiplier). if null, no
             *                 constraints
             * @param max      maximum value (compared to value * multiplier). if null, no
             *                 constraints
             * @param nullable null accept if true
             */
        public ByteType(string name, byte? min, byte? max, bool nullable, bool primitiveType)  : base(name, primitiveType ? typeof(byte) : typeof(byte?), 10, 0, nullable){

            this.min = min;
            this.max = max;
        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            if (!defaultValueUserDefined && !IsNullable()) {
                defaultValue = ((byte) ((byte)0));
            }
        }

        public virtual byte? GetMin() {
            return min;
        }

        public virtual void SetMin(byte? min) {
            this.min = min;
        }

        public virtual byte? GetMax() {
            return max;
        }

        public virtual void SetMax(byte? max) {
            this.max = max;
        }


        public override void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (!(@value is byte?)) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
            if (GetMin() != null && ((byte?) @value).Value.CompareTo(GetMin()) < 0) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("NumberTooLow", name, description, @value, GetMin());
            }
            if (GetMax() != null && ((byte?) @value).Value.CompareTo(GetMax()) > 0) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("NumberTooHigh", name, description, @value, GetMax());
            }
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder("Byte");
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
            if (@value == null || (@value.Trim().Length==0)) {
                return null;
            }
            return System.Convert.ToByte(@value);
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.TheVpc.Upa.Types.ByteType byteType = (Net.TheVpc.Upa.Types.ByteType) o;
            if (min != null ? !min.Equals(byteType.min) : byteType.min != null) return false;
            return max != null ? max.Equals(byteType.max) : byteType.max == null;
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
