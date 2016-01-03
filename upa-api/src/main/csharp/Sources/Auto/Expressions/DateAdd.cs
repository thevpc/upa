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
     * Created by IntelliJ IDEA.
     * User: root
     * Date: 22 mai 2003
     * Time: 12:07:34
     * To change this template use Options | File Templates.
     */
    public class DateAdd : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Expressions.DatePartType type;

        private Net.Vpc.Upa.Expressions.Expression count;

        private Net.Vpc.Upa.Expressions.Expression date;

        public DateAdd(Net.Vpc.Upa.Expressions.DatePartType type, Net.Vpc.Upa.Expressions.Expression count, Net.Vpc.Upa.Expressions.Expression date) {
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


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.DateAdd o = new Net.Vpc.Upa.Expressions.DateAdd(type, count.Copy(), date.Copy());
            return o;
        }
    }
}
