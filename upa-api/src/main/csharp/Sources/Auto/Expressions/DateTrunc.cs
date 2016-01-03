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


    /**
     * Created by IntelliJ IDEA. User: root Date: 22 mai 2003 Time: 12:07:34 To
     * change this template use Options | File Templates.
     */
    public class DateTrunc : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Expressions.DatePartType type;

        private Net.Vpc.Upa.Expressions.Expression @value;

        public DateTrunc(Net.Vpc.Upa.Expressions.DatePartType type, Net.Vpc.Upa.Types.Temporal date)  : this(type, new Net.Vpc.Upa.Expressions.Literal(date)){

        }

        public DateTrunc(Net.Vpc.Upa.Expressions.DatePartType type, string varDate)  : this(type, new Net.Vpc.Upa.Expressions.UserExpression(varDate)){

        }

        public DateTrunc(Net.Vpc.Upa.Expressions.DatePartType type, Net.Vpc.Upa.Expressions.Expression val) {
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
            return "datetrunc";
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


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.DateTrunc o = new Net.Vpc.Upa.Expressions.DateTrunc(type, @value.Copy());
            return o;
        }
    }
}
