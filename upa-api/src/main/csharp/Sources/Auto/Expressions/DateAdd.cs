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
    public class DateAdd : Net.Vpc.Upa.Expressions.FunctionExpression {



        private Net.Vpc.Upa.Expressions.DatePartType type;

        private Net.Vpc.Upa.Expressions.Expression count;

        private Net.Vpc.Upa.Expressions.Expression date;

        public DateAdd(Net.Vpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 3);
            Init((Net.Vpc.Upa.Expressions.DatePartType) ((Net.Vpc.Upa.Expressions.Cst) expressions[0]).GetValue(), expressions[1], expressions[2]);
        }

        public DateAdd(Net.Vpc.Upa.Expressions.DatePartType type, Net.Vpc.Upa.Expressions.Expression count, Net.Vpc.Upa.Expressions.Expression date) {
            Init(type, count, date);
        }

        private void Init(Net.Vpc.Upa.Expressions.DatePartType type, Net.Vpc.Upa.Expressions.Expression count, Net.Vpc.Upa.Expressions.Expression date) {
            this.type = type;
            this.count = count;
            this.date = date;
        }

        public virtual Net.Vpc.Upa.Expressions.DatePartType GetDatePartType() {
            return type;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetCount() {
            return count;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetDate() {
            return date;
        }


        public override string GetName() {
            return "DateAdd";
        }


        public override int GetArgumentsCount() {
            return 3;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            switch(index) {
                case 0:
                    return new Net.Vpc.Upa.Expressions.Cst(type);
                case 1:
                    return count;
                case 2:
                    return date;
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
                        count = e;
                        break;
                    }
                case 2:
                    {
                        date = e;
                        break;
                    }
            }
            throw new System.IndexOutOfRangeException();
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.DateAdd o = new Net.Vpc.Upa.Expressions.DateAdd(type, count.Copy(), date.Copy());
            return o;
        }
    }
}
