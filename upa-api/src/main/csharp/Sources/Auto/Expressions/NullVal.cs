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



namespace Net.TheVpc.Upa.Expressions
{


    public sealed class NullVal : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private Net.TheVpc.Upa.Types.DataType type;

        public NullVal(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            if (expressions.Length != 0 && expressions.Length != 1 && expressions.Length != 2) {
                CheckArgCount(GetName(), expressions, 1);
            }
            this.type = (Net.TheVpc.Upa.Types.DataType) ((Net.TheVpc.Upa.Expressions.Cst) expressions[0]).GetValue();
        }

        public NullVal(Net.TheVpc.Upa.Types.DataType type) {
            this.type = type;
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            if (index == 0) {
                this.type = (Net.TheVpc.Upa.Types.DataType) ((Net.TheVpc.Upa.Expressions.Cst) e).GetValue();
            } else {
                throw new System.IndexOutOfRangeException();
            }
        }


        public override string GetName() {
            return "NullVal";
        }


        public override int GetArgumentsCount() {
            return 1;
        }


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            if (index != 0) {
                throw new System.IndexOutOfRangeException();
            }
            return new Net.TheVpc.Upa.Expressions.Cst(type);
        }

        public string GetDescription() {
            return "NULL";
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.NullVal o = new Net.TheVpc.Upa.Expressions.NullVal(type);
            return o;
        }

        public override string ToString() {
            System.Type javaClass = type.GetPlatformType();
            int length = type.GetScale();
            int precision = type.GetPrecision();
            string tname = Net.TheVpc.Upa.Types.TypesFactory.GetTypeName(javaClass);
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
