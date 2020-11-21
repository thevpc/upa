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
    public class DateAdd : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private Net.TheVpc.Upa.Expressions.DatePartType type;

        private Net.TheVpc.Upa.Expressions.Expression count;

        private Net.TheVpc.Upa.Expressions.Expression date;

        public DateAdd(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 3);
            Init((Net.TheVpc.Upa.Expressions.DatePartType) ((Net.TheVpc.Upa.Expressions.Cst) expressions[0]).GetValue(), expressions[1], expressions[2]);
        }

        public DateAdd(Net.TheVpc.Upa.Expressions.DatePartType type, Net.TheVpc.Upa.Expressions.Expression count, Net.TheVpc.Upa.Expressions.Expression date) {
            Init(type, count, date);
        }

        private void Init(Net.TheVpc.Upa.Expressions.DatePartType type, Net.TheVpc.Upa.Expressions.Expression count, Net.TheVpc.Upa.Expressions.Expression date) {
            this.type = type;
            this.count = count;
            this.date = date;
        }

        public virtual Net.TheVpc.Upa.Expressions.DatePartType GetDatePartType() {
            return type;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetCount() {
            return count;
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetDate() {
            return date;
        }


        public override string GetName() {
            return "DateAdd";
        }


        public override int GetArgumentsCount() {
            return 3;
        }


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            switch(index) {
                case 0:
                    return new Net.TheVpc.Upa.Expressions.Cst(type);
                case 1:
                    return count;
                case 2:
                    return date;
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


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.DateAdd o = new Net.TheVpc.Upa.Expressions.DateAdd(type, count.Copy(), date.Copy());
            return o;
        }
    }
}
