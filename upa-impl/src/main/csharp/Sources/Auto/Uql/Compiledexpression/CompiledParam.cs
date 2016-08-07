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
     *
     * User: taha Date: 18 juin 2003 Time: 19:31:17
     *
     */
    public class CompiledParam : Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpressionImpl {

        private object @value;

        private string name;

        private bool unspecified = true;



        public CompiledParam(object @value, string name, Net.Vpc.Upa.Types.DataTypeTransform type, bool unspecified) {
            this.@value = @value;
            this.name = name;
            this.unspecified = unspecified;
            if (type == null) {
                if (@value == null) {
                    SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.OBJECT);
                } else {
                    SetTypeTransform(Net.Vpc.Upa.Impl.Transform.IdentityDataTypeTransform.ForNativeType(@value.GetType()));
                }
            } else {
                SetTypeTransform(type);
            }
        }


        public override void SetTypeTransform(Net.Vpc.Upa.Types.DataTypeTransform type) {
            base.SetTypeTransform(type);
        }

        public virtual object GetValue() {
            return @value;
        }

        public virtual string GetName() {
            return name;
        }

        public virtual void SetValue(object @value) {
            this.@value = @value;
        }

        public virtual bool IsUnspecified() {
            return unspecified;
        }

        public virtual void SetUnspecified(bool unspecified) {
            this.unspecified = unspecified;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression Copy() {
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam o = new Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledParam(@value, name, GetTypeTransform(), unspecified);
            o.SetDescription(GetDescription());
            o.GetClientParameters().SetAll(GetClientParameters());
            return o;
        }


        public override Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression[] GetSubExpressions() {
            return null;
        }


        public override void SetSubExpression(int index, Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression expression) {
            throw new System.Exception("Not supported.");
        }


        public override string ToString() {
            return ('{' + name + "=" + (unspecified ? ((string)("?")) : @value) + '}');
        }


        public override Net.Vpc.Upa.Types.DataTypeTransform GetEffectiveDataType() {
            Net.Vpc.Upa.Types.DataTypeTransform d = GetTypeTransform();
            Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression p = GetParentExpression();
            if (p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod v = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarVal) p).GetVar();
                v = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) v).GetFinest();
                object r = v.GetReferrer();
                if (r is Net.Vpc.Upa.Field) {
                    return Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity((Net.Vpc.Upa.Field) r);
                }
            } else if ((p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledEquals) || (p is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledDifferent)) {
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression o = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledBinaryOperatorExpression) p).GetOther(this);
                if (o is Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) {
                    o = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) o).GetFinest();
                    object r = ((Net.Vpc.Upa.Impl.Uql.Compiledexpression.CompiledVarOrMethod) o).GetReferrer();
                    if (r is Net.Vpc.Upa.Field) {
                        return Net.Vpc.Upa.Impl.Util.UPAUtils.GetTypeTransformOrIdentity((Net.Vpc.Upa.Field) r);
                    }
                }
            }
            return d;
        }
    }
}
