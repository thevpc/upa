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

    public sealed class Exists : Net.Vpc.Upa.Expressions.Function {



        private Net.Vpc.Upa.Expressions.QueryStatement query;

        public Exists() {
        }

        public Exists(Net.Vpc.Upa.Expressions.QueryStatement query) {
            SetQuery(query);
        }

        public int Size() {
            return 1;
        }

        public void SetQuery(Net.Vpc.Upa.Expressions.QueryStatement query) {
            this.query = query;
        }

        public Net.Vpc.Upa.Expressions.QueryStatement GetQuery() {
            return query;
        }

        public override bool IsValid() {
            return query.IsValid();
        }


        public override string GetName() {
            return "Exists";
        }


        public override int GetArgumentsCount() {
            return 1;
        }


        public override Net.Vpc.Upa.Expressions.Expression GetArgument(int index) {
            if (index != 0) {
                throw new System.IndexOutOfRangeException();
            }
            return query;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Exists o = new Net.Vpc.Upa.Expressions.Exists((Net.Vpc.Upa.Expressions.QueryStatement) query.Copy());
            return o;
        }
    }
}
