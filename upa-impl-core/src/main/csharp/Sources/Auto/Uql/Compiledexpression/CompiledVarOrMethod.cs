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



namespace Net.TheVpc.Upa.Impl.Uql.Compiledexpression
{


    /**
     *
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public abstract class CompiledVarOrMethod : Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        private Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod child;

        private object referrer;

        private string name;

        private string binding;

        public CompiledVarOrMethod() {
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod GetChild() {
            return child;
        }

        public virtual void SetChild(Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod child) {
            this.child = child;
            PrepareChildren(child);
        }

        public virtual object GetReferrer() {
            return referrer;
        }

        public virtual void SetReferrer(object referrer) {
            this.referrer = referrer;
            if (this.referrer is Net.TheVpc.Upa.Field) {
                this.SetTypeTransform(Net.TheVpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity((Net.TheVpc.Upa.Field) referrer));
            }
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetName(string name) {
            this.name = name;
        }

        public virtual string GetBinding() {
            return binding;
        }

        public virtual void SetBinding(string binding) {
            this.binding = binding;
        }


        public override Net.TheVpc.Upa.Types.DataTypeTransform GetEffectiveDataType() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod c = GetChild();
            if (c != null) {
                return c.GetEffectiveDataType();
            }
            return GetTypeTransform();
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod GetFinest() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod c = GetDeepChild();
            if (c == null) {
                return this;
            }
            return c;
        }

        public virtual Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod GetDeepChild() {
            Net.TheVpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod c = GetChild();
            if (c == null) {
                return null;
            }
            if (c.GetChild() == null) {
                return c;
            }
            return c.GetDeepChild();
        }
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public override abstract Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions();
        // This Method is added by J2CS UPA Portable Framework.  Do Not Edit
        public override abstract void SetSubExpression(int arg1, Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression arg2);
    }
}
