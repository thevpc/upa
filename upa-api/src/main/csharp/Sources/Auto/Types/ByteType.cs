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


    public class ByteType : Net.Vpc.Upa.Types.NumberType {

        public static readonly Net.Vpc.Upa.Types.ByteType DEFAULT = new Net.Vpc.Upa.Types.ByteType(null, null, true, false);

        protected internal byte? min;

        protected internal byte? max;

        public ByteType(byte? min, byte? max, bool nullable, bool primitiveType)  : this("BYTE", min, max, nullable, primitiveType){

        }

        /**
             * @param min minimum value (compared to value * multiplier). if null, no
             * constraints
             * @param max maximum value (compared to value * multiplier). if null, no
             * constraints
             * @param nullable null accept if true
             */
        public ByteType(string name, byte? min, byte? max, bool nullable, bool primitiveType)  : base(name, primitiveType ? typeof(byte) : typeof(byte?), 10, 0, nullable){

            this.min = min;
            this.max = max;
            SetDefaultNonNullValue((byte) ((byte)0));
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


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (GetMin() != null && ((byte?) @value).Value.CompareTo(GetMin()) < 0) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooLow", name, description, @value, GetMin());
            }
            if (GetMax() != null && ((byte?) @value).Value.CompareTo(GetMax()) > 0) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("NumberTooHigh", name, description, @value, GetMax());
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
            if (@value == null || @value.Trim().Length==0) {
                return null;
            }
            return System.Convert.ToByte(@value);
        }
    }
}
