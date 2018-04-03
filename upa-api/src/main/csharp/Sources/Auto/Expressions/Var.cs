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



namespace Net.Vpc.Upa.Expressions
{


    public class Var : Net.Vpc.Upa.Expressions.DefaultExpression {

        private static readonly Net.Vpc.Upa.Expressions.DefaultTag PARENT = new Net.Vpc.Upa.Expressions.DefaultTag("PARENT");



        public const char DOT = '.';

        private Net.Vpc.Upa.Expressions.Expression applier;

        private string name;

        public Var(string field)  : this(null, field){

        }

        public Var(Net.Vpc.Upa.Expressions.Expression applier, string name) {
            this.applier = applier;
            this.name = name;
            if (name.Contains(".")) {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("Name could not contain dots");
            }
        }

        public virtual void SetApplier(Net.Vpc.Upa.Expressions.Var applier) {
            this.applier = applier;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> list = new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>(1);
            if (applier != null) {
                list.Add(new Net.Vpc.Upa.Expressions.TaggedExpression(applier, PARENT));
            }
            return list;
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            if (tag.Equals(PARENT)) {
                this.applier = e;
            } else {
                throw new Net.Vpc.Upa.Exceptions.UPAIllegalArgumentException("Not supported yet.");
            }
        }

        public virtual Net.Vpc.Upa.Expressions.Expression GetApplier() {
            return applier;
        }

        public virtual string GetName() {
            return name;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Var o = new Net.Vpc.Upa.Expressions.Var(applier == null ? null : applier.Copy(), name);
            return o;
        }


        public override string ToString() {
            if (applier != null) {
                return applier.ToString() + "." + Net.Vpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(GetName());
            }
            return Net.Vpc.Upa.Expressions.ExpressionHelper.EscapeIdentifier(GetName());
        }
    }
}
