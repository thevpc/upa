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


    public class StringType : Net.TheVpc.Upa.Types.DefaultDataType {

        public static readonly Net.TheVpc.Upa.Types.StringType DEFAULT = new Net.TheVpc.Upa.Types.StringType("String", 0, 255, true);

        public static readonly Net.TheVpc.Upa.Types.StringType UNLIMITED = new Net.TheVpc.Upa.Types.StringType("String", 0, System.Int32.MaxValue, true);

        protected internal int min;

        protected internal int max;

        public virtual int GetMin() {
            return min;
        }

        public virtual int GetMax() {
            return max;
        }

        public StringType(string name)  : this(name, 0, 255, true){

        }

        public StringType(string name, int min, int max, bool nullable)  : base(name, typeof(string), max, 0, nullable){

            this.max = max;
            this.min = min;
        }


        protected internal override void ReevaluateCachedValues() {
            base.ReevaluateCachedValues();
            if (!defaultValueUserDefined && !IsNullable()) {
                defaultValue = ("");
            }
        }


        public override void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (!(@value is string)) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value);
            }
            string sval = (string) @value;
            if (GetMin() >= 0 && (sval).Length < GetMin()) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("StringTooShort", name, description, @value, min);
            }
            if (GetMax() > 0 && (sval).Length > GetMax()) {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("StringTooLong", name, description, @value, max);
            }
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder("String");
            if (max > 0 || (min > 0)) {
                s.Append("[");
                if (min > 0) {
                    s.Append(min);
                    s.Append("...");
                }
                if (max > 0) {
                    s.Append(max);
                }
                s.Append("]");
            }
            return s.ToString();
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            if (!base.Equals(o)) return false;
            Net.TheVpc.Upa.Types.StringType that = (Net.TheVpc.Upa.Types.StringType) o;
            if (min != that.min) return false;
            return max == that.max;
        }


        public override int GetHashCode() {
            int result = base.GetHashCode();
            result = 31 * result + min;
            result = 31 * result + max;
            return result;
        }


        public override Net.TheVpc.Upa.DataTypeInfo GetInfo() {
            Net.TheVpc.Upa.DataTypeInfo d = base.GetInfo();
            d.GetProperties()["min"]=System.Convert.ToString(min);
            d.GetProperties()["max"]=System.Convert.ToString(max);
            return d;
        }
    }
}
