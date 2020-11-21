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
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:12 PM To change
     * this template use File | Settings | File Templates.
     */
    public class EntityName : Net.TheVpc.Upa.Expressions.DefaultExpression, Net.TheVpc.Upa.Expressions.NameOrQuery {

        private string name;

        public EntityName(string name) {
            this.name = name;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            return new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>();
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            throw new System.Exception("Not supported yet.");
        }

        public virtual string GetName() {
            return name;
        }


        public override bool IsValid() {
            return true;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.EntityName o = new Net.TheVpc.Upa.Expressions.EntityName(name);
            return o;
        }


        public override string ToString() {
            return Net.TheVpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(name);
        }
    }
}
