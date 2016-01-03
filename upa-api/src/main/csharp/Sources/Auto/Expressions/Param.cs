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
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class Param : Net.Vpc.Upa.Expressions.DefaultExpression {



        private object @object;

        private string name;

        private bool unspecified;

        public Param()  : this(null){

        }

        public Param(string name) {
            this.unspecified = true;
            this.name = name;
        }

        public Param(string name, object @object) {
            this.unspecified = false;
            this.@object = @object;
            this.name = name;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual object GetObject() {
            return @object;
        }

        public virtual bool IsUnspecified() {
            return unspecified;
        }

        public virtual void SetObject(object @object) {
            this.@object = @object;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.Param o = unspecified ? new Net.Vpc.Upa.Expressions.Param(name) : new Net.Vpc.Upa.Expressions.Param(name, @object);
            return o;
        }


        public override string ToString() {
            if (IsUnspecified()) {
                return ":" + GetName();
            }
            return ":" + GetName() + "(=" + GetObject() + ")";
        }
    }
}
