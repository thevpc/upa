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
     * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 12:34 AM To change
     * this template use File | Settings | File Templates.
     */
    public class Union : Net.TheVpc.Upa.Expressions.DefaultEntityStatement, Net.TheVpc.Upa.Expressions.QueryStatement {

        private System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryStatement> queryStatements = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.QueryStatement>(2);


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>();
            for (int i = 0; i < (queryStatements).Count; i++) {
                all.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(queryStatements[i], new Net.TheVpc.Upa.Expressions.IndexedTag("#", i)));
            }
            return all;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            queryStatements[((Net.TheVpc.Upa.Expressions.IndexedTag) tag).GetIndex()]=(Net.TheVpc.Upa.Expressions.QueryStatement) e;
        }

        public virtual void Add(Net.TheVpc.Upa.Expressions.QueryStatement s) {
            queryStatements.Add(s);
        }

        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryStatement> GetQueryStatements() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.QueryStatement>(queryStatements);
        }

        public override string GetEntityName() {
            foreach (Net.TheVpc.Upa.Expressions.QueryStatement q in queryStatements) {
                string n = q.GetEntityName();
                if (n != null) {
                    return n;
                }
            }
            return null;
        }


        public override string GetEntityAlias() {
            return null;
        }


        public virtual int CountFields() {
            return queryStatements[0].CountFields();
        }


        public virtual Net.TheVpc.Upa.Expressions.QueryField GetField(int i) {
            return queryStatements[0].GetField(i);
        }


        public virtual System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.QueryField> GetFields() {
            return queryStatements[0].GetFields();
        }


        public override bool IsValid() {
            if ((queryStatements.Count==0)) {
                return false;
            }
            foreach (Net.TheVpc.Upa.Expressions.QueryStatement queryStatement in queryStatements) {
                if (!queryStatement.IsValid()) {
                    return false;
                }
            }
            return true;
        }


        public override bool Equals(object o) {
            if (this == o) {
                return true;
            }
            if (o == null || GetType() != o.GetType()) {
                return false;
            }
            Net.TheVpc.Upa.Expressions.Union union = (Net.TheVpc.Upa.Expressions.Union) o;
            if (queryStatements != null ? !queryStatements.Equals(union.queryStatements) : union.queryStatements != null) {
                return false;
            }
            return true;
        }


        public override int GetHashCode() {
            return queryStatements != null ? queryStatements.GetHashCode() : 0;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Union o = new Net.TheVpc.Upa.Expressions.Union();
            foreach (Net.TheVpc.Upa.Expressions.QueryStatement queryStatement in queryStatements) {
                o.Add((Net.TheVpc.Upa.Expressions.QueryStatement) queryStatement.Copy());
            }
            return o;
        }
    }
}
