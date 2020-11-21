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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class Param : Net.TheVpc.Upa.Expressions.DefaultExpression {



        private object @value;

        private string name;

        private bool unspecified;

        public Param()  : this(null){

        }

        public Param(string name) {
            this.unspecified = true;
            this.name = name;
        }

        public Param(string name, object @value) {
            this.unspecified = false;
            this.@value = @value;
            this.name = name;
        }

        public virtual void SetUnspecified(bool unspecified) {
            this.unspecified = unspecified;
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

        public virtual object GetValue() {
            return @value;
        }

        public virtual bool IsUnspecified() {
            return unspecified;
        }

        public virtual void SetValue(object @value) {
            this.@value = @value;
        }


        public override Net.TheVpc.Upa.Expressions.Expression Copy() {
            Net.TheVpc.Upa.Expressions.Param o = unspecified ? new Net.TheVpc.Upa.Expressions.Param(name) : new Net.TheVpc.Upa.Expressions.Param(name, @value);
            return o;
        }


        public override string ToString() {
            if (IsUnspecified()) {
                return ":" + (GetName() == null ? "?" : GetName());
            }
            return ":" + (GetName() == null ? "?" : GetName()) + "(=" + GetValue() + ")";
        }
    }
}
