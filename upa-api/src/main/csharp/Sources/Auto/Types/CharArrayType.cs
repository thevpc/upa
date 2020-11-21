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


    /**
     * User: taha Date: 16 juin 2003 Time: 15:47:42
     */
    public class CharArrayType : Net.TheVpc.Upa.Types.LOBType {


        public static readonly Net.TheVpc.Upa.Types.CharArrayType CHARS = new Net.TheVpc.Upa.Types.CharArrayType("FILE", false, null, true);

        public static readonly Net.TheVpc.Upa.Types.CharArrayType CHAR_REFS = new Net.TheVpc.Upa.Types.CharArrayType("FILE", true, null, true);

        private int? max;

        public CharArrayType(string name, int? max, bool nullable)  : this(name, false, max, nullable){

        }

        public CharArrayType(string name, bool @ref, int? max, bool nullable)  : base(name, @ref ? typeof(char?[]) : typeof(char[]), nullable){

            this.max = max;
        }


        public override void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (@value is char[]) {
                if ((GetMax()).Value > 0 && (GetMax()).Value < ((char[]) @value).Length) {
                    throw new Net.TheVpc.Upa.Types.ConstraintsException("ArraySizeTooLong", name, description, @value, max);
                }
            } else if (@value is char?[]) {
                if ((GetMax()).Value > 0 && (GetMax()).Value < ((char?[]) @value).Length) {
                    throw new Net.TheVpc.Upa.Types.ConstraintsException("ArraySizeTooShort", name, description, @value, max);
                }
            } else {
                throw new Net.TheVpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value, max);
            }
        }

        public virtual int? GetMax() {
            return max;
        }

        public virtual void SetMax(int? max) {
            this.max = max;
        }


        public override Net.TheVpc.Upa.DataTypeInfo GetInfo() {
            Net.TheVpc.Upa.DataTypeInfo d = base.GetInfo();
            if (max != null) {
                d.GetProperties()["max"]=System.Convert.ToString(max);
            }
            return d;
        }
    }
}
