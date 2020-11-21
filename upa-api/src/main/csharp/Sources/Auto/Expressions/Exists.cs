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

    public sealed class Exists : Net.TheVpc.Upa.Expressions.FunctionExpression {



        private Net.TheVpc.Upa.Expressions.QueryStatement query;

        public Exists(Net.TheVpc.Upa.Expressions.Expression expressions) {
            SetQuery((Net.TheVpc.Upa.Expressions.QueryStatement) expressions);
        }

        public Exists(Net.TheVpc.Upa.Expressions.Expression[] expressions) {
            CheckArgCount(GetName(), expressions, 1);
            SetQuery((Net.TheVpc.Upa.Expressions.QueryStatement) expressions[0]);
        }

        public Exists() {
        }

        public Exists(Net.TheVpc.Upa.Expressions.QueryStatement query) {
            SetQuery(query);
        }


        public override void SetArgument(int index, Net.TheVpc.Upa.Expressions.Expression e) {
            if (index == 0) {
                this.query = (Net.TheVpc.Upa.Expressions.QueryStatement) e;
            } else {
                throw new System.IndexOutOfRangeException();
            }
        }

        public int Size() {
            return 1;
        }

        public void SetQuery(Net.TheVpc.Upa.Expressions.QueryStatement query) {
            this.query = query;
        }

        public Net.TheVpc.Upa.Expressions.QueryStatement GetQuery() {
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


        public override Net.TheVpc.Upa.Expressions.Expression GetArgument(int index) {
            if (index != 0) {
                throw new System.IndexOutOfRangeException();
            }
            return query;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Exists o = new Net.TheVpc.Upa.Expressions.Exists((Net.TheVpc.Upa.Expressions.QueryStatement) query.Copy());
            return o;
        }
    }
}
