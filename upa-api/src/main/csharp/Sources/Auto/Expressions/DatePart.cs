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



namespace Net.Vpc.Upa.Expressions
{


    /**
     * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 12:07:34 To
     * change this template use Options | File Templates.
     */
    public class DatePart : Net.Vpc.Upa.Expressions.FunctionExpression {



        private Net.Vpc.Upa.Expressions.DatePartType type;

        private Net.Vpc.Upa.Expressions.Expression @value;

        public DatePart(Net.Vpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 2);
            Init((Net.Vpc.Upa.Expressions.DatePartType) ((Net.Vpc.Upa.Expressions.Cst) expressions[0]).GetValue(), expressions[1]);
        }

        public DatePart(Net.Vpc.Upa.Expressions.DatePartType type, Net.Vpc.Upa.Types.Temporal date)  : this(type, new Net.Vpc.Upa.Expressions.Literal(date)){

        }

        public DatePart(Net.Vpc.Upa.Expressions.DatePartType type, string varDate)  : this(type, new Net.Vpc.Upa.Expressions.UserExpression(varDate)){

        }

        public DatePart(Net.Vpc.Upa.Expressions.DatePartType type, Net.Vpc.Upa.Expressions.Expression val) {
            Init(type, val);
        }

        private void Init(Net.Vpc.Upa.Expressions.DatePartType type, Net.Vpc.Upa.Expressions.Expression val) {
            this.type = type;
            this.@value = val;
        }

        public virtual Net.Vpc.Upa.Expressions.DatePartType GetDatePartType() {
            return type;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetValue() {
            return @value;
        }


        public override string GetName() {
            return "datepart";
        }


        public override int GetArgumentsCount() {
            return 2;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            switch(index) {
                case 0:
                    return new Net.Vpc.Upa.Expressions.Cst(type);
                case 1:
                    return @value;
            }
            throw new System.IndexOutOfRangeException();
        }


        public override void SetArgument(int index, Net.Vpc.Upa.Expressions.Expression e) {
            switch(index) {
                case 0:
                    {
                        type = (Net.Vpc.Upa.Expressions.DatePartType) ((Net.Vpc.Upa.Expressions.Cst) e).GetValue();
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


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.DatePart o = new Net.Vpc.Upa.Expressions.DatePart(type, @value);
            return o;
        }
    }
}
