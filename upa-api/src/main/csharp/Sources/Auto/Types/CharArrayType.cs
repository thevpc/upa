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


    /**
     * User: taha Date: 16 juin 2003 Time: 15:47:42
     */
    public class CharArrayType : Net.Vpc.Upa.Types.LOBType {


        public static readonly Net.Vpc.Upa.Types.CharArrayType CHARS = new Net.Vpc.Upa.Types.CharArrayType("FILE", false, null, true);

        public static readonly Net.Vpc.Upa.Types.CharArrayType CHAR_REFS = new Net.Vpc.Upa.Types.CharArrayType("FILE", true, null, true);

        private int? maxSize;

        public CharArrayType(string name, int? maxSize, bool nullable)  : this(name, false, maxSize, nullable){

        }

        public CharArrayType(string name, bool @ref, int? maxSize, bool nullable)  : base(name, @ref ? typeof(char?[]) : typeof(char[]), nullable){

            this.maxSize = maxSize;
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (@value is char[]) {
                if ((GetMaxSize()).Value > 0 && (GetMaxSize()).Value < ((char[]) @value).Length) {
                    throw new Net.Vpc.Upa.Types.ConstraintsException("ArraySizeTooLong", name, description, @value, maxSize);
                }
            } else if (@value is char?[]) {
                if ((GetMaxSize()).Value > 0 && (GetMaxSize()).Value < ((char?[]) @value).Length) {
                    throw new Net.Vpc.Upa.Types.ConstraintsException("ArraySizeTooShort", name, description, @value, maxSize);
                }
            } else {
                throw new Net.Vpc.Upa.Types.ConstraintsException("InvalidCast", name, description, @value, maxSize);
            }
        }

        public virtual int? GetMaxSize() {
            return maxSize;
        }

        public virtual void SetMaxSize(int? maxSize) {
            this.maxSize = maxSize;
        }
    }
}
