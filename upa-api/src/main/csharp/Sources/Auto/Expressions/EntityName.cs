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
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:12 PM To change
     * this template use File | Settings | File Templates.
     */
    public class EntityName : Net.Vpc.Upa.Expressions.DefaultExpression, Net.Vpc.Upa.Expressions.NameOrQuery {

        private string name;

        public EntityName(string name) {
            this.name = name;
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>();
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            throw new System.Exception("Not supported yet.");
        }

        public virtual string GetName() {
            return name;
        }


        public override bool IsValid() {
            return true;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.EntityName o = new Net.Vpc.Upa.Expressions.EntityName(name);
            return o;
        }


        public override string ToString() {
            return Net.Vpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(name);
        }
    }
}
