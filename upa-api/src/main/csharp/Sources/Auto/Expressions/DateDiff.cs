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
    public class DateDiff : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Expressions.DatePartType type;

        private Net.Vpc.Upa.Expressions.Expression start;

        private Net.Vpc.Upa.Expressions.Expression end;

        public DateDiff(Net.Vpc.Upa.Expressions.DatePartType datePartType, Net.Vpc.Upa.Types.Temporal date1, Net.Vpc.Upa.Types.Temporal date2)  : this(datePartType, new Net.Vpc.Upa.Expressions.Literal(date1), new Net.Vpc.Upa.Expressions.Literal(date2)){

        }

        public DateDiff(Net.Vpc.Upa.Expressions.DatePartType datePartType, Net.Vpc.Upa.Expressions.Expression startDate, Net.Vpc.Upa.Expressions.Expression endDate) {
            this.type = datePartType;
            this.start = startDate;
            this.end = endDate;
        }

        public virtual Net.Vpc.Upa.Expressions.DatePartType GetDatePartType() {
            return type;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetStart() {
            return start;
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetEnd() {
            return end;
        }


        public override string GetName() {
            return "DateDiff";
        }


        public override int GetArgumentsCount() {
            return 3;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            switch(index) {
                case 0:
                    return new Net.Vpc.Upa.Expressions.Cst(type);
                case 1:
                    return start;
                case 2:
                    return end;
            }
            throw new System.IndexOutOfRangeException();
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.DateDiff o = new Net.Vpc.Upa.Expressions.DateDiff(type, start.Copy(), end.Copy());
            return o;
        }
    }
}
