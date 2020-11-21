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


    public class Var : Net.TheVpc.Upa.Expressions.DefaultExpression {

        private static readonly Net.TheVpc.Upa.Expressions.DefaultTag PARENT = new Net.TheVpc.Upa.Expressions.DefaultTag("PARENT");



        public const char DOT = '.';

        private Net.TheVpc.Upa.Expressions.Expression applier;

        private string name;

        public Var(string field)  : this(null, field){

        }

        public Var(Net.TheVpc.Upa.Expressions.Expression applier, string name) {
            this.applier = applier;
            this.name = name;
            if (name.Contains(".")) {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Name could not contain dots");
            }
        }

        public virtual void SetApplier(Net.TheVpc.Upa.Expressions.Var applier) {
            this.applier = applier;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }


        public override System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.TheVpc.Upa.Expressions.TaggedExpression>(1);
            if (applier != null) {
                list.Add(new Net.TheVpc.Upa.Expressions.TaggedExpression(applier, PARENT));
            }
            return list;
        }


        public override void SetChild(Net.TheVpc.Upa.Expressions.Expression e, Net.TheVpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(PARENT)) {
                this.applier = e;
            } else {
                throw new Net.TheVpc.Upa.Exceptions.UPAIllegalArgumentException("Not supported yet.");
            }
        }

        public virtual Net.TheVpc.Upa.Expressions.Expression GetApplier() {
            return applier;
        }

        public virtual string GetName() {
            return name;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Var o = new Net.TheVpc.Upa.Expressions.Var(applier == null ? null : applier.Copy(), name);
            return o;
        }


        public override string ToString() {
            if (applier != null) {
                return applier.ToString() + "." + Net.TheVpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(GetName());
            }
            return Net.TheVpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(GetName());
        }
    }
}
