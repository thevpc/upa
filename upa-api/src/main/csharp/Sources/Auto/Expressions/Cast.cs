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


    /**
     * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 12:21:56 To
     * change this template use Options | File Templates.
     */
    public class Cast : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private Net.TheVpc.Upa.Expressions.Expression @value;

        private Net.TheVpc.Upa.Types.DataType targetType;

        public Cast(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 2);
            Init(expressions[0], (Net.TheVpc.Upa.Types.DataType) ((Net.TheVpc.Upa.Expressions.Cst) expressions[1]).GetValue());
        }

        public Cast(Net.TheVpc.Upa.Expressions.Expression @value, Net.TheVpc.Upa.Types.DataType primitiveType) {
            Init(@value, primitiveType);
        }

        private void Init(Net.TheVpc.Upa.Expressions.Expression @value, Net.TheVpc.Upa.Types.DataType primitiveType) {
            this.@value = @value;
            this.targetType = primitiveType;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetValue() {
            return @value;
        }

        public virtual Net.TheVpc.Upa.Types.DataType GetDataType() {
            return targetType;
        }


        public override string GetName() {
            return "Cast";
        }


        public override int GetArgumentsCount() {
            return 2;
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            if (index == 0) {
                this.@value = e;
            } else {
                this.targetType = (Net.TheVpc.Upa.Types.DataType) ((Net.TheVpc.Upa.Expressions.Cst) e).GetValue();
            }
        }


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            switch(index) {
                case 0:
                    return @value;
                case 1:
                    return new Net.TheVpc.Upa.Expressions.Cst(targetType);
            }
            throw new System.IndexOutOfRangeException();
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            return new Net.TheVpc.Upa.Expressions.Cast(@value.Copy(), targetType);
        }


        public override string ToString() {
            System.Type javaClass = targetType.GetPlatformType();
            int length = targetType.GetScale();
            int precision = targetType.GetPrecision();
            string tname = Net.TheVpc.Upa.Types.TypesFactory.GetTypeName(javaClass);
            if (tname == null) {
                tname = ("UNKNOWN_TYPE(" + (javaClass).FullName + "," + length + "," + precision + ")");
            }
            if (javaClass.Equals(typeof(string))) {
                if (length > 0) {
                    tname = tname + "(" + length + ")";
                }
            }
            return "cast(" + @value + "," + tname + ")";
        }
    }
}
