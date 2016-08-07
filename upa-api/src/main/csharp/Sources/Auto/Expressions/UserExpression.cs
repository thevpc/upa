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


    public class UserExpression : Net.Vpc.Upa.Expressions.DefaultExpression {



        private string expression;

        private System.Collections.Generic.IDictionary<string , object> parameters = null;

        public UserExpression(string qlString) {
            this.expression = qlString;
        }


        public override System.Collections.Generic.IList<Net.Vpc.Upa.Expressions.TaggedExpression> GetChildren() {
            return new System.Collections.Generic.List<Net.Vpc.Upa.Expressions.TaggedExpression>();
        }


        public override void SetChild(Net.Vpc.Upa.Expressions.Expression e, Net.Vpc.Upa.Expressions.ExpressionTag tag) {
            throw new System.Exception("Not supported yet.");
        }

        public virtual Net.Vpc.Upa.Expressions.UserExpression SetParameters(System.Collections.Generic.IDictionary<string , object> parameters) {
            if (parameters != null) {
                if (this.parameters == null) {
                    this.parameters = new System.Collections.Generic.Dictionary<string , object>();
                }
                Net.Vpc.Upa.FwkConvertUtils.PutAllMap<string,object>(this.parameters,parameters);
            }
            return this;
        }

        public virtual object GetParameter(string name) {
            if (parameters != null) {
                return Net.Vpc.Upa.FwkConvertUtils.GetMapValue<string,object>(parameters,name);
            }
            return null;
        }

        public virtual System.Collections.Generic.IDictionary<string , object> GetParameters() {
            if (parameters == null) {
                //could not be supported safely on C#
                //return Collections.EMPTY_MAP;
                return new System.Collections.Generic.Dictionary<string , object>();
            }
            return new System.Collections.Generic.Dictionary<string , object>(parameters);
        }

        public virtual Net.Vpc.Upa.Expressions.UserExpression SetParameter(string name, object @value) {
            if (parameters == null) {
                parameters = new System.Collections.Generic.Dictionary<string , object>();
            }
            parameters[name]=@value;
            return this;
        }

        public virtual Net.Vpc.Upa.Expressions.UserExpression RemoveParameter(string name, object @value) {
            if (parameters != null) {
                parameters.Remove(name);
            }
            return this;
        }

        public virtual bool ContainsParameter(string name) {
            if (parameters != null) {
                return parameters.ContainsKey(name);
            }
            return false;
        }

        public virtual string GetExpression() {
            return expression;
        }


        public override Net.Vpc.Upa.Expressions.Expression Copy() {
            Net.Vpc.Upa.Expressions.UserExpression o = new Net.Vpc.Upa.Expressions.UserExpression(expression);
            return o;
        }


        public override string ToString() {
            return System.Convert.ToString(expression);
        }
    }
}
