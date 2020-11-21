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
    public class ByteArrayType : Net.TheVpc.Upa.Types.LOBType {


        public static readonly Net.TheVpc.Upa.Types.ByteArrayType BYTES = new Net.TheVpc.Upa.Types.ByteArrayType("FILE", false, null, true);

        public static readonly Net.TheVpc.Upa.Types.ByteArrayType BYTE_REFS = new Net.TheVpc.Upa.Types.ByteArrayType("FILE", true, null, true);

        private int? max;

        public ByteArrayType(string name, int? maxSize, bool nullable)  : this(name, false, maxSize, nullable){

        }

        public ByteArrayType(string name, bool refs, int? maxSize, bool nullable)  : base(name, refs ? typeof(byte?[]) : typeof(byte[]), nullable){

            this.max = maxSize;
        }


        public override void Check(object @value, string name, string description) /* throws Net.TheVpc.Upa.Types.ConstraintsException */  {
            base.Check(@value, name, description);
            if (@value == null) {
                return;
            }
            if (@value is byte[]) {
                if ((GetMax()).Value > 0 && (GetMax()).Value < ((byte[]) @value).Length) {
                    throw new Net.TheVpc.Upa.Types.ConstraintsException("FileSizeTooBig", name, description, @value, max);
                }
            } else if (@value is byte?[]) {
                if ((GetMax()).Value > 0 && (GetMax()).Value < ((byte?[]) @value).Length) {
                    throw new Net.TheVpc.Upa.Types.ConstraintsException("FileSizeTooSmall", name, description, @value, max);
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


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder("ByteArrayType");
            if (max != null) {
                s.Append("[");
                s.Append(max);
                s.Append("]");
            }
            return s.ToString();
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
