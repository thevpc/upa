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

    public class StringType : Net.Vpc.Upa.Types.DataType {

        public static readonly Net.Vpc.Upa.Types.StringType DEFAULT = new Net.Vpc.Upa.Types.StringType("String", 0, 255, true);

        public static readonly Net.Vpc.Upa.Types.StringType UNLIMITED = new Net.Vpc.Upa.Types.StringType("String", 0, System.Int32.MaxValue, true);

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
            SetDefaultNonNullValue("");
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            string sval = (string) @value;
            if (GetMin() >= 0 && (sval).Length < GetMin()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("StringTooShort", name, description, @value, min);
            }
            if (GetMax() > 0 && (sval).Length > GetMax()) {
                throw new Net.Vpc.Upa.Types.ConstraintsException("StringTooLong", name, description, @value, max);
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
    }
}
