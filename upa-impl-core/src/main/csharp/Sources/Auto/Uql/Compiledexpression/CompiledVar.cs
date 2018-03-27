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


    public class CompiledVar : Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod {

        public const char DOT = '.';



        private object oldReferrer;

        public CompiledVar(Net.Vpc.Upa.Field field)  : this(field.GetName(), field){

        }

        public CompiledVar(string name)  : this(name, null){

        }

        public virtual object GetOldReferrer() {
            return oldReferrer;
        }

        public virtual void SetOldReferrer(object oldReferrer) {
            this.oldReferrer = oldReferrer;
        }

        public CompiledVar(string name, object referrer) {
            SetName(name);
            SetReferrer(referrer);
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar(GetName(), GetReferrer());
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod c = GetChild();
            if (c != null) {
                c = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) c.Copy();
            }
            o.SetChild(c);
            o.SetBinding(GetBinding());
            o.SetDescription(GetDescription());
            o.SetOldReferrer(GetOldReferrer());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }

        public virtual Net.Vpc.Upa.Expressions.CompiledExpression GetNonVarParent() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression p = GetParentExpression();
            while (p != null) {
                if (!(p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod)) {
                    return p;
                }
                p = p.GetParentExpression();
            }
            return null;
        }

        public virtual string GetChildlessPath() {
            System.Text.StringBuilder v = new System.Text.StringBuilder();
            if (GetParentExpression() != null) {
                v.Append(".");
                if (GetParentExpression() is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) {
                    v.Append(((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVar) GetParentExpression()).GetChildlessPath());
                } else {
                    v.Append(GetParentExpression().ToString());
                }
            }
            v.Append(GetName());
            return v.ToString();
        }


        public override string ToString() {
            System.Text.StringBuilder v = new System.Text.StringBuilder();
            v.Append(GetName());
            if (GetChild() != null) {
                v.Append(".");
                v.Append(GetChild().ToString());
            }
            return v.ToString();
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            if (index == 0) {
                SetChild((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) expression);
            }
            throw new System.Exception();
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression c = GetChild();
            return c == null ? null : new Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] { c };
        }
    }
}
