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
     * Created with IntelliJ IDEA. User: vpc Date: 8/19/12 Time: 12:34 AM To change
     * this template use File | Settings | File Templates.
     */
    public class Union : Net.Vpc.Upa.Expressions.DefaultEntityStatement, Net.Vpc.Upa.Expressions.QueryStatement {

        private System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryStatement> queryStatements = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.QueryStatement>();


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> all = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>();
            for (int i = 0; i < (queryStatements).Count; i++) {
                all.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(queryStatements[i], new Net.Vpc.Upa.Expressions.IndexedTag("#", i)));
            }
            return all;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            queryStatements[((Net.Vpc.Upa.Expressions.IndexedTag) tag).GetIndex()]=(Net.Vpc.Upa.Expressions.QueryStatement) e;
        }

        public virtual void Add(Net.Vpc.Upa.Expressions.QueryStatement s) {
            queryStatements.Add(s);
        }

        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryStatement> GetQueryStatements() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.QueryStatement>(queryStatements);
        }

        public override string GetEntityName() {
            foreach (Net.Vpc.Upa.Expressions.QueryStatement q in queryStatements) {
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


        public virtual Net.Vpc.Upa.Expressions.QueryField GetField(int i) {
            return queryStatements[0].GetField(i);
        }


        public virtual System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.QueryField> GetFields() {
            return queryStatements[0].GetFields();
        }


        public override bool IsValid() {
            if ((queryStatements.Count==0)) {
                return false;
            }
            foreach (Net.Vpc.Upa.Expressions.QueryStatement queryStatement in queryStatements) {
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
            Net.Vpc.Upa.Expressions.Union union = (Net.Vpc.Upa.Expressions.Union) o;
            if (queryStatements != null ? !queryStatements.Equals(union.queryStatements) : union.queryStatements != null) {
                return false;
            }
            return true;
        }


        public override int GetHashCode() {
            return queryStatements != null ? queryStatements.GetHashCode() : 0;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Union o = new Net.Vpc.Upa.Expressions.Union();
            foreach (Net.Vpc.Upa.Expressions.QueryStatement queryStatement in queryStatements) {
                o.Add((Net.Vpc.Upa.Expressions.QueryStatement) queryStatement.Copy());
            }
            return o;
        }
    }
}
