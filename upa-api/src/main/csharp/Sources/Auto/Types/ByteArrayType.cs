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
    public class ByteArrayType : Net.Vpc.Upa.Types.LOBType {


        public static readonly Net.Vpc.Upa.Types.ByteArrayType BYTES = new Net.Vpc.Upa.Types.ByteArrayType("FILE", false, null, true);

        public static readonly Net.Vpc.Upa.Types.ByteArrayType BYTE_REFS = new Net.Vpc.Upa.Types.ByteArrayType("FILE", true, null, true);

        private int? maxSize;

        public ByteArrayType(string name, int? maxSize, bool nullable)  : this(name, false, maxSize, nullable){

        }

        public ByteArrayType(string name, bool refs, int? maxSize, bool nullable)  : base(name, refs ? typeof(byte?[]) : typeof(byte[]), nullable){

            this.maxSize = maxSize;
        }


        public override void Check(object @value, string name, string description) /* throws Net.Vpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (@value is byte[]) {
                if ((GetMaxSize()).Value > 0 && (GetMaxSize()).Value < ((byte[]) @value).Length) {
                    throw new Net.Vpc.Upa.Types.ConstraintsException("FileSizeTooBig", name, description, @value, maxSize);
                }
            } else if (@value is byte?[]) {
                if ((GetMaxSize()).Value > 0 && (GetMaxSize()).Value < ((byte?[]) @value).Length) {
                    throw new Net.Vpc.Upa.Types.ConstraintsException("FileSizeTooSmall", name, description, @value, maxSize);
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


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder("ByteArrayType");
            if (maxSize != null) {
                s.Append("[");
                s.Append(maxSize);
                s.Append("]");
            }
            return s.ToString();
        }
    }
}
