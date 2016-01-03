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



namespace Net.Vpc.Upa.Impl.Uql.Compiledexpression
{


    /**
     * Created with IntelliJ IDEA. User: vpc Date: 8/16/12 Time: 10:54 PM To change
     * this template use File | Settings | File Templates.
     */
    public abstract class CompiledFunction : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        private System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression> expressions = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression>();

        private string name;

        public CompiledFunction(string name) {
            this.name = name;
        }

        public string GetName() {
            return name;
        }

        public int GetArgumentsCount() {
            return (expressions).Count;
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetArgument(int index) {
            return expressions[index];
        }

        protected internal virtual void ProtectedSetArgument(int i, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            if (e == null) {
                throw new System.ArgumentException ();
            }
            expressions[i]=e;
            PrepareChildren(e);
        }

        protected internal virtual void ProtectedAddArgument(Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e) {
            if (e == null) {
                throw new System.ArgumentException ();
            }
            expressions.Add(e);
            PrepareChildren(e);
        }

        public Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression GetArgumentImpl(int index) {
            return null;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return GetArguments();
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            ProtectedSetArgument(index, expression);
        }

        public virtual Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetArguments() {
            int max = GetArgumentsCount();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] p = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[max];
            for (int i = 0; i < max; i++) {
                p[i] = GetArgument(i);
            }
            return p;
        }


        public override string ToString() {
            System.Text.StringBuilder s = new System.Text.StringBuilder(GetName()).Append("(");
            for (int i = 0; i < GetArgumentsCount(); i++) {
                if (i > 0) {
                    s.Append(",");
                }
                s.Append(GetArgument(i));
            }
            s.Append(")");
            return s.ToString();
        }


        public override bool IsValid() {
            int max = GetArgumentsCount();
            bool valid = max == 0;
            for (int i = 0; i < max; i++) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression e = GetArgument(i);
                if (e.IsValid()) {
                    valid = true;
                }
            }
            return valid;
        }

        protected internal virtual void ProtectedCopyTo(Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledFunction o) {
            foreach (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression element in GetArguments()) {
                o.ProtectedAddArgument(element.Copy());
            }
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
        }

        protected internal virtual void ProtectedClear() {
            expressions.Clear();
        }
    }
}
