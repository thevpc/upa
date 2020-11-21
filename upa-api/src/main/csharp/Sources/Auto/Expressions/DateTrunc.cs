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
     * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 12:07:34 To
     * change this template use Options | File Templates.
     */
    public class DateTrunc : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private Net.TheVpc.Upa.Expressions.DatePartType type;

        private Net.TheVpc.Upa.Expressions.Expression @value;

        public DateTrunc(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 2);
            Init((Net.TheVpc.Upa.Expressions.DatePartType) ((Net.TheVpc.Upa.Expressions.Cst) expressions[0]).GetValue(), expressions[1]);
        }

        public DateTrunc(Net.TheVpc.Upa.Expressions.DatePartType type, Net.TheVpc.Upa.Types.Temporal date)  : this(type, new Net.TheVpc.Upa.Expressions.Literal(date)){

        }

        public DateTrunc(Net.TheVpc.Upa.Expressions.DatePartType type, string varDate)  : this(type, new Net.TheVpc.Upa.Expressions.UserExpression(varDate)){

        }

        public DateTrunc(Net.TheVpc.Upa.Expressions.DatePartType type, Net.TheVpc.Upa.Expressions.Expression val) {
            Init(type, val);
        }

        private void Init(Net.TheVpc.Upa.Expressions.DatePartType type, Net.TheVpc.Upa.Expressions.Expression val) {
            this.type = type;
            this.@value = val;
        }

        public virtual Net.TheVpc.Upa.Expressions.DatePartType GetDatePartType() {
            return type;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetValue() {
            return @value;
        }


        public override string GetName() {
            return "datetrunc";
        }


        public override int GetArgumentsCount() {
            return 2;
        }


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            switch(index) {
                case 0:
                    return new Net.TheVpc.Upa.Expressions.Cst(type);
                case 1:
                    return @value;
            }
            throw new System.IndexOutOfRangeException();
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            switch(index) {
                case 0:
                    {
                        type = (Net.TheVpc.Upa.Expressions.DatePartType) ((Net.TheVpc.Upa.Expressions.Cst) e).GetValue();
                        break;
                    }
                case 1:
                    {
                        @value = e;
                        break;
                    }
            }
            throw new System.IndexOutOfRangeException();
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.DateTrunc o = new Net.TheVpc.Upa.Expressions.DateTrunc(type, @value.Copy());
            return o;
        }
    }
}
