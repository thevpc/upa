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



namespace Net.Vpc.Upa.Expressions
{


    public sealed class NullVal : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Types.DataType type;

        public NullVal(Net.Vpc.Upa.Types.DataType type) {
            this.type = type;
        }


        public override string GetName() {
            return "NullVal";
        }


        public override int GetArgumentsCount() {
            return 1;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            if (index != 0) {
                throw new System.IndexOutOfRangeException();
            }
            return new Net.Vpc.Upa.Expressions.Cst(type);
        }

        public string GetDescription() {
            return "NULL";
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.NullVal o = new Net.Vpc.Upa.Expressions.NullVal(type);
            return o;
        }

        public override string ToString() {
            System.Type javaClass = type.GetPlatformType();
            int length = type.GetScale();
            int precision = type.GetPrecision();
            string tname = Net.Vpc.Upa.Types.TypesFactory.GetTypeName(javaClass);
            if (tname == null) {
                tname = ("UNKNOWN_TYPE(" + (javaClass).FullName + "," + length + "," + precision + ")");
            }
            if (javaClass.Equals(typeof(string))) {
                if (length > 0) {
                    tname = tname + "(" + length + ")";
                }
            }
            return "nullval(" + tname + ")";
        }
    }
}
